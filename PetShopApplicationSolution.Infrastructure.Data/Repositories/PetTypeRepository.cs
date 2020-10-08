using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public PetType DeletePetType(PetType petTypeForDeletion)
        {
            throw new NotImplementedException();
        }

        public List<Pet> FindAllPetsByType(PetType theType)
        {
            throw new NotImplementedException();
        }

        public List<PetType> FindPetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PetType> FindPetTypeByName(string petTypeName)
        {
            throw new NotImplementedException();
        }

        public List<PetType> GetAllPetTypes()
        {
            //return _ptx.PetTypes;
            return _ptx.PetTypes;
        }

        public PetType UpdatePetType(PetType updatePetType, PetType oldPetType)
        {
            throw new NotImplementedException();
        }
    }
}
