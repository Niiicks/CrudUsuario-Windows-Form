using System;
using System.Collections.Generic;
using System.Text;

namespace CrudUsuario.Model
{
    class Contato
    {
        private int id;
        private string nome;
        private string email;
        private string telefone;

        public Contato(string nome, string email, string telefone)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }

        public string getNome()
        {
            return this.nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        public int getId()
        {
            return this.id;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }

}
