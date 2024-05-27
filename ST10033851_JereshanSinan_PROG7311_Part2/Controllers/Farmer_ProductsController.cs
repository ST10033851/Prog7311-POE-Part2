using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10033851_JereshanSinan_PROG7311_Part2.Data;
using ST10033851_JereshanSinan_PROG7311_Part2.Models;
using System.Data;

//www.tutorialsteacher.com. n.d. ViewBag in ASP.NET MVC. [online]
//Available at: https://www.tutorialsteacher.com/mvc/viewbag-in-asp.net-mvc. [Accessed 1 May 2024].‌

namespace ST10033851_JereshanSinan_PROG7311_Part2.Controllers
{
    [Authorize(Roles = "Employee")]
    public class Farmer_ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Farmer_ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Farmer_Products
        public async Task<IActionResult> Index()
        {
            //Uses LINQ to query all users that have the 'Farmer' role and initializes it as 'farmers'
            var farmers = (from userRole in _context.UserRoles
                           join user in _context.Users on userRole.UserId equals user.Id
                           join role in _context.Roles on userRole.RoleId equals role.Id
                           where role.Name == "Farmer"
                           select user).ToList();

            // Parses the list of farmers to the ViewBag, making it available to the index view
            ViewBag.Farmers = farmers;

            return _context.Products != null ?
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: Farmer_Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            string idString = id.ToString();

            //Retrieves all products that are linked to the farmer id that was clicked by the user
            var product = await _context.Products
            .Where(m => m.FarmerID == idString)
            .ToListAsync();

            ViewBag.Products = product;

            //If the farmer has no products then the user will be redirected to the index and display a message
            if (product == null || product.Count == 0)
            {
                TempData["ErrorMessage"] = "This farmer has no products";
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }



    }
}