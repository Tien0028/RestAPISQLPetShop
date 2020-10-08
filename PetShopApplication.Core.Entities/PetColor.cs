using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.Entities
{
    public class PetColor
    {
        public int IdOfPetColor { get; set; }
        public string NameOfPetColor { get; set; }
        public List<Pet> PetColors { get; set; }
    }
}
