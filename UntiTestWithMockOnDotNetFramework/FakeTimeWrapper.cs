using System;

namespace UntiTestWithMockOnDotNetFramework
{
    public class FakeTimeWrapper : ITimeWrapper
    {
        public DateTime MockTime;
        public DateTime Now => MockTime;
    }
}
