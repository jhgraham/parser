using System;
using Antlr4.Runtime;

namespace James
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = "SELECT * FROM Foo";

            var inputStream = new AntlrInputStream(expression);
        /*    var lexer = new SqlBaseLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new SqlBaseParser(tokenStream);

            var visitor = new SQLVisitor();
            var query = parser.query();
            var result = visitor.Visit(query);
        */

            
        }
    }
}
