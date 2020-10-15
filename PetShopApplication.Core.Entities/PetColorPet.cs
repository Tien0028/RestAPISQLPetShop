using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.Entities
{
    public class PetColorPet
    {
        public int PetColorID { get; set; }
        public PetColor PetColor { get; set; }
        public int PetID { get; set; }
        public Pet Pet { get; set; }
    }
}
