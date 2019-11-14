using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAcessosFila
{
    class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        public Cadastro()
        {
        }

        public void adicionarUsuario(Usuario usuario)
        {
            this.usuarios.Add(usuario);
        }

        public bool removerUsuario(Usuario usuario)
        {
            if(pesquisarUsuario(usuario).Ambientes.Count() == 0)
            {
                if (this.usuarios.Remove(usuario))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Usuario pesquisarUsuario(Usuario usuario)
        {

            return null;
        }

        public void adicionarAmbiente(Ambiente ambiente)
        {
            this.ambientes.Add(ambiente);
        }

        public bool removerAmbiente(Ambiente ambiente)
        {
            if (this.ambientes.Remove(ambiente))
                return true;
            else
                return false;
        }

        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            return null;
        }

        public void upload()
        {

        }

        public void download()
        {

        }
    }
}
