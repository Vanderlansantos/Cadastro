using Cadastro.Shared.Comandos;

namespace Cadastro.Dominio.Comandos.Entrada
{
    public class RegistroPessoaComando:IComandos
    {
       

        public string Nome { get;  set; }
        public string EnderecoEmail { get;  set; }
        public string Documento { get;   set; }
        public string Telefone { get;  set; }

    }
}
