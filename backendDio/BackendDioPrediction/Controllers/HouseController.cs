using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendDioPrediction.API.Response;
using BackendDioPrediction.HouseCommon.InputOutput;
using BackendDioPrediction.Interfaces.Interfaces;
using BackendDioPrediction.Models.DbModels;
using BackendDioPrediction.ViewModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using Microsoft.ML;

namespace BackendDioPrediction.Controllers
{
    [Route("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        private IHouseService houseService;
        public HouseController(IHouseService _houseService)
        {
            houseService = _houseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHousesAsync(string column, string direction, int page, int size, int donjaGranica = 0, int gornjaGranica = 0)
        {
            List<House> houses = await houseService.getFilteredResults(column, direction, page, size, donjaGranica, gornjaGranica);
            Response response = new Response();
            if (houses.Count > 0 && houses != null)
            {
                response.Success = true;
                response.Data.AddRange(houses);
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Data = new List<House>();
                return BadRequest(response);
            }

        }
        [HttpGet]
        [Route("totalData")]
        public async Task<IActionResult> GetNumberOfTotalData(int donjaGranica = 0, int gornjaGranica = 0)
        {
            return Ok(await houseService.getNumberOfData(donjaGranica, gornjaGranica));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHouseByIdentificatorAsync(int id)
        {
            House house = await houseService.GetHouseByIdAsync(id);
            if (house != null)
            {
                return Ok(house);
            }
            return NotFound();

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHouse(int id, [FromBody] HouseModelView house)
        {
            return await houseService.UpdateHouseAsync(id, house) == true ? Ok(new Response(true)) : NotFound(new Response(false));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            return await houseService.DeleteAsync(id) == true ? Ok(new Response(true)) : NotFound(new Response(false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouseAsync([FromBody] HouseModelView house)
        {

            return await houseService.AddNewHouse(house) == true ? Ok(new Response(true)) : BadRequest(new Response(false));
        }

        [HttpPost]
        [Route("prediction")]
        public IActionResult CreatePredictionForHouse([FromBody] HouseData houseData)
        {
            return Ok(houseService.PredictHousePrice(houseData));
        }

    }
}
