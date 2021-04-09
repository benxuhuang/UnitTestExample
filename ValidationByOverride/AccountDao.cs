using System;

namespace ValidationByOverride
{
    public class AccountDao
    {
        public virtual string GetPassword(string id)
        {
            throw new NotImplementedException();
        }
    }
}