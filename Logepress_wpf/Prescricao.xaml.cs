using Logepress_wpf.Conexoes;
using Logepress_wpf.Model;
using Logepress_wpf.Modelo;
using Saraff.Twain.DS;
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
    /// Lógica interna para Prescricao.xaml
    /// </summary>
    public partial class Prescricao : Window
    {
        private ObservableCollection<Paciente> pac;
        private ObservableCollection<Prescricao_> presc;

        public Prescricao(string carteira, int opcao)
        {
            InitializeComponent();
            if (opcao == 0)
                RetornaNomeCarteira(carteira);
            else
            {
                RetornaNomeCarteira(carteira);
                CarregaComboPrescricao(carteira);
                btnCarregaPresc.Visibility = Visibility.Visible;
                btnSalvar.IsEnabled = false;
                dropData.IsEnabled = true;
            }
        }

        private void RetornaNomeCarteira(string carteira)
        {
            BuscarPacientes bp = new BuscarPacientes(carteira);
            try
            {
                pac = new ObservableCollection<Paciente>()
                {
                new Paciente(){
                    Carteira = bp.table.Rows[0]["Carteira"].ToString(),
                    Nome = bp.table.Rows[0]["Nome"].ToString()}
                };
                txtNome.Text = pac[0].Nome.ToString();
                txtCarteira.Text = pac[0].Carteira.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Carteira Inválida", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CarregaComboPrescricao(string carteira)
        {
            int CarregaCombo = 1;
            try
            {
                BuscarPacientes p = new BuscarPacientes(carteira, CarregaCombo);
                presc = new ObservableCollection<Prescricao_>();

                for (int i = 0; i < p.table.Rows.Count; i++)
                {
                    presc.Add(new Prescricao_()
                    {
                        Data_Criacao_Prescricao = p.table.Rows[i]["Dt_Criacao"].ToString()
                    });
                    dropData.Items.Add(p.table.Rows[i]["Dt_Criacao"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Salvar_Prescricao_Click(object sender, RoutedEventArgs e)
        {
            string medicacao = Medicacao1.Text + ", " + Medicacao2.Text + ", " + Medicacao3.Text + ", " + Medicacao4.Text;

            CadastroPrescricao cdp = new CadastroPrescricao(txtCarteira.Text, txtCRM.Text, txtCID.Text, txtDescricao.Text, medicacao);
            MessageBox.Show(cdp.mensagem, "", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AtendimentoMedico ate = new AtendimentoMedico();
            ate.Show();
        }

        private void btnCarregaPresc_Click(object sender, RoutedEventArgs e)
        {
            BuscarPrescricao bp = new BuscarPrescricao(dropData.SelectedItem.ToString());
            presc = new ObservableCollection<Prescricao_>();

            presc.Add(new Prescricao_()
            {
                CRM = bp.table.Rows[0]["CRM_Medico"].ToString(),
                CID = bp.table.Rows[0]["CID"].ToString(),
                Conteudo = bp.table.Rows[0]["Conteudo"].ToString(),
                Medicacao = bp.table.Rows[0]["Medicacao"].ToString()
            });

            txtCRM.Text = presc[0].CRM.ToString();
            txtCID.Text = presc[0].CID.ToString();
            txtDescricao.Text = presc[0].Conteudo.ToString();
            Medicacao1.Text = presc[0].Medicacao.ToString().Replace(", , , ", "").Replace(", , ", "").Replace(", ", " ");
        }
        //txtNome.Text = pac[0].Nome.ToString();
        //txtCarteira.Text = pac[0].Carteira.ToString();
    }
}

