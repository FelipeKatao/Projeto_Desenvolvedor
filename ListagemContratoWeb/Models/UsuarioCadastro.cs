using System;
using System.ComponentModel.DataAnnotations;

namespace ListagemContratoWeb.Models
{
    public class UsuarioCadastroModel
    {
        [Key]
        public int CadastroId {get;set;}
        public string? Nome {get;set;}
        public string? Email {get;set;}

        public DateTime Data_Criacao {get;set;}
    }
}