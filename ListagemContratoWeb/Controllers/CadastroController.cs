using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Specialized;
using ListagemContratoWeb.Repository;
using ListagemContratoWeb.Models;
namespace ListagemContratoWeb.Controllers;

public class CadastroController : Controller{

    public ContatosRepository _contatosRepo;

    [ActivatorUtilitiesConstructor] 
    public CadastroController(ContatosRepository contatosRepository)
    {
        _contatosRepo = contatosRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detalhes(int id)
    {
        ViewData["List"] = id;
        ViewData["DadosContato"] = _contatosRepo.InfoContato(id);
        return View();
    }
    public IActionResult Editar(int id,string mensagem="none")
    {
        ViewData["DadosContato"] = _contatosRepo.InfoContato(id);
        ViewData["Mensagem"]=mensagem;
        return View();
    }
    [HttpPost]
    public IActionResult Alterar(){

        string Resposta = Request.Form["NomeUser_form"];
        int Id = Convert.ToInt32(Request.Form["IdUser_form"]);
        var InfoContato = _contatosRepo.InfoContato(Id);
        UsuarioCadastroModel UserModel = new()
        {
            Nome = Request.Form["NomeUser_form"],
            Email = Request.Form["EmailUser_form"],
            Data_Criacao = Convert.ToDateTime(Request.Form["DataUser_form"])
        };
        if (UserModel.Nome=="" || UserModel.Email == ""){
            return RedirectToAction("Editar", new { id = Id, mensagem = "Erro" });
        }
        _contatosRepo.AlterarDados(Id,UserModel);    
        return RedirectToAction("Editar", new { id = Id, mensagem = "Sucesso" });
    }

}