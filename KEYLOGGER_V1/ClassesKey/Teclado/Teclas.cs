/*   Author: Davi Roox
 *  Date  : 19/05/2016
 * 
 *      Objetivo:
 *  Retornar o valor da tecla ou valor + comportamento especifico.
 *  Cada classe representa uma tecla com seu determinado comportamento.
 *
 *  O método GetTecla é virtual,
 *  e pode ser sobrescrevido dependendo do comportamento da tecla.
 *   
 */


using System.Collections.Generic;
using System.Linq;

namespace ClassesKey.Teclado
{

    //repositorio de teclas
    public class Teclas
    {
        // Propriedades
        public IEnumerable<Tecla> FiltroDeTeclas { get; private set; }

        #region Métodos ,GetTeclas, GetTeclaPorCodigo
        // representa a interação entre as teclas (Repositorio de teclas) 
        public Teclas()
        {
            this.InstanciaVetorDeTeclas();
        }

        //Instancia todas as teclas,Caso tenha uma nova tecla adicionar neste vetor
        private void InstanciaVetorDeTeclas()
        {
            FiltroDeTeclas = new Tecla[] {
            new TeclaLWin(),
            new TeclaLControlKey(),
            new TeclaRControlKey(),
            new TeclaLMenu(),
            new TeclaRMenu(),
            new TeclaReturn(),
            new TeclaSpace(),
            new TeclaLShiftKey(),
            new TeclaRShiftKey(),
            new TeclaCapital(),
            new TeclaTab(),
            new TeclaOemtilde(),
            new TeclaEscape(),
            new TeclaBack(),
            new TeclaPrintScreen(),
            new TeclaPause(),
            new TeclaInsert(),
            new TeclaDelete(),
            new TeclaHome(),
            new TeclaPageUp(),
            new TeclaNext(),
            new TeclaEnd(),
            new TeclaApps(),
            new TeclaUp(),
            new TeclaDown(),
            new TeclaRight(),
            new TeclaLeft(),
            new TeclaOemplus(),
            new TeclaOemMinus(),
            new TeclaOem6(),
            new TeclaOem5(),
            new TeclaOem7(),
            new TeclaOemOpenBrackets(),
            new TeclaOem1(),
            new TeclaOemcomma(),
            new TeclaOemPeriod(),
            new TeclaOemQuestion(),
            new TeclaD1(),
            new TeclaD2(),
            new TeclaD3(),
            new TeclaD4(),
            new TeclaD5(),
            new TeclaD6(),
            new TeclaD7(),
            new TeclaD8(),
            new TeclaD9(),
            new TeclaD0(),
            new TeclaF1(),
            new TeclaF2(),
            new TeclaF3(),
            new TeclaF4(),
            new TeclaF5(),
            new TeclaF6(),
            new TeclaF7(),
            new TeclaF8(),
            new TeclaF9(),
            new TeclaF10(),
            new TeclaF11(),
            new TeclaF12()
            };
        }

        //retorna vetor com todas as teclas
        public string[] GetTeclas()
        {
            return FiltroDeTeclas.Select(e => e.nome).ToArray();
        }

        // retorna o valor da tecla de acordo com o código inserido
        //Ex: Codigo = LWin 
        //Retorna    = [Win]
        public string GetTeclaPorCodigo(string codigo)
        {
            return EncontrarPorCodigo(codigo).nome; 
        }

        private Tecla EncontrarPorCodigo(string codigo)
        {
            return FiltroDeTeclas.First(c => c.codigo == codigo);
        }
        #endregion
    }

