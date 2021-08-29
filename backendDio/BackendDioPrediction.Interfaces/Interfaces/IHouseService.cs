using BackendDioPrediction.HouseCommon.InputOutput;
using BackendDioPrediction.Models.DbModels;
using BackendDioPrediction.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendDioPrediction.Interfaces.Interfaces
{
    public interface IHouseService
    {
        Task<House> GetHouseByIdAsync(int id);

        Task<IEnumerable<House>> GetAllAsync();

        Task<bool> AddNewHouse(HouseModelView houseViewModel);

        Task<bool> UpdateHouseAsync(int id, HouseModelView houseViewModel);

        Task<bool> DeleteAsync(int id);

        float PredictHousePrice(HouseData houseData);

        Task<List<House>> getFilteredResults(string column, string direction, int page, int size, int donjaGranica, int gornjaGranica);

        Task<int> getNumberOfData(int donjaGranica, int gornjaGranica);
    }
}
