using Room_Productivity.Models;
using Room_Productivity.Models.ViewModel;
using Room_Productivity.Services.Interfaces;

namespace Room_Productivity.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly Room_ProductivityContext _context;

        public OfficeService(Room_ProductivityContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> CreateOffice(Oficce parametros)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var duplicate = _context.Oficces.Where(x => x.Name == parametros.Name);
                if (duplicate.Any())
                {
                    response.Message = "Nombre ya registrado";                    
                    return response;                    
                }

                var office = new Oficce()
                {
                    Name = parametros.Name
                };
                await _context.Oficces.AddAsync(office);
                _context.SaveChanges();

                response.Status = 200;                
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Status = 404;
                return response;

            }
        }

        //Obtener todas las oficinas
        public async Task<ResponseModel> GetOffice()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                List<Oficce> office = _context.Oficces.OrderBy(x => x.Name).ToList();
                response.Content = office;

                return response;                
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Status = 404;
                return response;
            }
        }        

        public async Task<ResponseModel> DeactivateOffice(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> EditOffice(Oficce parametros)
        {
            throw new NotImplementedException();
        }                
    }
}
