using FluentValidator;

namespace Cadastro.Dominio.ObjetoDeValor
{
    public  class Email:Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            new ValidationContract<Email>(this)
                .IsEmail(X => X.Endereco, "Email inválido")
                .IsRequired(x => x.Endereco, "Email Obrigatorio");

        }

        public string Endereco { get; private set; }



    }
}
