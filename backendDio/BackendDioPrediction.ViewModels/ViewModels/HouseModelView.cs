using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendDioPrediction.ViewModels.ViewModels
{
    public class HouseModelView
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("bedrooms")]
        public int Bedrooms { get; set; }

        [JsonProperty("bathrooms")]
        public float Bathrooms { get; set; }

        [JsonProperty("sqftLiving")]
        public int SqftLiving { get; set; }

        [JsonProperty("sqftLot")]
        public int SqftLot { get; set; }

        [JsonProperty("floors")]
        public float Floors { get; set; }

        [JsonProperty("view")]
        public int View { get; set; }

        [JsonProperty("condition")]
        public int Condition { get; set; }

        [JsonProperty("grade")]
        public int Grade { get; set; }

        [JsonProperty("yearBuilt")]
        public int YearBuilt { get; set; }

        [JsonProperty("yearRenovated")]
        public int YearRenovated { get; set; }

        [JsonProperty("sqftAbove")]
        public int SqftAbove { get; set; }

        [JsonProperty("sqftBasement")]
        public int SqftBasement { get; set; }
        public HouseModelView()
        {
        }

        public HouseModelView(int price, int bedrooms, float bathrooms, int sqftLiving, int sqftLot, float floors, int view, int condition, int grade, int yearBuilt, int yearRenovated, int sqftAbove, int sqftBasement)
        {
            Price = price;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            SqftLiving = sqftLiving;
            SqftLot = sqftLot;
            Floors = floors;
            View = view;
            Condition = condition;
            Grade = grade;
            YearBuilt = yearBuilt;
            YearRenovated = yearRenovated;
            SqftAbove = sqftAbove;
            SqftBasement = sqftBasement;
        }
    }
}
