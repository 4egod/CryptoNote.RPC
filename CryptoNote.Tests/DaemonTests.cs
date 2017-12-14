using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoNote.Tests
{
    using CryptoNote.RPC;
    using System.Diagnostics;

    [TestClass]
    public class DaemonTests
    {
        private DaemonClient _daemon = new DaemonClient("http://127.0.0.1:18081");

        [TestMethod]
        public void GetBlocksCountTest()
        {
            ulong count = _daemon.GetBlocksCount().Result;
            Debug.Write(count);
        }

        [TestMethod]
        public void GetBlockHashTest()
        {
            string hash = _daemon.GetBlockHash(1).Result;
            Debug.Write(hash);
        }

        [TestMethod]
        public void GetLastBlockHeaderTest()
        {
            BlockHeader blockHeader = _daemon.GetLastBlockHeader().Result;
            Debug.Write(blockHeader.Hash);
        }

        [TestMethod]
        public void GetBlockHeaderByHeightTest()
        {
            BlockHeader blockHeader = _daemon.GetBlockHeader(1).Result;
            Debug.Write(blockHeader.Hash);
        }

        [TestMethod]
        public void GetBlockHeaderByHashTest()
        {
            BlockHeader blockHeader = _daemon.GetBlockHeader("5736ff4f40790ae3163c51ed6f9bd880859d0972830cd836afe77edd8452931c").Result;
            Debug.Write(blockHeader.Hash);
        }

        [TestMethod]
        public void GetBlockTemplateTest()
        {
            BlockTemplate blockTemplate = _daemon.GetBlockTemplate("Sm3i1yokypheXjRnvSc9Gm1JtukB4pZMX5d8nEGFptHcXFsHFs11XnzTL1BC7pZKvx4NeyDDgvjxzgQYtizHLkrA29tvBHo9P", 4).Result;
            Debug.Write(blockTemplate.Blob);
        }
    }
}
