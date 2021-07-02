using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
	class Workspace
	{

		private IDictionary<Guid, Item> items { get; set; } = new ConcurrentDictionary<Guid, Item>();


	}
}

