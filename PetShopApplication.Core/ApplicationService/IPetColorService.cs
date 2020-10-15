using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.ApplicationService
{
    public interface IPetColorService
    {
        List<PetColor> GetAllPetColors();
        PetColor FindPetColorwithID(int id);
        PetColor FindPetColorWithIDwithPets(int id);
        List<PetColor> FindPetColorWithName(string pcName);
        PetColor CreatePetColor(PetColor newPetColor);
        PetColor DeletePetColor(int id);
        PetColor UpdatePetColor(PetColor updatePetColor);
        List<Pet> FindAllPetsByColor(PetColor findPetColor);
        List<PetColor> SearchForPetColor(FilterModel filter);
        List<PetColor> GetFilteredPetColors(FilterModel filter);
    }
}
