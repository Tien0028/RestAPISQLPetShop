using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public OwnerRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }
        public Owner Create(Owner owner)
        {
            //if (owner.OwnerPets !=null && _ptx.ChangeTracker.Entries<Pet>().FirstOrDefault(ce => ce.Entity.Id == owner.Id) == null)
            //{
            //    _ptx.Attach(owner.OwnerPets);
            //}
            //var saved = _ptx.Owners.Add(owner).Entity;
            //_ptx.SaveChanges();
            //return saved;
            _ptx.Attach(owner).State = EntityState.Added;
            _ptx.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerRemoved = _ptx.Remove(new Owner { ID = id }).Entity;
            _ptx.SaveChanges();
            return ownerRemoved;
        }

        public List<Pet> FindAllPetsByOwner(Owner theOwner)
        {
            return _ptx.Pets.Where(p => p.PetOwner == theOwner).ToList();
        }

        public List<Owner> FindOwner(int ownerId)
        {
            return (List<Owner>)_ptx.Owners.Where(o => o.ID == ownerId);
        }

        public IEnumerable<Owner> FindOwnerByAddress(string searchValue)
        {
            return _ptx.Owners.Where(o => o.Address.ToLower().Contains(searchValue.ToLower()));
        }

        public IEnumerable<Owner> FindOwnerByEmail(string searchValue)
        {
            return _ptx.Owners.Where(o => o.Email.ToLower().Equals(searchValue.ToLower()));
        }

        public List<Owner> FindOwnerById(int searchForOwner)
        {
            return (List<Owner>)_ptx.Owners.Where(o => o.ID == searchForOwner);
        }

        public IEnumerable<Owner> FindOwnerByName(string searchValue)
        {
            return _ptx.Owners.Where(o => o.FirstName.ToLower().Contains(searchValue.ToLower()) || o.LastName.ToLower().Contains(searchValue.ToLower()));
        }

        public IEnumerable<Owner> FindOwnerByPhoneNummer(string searchValue)
        {
            return _ptx.Owners.Where(o => o.PhoneNumber.ToLower().Contains(searchValue.ToLower()));
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return _ptx.Owners.ToList();
        }

        public Owner ReadOwnerById(int id)
        {
           
            return _ptx.Owners.FirstOrDefault(c => c.ID == id);
        }

        public List<Owner> ReadOwners()
        {
            return _ptx.Owners.ToList();
        }

        public Owner Update(Owner owner)
        {
            //if (owner.OwnerPets != null && _ptx.ChangeTracker.Entries<Pet>().FirstOrDefault(ce => ce.Entity.Id == owner.Id) == null)
            //{
            //    _ptx.Attach(owner.OwnerPets);
            //}
            //var saved = _ptx.Owners.Add(owner).Entity;
            //_ptx.SaveChanges();
            //return saved;
            
            //_ptx.Entry(owner).Reference(o => o.Id).IsModified = true;
            _ptx.Attach(owner).State = EntityState.Modified;
            _ptx.SaveChanges();
            return owner;
        }
    }
}
