using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public enum LogicalOperator
    {
        Or,
        And
    }

    public enum Operator
    {
        NotDefined,
        Equals,
        NotEquals,
        GreaterThan,
        GreaterOrEqualTo,
        LessThan,
        LessThanOrEqualTo
    }
    public class MatchCondition
    {
        public String Attribute { get; set; }

        public Operator Operator { get; set; }

        public String Value { get; set; }

        public LogicalOperator nextCondition;

    }
    class Where
    {
        public List<MatchCondition> matchConditions { get; set; }

    }
}
