using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextGen.Models;
using NextGen.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace NextGen.Controllers
{
    public class HomeController : Controller
    {
        IPieRepository _pieRepo;
        public HomeController(IPieRepository pieRepo)
        {
            _pieRepo = pieRepo;
        }
        public IActionResult Index()
        {

            //var pies = _pieRepo.GetAllPies().OrderBy(p => p.Name).ToList();
            //var homeVm = new HomeViewModel {

            //    Title = "We",
            //    Pies = pies
            //};
            return View(/*homeVm*/);
        }
    }
}