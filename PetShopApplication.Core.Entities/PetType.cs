using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.Entities
{
    public class PetType
    {
        public int ID { get; set; }
        public string NameOfPetTypes { get; set; }
        public List<Pet> PetTypes { get; set; }
       
    }
}
