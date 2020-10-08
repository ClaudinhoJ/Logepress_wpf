using Logepress_wpf.Controle;
using Logepress_wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Logepress_wpf
{
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }

        private void PesquisarPacientes(object sender, MouseButtonEventArgs e)
        {
            if (TabPacientes.IsSelected == true || TabCadastro.IsSelected == false)
            {
                Pacientes p = new Pacientes();
                
                GridPacientes.DataContext = p.table.DefaultView;
            }
        }

        private void PesquisarCarteira(object sender, RoutedEventArgs e)
        {
            
        }

        private void btbCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (((txtCarteira.Text == "") && (txtCpf.Text == "") && (txtNomeCliente.Text == "") && (txtEmail.Text == "") && (txtEndereco.Text == "")) || 
                    (txtCarteira.Text == "") || (txtCpf.Text == "") || (txtNomeCliente.Text == "") || (txtEndereco.Text == ""))
            {
                MessageBox.Show("Insira todos os dados necessários para o cadastro");
            }
            else
            {
                CadastroPaciente cad = new CadastroPaciente(txtNomeCliente.Text, txtCarteira.Text, txtCpf.Text, txtEmail.Text, txtEndereco.Text);
                MessageBox.Show(cad.mensagem);
            }
        }
    }
}
