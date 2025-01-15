using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Watosik.Application.Queries.GetWeather;
using Watosik.MVC.Models;

namespace Watosik.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;
    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    /*
    public IActionResult Index()
    {
        return View();
    }
    */
    public async Task<IActionResult> Index(string city = "Warsaw")
    {
        var weather = await _mediator.Send(new GetWeatherQuery(city));
        ViewData["City"] = city;
        return View(weather);
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
        return RedirectToAction("Phonebook", "Phonebook");
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
