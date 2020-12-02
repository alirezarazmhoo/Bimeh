using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bimeh.Models
{
	public class Chats
	{
		public int Id { get; set; }
		public string txtmessage { get; set; }
		public DateTime Time { get; set; }
		public byte Type { get; set; }
		public string CustomerId { get; set; }

	}
}