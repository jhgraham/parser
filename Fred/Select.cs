using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
	class Select
	{
		public From From {get; set; }

		public Where Where { get; set; }

		public List<String> Attributes { get; set; } = new List<String>();
	}
}
