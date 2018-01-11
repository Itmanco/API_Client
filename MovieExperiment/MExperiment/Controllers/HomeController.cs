using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MExperiment.Models;
using Microsoft.AspNetCore.Http;


namespace MExperiment.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

 

        public IActionResult Delete(string objectName)
        {
            return View("Index");            
        }

        public HomeController()
        {
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {  
            return View();
        }


    }
    // [END cloud_storage]
}

