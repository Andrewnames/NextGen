using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextGen.Models;
using NextGen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NextGen.Controllers
{
    public class HomeController : Controller
    {
        IRepository _mongoRepo;
        public HomeController(IRepository mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }
        public IActionResult Index()
        {

            var injectors = _mongoRepo.GetInjectorRecords();
            DeviceRecord myObj = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<DeviceRecord>(injectors);
            var homeVm = new HomeViewModel
            {

                Title = "Medrad Family",
                Injectors = myObj.models
            };
            return View(homeVm);
        }
    }
}