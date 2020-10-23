using Logepress_wpf.Conexao;
using System;
using System.CodeDom;
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

namespace Logepress_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Botao1_Click(object sender, RoutedEventArgs e)
        {
            CadastroUsuario c = new CadastroUsuario();
            c.Show();
            Prescricao p = new Prescricao();
            p.Show();
            Close();
        }

        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidaLogin();
            }
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            ValidaLogin();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            CadastroUsuario c = new CadastroUsuario();
            c.Show();
            Close();
        }

        private void ValidaLogin()
        {
            try
            {
                BuscaUsuario user = new BuscaUsuario(TxtUsuario.Text, TxtSenha.Password);
                if (user.table.Rows.Count == 1)
                {
                    Index index = new Index();
                    index.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("Login ou senha inválidos", "Erro ao entrar", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro, favor contactar o suporte", "ERRO: "+ e, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
