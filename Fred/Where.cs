using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{



    public class ComparisonOperator : Expression
    {
        public enum ComparisonEnum
        {
            NotDefined,
            Equals,
            NotEquals,
            GreaterThan,
            GreaterOrEqualTo,
            LessThan,
            LessThanOrEqualTo
        }

        public ComparisonOperator(ComparisonEnum opType)
        {
            this.Operator = opType;
        }

        public String Attribute { get; set; }

        public ComparisonEnum Operator { get; set; }

        public Object Value { get; set; }
    }


    public interface Expression
    {

    }

    public class BracketExpression : Expression
    {
        public Expression Expression { get; set; }
    }
    public class BooleanOperator : Expression
    {
        public enum BooleanOperatorEnum
        {
            OR,
            AND
        }

        public BooleanOperator(BooleanOperatorEnum type)
        {
            this.Type = type;
        }

        public BooleanOperatorEnum Type { get; set; }
        public Expression Left { get; set; }
        public Expression Right { get; set; }
    }


    class Where
    {
        public Expression Expression { get; set; }

    }
}
