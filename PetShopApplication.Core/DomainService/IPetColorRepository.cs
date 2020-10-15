using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.DomainService
{
    public interface IPetColorRepository
    {
        List<PetColor> GetAllPetColors(FilterModel filter = null);
        List<PetColor> FindPetColorwithID(int id);
        List<PetColor> FindPetColorwithIDwithPets(int id);
        List<PetColor> FindPetColorwithName(string pcName, FilterModel filter = null);
        PetColor CreatePetColor(PetColor newPetColor);
        PetColor DeletePetColor(PetColor deletePetColor);
        PetColor UpdatePetColor(PetColor updatePetColor);
        List<Pet> FindAllPetsByColor(PetColor pcolor, FilterModel filter = null);
        
    }
}
