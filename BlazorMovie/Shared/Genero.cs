using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMovie.Shared
{
	public class Genero
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
