using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public PetTypeRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }
        public PetType AddNewPetType(PetType newPetType)
        {
            var thePetType = _ptx.PetTypes.Add(newPetType).Entity;
            _ptx.SaveChanges();
            return thePetType;
        }

        public PetType DeletePetType(PetType petTypeForDeletion)
        {
            var pets = _ptx.Pets.Where(p => p.PetType == petTypeForDeletion);
            _ptx.RemoveRange(pets);
            var deleteType = _ptx.PetTypes.Remove(petTypeForDeletion).Entity;
            _ptx.SaveChanges();
            return deleteType;
        }

        public List<Pet> FindAllPetsByType(PetType theType)
        {
            return _ptx.Pets.Where(p => p.PetType == theType).ToList();
        }

        public List<PetType> FindPetTypeById(int id)
        {
            return _ptx.PetTypes.Where(p => p.IdOfPetTypes == id).ToList();
        }

        public List<PetType> FindPetTypeByName(string petTypeName)
        {
            return _ptx.PetTypes.Where(p => p.NameOfPetTypes.ToLower().Contains(petTypeName.ToLower())).ToList();
        }

        public List<PetType> GetAllPetTypes()
        {
            return _ptx.PetTypes.ToList();
        }

        public PetType UpdatePetType(PetType updatePetType, PetType oldPetType)
        {
            var updateType = _ptx.Update(updatePetType).Entity;
            _ptx.SaveChanges();
            return updateType;
        }
    }
}
