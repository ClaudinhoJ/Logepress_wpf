using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Conexoes
{
    public class BuscarPrescricao
    {
        private string _strConn = "Data Source=DESKTOP-5FMEE1N;Initial Catalog=Logepress;Integrated Security=True";
        SqlConnection objConn = null;
        public DataTable table = new DataTable();
        SqlCommand cmd = null;

        public BuscarPrescricao(string dt_criacao)
        {
            string strSQL = $"select CRM_Medico, CID, Conteudo, Medicacao from Prescricao_Medica where Dt_Criacao = convert(varchar, '{dt_criacao}', 21)";

            objConn = new SqlConnection(_strConn);
            objConn.Open();
            cmd = new SqlCommand(strSQL, objConn);
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
    }
}
