/*
 * Tarefa: Abstração de email. 
 * Autor:  Orion Poseidon
 * Data:   19-05-16
 */
namespace KEYLOGGER_V1.Email
{
    public class Email 
    {
       protected string _login { get; set; }
       protected string _senha { get; set; }
       protected string _remetente { get; set; }
       protected string _destinatario { get; set; }
       protected string _assunto { get; set; }
       protected string _corpo { get; set; }

    }
}
