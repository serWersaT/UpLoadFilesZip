using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using UpLoadZip.WEB.Services;
using UpLoadZip.WEB.Models;


namespace UpLoadZip.Test
{
    [TestClass]
    public class ZipServicesTest
    {
        ZipServices service = new ZipServices();

        [TestMethod]
        public void TestGetStruct()
        {

            string filepath = "C:\\Users\\wersa\\OneDrive\\Desktop\\fashion-maverick-009.myshopify.com-export-20220529174812 (1).zip";
            var expected = GetModel();
            var result = service.GetStruct(filepath);


            /*т.к. у разных экземпляров класса разные значения ссылок в стеке, по этому сравнение сделал таким образом*/
            bool equality = false;
            if (expected.FileName == result.FileName && expected.Acrchive.SequenceEqual(result.Acrchive))
                equality = true;

            Assert.AreEqual(equality, true);
        }



        private ZipStructModel GetModel()
        {
            ZipStructModel model = new ZipStructModel();
            model.FileName = @"C:\Users\wersa\OneDrive\Desktop\fashion-maverick-009.myshopify.com-export-20220529174812 (1).zip";
            model.Acrchive = new Dictionary<string, int>();
            model.Acrchive.Add("Article", 77);
            model.Acrchive.Add("Blog", 29);
            model.Acrchive.Add("Comment", 221);
            model.Acrchive.Add("Customer", 163);
            model.Acrchive.Add("Order", 2);
            model.Acrchive.Add("Product", 24);
            return model;
        }
    }
}
