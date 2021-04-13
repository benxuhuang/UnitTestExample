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
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/04/09");

            Pub target = new Pub(stubCheckInFee, fakeTimeWrapper);
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
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/04/09");
            Pub target = new Pub(stubCheckInFee, fakeTimeWrapper);

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

        [TestMethod]
        public void Test_CheckIn_Charge_Only_Male()
        {
            //arrange mock
            var customers = new List<Customer>();

            //2男1女
            var customer1 = new Customer { IsMale = true };
            var customer2 = new Customer { IsMale = true };
            var customer3 = new Customer { IsMale = false };

            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            MockRepository mock = new MockRepository();
            ICheckInFee stubCheckInFee = mock.StrictMock<ICheckInFee>();
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/04/09");
            using (mock.Record())
            {
                //期望呼叫ICheckInFee的GetFee()次數為2次
                stubCheckInFee.GetFee(customer1);

                LastCall
                    .IgnoreArguments()
                    .Return((decimal)100)
                    .Repeat.Times(2);
            }

            using (mock.Playback())
            {
                var target = new Pub(stubCheckInFee, fakeTimeWrapper);
                var count = target.CheckIn(customers);
            }
        }

        [TestMethod]
        public void Test_Friday_Charge_Customer_Count()
        {

            //arrange
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();

            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/04/09"); //friday

            Pub target = new Pub(stubCheckInFee, fakeTimeWrapper);

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
                {
                    new Customer{ IsMale=true},
                    new Customer{ IsMale=false},
                    new Customer{ IsMale=false},
                };

            decimal expected = 1;

            //act
            var actual = target.CheckIn(customers);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
