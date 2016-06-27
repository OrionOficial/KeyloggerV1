
using System.IO;
namespace KEYLOGGER_V1.Log
{
    public class LogServico:Log
    {
        #region Construtores

        /// <summary>
        ///  Construtor padrão para criação do log
        /// </summary>
        /// <param name="dirLog"> Diretorio de onde se localiza o log</param>
        /// <param name="conteudo"> Conteudo do Log </param>
        public LogServico(string dirLog, string conteudo,string nomeArquivo) 
        {
            _dirLog = dirLog;
            _conteudo = conteudo;
            _arquivo = nomeArquivo;
        }

        /// <summary>
        ///  Construtor auxiliar para utilização dos recursos do log. (excluir, contem)
        /// </summary>
        /// <param name="dirLog">Diretorio de onde se localiza o log</param>
        public LogServico(string dirLog) 
        {
            _dirLog = dirLog;
        }

        #endregion

        #region Metodos auxiliares de Serviço de Log

        /// <summary>
        ///  Atualizar as informações do log.
        /// </summary>
        public void Atualizar()
        {
            if (Contem())
            {
                if (_conteudo != null)
                {
                    StreamWriter SW = File.AppendText(_dirLog);
                    SW.WriteLine(_conteudo);
                    SW.Close();
                }
            }
            else
            {
                CriarNovo();
            }       
        }

        /// <summary>
        ///  Criar um novo log
        /// </summary>
        private void CriarNovo()
        {   
            StreamWriter SW = new StreamWriter(_dirLog+_arquivo, true);
            SW.Write(_conteudo);
            SW.Close();
        }

        /// <summary>
        ///  Excluir um log especifico.
        /// </summary>
        public void Excluir()
        {
            if (!Contem())
                File.Delete(_dirLog);
            
        }
        
        /// <summary>
        ///  Verifica a existência do arquivo de log
        /// </summary>
        public bool Contem() 
        {
            if (File.Exists(_dirLog))
                return true;
            else 
                return false;
            
        }

        #endregion

    }
}
