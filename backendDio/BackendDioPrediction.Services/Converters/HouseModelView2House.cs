using BackendDioPrediction.Models.DbModels;
using BackendDioPrediction.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendDioPrediction.Services.Converters
{
    public class HouseModelView2House
    {
        public HouseModelView2House()
        {

        }

        public static House ConvertViewModelToHouse(HouseModelView hmw)
        {
            return new House(hmw.Price, hmw.Bedrooms, hmw.Bathrooms, hmw.SqftLiving, hmw.SqftLot, hmw.Floors, hmw.View, hmw.Condition, hmw.Grade, hmw.YearBuilt, hmw.YearRenovated, hmw.SqftAbove, hmw.SqftBasement);
        }
    }
}
