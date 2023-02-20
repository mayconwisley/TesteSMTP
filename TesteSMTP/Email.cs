using System.Net;
using System.Net.Mail;

namespace TesteSMTP
{
    public class Email
    {
        private readonly string _smtp;
        private readonly int _porta;
        private readonly string _email;
        private readonly string _senha;
        private readonly bool _ssl;
        private readonly bool _credencial;

        public Email(string smtp, int porta, string email, string senha, bool ssl, bool credencial)
        {
            _smtp = smtp;
            _porta = porta;
            _email = email;
            _senha = senha;
            _ssl = ssl;
            _credencial = credencial;
        }

        public void EnviarEmail(string remente, string destinatario, string assunto, string corpo)
        {
            try
            {

                MailMessage mensage = new(remente, destinatario, assunto, corpo)
                {
                    IsBodyHtml = true
                };

                SmtpClient smtpClient = new()
                {
                    Host = _smtp,
                    Port = _porta,
                    UseDefaultCredentials = _credencial,
                    Credentials = new NetworkCredential(_email, _senha),
                    EnableSsl = _ssl
                };

                smtpClient.Send(mensage);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
