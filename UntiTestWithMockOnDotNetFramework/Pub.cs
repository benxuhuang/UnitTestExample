using System.Collections.Generic;

namespace UntiTestWithMockOnDotNetFramework
{
    public class Pub
    {
        private ICheckInFee _checkInFee;
        private decimal _inCome = 0;

        public Pub(ICheckInFee checkInFee)
        {
            this._checkInFee = checkInFee;
        }

        public int CheckIn(List<Customer> list)
        {
            var result = 0;
            foreach (var item in list)
            {
                var isFemale = !item.IsMale;
                if (isFemale)
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
