using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Core.ApplicationService;
using PetShopApplication.Core.Entities;

namespace PetShopApplicationSolutionRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetColorController : ControllerBase
    {
        IPetColorService _petColorService;

        public PetColorController(IPetColorService petColorService)
        {
            _petColorService = petColorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetColor>> Get([FromQuery] FilterModel filter)
        {
            if(string.IsNullOrEmpty(filter.SearchTerm) && string.IsNullOrEmpty(filter.SearchValue))
            {
                if(filter.CurrentPage == 0 && filter.ItemsOnPage == 0)
                {
                    if (string.IsNullOrEmpty(filter.OrganizeOrder))
                    {
                        try
                        {
                            return Ok(_petColorService.GetAllPetColors());
                        }
                        catch(Exception e)
                        {
                            return NotFound(e.Message);
                        }
                    }
                    else if(filter.OrganizeOrder.ToLower().Equals("asc") || filter.OrganizeOrder.ToLower().Equals("desc"))
                    {
                        try
                        {
                            return Ok(_petColorService.GetFilteredPetColors(filter));
                        }
                        catch(Exception e)
                        {
                            return NotFound(e.Message);
                        }
                    }
                    else
                    {
                        return BadRequest("You need to enter OrganizeOrder asc or desc");
                    }

                }
                else
                {
                    try
                    {
                        return Ok(_petColorService.GetFilteredPetColors(filter));
                    }
                    catch(Exception e)
                    {
                        return NotFound(e.Message);
                    }
                }
            }
            else
            {
                if(string.IsNullOrEmpty(filter.SearchTerm) || string.IsNullOrEmpty(filter.SearchValue))
                {
                    return BadRequest("Enter SearchTerm and SearchValue, NOT THAT HARD!");
                }
                else
                {
                    try
                    {
                        List<PetColor> foundColors = _petColorService.SearchForPetColor(filter);
                        if(foundColors.Count < 1)
                        {
                            return NotFound("No pets with thise colors exist. You probably did something wrong with your life");
                        }
                        else
                        {
                            return Ok(foundColors);
                        }

                    }
                    catch(Exception e)
                    {
                        return NotFound(e.Message);
                    }
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PetColor> Get(int id)
        {
            try
            {
                PetColor color = _petColorService.FindPetColorWithIDwithPets(id);
                if(color == null)
                {
                    return NotFound("There's no color with that id!");
                }
                else
                {
                    return Ok(color);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<PetColor> Post([FromBody] PetColor newPetColor)
        {
            if (string.IsNullOrEmpty(newPetColor.NameOfPetColor))
            {
                return BadRequest("Write a name for a new color. COME ON! Kindergarteners can do this!");
            }
            else
            {
                try
                {
                    return Created("Created this new color", _petColorService.CreatePetColor(newPetColor));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public ActionResult<PetColor> Put(int id, [FromBody] PetColor updatePetColor)
        {
            if (id != updatePetColor.ID || id == 0)
            {
                return BadRequest("Ids must match, and they can't be 0. What are you even doing now!");
            }
            else if (string.IsNullOrEmpty(updatePetColor.NameOfPetColor))
            {
                return BadRequest("Write a name for the updated color, pal!");
            }
            else
            {
                try
                {
                    return Accepted(_petColorService.UpdatePetColor(updatePetColor));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _petColorService.DeletePetColor(id);
                return Accepted($"Successfully deleted this color with the id: {id}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
