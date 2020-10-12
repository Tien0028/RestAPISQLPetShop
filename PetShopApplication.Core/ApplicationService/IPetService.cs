using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> ReadPets();
        List<Pet> ListAllPets();
        Pet FindPetById(int id);
        List<Pet> FindPetByName(string searchName);
        Pet NewPet(Pet newPet);
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        void Delete(Pet pet);
        //List<Pet> FilterForPetType(string type);
        List<Pet> Get5CheapestPets();
        List<Pet> sortedPetsByPrice();
        List<Pet> SearchForPet(FilterModel filter);
        List<Pet> GetFilteredPets(FilterModel filter);

    }
}
