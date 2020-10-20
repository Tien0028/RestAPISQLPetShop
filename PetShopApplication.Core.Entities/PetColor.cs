using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.Entities
{
    public class PetColor
    {
        public int ID { get; set; }
        public string NameOfPetColor { get; set; }
        public List<PetColorPet> ColorPets { get; set; }
    }
}
