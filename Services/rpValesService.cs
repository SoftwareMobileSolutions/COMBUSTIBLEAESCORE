using COMBUSTIBLEAESCORE.Data;
using COMBUSTIBLEAESCORE.Interfaces;
using COMBUSTIBLEAESCORE.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace COMBUSTIBLEAESCORE.Services
{
    public class rpValesService : IrpVales
    {
        public readonly conexion cn;
        public rpValesService(conexion _cn) {
            cn = _cn;
        }

        public async Task<IEnumerable<rpValesCombustibleModel>> getRpValesCombustible(int userid, int companyid, string fini, string ffin)
        {
            IEnumerable<rpValesCombustibleModel> datos = null;
            string comando = "exec comvale_obtenerReportesVales @fini, @ffin, @userid, @companyid";
            var conn = new SqlConnection(cn.Value);
           /* try
            {*/
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    datos = await conn.QueryAsync<rpValesCombustibleModel>(comando, new { fini, ffin, userid, companyid }, commandType: CommandType.Text);
                }
           /* }
            finally
            {*/
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
           // }
            return datos;
        }
    }
}
