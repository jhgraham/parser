using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Join
    {
        public enum JoinType
        {
            INNER
        }

        public JoinType Type { get; set; }
        public string Table { get; set; }
        public string column1 { get; set; }
        public string column2 { get; set; }
    }
}
