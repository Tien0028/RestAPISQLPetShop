using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.ApplicationService.Impl
{
    public class PetColorService : IPetColorService
    {
        private IPetColorRepository _petColorRepo;

        public PetColorService(IPetColorRepository petColorRepository)
        {
            _petColorRepo = petColorRepository;
        }

        public PetColor CreatePetColor(PetColor newPetColor)
        {
            return _petColorRepo.CreatePetColor(newPetColor);
        }

        public PetColor DeletePetColor(int id)
        {
            var petColorForDeletion = FindPetColorwithID(id);
            if(petColorForDeletion == null)
            {
                throw new Exception(message: "Id could not be found, moron.");
            }
            return _petColorRepo.DeletePetColor(petColorForDeletion);
        }

        public List<Pet> FindAllPetsByColor(PetColor findPetColor)
        {
            return _petColorRepo.FindAllPetsByColor(findPetColor);
        }

        public PetColor FindPetColorwithID(int id)
        {
            List<PetColor> petColors = _petColorRepo.FindPetColorwithID(id);
            if(petColors.Count != 1)
            {
                return null;
            }
            else
            {
                return petColors[0];
            }
        }

        public PetColor FindPetColorWithIDwithPets(int id)
        {
            List<PetColor> theColors = _petColorRepo.FindPetColorwithID(id);
            if (theColors.Count != 1)
            {
                return null;
            }
            else
            {
                return theColors[0];
            }
        }

        public List<PetColor> FindPetColorWithName(string pcName)
        {
            return _petColorRepo.FindPetColorwithName(pcName);
        }

        public List<PetColor> GetAllPetColors()
        {
            return _petColorRepo.GetAllPetColors();
        }

        public List<PetColor> GetFilteredPetColors(FilterModel filter)
        {
            return _petColorRepo.GetAllPetColors(filter);
        }

        public List<PetColor> SearchForPetColor(FilterModel filter)
        {
            string searchTerm = filter.SearchTerm.ToLower();
            switch (searchTerm)
            {
                case "id":
                    int theID;
                    if(int.TryParse(filter.SearchValue, out theID))
                    {
                        return new List<PetColor> { FindPetColorwithID(theID) };
                    }
                    else
                    {
                        throw new Exception(message: "Mind entering a valid id, bud? Not HARD!");
                    }
                case "name":
                    return _petColorRepo.FindPetColorwithName(filter.SearchValue, filter);
                default:
                    throw new Exception(message: "Searchterm does not compute");
            }
        }

        public PetColor UpdatePetColor(PetColor updatePetColor)
        {
            return _petColorRepo.UpdatePetColor(updatePetColor);
        }
    }
}
