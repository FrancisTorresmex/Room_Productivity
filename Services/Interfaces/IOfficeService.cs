using Microsoft.AspNetCore.Mvc;
using Room_Productivity.Models;
using Room_Productivity.Models.ViewModel;

namespace Room_Productivity.Services.Interfaces
{
    public interface IOfficeService
    {
        public Task<ResponseModel> CreateOffice(Oficce parametros);
        public Task<ResponseModel> GetOffice();
        public Task<ResponseModel> EditOffice(Oficce parametros);
        public Task<ResponseModel> DeactivateOffice(int id);
        
    }
}
