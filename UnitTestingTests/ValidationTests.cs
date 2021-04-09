using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Tests
{
    [TestClass()]
    public class ValidationTests
    {
        [TestMethod()]
        public void CheckAuthenticationTest()
        {
            IAccountDao accountDao = new StubAccountDao();
            IHash hash = new StubHash();
            Validation target = new Validation(accountDao, hash);

            string id = "id";
            string pwd = "pwd";

            bool expected = true;
            bool actual;

            actual = target.CheckAuthenticationTest(id, pwd);
            Assert.AreEqual(expected, actual);
        }
    }
}