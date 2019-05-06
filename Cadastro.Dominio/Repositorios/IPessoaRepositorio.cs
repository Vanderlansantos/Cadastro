using Cadastro.Dominio.Comandos.Entrada;
using Cadastro.Dominio.Entidade;
using Cadastro.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace Cadastro.Dominio.Repositorios
{
    public  interface IPessoaRepositorio
    {
        void Salvar(Pessoa pessoa);
        IEnumerable<Pessoa> ListarTodos();
        Pessoa BuscarPorId(Guid id);
        void Editar(Pessoa pessoa);
        void Deletar(Guid id);
        bool EmailExiste(string email);
        bool DocumentoExiste(string documento);
    }
}
