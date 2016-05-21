using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesKey.Teclado
{
    class TeclaLWin : Tecla
    {
        public override string codigo { get { return "LWin"; } }
        protected override string nome { get { return "[Win]"; } }

        public TeclaLWin()
        {

        }

        public override string GetTecla()
        {
            return "Tecla " + nome;
        }
    }
}
