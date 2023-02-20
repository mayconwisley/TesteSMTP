using System;
using System.Windows;

namespace TesteSMTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            string email = TxtEmailDe.Text.Trim();
            string senha = PwdSenha.Password.Trim();
            string smtp = TxtSmtp.Text.Trim();
            int porta = int.Parse(TxtPorta.Text.Trim());

            bool ssl = CbSsl.IsChecked.HasValue;
            bool credencial = CbCredencial.IsChecked.HasValue;

            Email EnviarEmail = new(smtp, porta, email, senha, ssl, credencial);

            try
            {
                string destinatario = TxtEmailPara.Text.Trim();
                string assunto = TxtAssunto.Text.Trim();
                string mensagem = TxtMensagem.Text.Trim();

                EnviarEmail.EnviarEmail(email, destinatario, assunto, mensagem);
                TxtStatys.Text = "Email enviado com sucesso.";
            }
            catch (Exception ex)
            {
                TxtStatys.Text = ex.Message;
            }
        }
    }
}
