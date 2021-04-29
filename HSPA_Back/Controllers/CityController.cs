using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HSPA_Back.Data;
using HSPA_Back.Models;
using HSPA_Back.Data.Repositories.CityRepository;

namespace HSPA_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase    
    {
        
        private readonly ICityRepository repo;
        private City City { get; set; }

        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }
       
        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            
            return Ok(await repo.GetCitiesAsync());
        }

        // GET: api/Citiy/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<City>> GetCity(int id)
        //{
        //    var city = await repo.(id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return city;
        //}

        // PUT: api/Citiy/5        
        [HttpPut("{id}")]
        public IActionResult PutCity(int id, City city)
        {


            return NoContent();
        }

        // POST: api/City       
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            repo.AddCity(city);
            await repo.SaveAsync();

            return Ok(city);
        }

        // DELETE: api/Citiy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            
            foreach (City item in await repo.GetCitiesAsync())
            {
                if (item.Id == id)
                {
                    this.City = item;
                }
            }
            if (City != null)
            {
                repo.DeleteCity(id);
                await repo.SaveAsync();
                return Ok(this.City);
            }
            else
            {
                return BadRequest();
            }           

            
        }

       
    }
}
