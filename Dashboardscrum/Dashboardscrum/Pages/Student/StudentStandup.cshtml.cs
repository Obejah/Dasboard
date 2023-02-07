using Dashboardscrum.Models;
using Dashboardscrum.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboardscrum.Pages.Student
{
    public class StudentStandupModel : PageModel
    {
        private readonly CrudRepository _crudRepository;
        private readonly UserRepository _userRepository;

        public StudentStandupModel(CrudRepository crudRepository, UserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
        }
        [BindProperty]public Standup? _Standup { get; set; }

        public async Task<IActionResult> OnPostStudentStandup()
        {
            _Standup.ApplicationUserId = _userRepository.GetCurrentUserId();
            if(ModelState.IsValid )
            {
                await _crudRepository.AddRow(_Standup);
            }
            return RedirectToPage("/Student/Index");
        }
    }
}
