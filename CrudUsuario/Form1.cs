using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudUsuario.Business;
using MySql.Data.MySqlClient;

namespace CrudUsuario
{
    public partial class Form1 : Form
    {
        private MySqlConnection conexao;
        private string dataSource = "datasource=localhost;username=root;password=Nick@slash1;database=db_agenda";
        private int ?idContatoSelecionado = null;

        public Form1()
        {
            InitializeComponent();

            lst_contatos.View = View.Details;
            lst_contatos.LabelEdit = true;
            lst_contatos.AllowColumnReorder = true;
            lst_contatos.FullRowSelect = true;
            lst_contatos.GridLines = true;

            lst_contatos.Columns.Add("id", 30, HorizontalAlignment.Left);
            lst_contatos.Columns.Add("nome", 150, HorizontalAlignment.Left);
            lst_contatos.Columns.Add("email", 150, HorizontalAlignment.Left);
            lst_contatos.Columns.Add("telefone", 150,  HorizontalAlignment.Left);

            carregaContatos();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            salvarContato();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            apagaRegistro();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apagaRegistro();
        }

        private void lst_contatos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itensSelecionados = lst_contatos.SelectedItems;

            btnExcluir.Visible = true;

            foreach (ListViewItem item in itensSelecionados)
            {
                idContatoSelecionado = Convert.ToInt32(item.SubItems[0].Text);
                txtNome.Text = item.SubItems[1].Text;                
                txtEmail.Text = item.SubItems[2].Text;
                txtTelefone.Text = item.SubItems[3].Text;
            }

        }

        private void carregaContatos()
        {
            try
            {
                // conectar com MySql
                conexao = new MySqlConnection(dataSource);
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "SELECT * FROM contatos ORDER BY id DESC ";


                MySqlDataReader reader = cmd.ExecuteReader();

                lst_contatos.Items.Clear();

                while (reader.Read())
                {
                    String[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    };

                    lst_contatos.Items.Add(new ListViewItem(row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void consultaDb()
        {
            try
            {
                // conectar com MySql
                conexao = new MySqlConnection(dataSource);
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "SELECT * FROM contatos WHERE nome LIKE @query OR email LIKE @query ";
                cmd.Parameters.AddWithValue("@query", "%" + txtBuscar.Text + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                lst_contatos.Items.Clear();

                while (reader.Read())
                {
                    String[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    };

                    lst_contatos.Items.Add(new ListViewItem(row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void salvarContato()
        {   
            if(idContatoSelecionado == null)
            {
                try
                {
                    conexao = new MySqlConnection(dataSource);
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO contatos (nome, email, telefone) VALUES (@nome , @email , @telefone)";

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                    carregaContatos();
                    limpaCampos();
                    MessageBox.Show("Contato salvo com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            } else
            {
                try
                {
                    conexao = new MySqlConnection(dataSource);
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conexao;
                    cmd.CommandText = "UPDATE contatos SET nome=@nome, email=@email, telefone=@telefone WHERE id=@id";
                   
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@id", idContatoSelecionado);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    carregaContatos();
                    limpaCampos();
                    MessageBox.Show("Contato atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }

        }

        private void limpaCampos()
        {
            idContatoSelecionado = null;
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            btnExcluir.Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            consultaDb();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txtNome.Focus();
        }

        private void apagaRegistro()
        {
            try
            {
                DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Ops, atenção!", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    conexao = new MySqlConnection(dataSource);
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM contatos WHERE id=@id";

                    cmd.Parameters.AddWithValue("@id", idContatoSelecionado);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    carregaContatos();
                    limpaCampos();
                    MessageBox.Show("Contato removido com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
