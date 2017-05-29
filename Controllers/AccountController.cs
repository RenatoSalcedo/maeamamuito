using MaeAmaMuito.Core.Interfaces;
using MaeAmaMuito.Core.Model;
using MaeAmaMuito.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaeAmaMuito.Controllers
{
    [Route("api/[controller]")]
    public class AccountController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountRepository<User> _repo;

        public AccountController(IHttpContextAccessor httpContextAccessor, IAccountRepository<User> repo) 
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
        }

        [HttpPost("[action]")]
        public User logIn([FromBody]User user)
        {
            user.Password = Crypter.Encrypt(user.Password);
            return _repo.LogIn(user);
        }

        [HttpPost("[action]")]
        public void logOut([FromBody]User user)
        {
            _repo.LogOut(user);
        }
    }
}