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
            var ownerRemoved = _ptx.Remove(new Owner { Id = id }).Entity;
            _ptx.SaveChanges();
            return ownerRemoved;
        }

        public List<Pet> FindAllPetsByOwner(Owner theOwner)
        {
            throw new NotImplementedException();
        }

        public List<Owner> FindOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> FindOwnerByAddress(string searchValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> FindOwnerByEmail(string searchValue)
        {
            throw new NotImplementedException();
        }

        public List<Owner> FindOwnerById(int searchForOwner)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> FindOwnerByName(string searchValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> FindOwnerByPhoneNummer(string searchValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return _ptx.Owners.ToList();
        }

        public Owner ReadOwnerById(int id)
        {
           
            return _ptx.Owners.FirstOrDefault(c => c.Id == id);

       
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
            _ptx.Attach(owner).State = EntityState.Modified;
            //_ptx.Entry(owner).Reference(o => o.Id).IsModified = true;
            _ptx.SaveChanges();
            return owner;
        }
    }
}
