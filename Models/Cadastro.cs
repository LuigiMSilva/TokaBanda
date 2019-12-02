using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokaBanda.Models
{
    public class Cadastro
    {
        public int UsuCodi { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public int Amigo { get; set; }
     
        public string Foto { get; set; }






    }
}
