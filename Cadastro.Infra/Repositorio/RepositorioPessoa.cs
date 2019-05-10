using Cadastro.Dominio.Entidade;
using Cadastro.Dominio.ObjetoDeValor;
using Cadastro.Dominio.Repositorios;
using Cadastro.Infra.Contexto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Infra.Repositorio
{
    public class RepositorioPessoa : IPessoaRepositorio
    {
        private readonly IDb _Db;


        public RepositorioPessoa(IDb db)
        {
            _Db = db;
        }



        public Pessoa BuscarPorId(Guid id)
        {
            using (var con = _Db.GetCon())
            {
                string sql = "Select Id,Nome,Telefone,Email AS Endereco,CPF AS Numero  From Pessoa Where Id= @Id";
                //var BuscarPorId = con.QuerySingleOrDefault<Pessoa>(sql, new { id });
                //return BuscarPorId;


                var item = con.Query<Pessoa, Email, Documento, Pessoa>(sql,
                    (p, e,d) => { p.SetEmail(e); p.SetDocumento(d); return p; },new { id }, splitOn: "Endereco, Numero").First();

                return item;



                //string sql = "Select Id,Nome,Telefone,Email AS Endereco,CPF AS Numero  From Pessoa  Where Id=@id";
                ///*"SELECT  * FROM  Pessoa";*/

                ////var ListaDePessoa = con.Query<Pessoa>(sql);

                //var ListaDePessoa = con.Query<Pessoa, Email, Documento, Pessoa>(sql, (pessoa, email, documento) =>
                //{
                //    pessoa.SetEmail(email);
                //    pessoa.SetDocumento(documento);
                //    return pessoa;
                //}, splitOn: "").ToList();


            }
        }

        public void Deletar(Guid id)
        {
            string sql = "Delete From Pessoa Where Id=@Id";

            using (var con = _Db.GetCon())
            {
                con.Execute(sql, new { id });
            }

        }

        public bool DocumentoExiste(string documento)
        {
            using (var con = _Db.GetCon())
            {
                string sql = " SELECT [CPF] FROM [Pessoa] WHERE CPF = @CPF ";
                int c = con.Query<Pessoa>(sql, new { CPF = documento }).Count();

                return c > 0 ? true : false;
            }
        }

        public void Editar(Pessoa pessoa)
        {
            string sql = @"UPDATE [dbo].[Pessoa]" +
                           " SET Nome=@Nome" +
                           ",Email = @Email " +
                           ",Telefone=@Telefone" +
                           " WHERE Id=@Id ";


            using (var con = _Db.GetCon())
            {


                con.Execute(sql, 
                new {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Email = pessoa.Email.Endereco,
                    Telefone = pessoa.Telefone
                });
            }
        }

        public bool EmailExiste(string email)
        {
            using (var con = _Db.GetCon())
            {
                string sql = " SELECT COUNT(*) FROM [Pessoa] WHERE Email = @Email ";
                return con.QuerySingleOrDefault<int>(sql, new { Email = email }) > 0;
            }
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            using (var con = _Db.GetCon())
            {
                string sql = "Select Id,Nome,Telefone,Email AS Endereco,CPF AS Numero  From Pessoa";
                /*"SELECT  * FROM  Pessoa";*/

                //var ListaDePessoa = con.Query<Pessoa>(sql);

                var ListaDePessoa = con.Query<Pessoa, Email, Documento, Pessoa>(sql, (pessoa, email, documento) =>
                {
                    pessoa.SetEmail(email);
                    pessoa.SetDocumento(documento);
                    return pessoa;
                }, splitOn: "Endereco, Numero").ToList();

                return ListaDePessoa;
            }


        }

        public void Salvar(Pessoa pessoa)
        {
            using (var con = _Db.GetCon())
            {
                string sql = @"Insert Into Pessoa" +
                              "(Id" +
                            ",Nome" +
                            ",Email" +
                            ",CPF" +
                            ",Telefone)" +
                            "VALUES" +
                             "(@Id" +
                            ",@Nome" +
                            ",@Email" +
                            ",@CPF" +
                            ",@Telefone)";
                con.Execute(sql, new
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Email = pessoa.Email.Endereco,
                    CPF = pessoa.Documento.Numero,
                    Telefone = pessoa.Telefone
                });
            }
        }
    }
}
