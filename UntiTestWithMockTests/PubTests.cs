using Microsoft.VisualStudio.TestTools.UnitTesting;
using UntiTestWithMock;
using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Mocks;

namespace UntiTestWithMock.Tests
{
    [TestClass()]
    public class PubTests
    {
        [TestMethod()]
        public void Test_Charge_Customer_Count()
        {
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();

            Pub target = new Pub(stubCheckInFee);
            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer {IsMale = true},
                new Customer {IsMale = false},
                new Customer {IsMale = false}
            };

            decimal expected = 1;
            var actual = target.CheckIn(customers);
            Assert.AreEqual(expected, actual);
        }
    }
}