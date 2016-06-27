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
            var Texto = new Teclado.RepositorioTeclas().GetTeclaPorCodigo(Console.ReadLine());
            Console.WriteLine(Texto);

            Console.ReadKey();
        }
    }
}
