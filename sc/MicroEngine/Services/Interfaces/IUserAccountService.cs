using MicroEngine.Data.Entities;
using MicroEngine.Framework.Entity;
using MicroEngine.Models.RequestModels;

namespace MicroEngine.Services
{
    public interface IUserAccountService
    {
        Task<List<UserAccount>> GetAllUser();

        Task<UserAccountModel> Create(UserAccountModel model);

        Task<UserAccount> Update(UserUpdateModel model);

        Task<UserAccount> GetById(int id);

        Task<UserAccount> GetByUserCode(string userCode);

        Task Delete(int id);

        Task<User> GetUserLogin(string loginName, string password);
    }
}
