using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly Tdata _Hii;

        public HomeController(Tdata Hii)
        {
            _Hii = Hii;
        }
         

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Mmodel Mode)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _Hii.Patient_Details.Add(Mode);
                _Hii.SaveChanges();
                TempData["hii"] = "Added Successfully";
                return RedirectToAction("Add");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Added" + ex;
                return View();

            }
        }
        public IActionResult Display()
        {
            var a = _Hii.Patient_Details.ToList();
            return View(a);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                var c = _Hii.Patient_Details.Find(Id);
                if (c != null)
                {
                    _Hii.Patient_Details.Remove(c);
                    _Hii.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Display");
        }
        public IActionResult Update(int Id)
        {
            var c = _Hii.Patient_Details.Find(Id);

            return View(c);
        }
        [HttpPost]

        public IActionResult Update(Mmodel Pode)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _Hii.Patient_Details.Update(Pode);
                _Hii.SaveChanges();
                TempData["hii"] = "Updated Successfully";
                return RedirectToAction("Display");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Updated" + ex;
                return View();

            }
        }


    }
}
