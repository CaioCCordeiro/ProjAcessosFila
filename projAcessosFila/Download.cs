using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projAcessosFila
{
    class Download
    {
        private List<Usuario> listausuario = new List<Usuario>();
        private List<Ambiente> listaambiente = new List<Ambiente>();

        public Download()
        {
            retornaAmbientes();
            retornaUsuarios();
            retornaLogs();
        }

        internal List<Usuario> Listausuario { get => listausuario; set => listausuario = value; }
        internal List<Ambiente> Listaambiente { get => listaambiente; set => listaambiente = value; }

        public void retornaAmbientes()
        {
            string[] arquivos = Directory.GetFiles(@"..\..\Ambientes\");
            int id, qtde;
            string nome;

            Ambiente novo = new Ambiente();

            foreach (string s in arquivos)
            {

                try
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        id = int.Parse(reader.ReadLine());
                        nome = reader.ReadLine();
                        qtde = int.Parse(reader.ReadLine());

                        novo = new Ambiente(id, nome);
                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
                finally
                {
                    listaambiente.Add(novo);
                }
            }
        }

        public void retornaUsuarios()
        {
            string[] arquivos = Directory.GetFiles(@"..\..\Usuarios\");
            int id, qtde;
            int[] idAmbiente;
            string nome;

            Usuario novo = new Usuario();

            foreach(string s in arquivos)
            {

                try
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        id = int.Parse(reader.ReadLine());
                        nome = reader.ReadLine();
                        qtde = int.Parse(reader.ReadLine());
                        idAmbiente = new int[qtde];

                        for(int i = 0; i < qtde; i++)
                        {
                            idAmbiente[i] = int.Parse(reader.ReadLine());
                        }

                        novo = new Usuario(id, nome);

                        foreach(Ambiente a in this.Listaambiente)
                        {
                            foreach(int i in idAmbiente)
                            {
                                if(a.Id == i)
                                {
                                    novo.concederPermissao(a);
                                    break;
                                }
                            }
                        }

                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
                finally
                {
                    listausuario.Add(novo);
                }
            }
        }

        public void retornaLogs()
        {
            foreach(Ambiente a in listaambiente)
            {
                string[] arquivos = Directory.GetFiles(@"..\..\Ambientes\" + a.Id);
                DateTime dtAcesso;
                int idUsuario;
                bool tipoAcesso;

                Log novo = new Log();

                foreach(string s in arquivos)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(s))
                        {
                            dtAcesso = DateTime.Parse(reader.ReadLine());
                            idUsuario = int.Parse(reader.ReadLine());
                            tipoAcesso = bool.Parse(reader.ReadLine());

                            foreach(Usuario u in listausuario)
                            {
                                if(u.Id == idUsuario)
                                {
                                    novo = new Log(dtAcesso, u, tipoAcesso);
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    finally
                    {
                        a.registrarLog(novo);
                    }
                }
            }
        }
    }
}
