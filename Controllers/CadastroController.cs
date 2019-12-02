using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using DocumentFormat.OpenXml.Wordprocessing;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TokaBanda.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TokaBanda.Controllers
{
    public partial class CadastroController : Controller
    {

        public string title { get; private set; }
        public object cmd { get; private set; }

        // GET: /<controller>/
        public IActionResult Lista()
        {
            List<Cadastro> lista = new List<Cadastro>();
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Database=tokabanda;Uid=root;Pwd=root;"))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT usuCodi, usuNome,usuSobN, usuDNas, usuGene, usuMail, usuPass, usuEsta, usuCida, usuCEP_, usuLogradouro, usuBair, amiCodi, Foto FROM usuario", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Cadastro p = new Cadastro();
                            p.UsuCodi = reader.GetInt32(0);
                            p.Nome = reader.GetString(1);
                            p.Sobrenome = reader.GetString(2);
                            p.DataDeNascimento = reader.GetDateTime(3);
                            p.Genero = reader.GetString(4);
                            p.Email = reader.GetString(5);
                            p.Senha = reader.GetString(6);
                            p.Estado = reader.GetString(7);
                            p.Cidade = reader.GetString(8);
                            p.CEP = reader.GetString(9);
                            p.Logradouro = reader.GetString(10);
                            p.Bairro = reader.GetString(11);
                           
                            
                            lista.Add(p);
                        }

                    }
                }

            }
            return View(lista);
        }





            public IActionResult ConfirmacaoEmail()
        {
            return View();
        }
     
        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult EntrarLogin()
        {

            return View();
        }
        public IActionResult editar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Salvar([FromForm]Cadastro pessoa)
        {
            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                throw new Exception("Nome Inválido!");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Sobrenome))
            {
                throw new Exception("Sobrenome Inválido!");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Genero))
            {
                throw new Exception("Gênero Inválido!");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Email))
            {
                throw new Exception("Email Inválido!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.Senha))
            {
                throw new Exception("Senha Inválida!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.Estado))
            {
                throw new Exception("Estado Inválido!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.Cidade))
            {
                throw new Exception("Cidade Inválido!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.CEP))
            {
                throw new Exception("CEP Inválido!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.Logradouro))
            {
                throw new Exception("Logradouro Inválido!");

            }

            if (string.IsNullOrWhiteSpace(pessoa.Bairro))
            {
                throw new Exception("Bairro Inválido!");

            }


            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Database=tokabanda;Uid=root;Pwd=root;"))
            {
                conn.Open();

                if (pessoa.UsuCodi == 0)
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO usuario (usuNome, usuSobN, usuDnas, usuGene, usuMail, usuPass, usuEsta, usuCida, usuCEP_, usuLogradouro, usuBair)"
                       + " VALUES (@nome, @sobrenome, @datadenascimento, @genero, @email,@senha,@estado,@cidade,@cep,@logradouro,@bairro)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                        cmd.Parameters.AddWithValue("@sobrenome", pessoa.Sobrenome);
                        cmd.Parameters.AddWithValue("@datadenascimento", pessoa.DataDeNascimento);
                        cmd.Parameters.AddWithValue("@genero", pessoa.Genero);
                        cmd.Parameters.AddWithValue("@email", pessoa.Email);
                        cmd.Parameters.AddWithValue("@senha", pessoa.Senha);
                        cmd.Parameters.AddWithValue("@estado", pessoa.Estado);
                        cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                        cmd.Parameters.AddWithValue("@cep", pessoa.CEP);
                        cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);                       
                        cmd.Parameters.AddWithValue("@bairro", pessoa.Bairro);

                        cmd.ExecuteNonQuery();


                    }
                }

                else
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE pessoa SET  usuEsta=@estado, " +
           "usuCida=@cidade, usuCEP_=@cep, usuLogradouro=@logradouro, usuBair=bairro WHERE usuCodi = @usucodi", conn))
                    {
                      
                        cmd.Parameters.AddWithValue("@estado", pessoa.Estado);
                        cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                        cmd.Parameters.AddWithValue("@cep", pessoa.CEP);
                        cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);
                        cmd.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                        cmd.Parameters.AddWithValue("@usucodi", pessoa.UsuCodi);


                        cmd.ExecuteNonQuery();
                    }



                }


                return View("ConfirmacaoEmail");
            }

        }
    }
}
