using CrudUsuario.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CrudUsuario.Business
{
    class ContatoDao
    {
        private MySqlConnection conexao;
        private string dataSource = "datasource=localhost;username=root;password=Nick@slash1;database=db_agenda";

        public ArrayList buscarContato(string s)
        {

            // conectar com MySql
            conexao = new MySqlConnection(dataSource);
            conexao.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "SELECT * FROM contatos WHERE nome LIKE @query OR email LIKE @query ";
            cmd.Parameters.AddWithValue("@query", "%" + s + "%");

            MySqlDataReader reader = cmd.ExecuteReader();

            ArrayList resultadoBusca = new ArrayList();

            while (reader.Read())
            {
                String[] row =
                {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                };

                resultadoBusca.Add(row);
            }
            conexao.Close();
            return resultadoBusca;
        }

        public void apagarContato(int? idContato)
        {
            conexao = new MySqlConnection(dataSource);
            conexao.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "DELETE FROM contatos WHERE id=@id";

            cmd.Parameters.AddWithValue("@id", idContato);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        public string salvarContato(int? idContato, Contato contato)
        {
            if(idContato == null)
            {
                conexao = new MySqlConnection(dataSource);
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO contatos (nome, email, telefone) VALUES (@nome , @email , @telefone)";

                cmd.Parameters.AddWithValue("@nome", contato.getNome());
                cmd.Parameters.AddWithValue("@email", contato.getEmail());
                cmd.Parameters.AddWithValue("@telefone", contato.getTelefone());
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conexao.Close();

                return "Contato salvo.";
            } else
            {
                conexao = new MySqlConnection(dataSource);
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE contatos SET nome=@nome, email=@email, telefone=@telefone WHERE id=@id";

                cmd.Parameters.AddWithValue("@nome", contato.getNome());
                cmd.Parameters.AddWithValue("@email", contato.getEmail());
                cmd.Parameters.AddWithValue("@telefone", contato.getTelefone());
                cmd.Parameters.AddWithValue("@id", contato.getId());
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conexao.Close();

                return "Contato atualizado.";
            }
        }
    }
}
