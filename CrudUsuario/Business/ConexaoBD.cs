using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CrudUsuario.Business
{
    class ConexaoBD
    {
        private MySqlConnection conexao;
        private string dataSource = "datasource=localhost;username=root;password=Nick@slash1;database=db_agenda";

        public ListView listarContatos()
        {
            conexao = new MySqlConnection(dataSource);
            conexao.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "SELECT * FROM contatos ORDER BY id DESC ";

            MySqlDataReader reader = cmd.ExecuteReader();
            ListView lista = new ListView(); 
            while (reader.Read())
            {
                String[] row =
                {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                };

                lista.Items.Add(new ListViewItem(row));    
            }
            return lista;
        }

    }
}
