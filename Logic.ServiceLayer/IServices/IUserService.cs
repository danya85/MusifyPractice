using Core.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ServiceLayer.IServices
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
    }
}
