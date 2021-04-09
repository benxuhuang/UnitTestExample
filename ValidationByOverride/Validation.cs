namespace ValidationByOverride
{
    public class Validation
    {
        public bool CheckAuthentication(string id, string password)
        {
            var accountDao = GetAccountDao();
            var passwordByDao = accountDao.GetPassword(id);

            var hash = GetHash();
            var hashResult = hash.GetHashResult(password);

            return passwordByDao == hashResult;
        }

        protected virtual AccountDao GetAccountDao()
        {
            var accountDao = new AccountDao();
            return accountDao;
        }

        protected virtual Hash GetHash()
        {
            var hash = new Hash();
            return hash;
        }

    }

}
