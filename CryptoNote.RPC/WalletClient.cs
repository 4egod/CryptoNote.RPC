using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    using WalletData;

    public class WalletClient : RpcClientBase
    {
        public WalletClient(string uri) : base(uri) { }

        public async Task<Balance> GetBalance()
        {
            RpcRequest<GetBalanceData.Request> request = new RpcRequest<GetBalanceData.Request>()
            {
                Method = "getbalance",
                Arguments = new GetBalanceData.Request()
            };

            RpcResponse<GetBalanceData.Response> response =
                await PostAsync<RpcResponse<GetBalanceData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return new Balance()
            {
                Available = response.Result.AvailableAmount,
                Locked = response.Result.LockedAmount
            };
        }

        public async Task<ulong> GetHeight()
        {
            RpcRequest<GetHeightData.Request> request = new RpcRequest<GetHeightData.Request>()
            {
                Method = "get_height",
                Arguments = new GetHeightData.Request()
            };

            RpcResponse<GetHeightData.Response> response =
                await PostAsync<RpcResponse<GetHeightData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Height;
        }

        public async Task<string> Transfer(string address, ulong amount, ulong fee, ulong mixin, string paymentId = "", ulong unlockTime = 0)
        {
            TransferData.Request arg = new TransferData.Request()
            {
                Destinations = new TransferData.Request.Destination[]
                {
                    new TransferData.Request.Destination()
                    {
                        Address = address,
                        Amount = amount
                    }
                },
                PaymentId = paymentId,
                Fee = fee,
                Mixin = mixin,
                UnlockTime = unlockTime
            };

            RpcRequest<TransferData.Request> request = new RpcRequest<TransferData.Request>()
            {
                Method = "transfer",
                Arguments = arg
            };

            RpcResponse<TransferData.Response> response = await PostAsync<RpcResponse<TransferData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Hash;
        }

        public async Task<List<TransactionData>> GetTransfers()
        {
            RpcRequest<GetTransfersData.Request> request = new RpcRequest<GetTransfersData.Request>()
            {
                Method = "get_transfers",
                Arguments = new GetTransfersData.Request()
            };

            RpcResponse<GetTransfersData.Response> response =
                await PostAsync<RpcResponse<GetTransfersData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Transfers;
        }

        public async Task Reset()
        {
            RpcRequest<ResetData.Request> request = new RpcRequest<ResetData.Request>()
            {
                Method = "reset",
                Arguments = new ResetData.Request()
            };

            RpcResponse<ResetData.Response> response =
                await PostAsync<RpcResponse<ResetData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }
        }

        public async Task Save()
        {
            RpcRequest<SaveData.Request> request = new RpcRequest<SaveData.Request>()
            {
                Method = "store",
                Arguments = new SaveData.Request()
            };

            RpcResponse<SaveData.Response> response =
                await PostAsync<RpcResponse<SaveData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }
        }

    }
}
