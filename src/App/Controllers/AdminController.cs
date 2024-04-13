using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MakVoj.Models;

namespace MakVoj.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult AdminHome()
    {
        return View();
    }
    
    public IActionResult AdminDestinations()
    {
        return View();
    }
    public IActionResult AdminUsers()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}