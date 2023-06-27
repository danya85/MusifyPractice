using Core.DomainLayer.Models;
using Data.RepositoryLayer.IRepository;
using Logic.ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}
