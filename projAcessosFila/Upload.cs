using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projAcessosFila
{
    class Upload
    {
        private List<Usuario> listausuario;
        private List<Ambiente> listaambiente;

        public Upload(List<Usuario> listausuario, List<Ambiente> listaambiente)
        {
            this.listausuario = listausuario;
            this.listaambiente = listaambiente;

            salvaAmbientes();
            salvaUsuarios();
        }

        internal List<Usuario> Listausuario { get => listausuario; set => listausuario = value; }
        internal List<Ambiente> Listaambiente { get => listaambiente; set => listaambiente = value; }

        public void salvaAmbientes()
        {
            foreach (Ambiente a in this.listaambiente)
            {
                string fileName = @"C:\Users\caioc\source\repos\projAcessosFila\projAcessosFila\Ambientes\" + a.Id + ".txt";
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(a.Id);
                        writer.WriteLine(a.Nome);
                        writer.WriteLine(a.Logs.Count);
                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }

        public void salvaUsuarios()
        {
            foreach (Usuario u in this.listausuario)
            {
                string fileName = @"C:\Users\caioc\source\repos\projAcessosFila\projAcessosFila\Usuarios\" + u.Id + ".txt";
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(u.Id);
                        writer.WriteLine(u.Nome);
                        writer.WriteLine(u.Ambientes.Count);

                        foreach(Ambiente a in u.Ambientes)
                        {
                            writer.WriteLine(a.Id);
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }
    }


}
