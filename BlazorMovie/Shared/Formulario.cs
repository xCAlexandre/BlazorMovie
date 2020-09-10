using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BlazorMovie.Shared
{
	public class Formulario1
	{
		[Required]
		public string Titulo { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		public string Sobrenome { get; set; }
		[Required]
		public DateTime? DatadeNascimento { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[MinLength(6)]
		public string Senha { get; set; }
		[Required]

		[MinLength(6)]
		[Compare("Senha")]
		public string ConfirmarSenha { get; set; }
		[Required]
		[Range(typeof(bool), "true", "true")]
		public bool Termos { get; set; }

    }
}
