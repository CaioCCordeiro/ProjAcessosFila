using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAcessosFila
{
    class Ambiente
    {
        private int id;
        private string nome;
        private Queue<Log> logs;

        public Ambiente()
        {
        }

        public Ambiente(int id)
        {
            this.id = id;
        }

        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Queue<Log> Logs { get => logs; set => logs = value; }

        public void registrarLog(Log log)
        {
            this.logs.Enqueue(log);

            if(this.logs.Count > 100)
            {
                this.logs.Dequeue();
            }
        }
    }
}
