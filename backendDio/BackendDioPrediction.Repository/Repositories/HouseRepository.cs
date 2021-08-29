using BackendDioPrediction.Interfaces;
using BackendDioPrediction.Models.DbModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendDioPrediction.Repository.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private ApplicationDbContext context;
        public HouseRepository(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            House house = await this.GetHouseById(id);
            if (house != null)
            {
                try
                {
                    context.Houses.Remove(house);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

            return false;
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await context.Houses.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<House> GetHouseById(int id)
        {
            return await context.Houses.FindAsync(id);
        }

        public async Task<bool> Save(House house)
        {
            try
            {
                await this.context.Houses.AddAsync(house);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdateAsync(int id, House house)
        {
            House pom = await GetHouseById(id);
            if (pom != null)
            {
                try
                {
                    pom.Price = house.Price;
                    pom.Bedrooms = house.Bedrooms;
                    pom.Bathrooms = house.Bathrooms;
                    pom.SqftLiving = house.SqftLiving;
                    pom.SqftLot = house.SqftLot;
                    pom.Floors = house.Floors;
                    pom.View = house.View;
                    pom.Condition = house.Condition;
                    pom.Grade = house.Grade;
                    pom.YearBuilt = house.YearBuilt;
                    pom.YearRenovated = house.YearRenovated;
                    pom.SqftAbove = house.SqftAbove;
                    pom.SqftBasement = house.SqftBasement;
                    context.Houses.Update(pom);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<List<House>> getFilteredResults(string column, string direction, int page, int size, int donjaGranica, int gornjaGranica)
        {
            IEnumerable<House> result = await this.GetAllAsync();
            switch (direction)
            {
                case "asc":
                    result = await getAscSorting(column, result);
                    break;
                case "desc":
                    result = getDescSorting(column, result);
                    break;
            }
            if (donjaGranica > 0 && gornjaGranica > 0)
            {
                if (donjaGranica > gornjaGranica)
                {
                    int pom = 0;
                    pom = gornjaGranica;
                    gornjaGranica = donjaGranica;
                }
                result = result.Where(x => x.Price <= gornjaGranica && x.Price >= donjaGranica);
            }
            else
            {
                if (donjaGranica > 0)
                {
                    result = result.Where(x => x.Price >= donjaGranica);
                }
                if (gornjaGranica > 0)
                {
                    result = result.Where(x => x.Price <= gornjaGranica);
                }

            }

            return result.Skip((page - 1) * size).Take(size).ToList();

        }

        private async Task<IEnumerable<House>> getAscSorting(string column, IEnumerable<House> result)
        {
            if (column.Equals("id"))
            {
                result = await this.GetAllAsync();
            }
            else if (column.Equals("price"))
            {
                result = result.OrderBy(x => x.Price);
            }
            else if (column.Equals("bedrooms"))
            {
                result = result.OrderBy(x => x.Bedrooms);
            }
            else if (column.Equals("bathrooms"))
            {
                result = result.OrderBy(x => x.Bathrooms);
            }
            else if (column.Equals("sqftLot"))
            {
                result = result.OrderBy(x => x.SqftLot);
            }
            else if (column.Equals("condition"))
            {
                result = result.OrderBy(x => x.Condition);
            }
            else if (column.Equals("grade"))
            {
                result = result.OrderBy(x => x.Grade);
            }
            else if (column.Equals("yearBuilt"))
            {
                result = result.OrderBy(x => x.YearBuilt);
            }

            return result;
        }

        private IEnumerable<House> getDescSorting(string column, IEnumerable<House> result)
        {
            if (column.Equals("id"))
            {
                result = result.OrderByDescending(x => x.Id);
            }
            else if (column.Equals("price"))
            {
                result = result.OrderByDescending(x => x.Price);
            }
            else if (column.Equals("bedrooms"))
            {
                result = result.OrderByDescending(x => x.Bedrooms);
            }
            else if (column.Equals("bathrooms"))
            {
                result = result.OrderByDescending(x => x.Bathrooms);
            }
            else if (column.Equals("sqftLot"))
            {
                result = result.OrderByDescending(x => x.SqftLot);
            }
            else if (column.Equals("condition"))
            {
                result = result.OrderByDescending(x => x.Condition);
            }
            else if (column.Equals("grade"))
            {
                result = result.OrderByDescending(x => x.Grade);
            }
            else if (column.Equals("yearBuilt"))
            {
                result = result.OrderByDescending(x => x.YearBuilt);
            }

            return result;
        }

        public async Task<int> getConfigurationData(int donjaGranica, int gornjaGranica)
        {
            IEnumerable<House> result = await GetAllAsync();
            if (donjaGranica > 0 && gornjaGranica > 0)
            {
                if (donjaGranica > gornjaGranica)
                {
                    int pom = 0;
                    pom = gornjaGranica;
                    gornjaGranica = donjaGranica;
                }
                result = result.Where(x => x.Price <= gornjaGranica && x.Price >= donjaGranica);
            }
            else
            {
                if (donjaGranica > 0)
                {
                    result = result.Where(x => x.Price >= donjaGranica);
                }
                if (gornjaGranica > 0)
                {
                    result = result.Where(x => x.Price <= gornjaGranica);
                }

            }
            return result.ToList().Count;
        }
    }
}
