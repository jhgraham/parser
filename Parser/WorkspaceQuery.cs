using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{

    /*
    interface ComparisonOperator
    {

    }

    class GreaterThan : ComparisonOperator
    {
        bool execute()
        {

        }
    }

    class Literal
    {
        String value;
    }

    class StringLiteral
    {
    
    }

    class Expression
    {
        private String _attrName;
        private ComparisonOperator _op;
        Expression(String attr, ComparisonOperator op, StringLiteral literal)
        {

        }

        bool Match(IItem item)
        {
            IAttribute attr = item.Attributes.Where(a => a.Name == _attrName).FirstOrDefault();
            if (attr != null)
            {
                _op.execute();
            }
            return false;
        }
    }

    interface LogicalOperator1
    {
    
    }


    class And : LogicalOperator1
    {
        public Expression expr1;
        public Expression expr2;
    }

    class Or : LogicalOperator1
    {
        public Expression expr1;
        public Expression expr2;
    }

    class Where1
    {
        ICollection<Expression> expressions;
    }

    class From
    {
        ICollection<string> categoryNames;

        public bool match(IItem item)
        {
            foreach (var categoryName in categoryNames)
            {
                ICategory category = item.Categories.Where(c => c.Name.Contains(categoryName)).FirstOrDefault();
                if (category != null)
                {
                    return true;
                }
            }
            return false;
        }

    }

    class Select
    {
        ICollection<string> attrNames;
        public IItem filter(IItem item)
        {
            if(attrNames.Count == 0)
            {
                return item;
            }
            else
            {
                IItem clone = item.clone();


                return clone;
            }
        }
    }

    class WorkspaceQuery
    {
        Where1 _where;
        From _from;

        ICollection<IItem> run(IWorkspace workspace)
        {
            ICollection<IItem> matches = from(workspace.items.Values);
            matches = where(matches);

            return null;
        }
        ICollection<IItem> from(ICollection<IItem> items)
        {
            ICollection<IItem> r = new List<IItem>();
            foreach (var it in items)
            {
                if (_from.match(it))
                {
                    r.Add(it);
                }
            }
            return r;
        }

        ICollection<IItem> select(ICollection<IItem> items)
        {
            return null;
        }
        ICollection<IItem> where(ICollection<IItem> items)
        {

            return null;
        }

    }*/
}
