using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace Dashboardscrum.Pages.Docent
{
    public class CreateTeamModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public CreateTeamModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }
        public List<ApplicationUser>? _applicationUsers { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [BindProperty] public Team Team { get; set; }

        public async Task<IActionResult> OnPostCreateTeam()
        {
            if (ModelState.IsValid)
            {
                Guid teamId = Guid.NewGuid();
                Team.TeamId = teamId;
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
