using Cadastro.Dominio.ObjetoDeValor;
using Cadastro.Shared.Entidade;

namespace Cadastro.Dominio.Entidade
{
    public  class Pessoa:Entidades
    {
        public Pessoa()
        {

        }
        public Pessoa(string nome, Email email, Documento documento, string telefone)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
            Telefone = telefone;

            

        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Documento Documento { get; private set; }
        public string Telefone { get; private set; }
      


        public void Update(string nome, Email email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public void SetEmail(Email email)
        {
            Email = email;
        }
        public void SetDocumento(Documento documento)
        {
            Documento = documento;
        }
    }
}
