using Core.DomainLayer.Models;

namespace Data.RepositoryLayer.IRepository;

public interface IUserRepository : IRepository<User>
{
    Task<User> FindByCredentials(string email, string password);
}