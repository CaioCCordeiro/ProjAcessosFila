using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projAcessosFila
{
    class Delete
    {
        public void deletaUsuario(int id)
        {
            string fileName = @"..\..\Usuarios\" + id + ".txt";

            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        public void deletaAmbiente(int id)
        {
            string path = @"..\..\Ambientes\" + id;
            string fileName = path + ".txt";

            if (File.Exists(fileName))
                File.Delete(fileName);

            if (Directory.Exists(path))
                Directory.Delete(path);
        }
    }
}
