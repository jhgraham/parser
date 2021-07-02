using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyParser;
using Parser;
using TSQL;
using TSQL.Statements;
using TSQL.Tokens;
using static Parser.Tokenizer;

namespace TSQLParserExample
{
	public class Program
	{




		public static void Main(string[] args)
		{

			string test = "select OrderDateKey, Name, SalesAmount from FactInternetSales where OrderDateKey > 20010000 and Name = 'bob'";
			//string test = "MATCH APP = 'My App' AND EX IN('System.NullReferenceException', 'System.FormatException') BETWEEN 2016 - 01 - 01 10:00:00 AND 2016 - 01 - 01 11:00:00 LIMIT 100";

			Tokenizer t = new Tokenizer();

			IEnumerable<DslToken> tokens =  t.Tokenize(test);

			foreach (DslToken token in tokens)
			{
				Console.WriteLine("\ttype: " + token.TokenType.ToString() + ", value: " + token.Value);

			}

		}


	List<TSQLToken> TransformToPolishNotation(List<TSQLToken> infixTokenList)
        {
			Queue<TSQLToken> outputQueue = new Queue<TSQLToken>();
			Stack<TSQLToken> stack = new Stack<TSQLToken>();

			int index = 0;
			while (infixTokenList.Count > index)
			{
				TSQLToken t = infixTokenList[index];

				switch (t.Type)
				{
					case TSQLTokenType.NumericLiteral:
					case TSQLTokenType.StringLiteral:
					outputQueue.Enqueue(t);
						break;
					case TSQLTokenType.Operator:
					//case Token.TokenType.UNARY_OP:
					//case Token.TokenType.OPEN_PAREN:
						stack.Push(t);
						break;
				/*	case Token.TokenType.CLOSE_PAREN:
						while (stack.Peek().type != Token.TokenType.OPEN_PAREN)
						{
							outputQueue.Enqueue(stack.Pop());
						}
						stack.Pop();
						if (stack.Count > 0 && stack.Peek().type == Token.TokenType.UNARY_OP)
						{
							outputQueue.Enqueue(stack.Pop());
						}
						break;
					default:
						break;*/
				}

				++index;
			}
			while (stack.Count > 0)
			{
				outputQueue.Enqueue(stack.Pop());
			}

			return outputQueue.Reverse().ToList();
		}
	}
}
