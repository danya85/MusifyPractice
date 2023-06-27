using Core.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryLayer.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByCredentials(string email, string password);

    }
}
