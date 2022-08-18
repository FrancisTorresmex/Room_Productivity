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
            var boss = (from usuario in _context.Users
                              from bosses in _context.Bosses
                              where usuario.IdUser == bosses.IdUser
                              select usuario);

            //Diccionario, se enviara en el formulario el IdOffice, pero la que se visualizara sera el nombre
            ViewData["Offices"] = new SelectList(_context.Oficces, "IdOffice", "Name");
            ViewData["Bosses"] = new SelectList(boss, "IdUser", "Name");


            return View();
        }

        // POST: HomeAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User parameters)
        {
            try
            {
                var user = new User()
                {
                    Name = parameters.Name,
                    Email = parameters.Email,
                    Phone = parameters.Phone,
                    IdBoss = parameters.IdBoss,
                    IdOffice = parameters.IdOffice,
                    Image = parameters.Image, //convertir a byte
                    Registration = DateTime.Now,
                    Special = parameters.Special,
                    Active = parameters.Active
                };
                await _context.Users.AddAsync(user);
                _context.SaveChanges();

                if (user.Special == true) //si es especial osea tendra personas a cargo
                {                    
                    var boss = new Boss()
                    {
                        Active = true,
                        IdUser = user.IdUser //para este punto user ya tiene una id registrada
                    };
                    await _context.Bosses.AddAsync(boss);
                    _context.SaveChanges();

                }

                
                
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateOffice()
        {
            return View();
        }

        

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetOffice(string name)
        {
            try
            {
                List<Oficce> office = new List<Oficce>();

                if (string.IsNullOrEmpty(name))
                {
                    office = _context.Oficces.ToList();
                }
                else //busca por palabra oficinas
                {
                    office = _context.Oficces.Where(x => x.Name.Contains(name)).ToList();
                }                

                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOffice(Oficce parametros)
        {            
            try
            {
                var duplicate = _context.Oficces.Where(x => x.Name == parametros.Name);
                if (duplicate.Any())
                {
                    return BadRequest("El nombre de la oficina ya existe");
                }

                var office = new Oficce()
                {
                    Name = parametros.Name                    
                };
                await _context.Oficces.AddAsync(office);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
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
