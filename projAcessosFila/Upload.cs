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
            salvaLogs();
        }

        internal List<Usuario> Listausuario { get => listausuario; set => listausuario = value; }
        internal List<Ambiente> Listaambiente { get => listaambiente; set => listaambiente = value; }

        public void salvaAmbientes()
        {
            foreach (Ambiente a in this.listaambiente)
            {
                string fileName = @"..\..\Ambientes\" + a.Id + ".txt";
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
                string fileName = @"..\..\Usuarios\" + u.Id + ".txt";
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

        public void salvaLogs()
        {
            foreach (Ambiente a in this.listaambiente)
            {
                string path = @"..\..\Ambientes\" + a.Id;
                int cont = 0;
                Directory.CreateDirectory(path);

                foreach(Log l in a.Logs)
                {
                    cont++;
                    string fileName = path + @"\" + cont + ".txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.WriteLine(l.DtAcesso);
                            writer.WriteLine(l.Usuario.Id);
                            writer.WriteLine(l.TipoAcesso);
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


}
