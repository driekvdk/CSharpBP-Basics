﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" 
                + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw"
                + " Available on: "; 

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_Object_Initializer()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };  
            var expected = "Hello Saw (1): 15-inch steel blade hand saw"
                + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMeterToInchesTest()
        {
            //Arrange
            var expected = 78.74;

            //Act
            var actual = 2 * Product.InchesPerMeter;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MinimunPriceTest_default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void MinimunPriceTest_bulk()
        {
            //Arrange
            var currentProduct = new Product(2, "Bulk goods", "Buy in large");
            var expected = 9.99m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductNameFormat()
        {
            // Arrange
            var currentProduct = new Product(1, "   Steel Hammer   ", "");
            var expected = "Steel Hammer";
            // Act
            var actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);

        }

    }
}