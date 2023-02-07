using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dashboardscrum.Pages.Docent
{
    public class BekijkStandupModel : PageModel
    {
        public readonly Guid TeamId;
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;
        public int gemaaktvandaag;
        public int gisterengemaakt;
        public bool ooitgedaan;
        public BekijkStandupModel(IHttpContextAccessor httpContext, CrudRepository crudRepository, UserRepository userRepository)
        {
            GeneralRepository.parseId(httpContext, out TeamId);
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
            _standups = crudRepository.ReadAllRows<Standup>().Result;
        }
        public List<Standup> _standups { get; set; }

        public List<ApplicationUser>? _applicationUsers { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [BindProperty] public Standup Standup { get; set; }

        public async Task<IActionResult> OnPostOudeStandup()
        {
            if (Standup.StandupId.ToString() != "00000000-0000-0000-0000-000000000000") 
            {
                return Redirect("/Docent/BekijkOudeStandup?TeamId=" + Standup.StandupId);
            }
                return Redirect("/Docent/BekijkStandup?TeamId=" + TeamId);
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
