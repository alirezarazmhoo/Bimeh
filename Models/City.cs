using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bimeh.Models
{
	public class City
	{
		public int Id { get; set; }
		[DisplayName("نام استان")]
		[Required(ErrorMessage = "نام استان را وارد کنید")]
		public string Name { get; set; }
	}
}