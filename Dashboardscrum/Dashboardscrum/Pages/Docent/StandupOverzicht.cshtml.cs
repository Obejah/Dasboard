using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Docent
{
    public class StandupOverzichtModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public StandupOverzichtModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _Standup = crudRepository.ReadAllRows<Standup>().Result;
            _Applicationuser = crudRepository.ReadAllRows<ApplicationUser>().Result;
            _Team = crudRepository.ReadAllRows<Team>().Result;
        }

        public Standup? Standup { get; set; }
        public Team? Team { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<Standup> _Standup { get; set; }
        public List<ApplicationUser> _Applicationuser { get; set; }
        public List<Team> _Team { get; set; }
        public int teamcount;
        public int vanteamingeleverd;
        public int ingeleverd;
        public int teams;

        public string lol;
        public async Task<IActionResult> OnPostBekijkStandup()
        {
            string teid = Team.TeamId.ToString();
            return Redirect("/Docent/BekijkStandup?TeamId=" + Team.TeamId);
        }
        public bool isDocent;
        public string userId;
        public void OnGet()
        {
            userId = _userRepository.GetCurrentUserId();
            ApplicationUser = _Applicationuser.Find(x => x.Id.Contains(userId));
            if (ApplicationUser.Role == 3)
            {
                isDocent = true;
            }
        }
    }
}
