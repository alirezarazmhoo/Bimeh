using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bimeh.Models
{
	public class Insurance
	{
		public int Id { get; set; }
		[DisplayName("نام بیمه")]
		[Required(ErrorMessage = "نام بیمه را وارد کنید")]
		public string Name { get; set; }
	}
}