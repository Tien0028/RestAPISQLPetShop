using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data
{
    public interface IDBInitializer
    {
        void SeedDB(PetShopApplicationContext ptx);
    }
}
