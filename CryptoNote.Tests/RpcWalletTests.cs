using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoNote.RPC;
using System.Diagnostics;

namespace CryptoNote.Tests
{
    [TestClass]
    public class RpcWalletTests
    {
        private RpcWalletClient _rpc = new RpcWalletClient("http://127.0.0.1:18083");

        [TestMethod]
        public void GetStatusTest()
        {
            var status = _rpc.GetStatus().Result;
            Debug.WriteLine($"Current Block Index: {status.CurrentBlockIndex}," +
                $" Last Block Index: {status.LastBlockIndex}, Last Block Hash: {status.LastBlockHash}");
        }

        [TestMethod]
        public void GetBalanceTest()
        {
            var balance = _rpc.GetBalance("Sm4JLf5tJxsfYPS8jdeL5aYNxdwVdsQVdhKSJeKpefNrA7mCjYNHV8eGM2PWHJTFUtikFVdxoeB2LE7E8rddWSLR15KQ2w8K6").Result;
            Debug.WriteLine($"Available: {balance.Available}, Locked: {balance.Locked}, Total: {balance.Total}");
        }

        [TestMethod]
        public void GetTransactionsTest()
        {
            var transactions = _rpc.GetTransactions(43350, 500).Result;
            foreach (var item in transactions)
            {
                Debug.WriteLine($"Transaction: Timestamp: {item.Timestamp}, Hash: {item.TransactionHash}, Amount: {item.Amount}");
                foreach (var transfer in item.Transfers)
                {
                    Debug.WriteLine($"  -->: Address: {transfer.Address}, Amount: {transfer.Amount}, Type: {transfer.Type}");
                }
            }
        }

        [TestMethod]
        public void SendTransactionTest()
        {
            string hash = _rpc.Transfer("Sm4JLf5tJxsfYPS8jdeL5aYNxdwVdsQVdhKSJeKpefNrA7mCjYNHV8eGM2PWHJTFUtikFVdxoeB2LE7E8rddWSLR15KQ2w8K6",
                "Sm4JLf5tJxsfYPS8jdeL5aYNxdwVdsQVdhKSJeKpefNrA7mCjYNHV8eGM2PWHJTFUtikFVdxoeB2LE7E8rddWSLR15KQ2w8K6", 100000000).Result;
            Debug.WriteLine($"Transaction hash: {hash}");
        }

        [TestMethod]
        public void CreateAddressTest()
        {
            string address = _rpc.CreateAddress().Result;
            Debug.WriteLine($"New address: {address}");
        }

    }
}
