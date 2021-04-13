using System;

namespace UntiTestWithMockOnDotNetFramework
{
    public class TimeWrapper : ITimeWrapper
    {
        public DateTime Now => DateTime.Now;
    }
}
