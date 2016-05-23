/*   Author: Davi Roox
 *  Date  : 19/05/2016
 * 
 *      Objetivo:
 *  Retornar o valor da tecla ou valor + comportamento especifico.
 *  Cada classe representa uma tecla com seu determinado comportamento.
 *  O método GetTecla é virtual,
 *  e pode ser sobrescrevido dependendo do comportamento da tecla.
 *   
 */


using System;

namespace ClassesKey.Teclado
{
    public class Teclas
    {
        // representa a interação entre as teclas (Repositorio de teclas) 
        public Teclas()
        {

        }
    }

    public class TeclaLWin : Tecla
    {
        public override string codigo { get { return "LWin"; } }
        protected override string nome { get { return "[Win]"; } }

        public TeclaLWin()
        {

        }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLControlKey : Tecla
    {
        public override string codigo { get { return "LControlKey"; } }
        protected override string nome { get { return "[Ctrl]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRControlKey : Tecla
    {
        public override string codigo { get { return "RControlKey"; } }
        protected override string nome { get { return "[Ctrl]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLMenu: Tecla
    {
        public override string codigo { get { return "LMenu"; } }
        protected override string nome { get { return "[Alt]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRMenu : Tecla
    {
        public override string codigo { get { return "RMenu"; } }
        protected override string nome { get { return "[Alt]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaReturn : Tecla
    {
        // Está tecla representa o precionar do Enter
        public override string codigo { get { return "Return"; } }
        protected override string nome { get { return "[Enter]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaSpace : Tecla
    {
        public override string codigo { get { return "Space"; } }
        protected override string nome { get { return "[Espaço]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLShiftKey : Tecla
    {
        public override string codigo { get { return "LShiftKey"; } }
        protected override string nome { get { return "[Shift]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRShiftKey : Tecla
    {
        public override string codigo { get { return "RShiftKey"; } }
        protected override string nome { get { return "[Shift]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //capslock
    public class TeclaCapital : Tecla
    {
        public override string codigo { get { return "Capital"; } }
        protected override string nome { get { return "[CapsLock]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaTab : Tecla
    {
        public override string codigo { get { return "Tab"; } }
        protected override string nome { get { return "[Tab]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //aspa simples
    public class TeclaOemtilde : Tecla
    {
        public override string codigo { get { return "Oemtilde"; } }
        protected override string nome { get { return "'"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaEscape : Tecla
    {
        public override string codigo { get { return "Escape"; } }
        protected override string nome { get { return "[Esc]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaBack : Tecla
    {
        public override string codigo { get { return "Back"; } }
        protected override string nome { get { return "[BackSpace]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPrintScreen : Tecla
    {
        public override string codigo { get { return "PrintScreen"; } }
        protected override string nome { get { return "[Print Screen]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPause : Tecla
    {
        public override string codigo { get { return "Pause"; } }
        protected override string nome { get { return "[Pause Break]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaInsert : Tecla
    {
        public override string codigo { get { return "Insert"; } }
        protected override string nome { get { return "[Insert]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaDelete : Tecla
    {
        public override string codigo { get { return "Delete"; } }
        protected override string nome { get { return "[Delete]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaHome : Tecla
    {
        public override string codigo { get { return "Home"; } }
        protected override string nome { get { return "[Home]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPageUp : Tecla
    {
        public override string codigo { get { return "PageUp"; } }
        protected override string nome { get { return "[Page up]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //PageDown
    public class TeclaNext : Tecla
    {
        public override string codigo { get { return "Next"; } }
        protected override string nome { get { return "[Page Down]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaEnd : Tecla
    {
        public override string codigo { get { return "End"; } }
        protected override string nome { get { return "[End]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaApps : Tecla
    {
        public override string codigo { get { return "Apps"; } }
        protected override string nome { get { return "[Menu]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaUp : Tecla
    {
        public override string codigo { get { return "Up"; } }
        protected override string nome { get { return "[Up]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaDown : Tecla
    {
        public override string codigo { get { return "Down"; } }
        protected override string nome { get { return "[Down]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRight : Tecla
    {
        public override string codigo { get { return "Right"; } }
        protected override string nome { get { return "[Right]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLeft : Tecla
    {
        public override string codigo { get { return "Left"; } }
        protected override string nome { get { return "[Left]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // igual =
    public class TeclaOemplus : Tecla
    {
        public override string codigo { get { return "Oemplus"; } }
        protected override string nome { get { return "="; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // menos -
    public class TeclaOemMinus : Tecla
    {
        public override string codigo { get { return "OemMinus"; } }
        protected override string nome { get { return "-"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem6 : Tecla
    {
        public override string codigo { get { return "Oem6"; } }
        protected override string nome { get { return "["; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem5 : Tecla
    {
        public override string codigo { get { return "Oem5"; } }
        protected override string nome { get { return "]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem7 : Tecla
    {
        public override string codigo { get { return "Oem7"; } }
        protected override string nome { get { return "[]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOemOpenBrackets : Tecla
    {
        public override string codigo { get { return "OemOpenBrackets"; } }
        protected override string nome { get { return "´"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // Ç
    public class TeclaOem1 : Tecla
    {
        public override string codigo { get { return "Oem1"; } }
        protected override string nome { get { return "ç"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // virgula ,
    public class TeclaOemcomma : Tecla
    {
        public override string codigo { get { return "Oemcomma"; } }
        protected override string nome { get { return ","; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // ponto final .
    public class TeclaOemPeriod : Tecla
    {
        public override string codigo { get { return "OemPeriod"; } }
        protected override string nome { get { return "."; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // Ponto e virgula ;
    public class TeclaOemQuestion : Tecla
    {
        public override string codigo { get { return "OemQuestion"; } }
        protected override string nome { get { return ";"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD1 : Tecla
    {
        public override string codigo { get { return "D1"; } }
        protected override string nome { get { return "1"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD2 : Tecla
    {
        public override string codigo { get { return "D2"; } }
        protected override string nome { get { return "2"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD3 : Tecla
    {
        public override string codigo { get { return "D3"; } }
        protected override string nome { get { return "3"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD4 : Tecla
    {
        public override string codigo { get { return "D4"; } }
        protected override string nome { get { return "4"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD5 : Tecla
    {
        public override string codigo { get { return "D5"; } }
        protected override string nome { get { return "5"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD6 : Tecla
    {
        public override string codigo { get { return "D6"; } }
        protected override string nome { get { return "6"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD7 : Tecla
    {
        public override string codigo { get { return "D6"; } }
        protected override string nome { get { return "6"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD8 : Tecla
    {
        public override string codigo { get { return "D8"; } }
        protected override string nome { get { return "8"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD9 : Tecla
    {
        public override string codigo { get { return "D9"; } }
        protected override string nome { get { return "9"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD0 : Tecla
    {
        public override string codigo { get { return "D0"; } }
        protected override string nome { get { return "0"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF1 : Tecla
    {
        public override string codigo { get { return "F1"; } }
        protected override string nome { get { return "[F1]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF2 : Tecla
    {
        public override string codigo { get { return "F2"; } }
        protected override string nome { get { return "[F2]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    
    public class TeclaF3 : Tecla
    {
        public override string codigo { get { return "F3"; } }
        protected override string nome { get { return "[F3]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF4 : Tecla
    {
        public override string codigo { get { return "F4"; } }
        protected override string nome { get { return "[F4]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF5 : Tecla
    {
        public override string codigo { get { return "F5"; } }
        protected override string nome { get { return "[F5]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF6 : Tecla
    {
        public override string codigo { get { return "F6"; } }
        protected override string nome { get { return "[F6]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF7 : Tecla
    {
        public override string codigo { get { return "F7"; } }
        protected override string nome { get { return "[F7]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF8 : Tecla
    {
        public override string codigo { get { return "F8"; } }
        protected override string nome { get { return "[F8]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF9 : Tecla
    {
        public override string codigo { get { return "F9"; } }
        protected override string nome { get { return "[F9]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF10 : Tecla
    {
        public override string codigo { get { return "F10"; } }
        protected override string nome { get { return "[F10]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF11 : Tecla
    {
        public override string codigo { get { return "F11"; } }
        protected override string nome { get { return "[F11]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF12 : Tecla
    {
        public override string codigo { get { return "F12"; } }
        protected override string nome { get { return "[F12]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
}
