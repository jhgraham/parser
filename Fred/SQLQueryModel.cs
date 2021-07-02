using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
	class SQLQueryModel
	{
		public Select Select { get; set; }
		public From From { get; set; }

		public Where Where { get; set; }
		public SQLQueryModel()
		{
			Select = new Select();
			From = new From();
			Where = new Where();
		}

	}
}
