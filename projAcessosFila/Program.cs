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

            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            this.cad.adicionarAmbiente(new Ambiente(id, nome));
            
        }

        public void consultarAmbiente()
        {
            int id;

            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());

            Ambiente pesquisado = this.cad.pesquisarAmbiente(new Ambiente(id));

            if(pesquisado.Id == 0)
                Console.WriteLine("Não foi possível encontrar o ambiente pesquisado");
            else
            {
                Console.WriteLine("ID do Ambiente: " + pesquisado.Id);
                Console.WriteLine("Nome: " + pesquisado.Nome);
                Console.WriteLine("Número de Logs: " + pesquisado.Logs.Count());
            }
        }

        public void excluirAmbiente()
        {
            int id;

            Console.Write("ID do Ambiente: ");
            id = int.Parse(Console.ReadLine());

            if (this.cad.removerAmbiente(new Ambiente(id)))
                Console.WriteLine("Ambiente excluído com sucesso!");
            else
                Console.WriteLine("Erro ao excluir o ambiente");
        }

        public void cadastrarUsuario()
        {
            int id;
            string nome;

            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            this.cad.adicionarUsuario(new Usuario(id, nome));
        }

        public void consultarUsuario()
        {
            int id;

            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());

            Usuario pesquisado = this.cad.pesquisarUsuario(new Usuario(id));

            if (pesquisado.Id == 0)
                Console.WriteLine("Não foi possível encontrar o usuário pesquisado");
            else
            {
                Console.WriteLine("ID do Usuário: " + pesquisado.Id);
                Console.WriteLine("Nome: " + pesquisado.Nome);
                Console.WriteLine("Número de Ambientes: " + pesquisado.Ambientes.Count());
            }
        }

        public void excluirUsuario()
        {
            int id;

            Console.Write("ID do Usuário: ");
            id = int.Parse(Console.ReadLine());

            if (this.cad.removerUsuario(new Usuario(id)))
                Console.WriteLine("Usuário excluído com sucesso!");
            else
                Console.WriteLine("Erro ao excluir o usuário");
        }

        public void permitirAcesso()
        {
            int idUsuario, idAmbiente;

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
                                u.concederPermissao(paraA);
                                break;
                            }
                        }
                    }

                } while (this.cad.pesquisarUsuario(new Usuario(idUsuario)).Id == 0);
            }

        }

        public void revogarAcesso()
        {

        }

        public void registrarAcesso()
        {

        }

        public void consultarLogs()
        {

        }
    }
}
