using System.Data;
using System.Data.SqlClient;

namespace Cadastro.Infra.Contexto
{
    public class SqlServer : IDb
    {
        IDbConnection _Db;

        public void Dispose()
        {
            _Db.Close();
            _Db.Dispose();
        }

        public IDbConnection GetCon()
        {



            //String de conexão com sql Server

            return _Db = new SqlConnection(@"server=(Servidor) database=pessoa; user id=(Usuario); password=(senha);");
            //return _Db = new SqlConnection(@"Data Source=(Servidor); Initial Catalog=pessoa; Integrated Security = SSPI;");

        }
    }
}
