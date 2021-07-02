using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
	class Join
	{
		public ICategory Category { get; set; }

		//Join on attribute
		public IAttribute attr { get; set; }

		public List<Join> Children { get; set; }


	}
}
