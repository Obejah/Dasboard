using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;
        public string currentId;

        public IndexModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
            _Team = crudRepository.ReadAllRows<Team>().Result;
        }
        public Team? Team { get; set; }
        public List<ApplicationUser> _applicationUsers;
        public List<Team> _Team;
        public ApplicationUser ApplicationUser;

        public void OnGet()
        {
            currentId = _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x =>   x.Id.Contains(currentId));
            Team = _Team.Find(x => x.TeamId.ToString().Contains(ApplicationUser.TeamId));
        }

        public async Task<IActionResult> OnPostHulp()
        {
            currentId = _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(currentId));
            Team = _Team.Find(x => x.TeamId.ToString().Contains(ApplicationUser.TeamId));
            if (Team.Hulp == 1)
            {
                Team.Hulp = 0;
            }
            else
            {
                Team.Hulp = 1;
            }
            await _crudRepository.UpdateRow(Team);

            return Redirect("/Student");
        }
        public async Task<IActionResult> OnPostStandup()
        {
            return Redirect("Student/StudentStandup");
        }
    }
}
