using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Room_Productivity.Models;

namespace Room_Productivity.Controllers.ControllersAdmin
{
    public class HomeAdminController : Controller
    {
        private readonly Room_ProductivityContext _context;

        public HomeAdminController(Room_ProductivityContext context)
        {
            _context = context;
        }

        // GET: HomeAdminController
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        public async Task<IActionResult> CreateUser()
        {
            return RedirectToAction("CreateUser", "UserAdmin");
        }

        public async Task<IActionResult> CreateOffice()
        {
            return RedirectToAction("CreateOffice", "OfficeAdmin");
        }

    }
}
