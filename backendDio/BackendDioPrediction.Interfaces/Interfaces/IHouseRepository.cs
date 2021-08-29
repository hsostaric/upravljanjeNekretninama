using BackendDioPrediction.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendDioPrediction.Interfaces
{
    public interface IHouseRepository
    {
        Task<bool> DeleteAsync(int id);

        Task<House> GetHouseById(int id);

        Task<List<House>> GetAllAsync();

        Task<bool> Save(House house);

        Task<bool> UpdateAsync(int id, House house);

        Task<List<House>> getFilteredResults(string column, string direction, int pageIndex, int pageSize, int donjaGranica, int gornjaGranica);

        Task<int> getConfigurationData(int donjaGranica, int gornjaGranica);


    }
}
