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
            var tecla = "LWin";

            Console.WriteLine($"{tecla} = {new Teclado.RepositorioTeclas().GetTeclaPorCodigo(tecla)}");

            Console.ReadKey();
        }
    }
}
