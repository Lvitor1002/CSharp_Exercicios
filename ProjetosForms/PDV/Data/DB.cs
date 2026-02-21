using MySql.Data.MySqlClient;
using System.Data;

namespace PDV.Models
{
    public static class DB
    {
        private static readonly Conexao conexao = new Conexao();

        public static DataTable ExecutarSelect(string sql, params MySqlParameter[] parametros)
        {
            using (var cn = new MySqlConnection(conexao.ConnectionString))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                cn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static void ExecutarComando(string sql, params MySqlParameter[] parametros)
        {
            using (var cn = new MySqlConnection(conexao.ConnectionString))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
