using Microsoft.VisualStudio.TestTools.UnitTesting;
using Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile_Team_Collab.Tests
{
    [TestClass()]
    public class AddDao_2_Tests
    {
        AddDao_2_ testing = new AddDao_2_();

        //Insert
        [TestMethod()]
        public void simpanTest()
        {
            string code = "001";
            string nama = "manggis";
            int price = 25000;
            decimal tax = 3;
            Assert.AreEqual(1, testing.simpan(code, nama, price, tax));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpanPriceMinus()
        {
            testing.simpan("001", "manggis", -25000, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpanTaxMinus()
        {
            testing.simpan("001", "manggis", 25000, -3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpanTaxLebih100()
        {
            testing.simpan("001", "manggis", 25000, 101);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpanNameKosong()
        {
            testing.simpan("001", "", 25000, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpanKodeKosong()
        {
            testing.simpan("", "manggis", 25000, 0);
        }

        //Update
        [TestMethod()]
        public void TestUpdate()
        {
            testing.simpan("001", "manggis", 25000, 5);
            Assert.AreEqual(1, testing.Update("001", "manggis", 25000, 5));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateHargaMinus()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Update("001", "manggis", -25000, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateTaxMinus()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Update("001", "manggis", 25000, -5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateTaxLebih100()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Update("001", "manggis", -25000, 101);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNameKosong()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Update("001", "", -25000, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateCodeKosong()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Update("", "manggis", -25000, 5);
        }

        //GetCode
        [TestMethod()]
        public void GetCodeTest()
        {
            Add item = new Add { Code = "001", Name = "Manggis", Price = 25000 };
            testing.simpan(item.Code, item.Name, item.Price, 3);
            Assert.AreEqual(item.Code, testing.GetCode("001").Code);
            Assert.AreEqual(item.Price, testing.GetCode("001").Price);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetCodeKosong()
        {
            Add item = new Add { Code = "001", Name = "Manggis", Price = 25000 };
            testing.simpan(item.Code, item.Name, item.Price, 3);
            Assert.AreEqual(item.Code, testing.GetCode("").Code);
        }

        //Delete
        [TestMethod()]
        public void DeleteTest()
        {
            testing.simpan("001", "manggis", 25000, 5);
            Assert.AreEqual(testing.Delete("001"), 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTestKosong()
        {
            testing.simpan("001", "manggis", 25000, 5);
            testing.Delete("");
        }
    }
}