using Logepress_wpf.Controle;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Conexoes
{
    public class MarcarConsulta
    {
        Conexao_bd conexao = new Conexao_bd();
        SqlCommand cmd = new SqlCommand();
        public string mensagem;

        public MarcarConsulta(string carteira, string nome, DateTime data_consulta)
        {
            //Comando Sql
            cmd.CommandText = "exec [dbo].[marcar_consulta] @carteira, @nome, @data";
            //Parâmetros
            cmd.Parameters.AddWithValue("@carteira", carteira);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@data", data_consulta);

            try
            {
                //Conectando com o banco
                cmd.Connection = conexao.Conectar();
                //Excecução do comando
                cmd.ExecuteNonQuery();
                //Desconectando
                conexao.Desconectar();
                mensagem = "Cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                mensagem = "Erro: " + ex;
            }
        }
    }
}
