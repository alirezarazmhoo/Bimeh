using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bimeh.Models
{
	public class Requests
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int IssuanceId { get; set; }
		public Issuance Issuance { get; set; }
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public status Status { get; set; }
	}

	public enum status
	{
		Accept , 
		Waiting , 
		Reject, 
	}

}