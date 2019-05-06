using Cadastro.Shared.Comandos;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
