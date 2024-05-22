using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFEngine
{
	public class IFRoom
	{
		public int RoomId { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<IFExit> Exits { get; set; } = new List<IFExit>();
		public List<IFItem> Items { get; set; } = new List<IFItem>();
	}
}
