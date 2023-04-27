using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using imc.Models;

namespace imc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
     public IActionResult Imc()
    {
        if(HttpMethods.IsPost(Request.Method)){
            double peso = Convert.ToDouble(Request.Form["txtPeso"]);
            double altura = Convert.ToDouble(Request.Form["txtAltura"]);
            double imc =peso / Math.Pow(altura, 2);
           ViewData["imc"] = imc.ToString();
        }
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
