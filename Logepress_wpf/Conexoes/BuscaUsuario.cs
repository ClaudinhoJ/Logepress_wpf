using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Conexao
{
    public class BuscaUsuario
    {
        private string _strConn = "Data Source=DESKTOP-5FMEE1N;Initial Catalog=Logepress;Integrated Security=True";
        SqlConnection objConn = null;
        public DataTable table = new DataTable();
        SqlCommand cmd = null;

        public BuscaUsuario(string usuario, string senha)
        {
            string strSQL = @"SELECT USUARIO, SENHA, ADM FROM allUsers WHERE USUARIO = '" + usuario + "' AND SENHA = '" + senha +"'";
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
