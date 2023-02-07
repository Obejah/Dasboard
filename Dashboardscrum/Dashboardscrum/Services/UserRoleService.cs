using Dashboardscrum.Models;
using Dashboardscrum.Pages;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Dashboardscrum.Services
{
    public class UserRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserRepository _userRepository;

        public UserRoleService(UserRepository userRepository, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUserWithRole(RegisterUser? registerUser, string roleName)
        {
            //role exists
            var exists = await _roleManager.RoleExistsAsync(roleName);

            //return if role or username doesn't exist
            if (!exists || registerUser?.UserName == null) return IdentityResult.Failed();

            //registers a new user
            var userResult = await _userRepository.RegisterUser(registerUser);

            //if everything goes well
            if (!userResult.Succeeded) return userResult;

            //finds user
            var user = await _userRepository.FindByNameAsync(registerUser.UserName);

            //uses the user and rolename to give the user a role
            var userRoleResult = await GiveUserRole(user, roleName);

            return userRoleResult;
        }

        private async Task<IdentityResult> GiveUserRole(ApplicationUser? user, string? name)
        {
            if (user == null || name == null) return IdentityResult.Failed();
            var role = await _roleManager.FindByNameAsync(name);
            return await _userRepository.AddToRole(user, role);
        }
    }
}