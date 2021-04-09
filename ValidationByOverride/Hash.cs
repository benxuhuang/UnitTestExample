using System;

namespace ValidationByOverride
{
    public class Hash
    {
        public virtual string GetHashResult(string password)
        {
            throw new NotImplementedException();
        }
    }
}