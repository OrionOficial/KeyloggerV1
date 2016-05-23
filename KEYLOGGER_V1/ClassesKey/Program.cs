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
            var VetorTeclas = new Teclado.RepositorioTeclas().GetTeclas();

            VetorTeclas.ToList().ForEach(t => Console.WriteLine(t));

            Console.ReadKey();
        }
    }
}
