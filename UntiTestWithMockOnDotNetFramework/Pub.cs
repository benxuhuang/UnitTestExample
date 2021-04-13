using System;
using System.Collections.Generic;

namespace UntiTestWithMockOnDotNetFramework
{
    public partial class Pub
    {
        private decimal _inCome = 0;
        private ICheckInFee _checkInFee;
        private ITimeWrapper _timeWrapper;

        public Pub(ICheckInFee checkInFee, ITimeWrapper timeWrapper)
        {
            this._checkInFee = checkInFee;
            this._timeWrapper = timeWrapper;
        }

        public int CheckIn(List<Customer> list)
        {
            var result = 0;
            foreach (var item in list)
            {
                var isFemale = !item.IsMale;
                var isLadyFriday = _timeWrapper.Now.DayOfWeek == DayOfWeek.Friday;
                if (isFemale && isLadyFriday)
                {
                    continue;
                }
                else
                {
                    this._inCome += this._checkInFee.GetFee(item);
                    result++;
                }
            }
            return result;
        }

        public decimal GetInCome()
        {
            return this._inCome;
        }

    }
}
