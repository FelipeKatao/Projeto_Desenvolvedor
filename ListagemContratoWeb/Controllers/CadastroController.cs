using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ListagemContratoWeb.Models;

namespace ListagemContratoWeb.Controllers;

public class CadastroController : Controller{

    public IActionResult Index()
    {
        ViewData["Titulo"] = "Hello world C#";
        return View();
    }
}