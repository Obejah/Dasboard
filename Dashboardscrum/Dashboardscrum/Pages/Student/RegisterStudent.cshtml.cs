using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace Dashboardscrum.Pages.Student
{
    public class RegisterStudentModel : PageModel
    {
        private readonly UserRepository _userRepository;
        private readonly CrudRepository _crudRepository;
        public readonly Guid NFC;
        public string currentId;
        public string NewNFC;

        public RegisterStudentModel(IHttpContextAccessor httpContext, UserRepository userRepository, CrudRepository crudRepository)
        {
            _crudRepository = crudRepository;
            GeneralRepository.parseId(httpContext, out NFC);
            _userRepository = userRepository;
            _applicationUsers = crudRepository.ReadAllRows<ApplicationUser>().Result;
        }

        [BindProperty] public ApplicationUser ApplicationUser { get; set; }
        public List<ApplicationUser>? _applicationUsers { get; set; }

        public void OnGet()
        {
            currentId = _userRepository.GetCurrentUserId();
            ApplicationUser = _applicationUsers.Find(x => x.Id.Contains(currentId));
        }

        public async void OnPost()
        {
            if (ApplicationUser != null)
            {
                await _crudRepository.UpdateRow(ApplicationUser);
            }
        }


    }
}
