using Microsoft.AspNetCore.Mvc;
using StateExample.Models;
using System.Diagnostics;

namespace StateExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? controllerVisitsNumber = HttpContext.Session.GetInt32("Home");
        if (controllerVisitsNumber == null)
        {
            controllerVisitsNumber = 1;
        }
        else
        {
            controllerVisitsNumber++;
        }

        HttpContext.Session.SetInt32("Home", controllerVisitsNumber.Value);

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
