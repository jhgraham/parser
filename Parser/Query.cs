using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
	class Query
	{
		/*
		private ICategory from;

		private ICollection<Select> select;

		private Where where;

		private ICollection<Join> joins;

		private ICollection<IItem> filteredItems;


		//SELECT AS, FROM, WHERE, JOIN
		void run(IWorkspace workspace)
		{
			filteredItems.Clear();
			//top level items
			ICollection<IItem> items = new List<IItem>(workspace.items.Values);

			doFrom(items);

			doJoin(joins, items);

			ICollection<IItem> items4 = doSelect(filteredItems);

		}

		private void doWhere()
		{
			
		}

		private void doJoin(ICollection<Join> joins, ICollection<IItem> items)
		{
			foreach (var j in joins)
			{
				foreach (var item in items)
				{
					ICategory category = item.Categories.Where(c => c.Name.Contains(j.Category.Name)).FirstOrDefault();
					if (category != null)
					{
						filteredItems.Add(item);

						doJoin(j.Children, items);
					}
				}
			}
		}

		private ICollection<IItem> doWhere(ICollection<IItem> items)
		{
			return null;
		}

		private void doFrom(ICollection<IItem> items)
		{
			foreach (var item in items)
			{
				ICategory category = item.Categories.Where(c => c.Name.Contains(from.Name)).FirstOrDefault();
				if (category != null)
				{
					filteredItems.Add(item);
				}
			}
		}

		private ICollection<IItem> doSelect(ICollection<IItem> items)
		{
			ICollection<IItem> copy = new List<IItem>(items.Select(it => it.clone()));

			foreach (var sel in select)
			{
				foreach (var it in copy)
				{


				}
			}
			return copy;
		}*/

	}
}