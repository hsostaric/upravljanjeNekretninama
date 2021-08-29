using BackendDioPrediction.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDioPrediction.API.Response
{
    public class Response
    {
        public bool Success { get; set; }
        public List<House> Data { get; set; }

        public Response()
        {
            Data = new List<House>();
        }

        public Response(bool success)
        {
            Success = success;
        }
    }
}
