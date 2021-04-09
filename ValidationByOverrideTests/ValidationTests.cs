using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationByOverride;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationByOverride.Tests
{
    [TestClass()]
    public class ValidationTests
    {
        [TestMethod()]
        public void CheckAuthenticationTest()
        {
            Validation target = new MyValidation();
            string id = "id";
            string pwd = "pwd";
            bool expected = true;
            bool actual;
            actual = target.CheckAuthentication(id, pwd);
            Assert.AreEqual(expected,actual);
        }
    }
}