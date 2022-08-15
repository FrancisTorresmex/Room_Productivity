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

        // GET: HomeAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult CreateUser()
        {
            //Diccionario, se enviara en el formulario el IdOffice, pero la que se visualizara sera el nombre
            ViewData["Offices"] = new SelectList(_context.Oficces, "IdOffice", "Name");
            //Diccionario, se enviara en el formulario el IdBoss, pero la que se visualizara sera el nombre
            ViewData["Bosses"] = new SelectList(_context.Bosses, "IdBoss", "IdUser");

            return View();
        }

        // POST: HomeAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User parameters)
        {
            try
            {
                var user = new UserModel()
                {
                    //Name = parameters.,
                    Email = parameters.Email,
                    Phone = parameters.Phone,
                    IdBoss = parameters.IdBoss,
                    IdOffice = parameters.IdOffice,
                    Image = parameters.Image, //convertir a byte
                    Registration = DateTime.Now,
                    Special = parameters.Special,
                    Active = parameters.Active
                };
                //_context.Users.Add(user);
                
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
