using Microsoft.EntityFrameworkCore;
using ListagemContratoWeb.Models;

namespace ListagemContratoWeb.provider{
    public class CadastroContext:DbContext{
        public  CadastroContext(DbContextOptions<CadastroContext> options):base(options)
        {}
        public DbSet<UsuarioCadastroModel> CadastroUsuarios {get;set;}

    }
}