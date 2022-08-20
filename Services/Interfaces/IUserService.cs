using Room_Productivity.Models;
using Room_Productivity.Models.ViewModel;

namespace Room_Productivity.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseModel> CreateUser(User parametros);
        public Task<ResponseModel> GetUser();
        public Task<ResponseModel> EditUser(Oficce parametros);
        public Task<ResponseModel> DeactivateUser(int id);
        public void UserData(ref List<User> bossData, ref List<Oficce> officeData);
    }
}
