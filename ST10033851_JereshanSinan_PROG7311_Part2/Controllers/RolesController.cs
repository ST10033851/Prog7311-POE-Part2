using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//www.c-sharpcorner.com. (2023). ASP.NET MVC 5 Security And Creating User Role. [online]
//Available at: https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/. [Accessed 1 May 2024]
namespace ST10033851_JereshanSinan_PROG7311_Part2.Controllers
{
    [Authorize(Roles ="Employee")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _manager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _manager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _manager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            //Allows an employee to create roles for authentication
            if (!_manager.RoleExistsAsync(role.Name).GetAwaiter().GetResult()) 
            {
                _manager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
