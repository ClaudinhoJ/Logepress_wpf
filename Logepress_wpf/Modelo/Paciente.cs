using Microsoft.VisualBasic;
using System;

namespace Logepress_wpf.Modelo
{
    internal class Paciente
    {
        public string Carteira { get; set; }
        public string Nome { get; set; }
        public string CID { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Data_Atendimento { get; set; }
        public string Data_Criacao_Prescricao { get; set; }
        public string Data_Alta { get; set; }
    }
}