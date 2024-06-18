using Microsoft.AspNetCore.Identity;
using OnlineBookStore.Core.IService;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user)
        {
            try
            {
                var result = await _userManager.CreateAsync(user);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
