using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackendDioPrediction.Models.DbModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string path = @"D:\foids\ds\3.semestarHS\diplomski_rad\praktičniRad\programskikod\backendDio\BackendDioPrediction.Models\Context\kc_house_data.csv";
            int i = 0;
            modelBuilder.Entity<House>().Property(e => e.Id).UseIdentityColumn(100, 1);
            List<House> items = File.ReadAllLines(path)
               .Skip(1)
               .Select(line => line.Split(","))
               .Select(house => new House
               {
                   Id = ++i,
                   Price = (int)this.parseToFloat(house[2]),
                   Bedrooms = this.parseToInt(house[3]),
                   Bathrooms = this.parseToFloat(house[4]),
                   SqftLiving = this.parseToInt(house[5]),
                   SqftLot = this.parseToInt(house[6]),
                   Floors = this.parseToFloat(house[7]),
                   View = this.parseToInt(house[9]),
                   Condition = this.parseToInt(house[10]),
                   Grade = this.parseToInt(house[11]),
                   YearBuilt = this.parseToInt(house[14]),
                   YearRenovated = this.parseToInt(house[15]),
                   SqftAbove = this.parseToInt(house[12]),
                   SqftBasement = this.parseToInt(house[13])
               }).ToList();
            modelBuilder.UseIdentityColumns(1, 1).Entity<House>().HasData(items);

        }

        private float parseToFloat(string value)
        {
            return float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatValue) ? floatValue : default(float);
        }

        private int parseToInt(string value)
        {
            return int.TryParse(value, out int intValue) ? intValue : default(int);
        }

        private bool parseToBoolean(string value)
        {
            return int.Parse(value).Equals(0) ? false : true;
        }

    }
}
