using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data
{
    public class PetShopApplicationContext: DbContext
    {
        public PetShopApplicationContext(DbContextOptions<PetShopApplicationContext> opt): base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<PetColor> PetColors { get; set; }
        public DbSet<PetColorPet> PetColorPet { get; set; }
    }
}
