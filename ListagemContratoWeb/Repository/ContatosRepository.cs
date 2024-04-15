using System;
using System.Linq;
using ListagemContratoWeb.Models;
using ListagemContratoWeb.provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ListagemContratoWeb.Repository;

public class ContatosRepository
{
    private readonly CadastroContext _context;
    public ContatosRepository(CadastroContext cadastroContext)
    {
        _context = cadastroContext;
    }

    public List<UsuarioCadastroModel> ListarContatos(){
        return _context.CadastroUsuarios.ToList();
    }

    public List<UsuarioCadastroModel> FiltrarContatos(DateTime Data,string nome="",string Email=""){
       if(Email=="" && nome=="")
       {
        return _context.CadastroUsuarios
        .Where(item =>  item.Data_Criacao == Data).ToList();
       }

       if(Email==""){
         return _context.CadastroUsuarios
        .Where(item => item.Nome.Contains(nome) ||  item.Data_Criacao == Data).ToList();
       }
       
        return _context.CadastroUsuarios
        .Where(item => item.Nome == nome ||  item.Email == Email || item.Data_Criacao == Data).ToList();
    }
    
    public List<UsuarioCadastroModel> InfoContato(int Id){
        return _context.CadastroUsuarios.Where(item => item.CadastroId == Id).ToList();
    }

    public bool AlterarDados(int Id,UsuarioCadastroModel Campos){
        var CamposAlterar = _context.CadastroUsuarios.Find(Id);
        if(CamposAlterar == null){
            return  false;  
        }
        CamposAlterar.Nome = Campos.Nome;
        CamposAlterar.Email = Campos.Email;
        CamposAlterar.Data_Criacao = Campos.Data_Criacao;
        _context.SaveChanges();
        return true;
    } 

    public int ObterNumeroContatos(){
        return _context.CadastroUsuarios.Count();
    }

    public bool CriarNovoRegistro(int id,string NomeUser,string EmailUser,DateTime DataUser){
        var NovoCliente = new UsuarioCadastroModel{
            Nome = NomeUser,
            Email = EmailUser,
            Data_Criacao = DataUser
        };
        _context.CadastroUsuarios.Add(NovoCliente);
        _context.SaveChanges();
        return true;
    }

    public bool ApagarRegistro(int id){
        var ValorParaApagar = _context.CadastroUsuarios.Find(id);
        _context.CadastroUsuarios.Remove(ValorParaApagar);
        _context.SaveChanges();
        return true;

    }
}
