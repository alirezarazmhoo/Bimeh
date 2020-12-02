using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Bimeh.Models
{
	public class ServiceProviderCenters
	{
		public int Id { get; set; }
		[DisplayName("کد نمایندگی")]
		[Required(ErrorMessage = "نام نمایندگی را وارد کنید")]
		public string Name { get; set; }
		[DisplayName("آدرس")]
		[Required(ErrorMessage = "آدرس نمایندگی را وارد کنید")]
		public string Address { get; set; }
		[DisplayName("شماره تماس")]
		[Required(ErrorMessage = "شماره تماس نمایندگی را وارد کنید")]
		public string Telephone { get; set; }
		[DisplayName("دورنگار")]
		public string Fax { get; set; }
		[DisplayName("واقع در استان")]
		[Required]
		public int CityId { get; set; }
		public City City { get; set; }
		[DisplayName("بیمه ارایه دهنده")]
		[Required]
		public int InsuranceId { get; set; }
		public Insurance Insurance { get; set; }
	}
}