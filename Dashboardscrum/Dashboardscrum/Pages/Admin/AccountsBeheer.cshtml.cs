using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Admin
{
    public class AccountsBeheerModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;
        public bool IsAdmin { get; set; }
        public string rol = "DOCENT";

        public AccountsBeheerModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }

        public List<ApplicationUser> _applicationUsers { get; set; }
        [BindProperty] public ApplicationUser? ApplicationUser { get; set; }

        public string currentId;

        public async void OnGet()
        {
            currentId = _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(currentId));
            if(ApplicationUser.Role == 3)
            {
                IsAdmin = true;
            }
        }
        public async Task<IActionResult> OnPostUpdateRole()
        {
            if (_applicationUsers != null)
            {
                await _crudRepository.UpdateRow(ApplicationUser);
                await _userRepository.AddToRole(ApplicationUser, rol);
            }
            return RedirectToPage("/Admin/Accountsbeheer");
        }
        public async Task<IActionResult> OnPostVerwijderUser()
        {
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(ApplicationUser.Id));
            return RedirectToPage("/Admin/Accountsbeheer");
        }
    }
}
