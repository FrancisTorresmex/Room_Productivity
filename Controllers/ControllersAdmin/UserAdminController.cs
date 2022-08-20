using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Room_Productivity.Models;
using Room_Productivity.Services.Interfaces;

namespace Room_Productivity.Controllers.ControllersAdmin
{
    public class UserAdminController : Controller
    {
        private IUserService _service;

        //llenaran los viewData con los datos traidos como referencia
        List<User> boss;
        List<Oficce> office;

        public UserAdminController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {

            //bossData = from usuario in _context.Users
            //            from bosses in _context.Bosses
            //            where usuario.IdUser == bosses.IdUser
            //            select usuario;            

            _service.UserData(ref boss, ref office);

            //Diccionario, se enviara en el formulario el IdOffice, pero la que se visualizara sera el nombre
            ViewData["Offices"] = new SelectList(office, "IdOffice", "Name");
            ViewData["Bosses"] = new SelectList(boss, "IdUser", "Name");


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User parameters)
        {
            try
            {
                var resp = await _service.CreateUser(parameters);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
