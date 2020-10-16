using Logepress_wpf.Controle;
using Logepress_wpf.Modelo;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Logepress_wpf.Model
{
    public class BuscarPacientes: Index
    {
        private string _strConn = "Data Source=DESKTOP-5FMEE1N;Initial Catalog=Logepress;Integrated Security=True";
        SqlConnection objConn = null;
        public DataTable table = new DataTable();
        SqlCommand cmd = null;

        public BuscarPacientes()
        {
            string strSQL = "SELECT Carteira, Nome, CPF, Email, Endereco FROM PACIENTE";
            objConn = new SqlConnection(_strConn);
            objConn.Open();
            cmd = new SqlCommand(strSQL,objConn);
            //cmd.ExecuteNonQuery();
            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(table);
                adapt.Update(table);
                objConn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public BuscarPacientes(string Carteira)
        {
            string strSQL = $"SELECT Carteira, Nome, CPF, Email, Endereco FROM PACIENTE WHERE CARTEIRA = '{Carteira}'";
            objConn = new SqlConnection(_strConn);
            objConn.Open();
            cmd = new SqlCommand(strSQL, objConn);
            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(table);
                txtNomeCliente.Text = table.Columns[1].ToString();
                txtCpf.Text = table.Columns[2].ToString();
                txtEmail.Text = table.Columns[3].ToString();
                txtEndereco.Text = table.Columns[4].ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
