using Cadastro.Shared.Comandos;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Dominio.Comandos.Entrada
{
    public class RegistroPessoaComando : IComandos
    {


        public string Nome { get; set; }
        [Display(Name = "Email")]
        public string EnderecoEmail { get;  set; }
        [Display(Name ="CPF")]
        public string Documento { get;   set; }
        public string Telefone { get;  set; }

    }
}
