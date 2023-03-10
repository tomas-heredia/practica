using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using practica6.Models;
using practica.Controllers;



namespace practica6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

     public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
        && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
            return RedirectToAction("Index","Usuario"); 
        }else
        {
            return View();
            
        }
    }
    [HttpPost]
    public IActionResult IndexCliente(){
       
            
           
        return RedirectToAction("Cargar","Cliente");
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
