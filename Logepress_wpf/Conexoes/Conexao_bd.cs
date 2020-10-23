using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Controle
{
    public class Conexao_bd
    {
        SqlConnection con = new SqlConnection();
        public Conexao_bd()
        {
            con.ConnectionString = "Data Source=DESKTOP-5FMEE1N;Initial Catalog=Logepress;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
