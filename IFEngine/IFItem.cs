using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFItem
	{
		public int itemId { get; set; } = 0;
		public string name { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public int quantity { get; set; } = 1;
		public List<IFAction> actions { get; set; } = new List<IFAction>();
	}
}
