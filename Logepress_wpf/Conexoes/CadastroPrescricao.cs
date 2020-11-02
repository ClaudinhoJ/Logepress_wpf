using Logepress_wpf.Controle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Logepress_wpf.Conexoes
{
    public class CadastroPrescricao
    {
        Conexao_bd conexao = new Conexao_bd();
        SqlCommand cmd = new SqlCommand();
        public string mensagem;
        public CadastroPrescricao(string carteira, string crm, string cid, string conteudo, string medicacao)
        {
            //Comando Sql
            cmd.CommandText = $"exec [dbo].[inserir_prescricao] '{carteira}','{crm}','{cid}','{conteudo}','{medicacao}'";

            try
            {
                //Conectando com o banco
                cmd.Connection = conexao.Conectar();
                //Excecução do comando
                cmd.ExecuteNonQuery();
                //Desconectando
                conexao.Desconectar();
                mensagem = "Prescrição Salva";
            }
            catch (Exception ex)
            {
                mensagem = "Erro: " + ex;
            }
        }
    }
}
