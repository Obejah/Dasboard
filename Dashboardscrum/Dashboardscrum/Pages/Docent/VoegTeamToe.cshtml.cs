using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Docent
{
    public class VoegTeamToeModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public VoegTeamToeModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _teams = crudRepository.ReadAllRows<Team>().Result;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }

        [BindProperty]public Team? Team { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public List<ApplicationUser> _applicationUsers { get; set; }
        public List<Team> _teams { get; set; }

        public async Task<IActionResult> OnPostAddTeam()
        {
            if (ModelState.IsValid)
            {
                await _crudRepository.AddRow(Team);
            }
            return RedirectToPage("/Docent/TeamsOverzicht");
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
