using Logepress_wpf.Controle;
using Logepress_wpf.Model;
using Logepress_wpf.Modelo;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Logepress_wpf
{
    public partial class Index : Window
    {
        private ObservableCollection<Paciente> pac;
        //private DataGridItemsIndex d;

        public Index()
        {
            InitializeComponent();
        }

        private void PesquisarPacientes(object sender, MouseButtonEventArgs e)
        {
            BuscarPacientes p = new BuscarPacientes();
            pac = new ObservableCollection<Paciente>();

            for (int i = 0; i < p.table.Rows.Count; i++)
            {
                pac.Add(new Paciente()
                {
                    Carteira = p.table.Rows[i]["Carteira"].ToString(),
                    CPF = p.table.Rows[i]["CPF"].ToString(),
                    Nome = p.table.Rows[i]["Nome"].ToString(),
                    Endereco = p.table.Rows[i]["Endereco"].ToString()
                });
            }

            GridPacientes.ItemsSource = pac;
        }

        private void PesquisarCarteira(object sender, RoutedEventArgs e)
        {
            BuscarPacientes p = new BuscarPacientes(txtCarteira.Text);
        }

        private void btbCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (((txtCarteira.Text == "") && (txtCpf.Text == "") && (txtNomeCliente.Text == "") && (txtEndereco.Text == "")) ||
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
