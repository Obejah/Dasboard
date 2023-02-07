using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dashboardscrum.Repositories;
using System.Runtime.InteropServices;
using Dashboardscrum.Models;
using System.Diagnostics.Contracts;

namespace Dashboardscrum.Pages.Docent
{
    public class UpdateTeamModel : PageModel
    {
        public readonly Guid TeamId;
        public string teid;
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public UpdateTeamModel(IHttpContextAccessor httpContext, CrudRepository crudRepository, UserRepository userRepository)
        {   
            GeneralRepository.parseId(httpContext, out TeamId);
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
            _teams = crudRepository.ReadAllRows<Team>().Result;
        }

        [BindProperty]public Team? Team { get; set; }
        [BindProperty]public ApplicationUser? ApplicationUser { get; set; }

        public List<ApplicationUser>? _applicationUsers { get; set; }
        public List<Team> _teams { get; set; }

        public async Task<IActionResult> OnPostUpdateTeam()
        {
            if (_applicationUsers != null)
            {
                await _crudRepository.UpdateRow(ApplicationUser);
            }
            return Redirect("/Docent/UpdateTeam?TeamId=" + ApplicationUser.TeamId);
        }
        public async Task<IActionResult> OnPostDeleteTeamlid()
        {
                if (_applicationUsers != null)
                {
                    teid = Team.TeamId.ToString();
                    await _crudRepository.UpdateRow(ApplicationUser);
                }
                
            return Redirect("/Docent/UpdateTeam?TeamId=" + teid);
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
