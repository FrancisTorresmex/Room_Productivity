using Microsoft.AspNetCore.Mvc.Rendering;
using Room_Productivity.Models;
using Room_Productivity.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Room_Productivity.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly Room_ProductivityContext _context;

        //llenar las viewData de la vista createUser
        public static object bossData;
        public static object officesData;

        public UserService(Room_ProductivityContext context)
        {
            _context = context;
        }

        //obtener todos los usuarios
        public async Task<ResponseModel> GetUser()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                List<Oficce> users = _context.Oficces.OrderBy(x => x.Name).ToList();
                response.Content = users;

                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Status = 404;
                return response;
            }
        }

        public async Task<ResponseModel> CreateUser(User parameters)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var searchEmail = _context.Users.Where(x => x.Email == parameters.Email).FirstOrDefault();
                if (searchEmail != null) //ya existe
                {
                    response.Message = "El correo ya se encuentra registrado";
                    return response;
                }

                var searchPhone = _context.Users.Where(x => x.Phone == parameters.Phone).FirstOrDefault();
                if (searchEmail != null) //ya existe
                {
                    response.Message = "El télefono ya se encuentra registrado";
                    return response;
                }

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
                
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Status = 404;
                return response;
            }
        }

        public async Task<ResponseModel> DeactivateUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> EditUser(Oficce parametros)
        {
            throw new NotImplementedException();
        }

        //llenar de datos la vista con referencias a los datos
        public void UserData(ref List<User> bossData, ref List<Oficce> officeData)
        {
            try
            {
                bossData = (from usuario in _context.Users
                            from bosses in _context.Bosses
                            where usuario.IdUser == bosses.IdUser
                            select usuario).ToList();

                officeData = _context.Oficces.ToList();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
