using System;
using System.Linq;
using ListagemContratoWeb.Models;
using ListagemContratoWeb.provider;
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
}
