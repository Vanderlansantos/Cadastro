using Cadastro.Dominio.Comandos.Entrada;
using Cadastro.Dominio.Comandos.Resultados;
using Cadastro.Dominio.Entidade;
using Cadastro.Dominio.ObjetoDeValor;
using Cadastro.Dominio.Repositorios;
using Cadastro.Shared.Comandos;
using FluentValidator;

namespace Cadastro.Dominio.Comandos.Manipuladores
{
    public class RegistroPessoaManipuladorComando:
        Notifiable, IManipuladorComando<RegistroPessoaComando>, IManipuladorComando<EditarPessoaComando>
    {

        private readonly IPessoaRepositorio _pessoaRepositorio;

        public RegistroPessoaManipuladorComando(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public IResultadoComando manipulador(RegistroPessoaComando comando)
        {

            // - 1. Verificar se o CPF e o Email  já existe 

            if (_pessoaRepositorio.DocumentoExiste(comando.Documento) )
                AddNotification("Documento", "Este CPF já está em uso!");
            if (_pessoaRepositorio.EmailExiste(comando.EnderecoEmail))
                AddNotification("Documento", "Este Email já está em uso!");


            // - 2  - Declaras VOs
            var documento = new Documento(
                comando.Documento);
            var email = new Email(
                comando.EnderecoEmail);

            var pessoa = new Pessoa(
                comando.Nome,
                email,
                documento,
                comando.Telefone);
            
            // - 3 Adicionar Notificações

            AddNotifications(documento.Notifications);
            AddNotifications(email.Notifications);
            if (!IsValid())
                return null;

            // - 4 - Salvar no Banco
            if(IsValid())
            _pessoaRepositorio.Salvar(pessoa);


            // - 5 RETORNAR O COMANDO RESULTADO APROPRIADO
            return new RegistroPessoaResultadoComando(pessoa.Id, pessoa.Nome);

        }

        public IResultadoComando manipulador(EditarPessoaComando comando)
        {
            //1 Recuperar Cadastro
            var pessoa = _pessoaRepositorio.BuscarPorId(comando.Id);

            //2 - Caso cliente não existe

            if(pessoa == null)
            {
                AddNotification("Pessoa", "Cadastro não encontrado");
                
            }

            
            //3  - Declaras VOs
            var email = new Email(
                comando.EnderecoEmail);

            var documento = new Documento(
               comando.Documento);

            //4 Atualizar as entidade 


            var update = new Pessoa(
                comando.Nome,
                email,
                documento,
                comando.Telefone);
            pessoa.Update(comando.Nome, email, comando.Telefone);


            //5 Persistir no banco

            if (IsValid())
            {
                _pessoaRepositorio.Editar(pessoa);
            }

            return new RegistroPessoaResultadoComando(pessoa.Id, pessoa.Nome);

        }
    }
}
