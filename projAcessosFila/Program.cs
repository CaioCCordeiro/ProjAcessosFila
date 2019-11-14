using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAcessosFila
{
    class Program
    {
        private Cadastro cad = new Cadastro();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.cad.download();
            int index = 0;

            do
            {
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuario");
                Console.WriteLine("5. Consultar usuario");
                Console.WriteLine("6. Excluir usuario");
                Console.WriteLine("7. Conceder permissão de acesso ao usuario");
                Console.WriteLine("8. Revogar permissão de acesso ao usuario");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs de acesso");

                Console.Write("Insira a opção escolhida: ");
                index = int.Parse(Console.ReadLine());

                switch (index)
                {
                    case 0: break;
                    case 1: program.cadastrarAmbiente(); break;
                    case 2: program.consultarAmbiente(); break;
                    case 3: program.excluirAmbiente(); break;
                    case 4: program.cadastrarUsuario(); break;
                    case 5: program.consultarUsuario(); break;
                    case 6: program.excluirUsuario(); break;
                    case 7: program.permitirAcesso(); break;
                    case 8: program.revogarAcesso(); break;
                    case 9: program.registrarAcesso(); break;
                    case 10: program.consultarLogs(); break;
                    default: Console.WriteLine("Opção inválida"); break;
                }
            } while (index != 0);

            program.cad.upload();
        }

        public void cadastrarAmbiente()
        {
            int id;
            string nome;

            Console.WriteLine("--------CADASTRAR AMBIENTE--------");
            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            this.cad.adicionarAmbiente(new Ambiente(id, nome));

            Console.WriteLine("----------------");
        }

        public void consultarAmbiente()
        {
            int id;

            Console.WriteLine("--------CONSULTAR AMBIENTE--------");
            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------");

            Ambiente pesquisado = this.cad.pesquisarAmbiente(new Ambiente(id));

            if(pesquisado.Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Console.WriteLine("ID: " + pesquisado.Id);
                Console.WriteLine("Nome: " + pesquisado.Nome);
                Console.WriteLine("Número de Logs: " + pesquisado.Logs.Count());
            }

            Console.WriteLine("----------------");
        }

        public void excluirAmbiente()
        {
            int id;

            Console.WriteLine("--------EXCLUIR AMBIENTE--------");
            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());

            if (this.cad.removerAmbiente(new Ambiente(id)))
                Console.WriteLine("Ambiente excluído com sucesso!");
            else
                Console.WriteLine("Erro ao excluir o ambiente");

            Console.WriteLine("----------------");
        }

        public void cadastrarUsuario()
        {
            int id;
            string nome;

            Console.WriteLine("--------CADASTRAR USUÁRIO--------");
            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            this.cad.adicionarUsuario(new Usuario(id, nome));

            Console.WriteLine("----------------");
        }

        public void consultarUsuario()
        {
            int id;

            Console.WriteLine("--------CONSULTAR USUÁRIO--------");
            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------");

            Usuario pesquisado = this.cad.pesquisarUsuario(new Usuario(id));

            if (pesquisado.Id == 0)
                Console.WriteLine("Não foi possível encontrar o usuário pesquisado");
            else
            {
                Console.WriteLine("ID: " + pesquisado.Id);
                Console.WriteLine("Nome: " + pesquisado.Nome);
                Console.WriteLine("Número de Ambientes: " + pesquisado.Ambientes.Count());
            }

            Console.WriteLine("----------------");
        }

        public void excluirUsuario()
        {
            int id;

            Console.WriteLine("--------EXCLUIR USUÁRIO--------");
            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());

            if (this.cad.removerUsuario(new Usuario(id)))
                Console.WriteLine("Usuário excluído com sucesso!");
            else
                Console.WriteLine("Erro ao excluir o usuário");

            Console.WriteLine("----------------");
        }

        public void permitirAcesso()
        {
            int idUsuario, idAmbiente;

            Console.WriteLine("--------PERMITIR ACESSO--------");
            Console.Write("ID do Ambiente: ");
            idAmbiente = int.Parse(Console.ReadLine());

            if (this.cad.pesquisarAmbiente(new Ambiente(idAmbiente)).Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Ambiente paraA = this.cad.pesquisarAmbiente(new Ambiente(idAmbiente));

                do
                {
                    Console.Write("ID do Usuário: ");
                    idUsuario = int.Parse(Console.ReadLine());

                    if (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0)
                        Console.WriteLine("Não foi possível encontrar o usuário pesquisado");
                    else
                    {
                        Usuario paraU = this.cad.pesquisarUsuario(new Usuario(idUsuario));

                        foreach(Usuario u in this.cad.Usuarios)
                        {
                            if (u == paraU)
                            {
                                if (u.concederPermissao(paraA))
                                    Console.WriteLine("Permissão concedida com sucesso!");
                                else
                                    Console.WriteLine("ERRO! Permissão já concedida");

                                break;
                            }
                        }
                    }

                } while (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0);
            }

            Console.WriteLine("----------------");
        }

        public void revogarAcesso()
        {
            int idUsuario, idAmbiente;

            Console.WriteLine("--------REVOGAR ACESSO--------");
            Console.Write("ID do Ambiente: ");
            idAmbiente = int.Parse(Console.ReadLine());

            if (this.cad.pesquisarAmbiente(new Ambiente(idAmbiente)).Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Ambiente paraA = this.cad.pesquisarAmbiente(new Ambiente(idAmbiente));

                do
                {
                    Console.Write("ID do Usuário: ");
                    idUsuario = int.Parse(Console.ReadLine());

                    if (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0)
                        Console.WriteLine("Não foi possível encontrar o usuário pesquisado");
                    else
                    {
                        Usuario paraU = this.cad.pesquisarUsuario(new Usuario(idUsuario));

                        foreach (Usuario u in this.cad.Usuarios)
                        {
                            if (u == paraU)
                            {
                                if (u.revogarPermissao(paraA))
                                    Console.WriteLine("Permissão revogada com sucesso!");
                                else
                                    Console.WriteLine("Esta permissão já não estava concedida");

                                break;
                            }
                        }
                    }

                } while (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0);
            }

            Console.WriteLine("----------------");
        }

        public void registrarAcesso()
        {
            int idUsuario, idAmbiente;

            Console.WriteLine("--------REGISTRAR ACESSO--------");
            Console.Write("ID do Ambiente: ");
            idAmbiente = int.Parse(Console.ReadLine());

            if (this.cad.pesquisarAmbiente(new Ambiente(idAmbiente)).Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Ambiente paraA = this.cad.pesquisarAmbiente(new Ambiente(idAmbiente));

                do
                {
                    Console.Write("ID do Usuário: ");
                    idUsuario = int.Parse(Console.ReadLine());

                    if (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0)
                        Console.WriteLine("Não foi possível encontrar o usuário pesquisado");
                    else
                    {
                        Usuario paraU = this.cad.pesquisarUsuario(new Usuario(idUsuario));

                        bool acesso;
                        if (paraU.Ambientes.Contains(paraA))
                            acesso = true;
                        else
                            acesso = false;

                        Log log = new Log(DateTime.Now, paraU, acesso);

                        foreach (Ambiente a in this.cad.Ambientes)
                        {
                            if (a == paraA)
                            {
                                a.registrarLog(log);
                                break;
                            }
                        }
                    }

                } while (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0);
            }

            Console.WriteLine("----------------");
        }

        public void consultarLogs()
        {
            int id, opcao;

            Console.WriteLine("--------CONSULTAR LOGS--------");
            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());

            if (this.cad.pesquisarAmbiente(new Ambiente(id)).Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Console.WriteLine("Filtrar por: ");
                Console.WriteLine("0. Todos / 1. Autorizados / 2. Negados");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------");

                Ambiente pesquisado = this.cad.pesquisarAmbiente(new Ambiente(id));


                if(opcao == 1)
                    foreach (Log l in pesquisado.Logs)
                    {
                        if (l.TipoAcesso)
                        {
                            Console.WriteLine("Data: " + l.DtAcesso);
                            Console.WriteLine("Usuário: " + l.Usuario.Nome);
                        }
                    }
                else if(opcao == 2)
                    foreach (Log l in pesquisado.Logs)
                    {
                        if (!l.TipoAcesso)
                        {
                            Console.WriteLine("Data: " + l.DtAcesso);
                            Console.WriteLine("Usuário: " + l.Usuario.Nome);
                        }
                    }
                else
                    foreach (Log l in pesquisado.Logs)
                    {
                        Console.WriteLine("Data: " + l.DtAcesso);
                        Console.WriteLine("Usuário: " + l.Usuario.Nome);
                        Console.Write("Tipo de Acesso: ");
                        if (l.TipoAcesso)
                            Console.WriteLine("Autorizado");
                        else
                            Console.WriteLine("Negado");
                    }
            }
        }
    }
}
