using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFictionEngine
{
	public class IFExit
	{
		public IFDirection? direction { get; set; } = null;
		public string customDirection { get; set; } = string.Empty;
		public int roomId { get; set; } = 0;
		public List<string> commands { get; set; } = new List<string>();
	}
}
