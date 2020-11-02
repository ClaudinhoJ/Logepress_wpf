using System;
using System.Collections.Generic;
using System.Text;

namespace Logepress_wpf.Modelo
{
    public class Usuario
    {
        public string User { get; set; }
        public string Senha { get; set; }
        public decimal Tipo { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public bool Adm { get; set; }
    }
}
