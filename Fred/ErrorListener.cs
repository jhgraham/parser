using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace Fred
{
    public class ErrorListener : BaseErrorListener
    {
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Console.WriteLine("{0}: line {1}/column {2} {3}", e, line, charPositionInLine, msg);
        }
    }
}
