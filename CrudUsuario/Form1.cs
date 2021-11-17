using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudUsuario.Business;
using CrudUsuario.Model;
using MySql.Data.MySqlClient;

namespace CrudUsuario
{
    public partial class Form1 : Form
    {
        private int ?idContatoSelecionado = null;
        private ConexaoBD bd;
        private ContatoDao contatoDao;
        private Contato contato;

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

            carregarContatos();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            salvarContato();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            apagarRegistro();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apagarRegistro();
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

        private void carregarContatos()
        {
            try
            {
                bd = new ConexaoBD();               
                ArrayList listaDeContatos = bd.listarContatos();
                lst_contatos.Items.Clear();
                foreach (String[] item in listaDeContatos)
                {
                    lst_contatos.Items.Add(new ListViewItem(item));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buscarContato(string s)
        {
            try
            {
                contatoDao = new ContatoDao();
                ArrayList listaDeContatos = contatoDao.buscarContato(s);
                lst_contatos.Items.Clear();
                foreach (String[] item in listaDeContatos)
                {
                    lst_contatos.Items.Add(new ListViewItem(item));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void salvarContato()
        { 
            try
            {
                contatoDao = new ContatoDao();
                contato = new Contato(txtNome.Text, txtEmail.Text, txtTelefone.Text);
                string retorno = contatoDao.salvarContato(idContatoSelecionado, contato);                    
                carregarContatos();
                limpaCampos();
                MessageBox.Show(retorno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpaCampos()
        {
            idContatoSelecionado = null;
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            txtBuscar.Text = String.Empty;
            btnExcluir.Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarContato(txtBuscar.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpaCampos();
            carregarContatos();
            txtNome.Focus();
        }

        private void apagarRegistro()
        {
            try
            {
                DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Ops, atenção!", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    contatoDao = new ContatoDao();
                    contatoDao.apagarContato(idContatoSelecionado);
                    carregarContatos();
                    limpaCampos();
                    MessageBox.Show("Contato removido com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
