using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkLab.Models
{
    public class EFCarRepository : ICarRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }

        public void SaveCar(Car car)
        {
            if (car.CarID == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                Car dbEntry = context.Cars.Find(car.CarID);
                if (dbEntry != null)
                {
                    dbEntry.CarMake = car.CarMake;
                    dbEntry.CarModel = car.CarModel;
                    dbEntry.Year = car.Year;
                    dbEntry.Miles = car.Miles;
                    dbEntry.Color = car.Color;
                    dbEntry.Price = car.Price;
                }
            }
            context.SaveChanges();
        }

        public Car DeleteCar(int CarID)
        {
            Car dbEntry = context.Cars.Find(CarID);
            if (dbEntry != null)
            {
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}