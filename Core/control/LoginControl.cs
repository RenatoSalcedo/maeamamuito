using oficial.Core.model;
using oficial.Core.model.dao;
using oficial.Core.util;

namespace oficial.Core.control
{
    public class LoginControl
    {
        LoginDAO lDao = new LoginDAO();

        public User login(string userName, string userPass)
        {
            userPass = Crypter.EncryptString(userPass);
            return lDao.login(userName, userPass);
        }

        public int verifySession(string userName, string userPass)
        {
            userPass = Crypter.EncryptString(userPass);
            return lDao.verifySession(userName, userPass);
        }
    }
}