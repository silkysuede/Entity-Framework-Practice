using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EntityFrameworkLab.Models
{
    public interface ICarRepository
    {
        IEnumerable <Car> Cars { get; }
        void SaveCar(Car car);
        Car DeleteCar(int CarID);
    }
}