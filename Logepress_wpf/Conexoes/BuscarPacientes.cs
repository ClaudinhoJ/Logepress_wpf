using Logepress_wpf.Controle;
using Logepress_wpf.Modelo;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Logepress_wpf.Model
{
    public class BuscarPacientes
    {
        private string _strConn = "Data Source=DESKTOP-5FMEE1N;Initial Catalog=Logepress;Integrated Security=True";
        SqlConnection objConn = null;
        public DataTable table = new DataTable();
        SqlCommand cmd = null;

        public BuscarPacientes()
        {
            string strSQL = @"select Carteira,CPF, Nome_Paciente,Endereco,Dt_Atendimento,Dt_Alta 
                              from Consultas_Andamento left join Paciente on Consultas_Andamento.ID_Paciente = Paciente.ID
                              where Dt_Atendimento >= (convert(date, GETDATE(), 102))";
            objConn = new SqlConnection(_strConn);
            objConn.Open();
            cmd = new SqlCommand(strSQL,objConn);
            //cmd.ExecuteNonQuery();
            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(table);
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
                objConn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
