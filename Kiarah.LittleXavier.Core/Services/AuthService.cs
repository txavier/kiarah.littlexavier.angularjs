using Kiarah.LittleXavier.Core.Interfaces;
using Kiarah.LittleXavier.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiarah.LittleXavier.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var result = _authRepository.RegisterUser(userModel);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var result = await _authRepository.FindUser(userName, password);

            return result;
        }

        public void Dispose()
        {
            _authRepository.Dispose();
        }
    }
}
