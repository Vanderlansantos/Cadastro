using Cadastro.Shared.Comandos;
using System;

namespace Cadastro.Dominio.Comandos.Resultados
{
    public class RegistroPessoaResultadoComando : IResultadoComando
    {
        public RegistroPessoaResultadoComando()
        {

        }

        public RegistroPessoaResultadoComando(Guid id, string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get;  set; }
        public string Nome { get; set; }
    }
}
