using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Teste");
            Console.Write(new Teclado.TeclaReturn().GetTecla());
            Console.Write("Teste");
            Console.ReadKey();
        }
    }
}
