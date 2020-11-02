using Logepress_wpf.Conexoes;
using Logepress_wpf.Controle;
using Logepress_wpf.Model;
using Logepress_wpf.Modelo;
using MaterialDesignColors.Recommended;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Logepress_wpf
{
    public partial class Index : Window
    {
        private ObservableCollection<Paciente> pac;

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
                    Nome = p.table.Rows[i]["Nome_Paciente"].ToString(),
                    Endereco = p.table.Rows[i]["Endereco"].ToString(),
                    Data_Atendimento = p.table.Rows[i]["Dt_Atendimento"].ToString(),
                    Data_Alta = p.table.Rows[i]["Dt_Alta"].ToString()
                });
            }

            GridPacientes.ItemsSource = pac;
        }

        private void PesquisarCarteira(object sender, RoutedEventArgs e)
        {
            BuscarPacientes p = new BuscarPacientes(txtCarteira.Text);

            if (p.table.Rows != null)
            {
                btnMarcarConsulta.IsEnabled = true;
            }

            pac = new ObservableCollection<Paciente>()
            {
                new Paciente(){
                Carteira = p.table.Rows[0]["Carteira"].ToString(),
                    CPF = p.table.Rows[0]["CPF"].ToString(),
                    Nome = p.table.Rows[0]["Nome"].ToString(),
                    Email = p.table.Rows[0]["Email"].ToString(),
                    Endereco = p.table.Rows[0]["Endereco"].ToString()}
            };
            txtCpf.Text = pac[0].CPF.ToString();
            txtNomeCliente.Text = pac[0].Nome.ToString();
            txtEmail.Text = pac[0].Email.ToString();
            txtEndereco.Text = pac[0].Endereco.ToString();
        }

        private void btnNovoAtendimento_Click(object sender, RoutedEventArgs e)
        {
            if (txtCarteira.Text != null)
            {
                MarcarConsulta mc = new MarcarConsulta(txtCarteira.Text, txtNomeCliente.Text, dtMarcarConsulta.SelectedDate.Value);
                txtCarteira.Text = null;
                txtCpf.Text = null;
                txtEmail.Text = null;
                txtEndereco.Text = null;
                txtNomeCliente.Text = null;
                btnMarcarConsulta.IsEnabled = false;

                MessageBox.Show("Consulta marcada para " + dtMarcarConsulta.SelectedDate.Value);
            }
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
                txtCarteira.Text = null;
                txtCpf.Text = null;
                txtEmail.Text = null;
                txtEndereco.Text = null;
                txtNomeCliente.Text = null;
                MessageBox.Show(cad.mensagem);
            }
        }

        private void refresh_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            refresh.BorderBrush = Brushes.Purple;
        }
    }
}
