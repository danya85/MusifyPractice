using Core.DomainLayer.Models;

namespace Logic.ServiceLayer.IServices;

public interface IUserService
{
    Task<User> GetAsync(int id);
}