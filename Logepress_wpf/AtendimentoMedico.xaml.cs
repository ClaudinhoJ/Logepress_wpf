using Logepress_wpf.Model;
using Logepress_wpf.Modelo;
using Microsoft.AspNetCore.Routing.Template;
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
    /// <summary>
    /// Lógica interna para AtendimentoMedico.xaml
    /// </summary>
    public partial class AtendimentoMedico : Window
    {
        private ObservableCollection<Paciente> pac;

        public AtendimentoMedico()
        {
            InitializeComponent();
        }

        private void PesquisarPacientes(object sender, MouseButtonEventArgs e)
        {
            BuscarPacientes p = new BuscarPacientes(null);
            pac = new ObservableCollection<Paciente>();

            for (int i = 0; i < p.table.Rows.Count; i++)
            {
                pac.Add(new Paciente()
                {
                    Carteira = p.table.Rows[i]["Carteira"].ToString(),
                    Nome = p.table.Rows[i]["Nome"].ToString(),
                    CID = p.table.Rows[i]["CID"].ToString(),
                    Data_Atendimento = p.table.Rows[i]["Dt_Atendimento"].ToString(),
                    Data_Alta = p.table.Rows[i]["Dt_Alta"].ToString()
                });
            }

            GridPacientes.ItemsSource = pac;
        }

        private void btnAtender_Click(object sender, RoutedEventArgs e)
        {
            Prescricao ps = new Prescricao(txtCarteira.Text, 0);
            ps.Show();
            Close();
        }

        private void AbrirPrescricao_Click(object sender, RoutedEventArgs e)
        {
            Prescricao ps = new Prescricao(txtCarteira.Text, 1);
            ps.Show();
            Close();
        }
    }
}