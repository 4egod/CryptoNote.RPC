using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    using DaemonData;

    public class DaemonClient : RpcClientBase
    {       
        public DaemonClient(string uri) : base(uri) { }

        public async Task<ulong> GetBlocksCount()
        {
            RpcRequest<GetBlocksCountData.Request> request = new RpcRequest<GetBlocksCountData.Request>()
            {
                Method = "getblockcount",
                Arguments = new GetBlocksCountData.Request()
            };

            RpcResponse<GetBlocksCountData.Response> response = 
                await PostAsync<RpcResponse<GetBlocksCountData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Count;
        }

        public async Task<string> GetBlockHash(ulong height)
        {
            return (await GetBlockHeader(height)).Hash;
        }

        public async Task<BlockHeader> GetLastBlockHeader()
        {
            RpcRequest<GetLastBlockHeaderData.Request> request = new RpcRequest<GetLastBlockHeaderData.Request>()
            {
                Method = "getlastblockheader",
                Arguments = new GetLastBlockHeaderData.Request() { }
            };

            RpcResponse<GetLastBlockHeaderData.Response> response =
                await PostAsync<RpcResponse<GetLastBlockHeaderData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.BlockHeader;
        }

        public async Task<BlockHeader> GetBlockHeader(ulong height)
        {
            RpcRequest<GetBlockHederByHeightData.Request> request = new RpcRequest<GetBlockHederByHeightData.Request>()
            {
                Method = "getblockheaderbyheight",
                Arguments = new GetBlockHederByHeightData.Request() { Height = height }
            };

            RpcResponse<GetBlockHederByHeightData.Response> response =
                await PostAsync<RpcResponse<GetBlockHederByHeightData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.BlockHeader;
        }

        public async Task<BlockHeader> GetBlockHeader(string hash)
        {
            RpcRequest<GetBlockHederByHashData.Request> request = new RpcRequest<GetBlockHederByHashData.Request>()
            {
                Method = "getblockheaderbyhash",
                Arguments = new GetBlockHederByHashData.Request() { Hash = hash }
            };

            RpcResponse<GetBlockHederByHashData.Response> response =
                await PostAsync<RpcResponse<GetBlockHederByHashData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.BlockHeader;
        }

        public async Task<BlockTemplate> GetBlockTemplate(string walletAddress, int reserveSize)
        {
            RpcRequest<GetBlockTemplateData.Request> request = new RpcRequest<GetBlockTemplateData.Request>()
            {
                Method = "getblocktemplate",
                Arguments = new GetBlockTemplateData.Request() { WalletAddress = walletAddress, ReserveSize = reserveSize }
            };

            RpcResponse<GetBlockTemplateData.Response> response =
                await PostAsync<RpcResponse<GetBlockTemplateData.Response>>(request, Uri + JsonRoot);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return new BlockTemplate()
            {
                Blob = response.Result.Blob,
                Difficulty = response.Result.Difficulty,
                Height = response.Result.Height,
                ReservedOffset = response.Result.ReservedOffset
            };      
        }

        public async Task<DaemonInfo> GetDaemonInfo()
        {
            RpcRequest<object> request = new RpcRequest<object>()
            {
            };

            DaemonInfo response = await GetAsync<DaemonInfo>(Uri + "/getinfo");

            return response;
        }

        public async Task<BlockInfo> GetBlockInfo(string blockHash)
        {
            GetBlockInfoData.Request arg = new GetBlockInfoData.Request()
            {
                Hash = blockHash
            };

            RpcRequest<GetBlockInfoData.Request> request = new RpcRequest<GetBlockInfoData.Request>()
            {
                Method = "f_block_json",
                Arguments = arg
            };

            RpcResponse<GetBlockInfoData.Response> response = await PostAsync<RpcResponse<GetBlockInfoData.Response>>(request, Uri + "/json_rpc");

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            BlockInfo res = new BlockInfo()
            {
                BaseReward = response.Result.Data.BaseReward,
                BlockSize = response.Result.Data.BlockSize,
                Difficulty = response.Result.Data.Difficulty,
                Hash = response.Result.Data.Hash,
                Height = response.Result.Data.Height,
                IsOrphan = response.Result.Data.IsOrphan,
                MajorVersion = response.Result.Data.MajorVersion,
                MinorVersion = response.Result.Data.MinorVersion,
                MedianSize = response.Result.Data.MedianSize,
                PreviousHash = response.Result.Data.PreviousHash,
                Reward = response.Result.Data.Reward,
                RewardPenalty = response.Result.Data.RewardPenalty,
                Timestamp = new DateTime(1970, 1, 1).AddSeconds(response.Result.Data.Timestamp),
                TotalCoinsInNetwork = response.Result.Data.TotalCoinsInNetwork,
                TotalFeeAmount = response.Result.Data.TotalFeeAmount,
                TotalTransactionsInNetwork = response.Result.Data.TotalTransactionsInNetwork,
                TransactionsSize = response.Result.Data.TransactionsSize
            };

            res.TransactionsHashes = new List<string>();
            if (response.Result.Data.TotalTransactionsInBlock > 0)
            {
                foreach (var item in response.Result.Data.Transactions)
                {
                    res.TransactionsHashes.Add(item.Hash);
                }
            }

            return res;
        }

        public async Task<TransactionInfo> GetTransactionInfo(string transactionHash)
        {
            GetTransactionInfoData.Request arg = new GetTransactionInfoData.Request()
            {
                Hash = transactionHash
            };

            RpcRequest<GetTransactionInfoData.Request> request = new RpcRequest<GetTransactionInfoData.Request>()
            {
                Method = "f_transaction_json",
                Arguments = arg
            };

            RpcResponse<GetTransactionInfoData.Response> response = await PostAsync<RpcResponse<GetTransactionInfoData.Response>>(request, Uri + "/json_rpc");

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            TransactionInfo res = new TransactionInfo()
            {
                AmountOut = response.Result.TXDetails.AmountOut,
                Fee = response.Result.TXDetails.Fee,
                Mixin = response.Result.TXDetails.Mixin,
                Hash = response.Result.TXDetails.Hash,
                PaymentId = response.Result.TXDetails.PaymentId,
                Size = response.Result.TXDetails.Size,
                FromBlock = new TransactionInfo.Block()
                {
                    Hash = response.Result.BlockInfo.Hash,
                    Height = response.Result.BlockInfo.Height,
                    Timestamp = new DateTime(1970, 1, 1).AddSeconds(response.Result.BlockInfo.Timestamp)
                }
            };

            res.VIN = new List<TransactionInfo.VINItem>();

            foreach (var item in response.Result.TX.VIN)
            {
                res.VIN.Add(new TransactionInfo.VINItem()
                {
                    Amount = item.Value.Amount,
                    Image = item.Value.Image
                });
            }

            res.VOUT = new List<TransactionInfo.VOUTItem>();

            foreach (var item in response.Result.TX.VOUT)
            {
                res.VOUT.Add(new TransactionInfo.VOUTItem()
                {
                    Amount = item.Amount,
                    Key = item.Target.Data.Key
                });
            }

            return res;
        }
    }
}
