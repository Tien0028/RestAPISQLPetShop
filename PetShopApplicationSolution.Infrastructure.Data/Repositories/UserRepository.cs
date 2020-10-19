using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public UserRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }

        public void Add(User newUser)
        {
            _ptx.Users.Add(newUser);
            _ptx.SaveChanges();
        }

        public void Edit(User updateUser)
        {
            _ptx.Entry(updateUser).State = EntityState.Modified;
            _ptx.SaveChanges();
        }

        public User Get(long id)
        {
            
            return _ptx.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _ptx.Users.ToList();
        }

        public void Remove(long id)
        {
            var item = _ptx.Users.FirstOrDefault(u => u.Id == id);
            _ptx.Users.Remove(item);
            _ptx.SaveChanges();
        }
    }
}
