using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlazorMovie.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovie.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : Controller
    {

        [HttpGet]
        [Route("List")]
        public IEnumerable<Formulario1> Get()
        {
            List<Formulario1> forms = new List<Formulario1>()
            {
                new Formulario1(){Titulo = "Sr", Nome = "Joao", Sobrenome = "Das Cove",
                    Email = "teste@teste.com", DatadeNascimento = DateTime.Now, Senha="1234567",
                    ConfirmarSenha = "1234567", Termos = true },

                new Formulario1(){Titulo = "Sr", Nome = "Joao2", Sobrenome = "Das Cove2",
                    Email = "teste@teste.com", DatadeNascimento = DateTime.Now, Senha="1234567",
                    ConfirmarSenha = "1234567", Termos = true },
            };

            return forms;
        }


    }
}
