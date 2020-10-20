using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public ToDoRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }
        public void Add(ToDoItem newItem)
        {
            _ptx.ToDoItems.Add(newItem);
            _ptx.SaveChanges();
        }

        public void Edit(ToDoItem updateItem)
        {
            _ptx.Entry(updateItem).State = EntityState.Modified;
            _ptx.SaveChanges();
        }

        public ToDoItem Get(long id)
        {
            return _ptx.ToDoItems.FirstOrDefault(u => u.ID == id);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _ptx.ToDoItems.ToList();
        }

        public void Remove(long id)
        {
            var item = _ptx.ToDoItems.FirstOrDefault(b => b.ID == id);
            _ptx.ToDoItems.Remove(item);
            _ptx.SaveChanges();
        }
    }
}
