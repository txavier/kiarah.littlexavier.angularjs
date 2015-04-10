using System;
namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IAuthService
    {
        System.Threading.Tasks.Task<Microsoft.AspNet.Identity.IdentityResult> RegisterUser(Kiarah.LittleXavier.Core.Models.UserModel userModel);

        void Dispose();

        System.Threading.Tasks.Task<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> FindUser(string userName, string password);
    }
}
