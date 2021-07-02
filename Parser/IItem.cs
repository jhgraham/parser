using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
	interface IItem
	{
		ICollection<ICategory> Categories { get; set; }

		ICollection<IAttribute> Attributes { get; set; }

		IItem clone();
	}
}
