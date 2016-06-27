/*
 * Tarefa: Efetua verificações de conexões específicas do projeto. 
 * Autor:  Orion Poseidon
 * Data:   19-05-16
 */

using System;
using System.Runtime.InteropServices;


namespace KEYLOGGER_V1
{
    public class Conexao: Interfaces.IConexao
    {
       

        #region Importação de DLL
        /// <summary>
        ///  Utilizado para a Confirmação da conexão.
        /// </summary>
        /// <param name="Description">.....</param>
        /// <param name="ReservedValue">......</param>
        /// <returns></returns>
        [DllImport("wininet.dll")]

        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);
        #endregion

        #region Metodos de verificar Conexões no sistema
        
        /// <summary>
        ///  verifica a conexão com a internet / Web.
        /// </summary>
        /// <returns> True, caso esteja conectado. </returns>
        public bool conexaoWeb() 
            {
                try
                {
                    int Description;
                    return InternetGetConnectedState(out Description, 0);
                }
                catch
                { return false; }   
            }

        #endregion

    }
}

