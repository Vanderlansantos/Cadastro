using Cadastro.Shared.Comandos;
using System;

namespace Cadastro.Dominio.Comandos.Entrada
{
    public class EditarPessoaComando:IComandos
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoEmail { get; set; }
        public string Telefone { get; set; }

    }
}

