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
            return _Db = new SqlConnection(@"server=scorpion\sqlexpress01; database =pessoa; user id=root; password=123;");
            //return _Db = new SqlConnection(@"server=F-L303; database =Pessoa; user id=sa; password=123;");
            //return _Db = new SqlConnection(@"server=DESKTOP-SFONDKR; database=Pessoa; user id=sa; password=123;");

        }
    }
}
