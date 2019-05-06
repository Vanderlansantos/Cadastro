using System;

namespace Cadastro.Shared.Entidade
{
    public abstract class Entidades
    {

        public Entidades()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }


        public Guid Id { get;  set; }
        public  DateTime CriadoEm { get;  set; }
    }
}
