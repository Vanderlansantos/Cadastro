using System;
using System.Data;

namespace Cadastro.Infra.Contexto
{
    public  interface IDb:IDisposable

    {
        IDbConnection GetCon();
    }
}
