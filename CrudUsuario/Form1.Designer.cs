
namespace CrudUsuario
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_contatos = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.Novo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(10, 27);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(147, 23);
            this.txtNome.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(10, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(10, 120);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(147, 23);
            this.txtTelefone.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefone";
            // 
            // lst_contatos
            // 
            this.lst_contatos.ContextMenuStrip = this.contextMenuStrip1;
            this.lst_contatos.HideSelection = false;
            this.lst_contatos.Location = new System.Drawing.Point(181, 67);
            this.lst_contatos.MultiSelect = false;
            this.lst_contatos.Name = "lst_contatos";
            this.lst_contatos.ShowItemToolTips = true;
            this.lst_contatos.Size = new System.Drawing.Size(474, 184);
            this.lst_contatos.TabIndex = 7;
            this.lst_contatos.UseCompatibleStateImageBehavior = false;
            this.lst_contatos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lst_contatos_ItemSelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem1.Text = "Excluir";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(181, 27);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Digite um nome ou email para buscar!";
            this.txtBuscar.Size = new System.Drawing.Size(221, 23);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // Novo
            // 
            this.Novo.Location = new System.Drawing.Point(10, 162);
            this.Novo.Name = "Novo";
            this.Novo.Size = new System.Drawing.Size(64, 23);
            this.Novo.TabIndex = 10;
            this.Novo.Text = "Novo";
            this.Novo.UseVisualStyleBackColor = true;
            this.Novo.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.ForeColor = System.Drawing.Color.Firebrick;
            this.btnExcluir.Location = new System.Drawing.Point(10, 192);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(147, 23);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir Contato";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 420);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.Novo);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lst_contatos);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lst_contatos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button Novo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

