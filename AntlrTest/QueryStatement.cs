using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
	class QueryStatement
	{
		public Select Select { get; set; }
		public From From { get; set; }
		public Where Where { get; set; }
		public List<Join> Join { get; set; }
		public QueryStatement()
		{
			Select = new Select();
			From = new From();
			Where = new Where();
			Join = new List<Join>();
		}

	}
}
