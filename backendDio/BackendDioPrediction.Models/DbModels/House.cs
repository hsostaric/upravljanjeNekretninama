using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendDioPrediction.Models.DbModels
{
    public class House
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Price { get; set; }

        public int Bedrooms { get; set; }

        public float Bathrooms { get; set; }

        public int SqftLiving { get; set; }
        public int SqftLot { get; set; }

        public float Floors { get; set; }

        public int View { get; set; }

        public int Condition { get; set; }

        public int Grade { get; set; }

        public int YearBuilt { get; set; }

        public int YearRenovated { get; set; }

        public int SqftAbove { get; set; }

        public int SqftBasement { get; set; }


        public House()
        {

        }

        public House(int price, int bedrooms, float bathrooms, int sqftLiving, int sqftLot, float floors, int view, int condition, int grade, int yearBuilt, int yearRenovated, int sqftAbove, int sqftBasement)
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

        public House(int id, int price, int bedrooms, float bathrooms, int sqftLiving, int sqftLot, float floors, int view, int condition, int grade, int yearBuilt, int yearRenovated, int sqftAbove, int sqftBasement)
        {
            Id = id;
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
