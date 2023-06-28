using Core.DomainLayer.Models;
using Data.RepositoryLayer.IRepository;
using Logic.ServiceLayer.IServices;

namespace Logic.ServiceLayer.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetAsync(int id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
            throw new ArgumentNullException(nameof(id));

        return await _userRepository.FindByIdAsync(id);
    }
}