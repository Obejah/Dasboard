using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public LogoutModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _userRepository.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDontLogoutAsync()
        {
            return RedirectToPage("/Index");
        }
    }
}
