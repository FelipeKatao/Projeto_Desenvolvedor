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
    public IActionResult Index(string status="")
    {   
        ViewData["Status"]= status;
        return View();
    }
    
    public IActionResult Detalhes(int id)
    {
        ViewData["List"] = id;
        ViewData["DadosContato"] = _contatosRepo.InfoContato(id);
        return View();
    }
    
    [HttpPost]
    [HttpGet]
    public IActionResult Editar(int id,string mensagem="none")
    {
        if(Request.Method == "POST")
        {
            ViewData["DadosContato"] = _contatosRepo.InfoContato(id);
            ViewData["Mensagem"]="Sucesso";

            UsuarioCadastroModel UserModel = new()
            {
            Nome = Request.Form["NomeUser_form"],
            Email = Request.Form["EmailUser_form"],
            Data_Criacao = Convert.ToDateTime(Request.Form["DataUser_form"])
            };
            _contatosRepo.AlterarDados(id,UserModel);
            return View();
        }
        ViewData["DadosContato"] = _contatosRepo.InfoContato(id);
        ViewData["Mensagem"]=mensagem;
        return View();
    }
 
    [HttpPost]
    [HttpGet]
    public IActionResult Adicionar(UsuarioCadastroModel modelo){
        ViewData["IdMaximo"]=_contatosRepo.ObterNumeroContatos()+1;
        if(Request.Method == "POST")
        {
          if (ModelState.IsValid!)
         {
            _contatosRepo.CriarNovoRegistro(Convert.ToInt16(Request.Form["IdUser_form"]),Request.Form["NomeUser_form"],Request.Form["EmailUser_form"],Convert.ToDateTime(Request.Form["DataUser_form"]));
            return View(modelo);
         }
        
        return RedirectToAction("Adicionar");
        }       
        return View();
    }

    public IActionResult AdicionarValor(UsuarioCadastroModel modelo){
         if (ModelState.IsValid!)
         {
            return View(modelo);
         }
        _contatosRepo.CriarNovoRegistro(Convert.ToInt16(Request.Form["IdUser_form"]),Request.Form["NomeUser_form"],Request.Form["EmailUser_form"],Convert.ToDateTime(Request.Form["DataUser_form"]));
        return RedirectToAction("Adicionar");
    }

    public IActionResult ApagarContato(int id){
        _contatosRepo.ApagarRegistro(id);
        return  RedirectToAction("Index",new{status="delete"});
    }

}