using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MakVoj.Models;

namespace MakVoj.Controllers;

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

    public IActionResult DetailTours()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    //maki added start
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Destinations()
    {
        return View();
    }
    public IActionResult DestinationHotels()
    {
        return View();
    }
    public IActionResult Profile()
    {
        return View();
    }
    public IActionResult Tours()
    {
        return View();
    }
    public IActionResult AboutUs()
    {
        return View();
    }
    //maki added end

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}