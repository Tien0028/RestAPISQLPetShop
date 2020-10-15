using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public PetRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }

        public Pet Create(Pet createPet)
        {
            _ptx.Attach(createPet).State = EntityState.Added;
            _ptx.SaveChanges();
            return createPet;
        }

        public void Delete(Pet pet)
        {
            _ptx.Remove(pet);
        }

        public List<Pet> FindPetById(int searchPetId)
        {

            return (List<Pet>)_ptx.Pets.Where(p => p.Id == searchPetId);
            

        }

        public IEnumerable<Pet> FindPetByName(string petName)
        {

            return _ptx.Pets.Where(p => p.Name.ToLower().Contains(petName.ToLower()));

            

        }

        public IEnumerable<Pet> FindPetsByFormerOwner(string searchValue)
        {
            return _ptx.Pets.Where(p => p.previousOwner.ToLower().Contains(searchValue.ToLower()));
        }

        public IEnumerable<Pet> FindPetsByPrice(long priceValue)
        {
            return _ptx.Pets.Where(p => p.Price <= priceValue - 10 && p.Price <= priceValue + 10);
        }

        public IEnumerable<Pet> FindPetsBySoldDate(DateTime soldValue)
        {
            return _ptx.Pets.Where(p => p.SoldDate.Year == soldValue.Year);
        }

        public IEnumerable<Pet> GetAllPets(FilterModel filter)
        {
            if(filter == null)
            {
                return _ptx.Pets;
            }
            return _ptx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsOnPage).Take(filter.ItemsOnPage);
        }

        public Pet ReadByPetId(int id)
        {
            return _ptx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public List<Pet> ReadPets()
        {
            return _ptx.Pets.ToList();
        }

        public IEnumerable<Pet> SearchPetsBytBirthday(DateTime dateValue)
        {
            return _ptx.Pets.Where(p => p.Birthdate.Year == dateValue.Year);
        }

        public Pet UpdateDB(Pet pet)
        {
            _ptx.Attach(pet.Name);
            _ptx.Attach(pet.PetOwner);
            _ptx.Attach(pet.PetType);
            var updatedPet = _ptx.Update(pet).Entity;
            _ptx.SaveChanges();
            return updatedPet;
        }
    }
}
