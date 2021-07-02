using System;
using Antlr4.Runtime;



//https://putridparrot.com/blog/antlr-in-c/
//https://notes.kartashov.com/2016/01/30/writing-a-simple-query-language-with-antlr/


namespace Fred
{
    class Program
    {
        static void Main(string[] args)
        {
            // add these using clauses
            // using Antlr4.Runtime;
            // using Example.Generated;

            try
            {
                // example expression
                //var expression = "SELECT * FROM T1";
                //var expression = "SELECT foo, bar, baz FROM TA, TB WHERE ab == 'gf'";
                //var expression = "SELECT foo, bar, baz FROM TA, TB WHERE ab >= 766 AND trt == 654";
                var expression = " ab >= 766 AND trt > 654";

                //expression = "SELECT *";
                //var expression = "\"HELLO\" AND 123";
                //FROM MyTable

                var inputStream = new AntlrInputStream(expression);
                var lexer = new GDMQLLexer(inputStream);
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new GDMQLParser(tokenStream);

                //parser.RemoveErrorListeners();
                //parser.AddErrorListener(new ErrorListener()); // add ours

                var visitor = new GDMQLVisitor();
                var query = parser.where();
                var result = visitor.Visit(query);

                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            
        }
    }
}
