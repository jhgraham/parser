using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
	class IWorkspace
	{
		public IDictionary<Guid, IItem> items {get; set;}

	}
}
