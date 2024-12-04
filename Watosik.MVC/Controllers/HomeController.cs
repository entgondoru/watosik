using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Watosik.MVC.Models;

namespace Watosik.MVC.Controllers;

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

    public IActionResult Account()
    {
        return View();
    }

    public IActionResult Canteen() 
    {
        return Redirect("~/Canteen/Canteen");
    }
    public IActionResult Legislation()
    {
        return Redirect("~/Legislation/Legislation");
    }
    public IActionResult Phonebook()
    {
        return Redirect("~/Phonebook/Phonebook");
    }
    public IActionResult Map()
    {
        return Redirect("~/Map/Map");
    }
    public IActionResult Sport()
    {
        return Redirect("~/Sport/Sport");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
