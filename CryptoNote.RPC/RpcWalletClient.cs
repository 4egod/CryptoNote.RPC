using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    using RpcWalletData;

    public class RpcWalletClient : RpcClientBase
    {
        public class Status
        {
            public uint CurrentBlockIndex { get; set; }

            public uint LastBlockIndex { get; set; }

            public string LastBlockHash { get; set; }

            public uint PeersCount { get; set; }
        }

        public RpcWalletClient(string uri) : base(uri + "/json_rpc") { }

        public async Task<Status> GetStatus()
        {
            RpcRequest<GetStatusData.Request> request = new RpcRequest<GetStatusData.Request>()
            {
                Method = "getStatus",
                Arguments = new GetStatusData.Request()
            };

            RpcResponse<GetStatusData.Response> response = await PostAsync<RpcResponse<GetStatusData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            Status res = new Status()
            {
                CurrentBlockIndex = response.Result.CurrentBlockIndex,
                LastBlockIndex = response.Result.LastBlockIndex,
                LastBlockHash = response.Result.LastBlockHash,
                PeersCount = response.Result.PeersCount
            };

            return res;
        }

        public async Task<Balance> GetBalance(string address)
        {
            GetBalanceData.Request arg = new GetBalanceData.Request()
            {
                Address = address
            };

            RpcRequest<GetBalanceData.Request> request = new RpcRequest<GetBalanceData.Request>()
            {
                Method = "getBalance",
                Arguments = arg
            };

            RpcResponse<GetBalanceData.Response> response = await PostAsync<RpcResponse<GetBalanceData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            Balance res = new Balance()
            {
                Available = response.Result.AvailableAmount,
                Locked = response.Result.LockedAmount
            };

            return res;
        }

        public async Task<List<Transaction>> GetTransactions(uint firstBlockIndex, uint blocksCount)
        {
            GetTransactionsData.Request arg = new GetTransactionsData.Request()
            {
                FirstBlockIndex = firstBlockIndex,
                BlockCount = blocksCount,
                Addresses = new List<string>(),
                //BlockHash = string.Empty,
                PaymentId = string.Empty
            };

            RpcRequest<GetTransactionsData.Request> request = new RpcRequest<GetTransactionsData.Request>()
            {
                Method = "getTransactions",
                Arguments = arg
            };

            RpcResponse<GetTransactionsData.Response> response = await PostAsync<RpcResponse<GetTransactionsData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            List<Transaction> res = new List<Transaction>();
            foreach (var block in response.Result.Blocks)
            {
                foreach (var transaction in block.Transactions)
                {
                    Transaction t = new Transaction()
                    {
                        Transfers = new List<Transfer>(),
                        TransactionHash = transaction.TransactionHash,
                        Amount = transaction.Amount,
                        Fee = transaction.Fee,
                        PaymentId = transaction.PaymentId,
                        Timestamp = new DateTime(1970, 1, 1).AddSeconds(transaction.Timestamp),
                        BlockIndex = transaction.BlockIndex,
                        //UnlockTime = transaction.UnlockTime
                        
                    };

                    foreach (var item in transaction.Transfers)
                    {
                        t.Transfers.Add(new Transfer()
                        {
                            Address = item.Address,
                            Amount = item.Amount,
                            Type = item.Type
                        });
                    }

                    res.Add(t);
                }
            }

            return res;
        }

        public async Task<string> Transfer(string fromAddress, string toAddress, ulong amount, string paymentId = "", ulong fee = 1000000, ulong mixin = 0, ulong unlockTime = 0)
        {
            SendTransactionData.Request arg = new SendTransactionData.Request()
            {
                Addresses = new string[1]
                {
                    fromAddress
                },
                Transfers = new SendTransactionData.Request.Transfer[1]
                {
                    new SendTransactionData.Request.Transfer()
                    {
                        Address = toAddress,
                        Amount = amount
                    }
                },
                PaymentId = paymentId,
                Fee = fee,
                Mixin = mixin,
                UnlockTime = unlockTime
            };

            RpcRequest<SendTransactionData.Request> request = new RpcRequest<SendTransactionData.Request>()
            {
                Method = "sendTransaction",
                Arguments = arg
            };

            RpcResponse<SendTransactionData.Response> response = await PostAsync<RpcResponse<SendTransactionData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.TransactionHash;
        }

        public async Task<string> CreateAddress()
        {
            RpcRequest<CreateAddressData.Request> request = new RpcRequest<CreateAddressData.Request>()
            {
                Method = "createAddress",
                Arguments = new CreateAddressData.Request()
            };

            RpcResponse<CreateAddressData.Response> response = await PostAsync<RpcResponse<CreateAddressData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            string res = response.Result.Address;

            return res;
        }
    }
}
