using Logepress_wpf.Controle;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Model
{
    public class CadastroPaciente
    {
        Conexao_bd conexao = new Conexao_bd();
        SqlCommand cmd = new SqlCommand();
        public string mensagem;

        public CadastroPaciente(string nome, string carteira, string cpf, string email, string endereco)
        {
            //Comando Sql
            cmd.CommandText = "insert into [Paciente] values (@carteira, @nome, @cpf, @email, @endereco)";
            //Parâmetros
            cmd.Parameters.AddWithValue("@carteira", carteira);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@endereco", endereco);

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
