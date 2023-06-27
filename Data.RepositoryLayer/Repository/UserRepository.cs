using Core.DomainLayer.Data;
using Core.DomainLayer.Models;
using Data.RepositoryLayer.IRepository;

namespace Data.RepositoryLayer.Repository
{
    public class UserRepository :  GenericRepository<User>, IUserRepository
    { 
        AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> FindByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return new Core.DomainLayer.Models.User { Email = "dd@sds.com", Id = id };
        }
    }
}
