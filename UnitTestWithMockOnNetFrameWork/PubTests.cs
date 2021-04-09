using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using UntiTestWithMockOnDotNetFramework;

namespace UntiTestWithMockOnDotNetFrameworkTests
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

        [TestMethod]
        public void Test_Income()
        {
            //arrange
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer{ IsMale=true},
                new Customer{ IsMale=false},
                new Customer{ IsMale=false},
            };

            var inComeBeforeCheckIn = target.GetInCome();
            Assert.AreEqual(0, inComeBeforeCheckIn);

            decimal expectedIncome = 100;

            //act
            var chargeCustomerCount = target.CheckIn(customers);

            var actualIncome = target.GetInCome();

            //assert
            Assert.AreEqual(expectedIncome, actualIncome);
        }
    }
}
