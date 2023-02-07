using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Dashboardscrum.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserRepository _userRepository;
        private readonly CrudRepository _crudReporsitory;
        public string currentId;

        public RegisterModel(UserRepository userRepository, CrudRepository crudRepository)
        {
            _userRepository = userRepository;
            _crudReporsitory = crudRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }

        [BindProperty] public RegisterUser RegisterUser { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public List<ApplicationUser> _applicationUsers { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _userRepository.RegisterUser(RegisterUser);


            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(x =>
                    ModelState.AddModelError("", x.Description ?? "Er is helaas iets mis gegaan."));
                return Page();
            }

            else
            {
                return RedirectToPage("/Login");
            }
        }
        public bool isDocent;
        public string userId;
        public void OnGet()
        {
            userId = _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(userId));
            if (ApplicationUser.Role == 3)
            {
                isDocent = true;
            }
        }
    }
}
