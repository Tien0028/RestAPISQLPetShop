using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User newUser);
        void Edit(User updateUser);
        void Remove(long id);
    }
}
