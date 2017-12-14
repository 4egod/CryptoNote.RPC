using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoNote.Tests
{
    using CryptoNote.RPC;
    using System.Diagnostics;

    [TestClass]
    public class WalletTests
    {
        private WalletClient _wallet = new WalletClient("http://127.0.0.1:18082");

        [TestMethod]
        public void GetBalanceTest()
        {
            Balance balance = _wallet.GetBalance().Result;
            Debug.Write(balance.Total);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            ulong height = _wallet.GetHeight().Result;
            Debug.Write(height);
        }

        [TestMethod]
        public void TransferTest()
        {
            string hash = _wallet.Transfer("Sm3USXEeQueQHiB1xVugmx9zNWq7mcbCsYdxqvd6XEWW1CDCMZZ6BbKdCHjnGbQSjMZCjyZbP9soKhD3kpYBz2pD32Bukozpz",
                1000000000, 1000000, 7).Result;
            Debug.Write(hash);
        }

        [TestMethod]
        public void GetTransfers()
        {
            var transfers = _wallet.GetTransfers().Result;
        }

        [TestMethod]
        public void ResetTest()
        {
            _wallet.Reset().Wait();
        }

        [TestMethod]
        public void SaveTest()
        {
            _wallet.Save().Wait();
        }

    }
}
