using Logepress_wpf.Controle;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Conexoes
{
    public class CadUsuario
    {
        Conexao_bd conexao = new Conexao_bd();
        SqlCommand cmd = new SqlCommand();
        public string mensagem;

        public CadUsuario(string nome, string email, string crm, string usuario, string senha, decimal tipo, bool adm)
        {
            //Comando Sql
            cmd.CommandText = "insert into allUsers values (@nome,@email,@crm,@usuario,@senha,@tipo,@adm);";
            //Parâmetros
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@crm", crm);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@adm", adm);

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
