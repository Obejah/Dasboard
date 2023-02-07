using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Security.Cryptography.X509Certificates;

namespace Dashboardscrum.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public DashboardModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
            _teams = crudRepository.ReadAllRows<Team>().Result;
        }

        public ApplicationUser? ApplicationUser { get; set; }
        [BindProperty] public Team? Team { get; set; }

        public List<ApplicationUser>? _applicationUsers { get; set; }
        public List<Team> _teams { get; set; }

        public int teamcount;
        public int teamaanwezigcount;
    }
}
