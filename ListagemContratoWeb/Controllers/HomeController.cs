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
