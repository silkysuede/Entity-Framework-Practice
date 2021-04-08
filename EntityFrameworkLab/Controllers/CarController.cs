using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkLab.Models;
namespace EntityFrameworkLab.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        ICarRepository repository;

        public CarController(ICarRepository repPassedIn)
        {
            repository = repPassedIn;
        }

        public ActionResult InventoryList()
        {
            return View(repository.Cars);
        }

        public ActionResult Edit(int CarID)
        {
            Car car = repository.Cars.FirstOrDefault(p => p.CarID == CarID);
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCar(car);
                TempData["message"] = string.Format("{0} has been saved", car.CarMake);
                return RedirectToAction("InventoryList");
            }
            else
            {
                return View(car);
            }
        }

        public ActionResult Create()
        {
            return View("Edit", new Car());
        }

        public ActionResult Delete(int CarID)
        {
            Car deletedCar = repository.DeleteCar(CarID);
            if (deletedCar != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedCar.CarMake);
            }
            return RedirectToAction("InventoryList");
        }
    }
}