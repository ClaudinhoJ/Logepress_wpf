using Logepress_wpf.Conexao;
using Logepress_wpf.Modelo;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Logepress_wpf
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Usuario> usuario;
        public MainWindow()
        {
            InitializeComponent();
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
                usuario = new ObservableCollection<Usuario>()
                {
                    new Usuario(){
                        User =   user.table.Rows[0]["Usuario"].ToString(),
                        Senha =    user.table.Rows[0]["Senha"].ToString(),
                        Tipo =   (decimal)user.table.Rows[0]["Tipo"],
                        Adm = (bool)user.table.Rows[0]["adm"]}
                };

                if ((user.table.Rows.Count == 1) && (usuario[0].Tipo == 1))
                {
                    AtendimentoMedico at = new AtendimentoMedico();
                    at.Show();
                    Close();
                }
                else if ((user.table.Rows.Count == 1) && (usuario[0].Tipo == 2))
                {
                    Index index = new Index();
                    index.Show();
                    Close();
                }
                else if ((user.table.Rows.Count == 1) && (usuario[0].Adm == true))
                {
                    CadastroUsuario cd = new CadastroUsuario();
                    cd.Show();
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Preencha todos os campos.\nCaso o problema persista contacte o suporte.", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
