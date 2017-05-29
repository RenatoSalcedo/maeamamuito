using MaeAmaMuito.Core.Model;

namespace MaeAmaMuito.Core.Interfaces
{
    public interface IAccountRepository<User>
    {
        User LogIn(User user);
        void LogOut(User user);
    }
}