using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ListagemContratoWeb.Models;
using ListagemContratoWeb.Repository;

namespace ListagemContratoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ContatosRepository _contatosRepository;
    public ContatosRepository ContatosRepository { get => _contatosRepository; set => _contatosRepository = value; }

    public HomeController(ILogger<HomeController> logger,ContatosRepository contatosRepository)
    {
        _logger = logger;
        _contatosRepository = contatosRepository;
    }

    public IActionResult Index()
    {
        ViewData["DadosCadastrados"] = _contatosRepository.ListarContatos();
        return View();
    }

    public IActionResult Detalhes()
    {
        ViewData["DadosCadastrados"] = _contatosRepository.ListarContatos();
        return View();
    }

    [HttpGet]
    [HttpPost]
    public IActionResult Filtrar()
    {
    if (Request.Method == "POST"){
        DateTime Data;
        if(Request.Form["Data_filtro"] == ""){
            Data = DateTime.MinValue;
        }
        else
        {
            Data = Convert.ToDateTime(Request.Form["Data_filtro"]);
        }
        ViewData["DadosFiltrados"]= _contatosRepository.FiltrarContatos(Data,Request.Form["Nome_filtro"],Request.Form["email_filtro"]);  
        return View();
    }
    else{
        return View();
    }       
    }

    public IActionResult Privacy(string status="")
    {
        ViewData["Status"]=status;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
