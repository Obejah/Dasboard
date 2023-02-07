using Dashboardscrum.Models;
using Microsoft.AspNetCore.Identity;

namespace Dashboardscrum.Repositories;

public class UserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentUserId()
    {
        return _httpContextAccessor.HttpContext.User.Claims.First().Value;
    }

    public async Task<IdentityResult> RegisterUser (RegisterUser registerUser)
    {
        if (registerUser.Password == null || registerUser.UserName == null || registerUser.Email == null) return IdentityResult.Failed();
        var user = new ApplicationUser()
        {
            UserName = registerUser.UserName,
            Email = registerUser.Email
        };

        //makes a new user
        var result = await _userManager.CreateAsync(user, registerUser.Password);

        //return
        return result;
    }
    /// <summary>
    ///     checks if the current user has specific role
    /// </summary>
    /// <param name="role"></param>
    /// <returns>true/false</returns>
    public bool IsCurrentUserRole(string role)
    {
        return _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User.IsInRole(role);
    }

    /// <summary>
    ///     gives <see cref="ApplicationUser" /> supplied <see cref="IdentityRole" />
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    /// <returns>
    ///     <see cref="IdentityResult" />
    /// </returns>
    public async Task<IdentityResult> AddToRole(ApplicationUser user, IdentityRole role)
    {
        return await _userManager.AddToRoleAsync(user, role.Name);
    }
    /// <summary>
    ///     finds <see cref="ApplicationUser" /> by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>
    ///     <see cref="ApplicationUser"/>
    /// </returns>
    public async Task<ApplicationUser> FindByNameAsync(string name)
    {
        return await _userManager.FindByNameAsync(name);
    }

    public async Task<SignInResult> Login(LoginUser loginUser)
    {
        //kijkt of het wachtwoord overeen komt met de werkelijke gebruiker 
        return await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, loginUser.rememberMe, false);
    }
    public bool IsUserLoggedIn() => _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User.Claims.Any();

    public async Task Logout() => await _signInManager.SignOutAsync();

    internal async Task<IdentityResult> AddToRole(ApplicationUser? applicationUser, string rol)
    {
        return await _userManager.AddToRoleAsync(applicationUser, rol);
    }
} 