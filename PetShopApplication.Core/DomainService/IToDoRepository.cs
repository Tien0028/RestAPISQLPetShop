using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.DomainService
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem Get(long id);
        void Add(ToDoItem newItem);
        void Edit(ToDoItem updateItem);
        void Remove(long id);
    }
}

