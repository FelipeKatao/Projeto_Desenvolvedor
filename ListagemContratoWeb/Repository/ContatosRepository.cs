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
}
