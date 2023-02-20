using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            bool ssl = CbSsl.IsChecked.Value;
            bool credencial = CbCredencial.IsChecked.Value;

            Email EnviarEmail = new Email(smtp, porta, email, senha, ssl, credencial);

            try
            {
                EnviarEmail.EnviarEmail(TxtEmailDe.Text.Trim(), TxtEmailPara.Text.Trim(), TxtAssunto.Text.Trim(), TxtMensagem.Text.Trim());
                TxtStatys.Text = "Email enviado com sucesso.";
            }
            catch (Exception ex)
            {
                TxtStatys.Text = ex.Message;
            }
        }
    }
}
