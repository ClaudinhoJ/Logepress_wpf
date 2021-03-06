﻿using Logepress_wpf.Conexoes;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        decimal tipo;
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void CadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rdRecep.IsChecked)
            {
                tipo = 2;
            }

            if ((bool)rdMedico.IsChecked)
            {
                tipo = 1;
            }

            CadUsuario cd = new CadUsuario(txtNome.Text, txtEMail.Text, txtCRM.Text, txtUsuario.Text, txtSenha.Password, tipo, false);
        }
    }
}
