using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAcessosFila
{
    class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes = new List<Ambiente>();

        public Usuario()
        {
        }

        public Usuario(int id)
        {
            this.id = id;
        }

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        internal List<Ambiente> Ambientes { get => ambientes; set => ambientes = value; }

        public bool concederPermissao(Ambiente ambiente)
        {
            if (this.ambientes.Contains(ambiente))
                return false;
            else
            {
                this.ambientes.Add(ambiente);
                return true;
            }
        }

        public bool revogarPermissao(Ambiente ambiente)
        {
            if (this.ambientes.Contains(ambiente))
            {
                this.ambientes.Remove(ambiente);
                return true;
            }

            else
                return false;
        }
    }
}
