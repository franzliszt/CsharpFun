using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsharpPractise;
using System.Collections.Generic;

namespace Testing {
    [TestClass]
    public class UnitTesting {

        [TestMethod]
        public void Test_ValidateFirstname_True() {
            // arrange
            string firstname = "Donald";

            // act
            bool result = Program.ValidateFirstname(firstname);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_ValidateFirstname_False() {
            // arrange
            string firstname = "Donald-113";

            // act
            bool result = Program.ValidateFirstname(firstname);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_ValidateZipcode_True() {
            string zip = "9875";

            bool result = Program.ValidateZipcode(zip);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_ValidateZipcode_False() {
            // arrange
            string[] zip = {
                "07890",
                "0xi7",
                "-1203",
                "999\\",
                "9-09+"
            };

            
            foreach (var item in zip) {
                // act
                bool result = Program.ValidateZipcode(item);
                // assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void Test_ToChar_Equal() {
            // arrange 
            string test = "abba cd efg";
            Array expectedArray = new char[] { 'a', 'b', 'b', 'a', 'c', 'd', 'e', 'f', 'g' };

            // act
            char[] actualArray = Program.ToChar(test);

            // assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void Test_ToChar_NotEqual() {
            // arrange 
            string test = "abba cd efg1";
            Array expectedArray = new char[] { 'a', 'b', 'b', 'a', 'c', 'd', 'e', 'f', 'g' };

            // act
            char[] actualArray = Program.ToChar(test);
           
            // assert
            CollectionAssert.AreNotEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void Test_IsOdd_True() {
            bool expected = true;
            int i = -5;

            Assert.IsTrue(expected == Program.IsOdd(i));
        }

        [TestMethod]
        public void Test_IsOdd_False() {
            bool expected = false;
            int i = 2;

            Assert.IsTrue(expected == Program.IsOdd(i));
        }

        [TestMethod]
        public void Test_FizzBuzz_Null() {
            // arrange
            string expected1 = null;
            string expected2 = null;

            // act
            string actual1 = Program.FizzBuzz(0);
            string actual2 = Program.FizzBuzz(2);


            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void Test_FizzBuzz_FizzBuzz() {
            // arrange
            string expected = "FizzBuzz";

            // act
            string actual = Program.FizzBuzz(45);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_FizzBuzz_Fizz() {
            // arrange
            string expected = "Fizz";

            // act
            string actual = Program.FizzBuzz(6);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_FizzBuzz_Buzz() {
            // arrange
            string expected = "Buzz";

            // act
            string actual = Program.FizzBuzz(10);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
