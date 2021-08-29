using BackendDioPrediction.HouseCommon.InputOutput;
using BackendDioPrediction.Interfaces;
using BackendDioPrediction.Interfaces.Interfaces;
using BackendDioPrediction.Models.DbModels;
using BackendDioPrediction.Services.Converters;
using BackendDioPrediction.ViewModels.ViewModels;
using Microsoft.Extensions.ML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendDioPrediction.Services.HouseDatabaseServices
{
    public class HouseService : IHouseService
    {
        private IHouseRepository houseRepository;
        private readonly PredictionEnginePool<HouseData, HouseOutput> predictEnginePool;
        public HouseService(IHouseRepository _houseRepository, PredictionEnginePool<HouseData, HouseOutput> _predictEnginePool)
        {
            houseRepository = _houseRepository;
            predictEnginePool = _predictEnginePool;
        }
        public float PredictHousePrice(HouseData houseData)
        {
            HouseOutput houseOutput = predictEnginePool.Predict(modelName: "HouseValuePredictModel", example: houseData);
            return houseOutput.Score;
        }

        public Task<bool> AddNewHouse(HouseModelView houseViewModel)
        {
            House newHouse = HouseModelView2House.ConvertViewModelToHouse(houseViewModel);

            return houseRepository.Save(newHouse);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await houseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<House>> GetAllAsync()
        {
            return await houseRepository.GetAllAsync();
        }

        public async Task<House> GetHouseByIdAsync(int id)
        {
            return await houseRepository.GetHouseById(id);
        }

        public async Task<bool> UpdateHouseAsync(int id, HouseModelView houseViewModel)
        {
            House houseForUpdate = HouseModelView2House.ConvertViewModelToHouse(houseViewModel);
            return await houseRepository.UpdateAsync(id, houseForUpdate);
        }

        public async Task<List<House>> getFilteredResults(string column, string direction, int page, int size, int donjaGranica, int gornjaGranica)
        {
            return await houseRepository.getFilteredResults(column, direction, page, size, donjaGranica, gornjaGranica);
        }

        public async Task<int> getNumberOfData(int donjaGranica, int gornjaGranica)
        {
            return await houseRepository.getConfigurationData(donjaGranica, gornjaGranica);
        }
    }
}
