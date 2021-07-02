using System;
using Antlr4.Runtime;
using Parser;



//https://putridparrot.com/blog/antlr-in-c/

namespace AntlrTest
{
    class Program
    {
        class MyParseErrorListener : BaseErrorListener
        {
            public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                System.Console.WriteLine("Syntax error: " + msg +  " symbol " + offendingSymbol.Text + " at position  " + charPositionInLine);
            }
        }


        static QueryStatement parse(string queryStr)
        {
            var inputStream = new AntlrInputStream(queryStr);
            var lexer = new QueryLanguageLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokenStream);

            parser.RemoveErrorListeners();
            parser.AddErrorListener(new MyParseErrorListener());

            var visitor = new QueryLanguageVisitor();
            var query = parser.statement();
            return (QueryStatement)visitor.Visit(query);
        }

        static void Main(string[] args)
        {
            QueryStatement statement;
            //All attributes from all CommsNetwork instances
            statement = parse("SELECT * FROM CommsNetwork"  );
            //Attributes ID and Description from all CommsNetwork instances.
            statement = parse("SELECT ID, Description FROM CommsNetwork");
            //Attributes ID and Description from CommsNetwork and CommsNetworkType 
            statement = parse("SELECT CommsNetwork.ID, CommsNetworkType.Description FROM CommsNetwork, CommsNetworkType");
            //All attributes for a CommsNetwork instance with ID '123456abcd'.
            statement = parse("SELECT * FROM CommsNetwork WHERE CommsNetwork.ID == '123456abcd'");
            //All attributes for a CommsNetwork instance where ID is supplied at runtime'.
            statement = parse("SELECT * FROM CommsNetwork WHERE CommsNetwork.ID == {0}");
            //All attributes for a CommsNetwork instance where ID is an integer.
            statement = parse("SELECT * FROM CommsNetwork WHERE CommsNetwork.ID == 1234");
            //All attributes for CommsNetwork instances where Size >= 1234.5678 (double).
            statement = parse("SELECT * FROM CommsNetwork WHERE CommsNetwork.Size >= 1234.5678");
            statement = parse("SELECT * FROM CommsNetwork WHERE CommsNetwork.Size < 1234.5678");
            statement = parse("SELECT table1.foo, table2.bar FROM table1 WHERE table1.foo == 'abc' AND table1.bar > 70 ");
            statement = parse("SELECT table1.foo, table2.bar FROM table1 WHERE table1.foo == 'abc' OR table1.bar > 70 ");
            statement = parse("SELECT table1.foo, table2.bar FROM table1 WHERE table1.foo == 'abc' OR (table1.foo > 70 AND table2.bar < 100)");
            statement = parse("SELECT * FROM table1 WHERE table1.foo == 'abc' JOIN table2 ON table1.ID = table2.ParentID");
            statement = parse("SELECT * FROM table1 WHERE table1.foo == 'abc' JOIN table2 ON table1.ID = table2.ParentID JOIN table3 ON table1.ID = table3.ParentID");
           
        }
    }
}
