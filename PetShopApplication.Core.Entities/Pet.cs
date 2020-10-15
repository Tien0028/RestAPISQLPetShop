using System;
using System.Collections.Generic;

namespace PetShopApplication.Core.Entities
{
    public class Pet
    {
        public PetType PetType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string previousOwner { get; set; }
        public Owner PetOwner { get; set; }
        public double Price { get; set; }
        public List<PetColorPet> PetColor { get; set; }
    }
}
