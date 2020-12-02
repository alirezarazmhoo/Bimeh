using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bimeh.Models
{
	public class Issuance
	{
		public int Id { get; set; }
		[DisplayName("قیمت")]
		[Required(ErrorMessage = "قیمت بیمه را وارد کنید")]
		public long Price { get; set; }
		[DisplayName("مدت اعتبار ")]
		[Required(ErrorMessage = "مدت اعتبار بیمه را وارد کنید")]
		public int ValidiDuration { get; set; }
		public InsuranceType InsuranceType { get; set; }
		public int ServiceProviderCenterId { get; set; }
		public ServiceProviderCenters ServiceProviderCenter { get; set; }
		[DisplayName("تصویر")]

		public string ImageUrl { get; set; }
	}
	public enum InsuranceType
	{
		Thirdpartyinsurance,
		Bodyinsurance,
		Travelinsurance,
		Supplementaryinsurance,
		Lifeinsurance,
		Fireinsurance,
		Organizationalfireinsurance
	}
}