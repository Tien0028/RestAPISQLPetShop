using Microsoft.EntityFrameworkCore;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data.Repositories
{
    public class PetColorRepository : IPetColorRepository
    {
        private readonly PetShopApplicationContext _ptx;

        public PetColorRepository(PetShopApplicationContext ptx)
        {
            _ptx = ptx;
        }

        public PetColor CreatePetColor(PetColor newPetColor)
        {
            var petColor = _ptx.Add(newPetColor).Entity;
            _ptx.SaveChanges();
            return petColor;
        }

        public PetColor DeletePetColor(PetColor deletePetColor)
        {
            var deleteColor = _ptx.Remove(deletePetColor).Entity;
            _ptx.SaveChanges();
            return deleteColor;
        }

        public List<Pet> FindAllPetsByColor(PetColor pcolor, FilterModel filter = null)
        {
            List<PetColorPet> coloredPets = _ptx.PetColorPet.Where(p => p.PetColor == pcolor).ToList();
            IEnumerable<Pet> pets = new List<Pet>();
            foreach (var colorpets in coloredPets)
            {
                pets = pets.Concat(new List<Pet> { colorpets.Pet});
            }
            if (filter == null)
            {
                return pets.ToList();
            }
            else
            {
                pets.Skip(filter.CurrentPage - 1 * filter.ItemsOnPage).Take(filter.ItemsOnPage);

                if (string.IsNullOrEmpty(filter.OrganizeOrder))
                {
                    return pets.ToList();
                }
                else if (filter.OrganizeOrder.ToLower().Equals("desc"))
                {
                    return pets.OrderByDescending(p => p.Name).ToList();
                }
                else
                {
                    return pets.OrderBy(p => p.Name).ToList();
                }
            }

        }

        public List<PetColor> FindPetColorwithID(int id)
        {
            return _ptx.PetColors.Where(p => p.IdOfPetColor == id).ToList();
        }

        public List<PetColor> FindPetColorwithIDwithPets(int id)
        {
            return _ptx.PetColors.Include(p => p.ColorPets).Where(p => p.IdOfPetColor == id).ToList();
        }

        public List<PetColor> FindPetColorwithName(string pcName, FilterModel filter)
        {
            if(filter == null)
            {
                return _ptx.PetColors.Where(p => p.NameOfPetColor.ToLower().Contains(pcName.ToLower())).ToList();
            }
            else
            {
                IEnumerable<PetColor> colors = _ptx.PetColors.Where(p => p.NameOfPetColor.ToLower().Contains(pcName.ToLower()))
                    .Skip((filter.CurrentPage - 1) * filter.ItemsOnPage).Take(filter.ItemsOnPage);
                if (string.IsNullOrEmpty(filter.OrganizeOrder))
                {
                    return colors.ToList();
                }
                else if(filter.OrganizeOrder.ToLower().Equals( "desc"))
                {
                    return colors.OrderByDescending(p => p.NameOfPetColor).ToList();
                }
                else
                {
                    return colors.OrderBy(p => p.NameOfPetColor).ToList();
                }
            }
        }

        public List<PetColor> GetAllPetColors(FilterModel filter)
        {
            if(filter == null)
            {
                return _ptx.PetColors.ToList();
            }
            else
            {
                IEnumerable<PetColor> colors = _ptx.PetColors.Skip((filter.CurrentPage - 1) * filter.ItemsOnPage).Take(filter.ItemsOnPage);
                if (string.IsNullOrEmpty(filter.OrganizeOrder))
                {
                    return colors.ToList();
                }
                else if (filter.OrganizeOrder.ToLower().Equals("desc"))
                {
                    return colors.OrderByDescending(p => p.NameOfPetColor).ToList();
                }
                else
                {
                    return colors.OrderBy(p => p.NameOfPetColor).ToList();
                }
            }
        }

        public PetColor UpdatePetColor(PetColor updatePetColor)
        {
            var updatecolor = _ptx.Update(updatePetColor).Entity;
            _ptx.SaveChanges();
            return updatecolor;
        }
    }
}
