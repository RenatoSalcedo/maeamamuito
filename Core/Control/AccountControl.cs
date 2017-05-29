using System;
using MaeAmaMuito.Core.Model;
using MaeAmaMuito.Core.Repo;
using MaeAmaMuito.Core.Utility;
using Microsoft.AspNetCore.DataProtection;

namespace MaeAmaMuito.Core.Control
{
    public class AccountControl
    {
        AccountRepo accRpo = new AccountRepo();

        public User LogIn(User user)
        {
            try
            {
                user.Password = Crypter.Encrypt(user.Password);
                return accRpo.logIn(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogOut(User user)
        {
            try
            {
                user.Password = Crypter.Encrypt(user.Password);
                accRpo.logOut(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}