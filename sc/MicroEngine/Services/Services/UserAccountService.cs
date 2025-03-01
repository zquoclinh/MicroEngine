using AutoMapper;
using MicroEngine.Data.Entities;
using MicroEngine.Framework.Entity;
using MicroEngine.Framework.MappinExtesions;
using MicroEngine.Framework.Repository;
using MicroEngine.Models.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IRepository<UserAccount> _userRepository;
        private readonly IMapper _mapper;

        public UserAccountService(IRepository<UserAccount> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserAccount>> GetAllUser()
        {
            var response = await _userRepository.Table.ToListAsync();
            return response;
        }

        public async Task<UserAccountModel> Create(UserAccountModel model)
        {
            if (!string.IsNullOrEmpty(model.Email) && !Utils.Utils.IsValidEmail(model.Email))
            {
                throw new Exception("Invalid email");
            }
            var entity = _mapper.Map<UserAccount>(model);
            await _userRepository.AddAsync(entity);
            return model;
        }

        public async Task<UserAccount> GetById(int id)
        {
            var emp = await _userRepository.GetByIdAsync(id) ?? null;
            return emp;
        }

        public async Task<UserAccount> GetByUserCode(string userCode)
        {
            var emp = await _userRepository
                .Table.Where(s => s.UserCode == userCode)
                .FirstOrDefaultAsync();
            return emp;
        }

        public async Task<UserAccount> Update(UserUpdateModel model)
        {
            if (!string.IsNullOrEmpty(model.Email) && !Utils.Utils.IsValidEmail(model.Email))
            {
                throw new Exception("Invalid email");
            }

            var emp = await _userRepository.GetByIdAsync(model.Id);

            if (emp != null)
            {
                var entity = model.FromModel<UserAccount>();
                await _userRepository.UpdateAsync(entity);
            }
            else
            {
                var enity = _mapper.Map<UserAccount>(model);
                await _userRepository.AddAsync(enity);
            }

            return await GetById(model.Id);
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetUserLogin(string loginName, string password)
        {
            var userAccount = await _userRepository
                .Table.Where(s => s.LoginName == loginName && s.Password == password)
                .SingleOrDefaultAsync();
            var user = _mapper.Map<User>(userAccount);
            return user;
        }
    }
}
