using HSPA_Back.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HSPA_Back.Data.Repositories.CityRepository
{
    public class CitySqlDbRepository : ICityRepository
    {
        private readonly AppDBContext context;

        public CitySqlDbRepository(AppDBContext context)
        {
            this.context = context;
        }
        public void AddCity(City city)
        {
            context.Cities.Add(city);
        }

        public void DeleteCity(int cityId)
        {
            City city = context.Cities.Find(cityId);
            context.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await context.Cities.ToListAsync();
        }

        //TODO Move in unit of work
        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
