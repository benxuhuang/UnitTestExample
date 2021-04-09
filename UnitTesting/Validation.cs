using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public partial class Validation
    {
        private IAccountDao _accountDao;
        private IHash _hash;

        public Validation(IAccountDao dao, IHash hash)
        {
            this._accountDao = dao;
            this._hash = hash;
        }

        public bool CheckAuthenticationTest(string id,string password)
        {
            var passwordByDao = this._accountDao.GetPassword(id);
            var hashResult = this._hash.GetHashCode(password);
            return passwordByDao == hashResult;
        }
    }
}
