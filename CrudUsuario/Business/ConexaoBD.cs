using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CrudUsuario.Business
{
    class ConexaoBD
    {
        private MySqlConnection conexao;
        private string dataSource = "datasource=localhost;username=root;password=Nick@slash1;database=db_agenda";
        private ArrayList lista = new ArrayList();
        public ConexaoBD()
        {
        }

        public ArrayList listarContatos()
        {
            conexao = new MySqlConnection(dataSource);
            conexao.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "SELECT * FROM contatos ORDER BY id DESC ";

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String[] row =
                {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                };

                lista.Add(row);    
            }
            conexao.Close();
            return lista;
        }

    }
}
