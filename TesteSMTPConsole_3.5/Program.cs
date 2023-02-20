using System;
using TesteSMTP;

namespace TesteSMTPConsole_3._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste de SMTP");
            Console.WriteLine("Digite as informacoes do SMTP");

            Console.Write("SMTP: ");
            string smtp = Console.ReadLine();
            Console.Write("Porta: ");
            int porta = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = string.Empty;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                senha += key.KeyChar;
                Console.Write("*");
            }

            Console.WriteLine();
            Console.Write("SSL(S/N): ");
            bool ssl = true;
            if (Console.ReadLine().ToUpper() == "S")
            {
                ssl = true;
            }
            else
            {
                ssl = false;
            }

            Console.Write("Credenciais (S/N): ");
            bool credencial = true;
            if (Console.ReadLine().ToUpper() == "S")
            {
                credencial = true;
            }
            else
            {
                credencial = false;
            }

            Email EnviarEmail = new Email(smtp, porta, email, senha, ssl, credencial);

            try
            {
                Console.Write("Email Destinatario: ");
                string destinatario = Console.ReadLine();
                string assunto = "Teste SMTP";
                string mensagem = "Envio teste SMTP";

                EnviarEmail.EnviarEmail(email, destinatario, assunto, mensagem);
                Console.WriteLine("E-mail enviado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
