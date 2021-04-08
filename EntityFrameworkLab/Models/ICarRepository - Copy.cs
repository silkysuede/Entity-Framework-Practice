using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EntityFrameworkLab.Models
{
    public interface ICarRepository2
    {
        IEnumerable <Car> Cars { get; }
    }
}