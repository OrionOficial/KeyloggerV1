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
            // Teste de teclas
            var Tecla = new Teclado.TeclaLWin();

            Console.WriteLine(Tecla.GetTecla());
            Console.ReadKey();
        }
    }
}
