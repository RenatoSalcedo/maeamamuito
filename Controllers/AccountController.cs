using MaeAmaMuito.Core.Control;
using MaeAmaMuito.Core.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace MaeAmaMuito.Controllers
{
    [Route("api/[controller]")]
    public class AccountController
    {
        AccountControl accCtrl = new AccountControl();

        [HttpPost("[action]")]
        public User logIn([FromBody]User user)
        {
            return accCtrl.LogIn(user);
        }

        [HttpPost("[action]")]
        public void logOut([FromBody]User user)
        {
            accCtrl.LogOut(user);
        }
    }
}