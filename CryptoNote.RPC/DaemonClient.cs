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

    }
}