    #region Teclas com funções especificas (ex: espaço,shift,ctrl...) 
    public class TeclaLWin : Tecla
    {
        public override string codigo { get { return "LWin"; } }
        public override string nome { get { return "[Win]"; } }

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
        public override string nome { get { return "[Ctrl]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRControlKey : Tecla
    {
        public override string codigo { get { return "RControlKey"; } }
        public override string nome { get { return "[Ctrl]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLMenu : Tecla
    {
        public override string codigo { get { return "LMenu"; } }
        public override string nome { get { return "[Alt]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRMenu : Tecla
    {
        public override string codigo { get { return "RMenu"; } }
        public override string nome { get { return "[Alt]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaReturn : Tecla
    {
        // Está tecla representa o precionar do Enter
        public override string codigo { get { return "Return"; } }
        public override string nome { get { return "[Enter]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaSpace : Tecla
    {
        public override string codigo { get { return "Space"; } }
        public override string nome { get { return "[Espaço]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLShiftKey : Tecla
    {
        public override string codigo { get { return "LShiftKey"; } }
        public override string nome { get { return "[Shift]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRShiftKey : Tecla
    {
        public override string codigo { get { return "RShiftKey"; } }
        public override string nome { get { return "[Shift]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //capslock
    public class TeclaCapital : Tecla
    {
        public override string codigo { get { return "Capital"; } }
        public override string nome { get { return "[CapsLock]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaTab : Tecla
    {
        public override string codigo { get { return "Tab"; } }
        public override string nome { get { return "[Tab]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //aspa simples
    public class TeclaOemtilde : Tecla
    {
        public override string codigo { get { return "Oemtilde"; } }
        public override string nome { get { return "'"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaEscape : Tecla
    {
        public override string codigo { get { return "Escape"; } }
        public override string nome { get { return "[Esc]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaBack : Tecla
    {
        public override string codigo { get { return "Back"; } }
        public override string nome { get { return "[BackSpace]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPrintScreen : Tecla
    {
        public override string codigo { get { return "PrintScreen"; } }
        public override string nome { get { return "[Print Screen]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPause : Tecla
    {
        public override string codigo { get { return "Pause"; } }
        public override string nome { get { return "[Pause Break]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaInsert : Tecla
    {
        public override string codigo { get { return "Insert"; } }
        public override string nome { get { return "[Insert]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaDelete : Tecla
    {
        public override string codigo { get { return "Delete"; } }
        public override string nome { get { return "[Delete]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaHome : Tecla
    {
        public override string codigo { get { return "Home"; } }
        public override string nome { get { return "[Home]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaPageUp : Tecla
    {
        public override string codigo { get { return "PageUp"; } }
        public override string nome { get { return "[Page up]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    //PageDown
    public class TeclaNext : Tecla
    {
        public override string codigo { get { return "Next"; } }
        public override string nome { get { return "[Page Down]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaEnd : Tecla
    {
        public override string codigo { get { return "End"; } }
        public override string nome { get { return "[End]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaApps : Tecla
    {
        public override string codigo { get { return "Apps"; } }
        public override string nome { get { return "[Menu]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaUp : Tecla
    {
        public override string codigo { get { return "Up"; } }
        public override string nome { get { return "[Up]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaDown : Tecla
    {
        public override string codigo { get { return "Down"; } }
        public override string nome { get { return "[Down]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaRight : Tecla
    {
        public override string codigo { get { return "Right"; } }
        public override string nome { get { return "[Right]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaLeft : Tecla
    {
        public override string codigo { get { return "Left"; } }
        public override string nome { get { return "[Left]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    #endregion

    #region Teclas Caracteres especiais
    // igual =
    public class TeclaOemplus : Tecla
    {
        public override string codigo { get { return "Oemplus"; } }
        public override string nome { get { return "="; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // menos -
    public class TeclaOemMinus : Tecla
    {
        public override string codigo { get { return "OemMinus"; } }
        public override string nome { get { return "-"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem6 : Tecla
    {
        public override string codigo { get { return "Oem6"; } }
        public override string nome { get { return "["; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem5 : Tecla
    {
        public override string codigo { get { return "Oem5"; } }
        public override string nome { get { return "]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOem7 : Tecla
    {
        public override string codigo { get { return "Oem7"; } }
        public override string nome { get { return "[]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaOemOpenBrackets : Tecla
    {
        public override string codigo { get { return "OemOpenBrackets"; } }
        public override string nome { get { return "´"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // Ç
    public class TeclaOem1 : Tecla
    {
        public override string codigo { get { return "Oem1"; } }
        public override string nome { get { return "ç"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // virgula ,
    public class TeclaOemcomma : Tecla
    {
        public override string codigo { get { return "Oemcomma"; } }
        public override string nome { get { return ","; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // ponto final .
    public class TeclaOemPeriod : Tecla
    {
        public override string codigo { get { return "OemPeriod"; } }
        public override string nome { get { return "."; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    // Ponto e virgula ;
    public class TeclaOemQuestion : Tecla
    {
        public override string codigo { get { return "OemQuestion"; } }
        public override string nome { get { return ";"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    #endregion

    #region Teclas numericas
    public class TeclaD1 : Tecla
    {
        public override string codigo { get { return "D1"; } }
        public override string nome { get { return "1"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD2 : Tecla
    {
        public override string codigo { get { return "D2"; } }
        public override string nome { get { return "2"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD3 : Tecla
    {
        public override string codigo { get { return "D3"; } }
        public override string nome { get { return "3"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD4 : Tecla
    {
        public override string codigo { get { return "D4"; } }
        public override string nome { get { return "4"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD5 : Tecla
    {
        public override string codigo { get { return "D5"; } }
        public override string nome { get { return "5"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD6 : Tecla
    {
        public override string codigo { get { return "D6"; } }
        public override string nome { get { return "6"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD7 : Tecla
    {
        public override string codigo { get { return "D6"; } }
        public override string nome { get { return "6"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD8 : Tecla
    {
        public override string codigo { get { return "D8"; } }
        public override string nome { get { return "8"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD9 : Tecla
    {
        public override string codigo { get { return "D9"; } }
        public override string nome { get { return "9"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaD0 : Tecla
    {
        public override string codigo { get { return "D0"; } }
        public override string nome { get { return "0"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    #endregion

    #region Teclas do F1 ao F12
    public class TeclaF1 : Tecla
    {
        public override string codigo { get { return "F1"; } }
        public override string nome { get { return "[F1]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF2 : Tecla
    {
        public override string codigo { get { return "F2"; } }
        public override string nome { get { return "[F2]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF3 : Tecla
    {
        public override string codigo { get { return "F3"; } }
        public override string nome { get { return "[F3]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF4 : Tecla
    {
        public override string codigo { get { return "F4"; } }
        public override string nome { get { return "[F4]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF5 : Tecla
    {
        public override string codigo { get { return "F5"; } }
        public override string nome { get { return "[F5]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF6 : Tecla
    {
        public override string codigo { get { return "F6"; } }
        public override string nome { get { return "[F6]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF7 : Tecla
    {
        public override string codigo { get { return "F7"; } }
        public override string nome { get { return "[F7]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF8 : Tecla
    {
        public override string codigo { get { return "F8"; } }
        public override string nome { get { return "[F8]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF9 : Tecla
    {
        public override string codigo { get { return "F9"; } }
        public override string nome { get { return "[F9]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF10 : Tecla
    {
        public override string codigo { get { return "F10"; } }
        public override string nome { get { return "[F10]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF11 : Tecla
    {
        public override string codigo { get { return "F11"; } }
        public override string nome { get { return "[F11]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }

    public class TeclaF12 : Tecla
    {
        public override string codigo { get { return "F12"; } }
        public override string nome { get { return "[F12]"; } }

        public override string GetTecla()
        {
            return nome;
        }
    }
    #endregion
}
