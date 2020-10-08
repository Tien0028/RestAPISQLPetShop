using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
