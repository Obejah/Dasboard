using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Docent
{
    public class BekijkOudeStandupModel : PageModel
    {
        public readonly Guid TeamId;
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;
        public string userId;
        public bool isDocent;
        public string Link;

        public BekijkOudeStandupModel(IHttpContextAccessor httpContext, CrudRepository crudRepository, UserRepository userRepository)
        {
            GeneralRepository.parseId(httpContext, out TeamId);
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _standups = crudRepository.ReadAllRows<Standup>().Result;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }

        public List<Standup> _standups { get; set; }
        public List<ApplicationUser> _applicationUsers { get; set; }

        [BindProperty]public Standup Standup { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnPostOudeStandup()
        {
            if (Standup.StandupId.ToString() != null)
            {
                return Redirect("/Docent/BekijkOudeStandup?TeamId=" + Standup.StandupId);
            }
            return Redirect("/Docent/BekijkOudeStandup?TeamId=" + TeamId);
        }
        
        public void OnGet()
        {
            userId =  _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(userId));
            if (ApplicationUser.Role == 3)
            {
                isDocent = true;
            }
        }
    }
}
