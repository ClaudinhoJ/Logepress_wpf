using Logepress_wpf.Controle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Model
{
    public class Pacientes
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaptador = new SqlDataAdapter();

        public void CarregaDataTable()
        {
            DataTable table = new DataTable();
            DataColumn Carteira = new DataColumn("Carteira", typeof(string));
            DataColumn Nome = new DataColumn("Nome", typeof(string));
            DataColumn CPF = new DataColumn("CPF", typeof(string));
            DataColumn Email = new DataColumn("Email", typeof(string));
            DataColumn Endereco = new DataColumn("Endereco", typeof(string));

            table.Columns.Add(Carteira);
            table.Columns.Add(Nome);
            table.Columns.Add(CPF);
            table.Columns.Add(Email);
            table.Columns.Add(Endereco);

            foreach(DataRow row in table.Rows)
            {

            }
        }

        public void PacientesSelect()
        {
            cmd.CommandText = "SELECT Carteira, Nome, CPF, Email, Endereco FROM PACIENTE";
            //adaptador.SelectCommand = cmd;
            //adaptador.Fill(table);
            try
            {
                //Conectando com o banco
                cmd.Connection = conexao.Conectar();
                //Excecução do comando

                //Desconectando
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
