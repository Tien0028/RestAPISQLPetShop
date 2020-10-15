using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication.Core.Entities
{
    public class FilterModel
    {
        public string SearchValue { get; set; }
        public string SearchTerm { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsOnPage { get; set; }
        public string OrganizeOrder { get; set; }

    }
}
