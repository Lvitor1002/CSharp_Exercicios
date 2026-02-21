
using System.Data;
using MySql.Data.MySqlClient;

namespace PDV.Models
{
    public static class FuncoesUteis
    {
        public static DataTable RetornarDataTableFuncionarios(string cbxCargo)
        {
            string sql = $"SELECT * FROM funcionarios ORDER BY nome ASC";
            //if(cbxCargo != "")
            //    sql += $" WHERE cargo = '{cbxCargo}' ORDER BY nome ASC";

            return DB.ExecutarSelect(sql);
        }
        public static DataTable RetornarDataTableClientes(string txtNome, string txtCpf)
        {
            string sql = $@"SELECT 
                        id as Id, 
                        codigo as Código,
                        nome as Nome,
                        cpf as Cpf,
                        valorAberto as 'Em aberto',
                        telefone as Telefone,
                        email as Email,
                        desbloqueado as Desbloqueado,
                        inadiplente as Status,
                        endereco as Endereço,
                        funcionario as Funcionário,
                        imagem as Img,
                        data as Data
                        FROM clientes";
            if(string.IsNullOrEmpty(txtNome))
                sql += $" WHERE nome like '%{txtNome}'";
            if (string.IsNullOrEmpty(txtCpf))
                sql += $" WHERE cargo like '%{txtCpf}'";

            sql += "ORDER BY Nome ASC";

            return DB.ExecutarSelect(sql);
        }

        public static void SalvarFuncionarios(string nome, string cpf, string telefone,string endereco, string cargo, byte[] foto)
        {
            string sql = @"INSERT INTO funcionarios (nome, cpf, telefone, endereco, cargo, data, foto) 
                        VALUES (@nome, @cpf, @telefone, @endereco, @cargo, curDate(), @foto)";

            DB.ExecutarComando(sql,
                new MySqlParameter("@nome", nome),
                new MySqlParameter("@cpf", cpf),
                new MySqlParameter("@telefone", telefone),
                new MySqlParameter("@endereco", endereco),
                new MySqlParameter("@cargo", cargo),
                new MySqlParameter("@foto", foto)
            );
        }
        public static void SalvarCargos(string nome)
        {
            string sql = @"INSERT INTO cargos (nome, data) VALUES (@nome, curDate())";
            DB.ExecutarComando(sql,new MySqlParameter("@nome", nome));
        }

        public static void EditarFuncionarios(int id, string nome, string cpf, string telefone, string endereco, string cargo, byte[] foto = null)
        {
            string sql = $@"UPDATE funcionarios SET 
                                    nome = @nome, 
                                    cpf =  @cpf, 
                                    telefone = @telefone, 
                                    endereco = @endereco, 
                                    cargo = @cargo, 
                                    foto = IFNULL(@foto, foto)
                                    WHERE id = @id";
            /*
                    IFNULL IFNULL(@foto, foto)
            se @foto for null → mantém a foto atual
            se @foto tiver valor → atualiza

            */

            DB.ExecutarComando(sql,
                new MySqlParameter("@id",id),
                new MySqlParameter("@nome", nome),
                new MySqlParameter("@cpf", cpf),
                new MySqlParameter("@telefone", telefone),
                new MySqlParameter("@endereco", endereco),
                new MySqlParameter("@cargo", cargo),
                new MySqlParameter("@foto", foto)
            );
        }
        public static void EditarCargos(int id, string nome)
        {
            string sql = $@"UPDATE cargos SET nome = @nome WHERE id = @id";

            DB.ExecutarComando(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@nome", nome)
            );
        }
        public static void ExcluirFuncionarios(int id)
        {
            string sql = "DELETE FROM funcionarios WHERE id = @id";
            DB.ExecutarComando(sql,new MySqlParameter("@id", id));
        }
        public static void ExcluirCargos(int id)
        {
            string sql = "DELETE FROM cargos WHERE id = @id";
            DB.ExecutarComando(sql, new MySqlParameter("@id", id));
        }
        public static DataTable RetornarDataTableCargos()
        {
            string sql = "SELECT * FROM CARGOS ORDER BY NOME ASC";
            return DB.ExecutarSelect(sql);
        }
        public static void BuscarFuncionariosPorCargo()
        {
            // Implementar a lógica de busca de funcionários conforme necessário
        }
    }
}
