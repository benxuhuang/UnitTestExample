using System;

namespace UnitTesting
{
    public class AccountDao : IAccountDao
    {
        string IAccountDao.GetPassword(string id)
        {
            throw new NotImplementedException();
        }
    }
}
