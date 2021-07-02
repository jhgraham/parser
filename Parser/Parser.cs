using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Parser.Tokenizer;

namespace Parser
{
    class Parser
    {
        // Stack and Lookaheads
        private Stack<DslToken> _tokenSequence;
        private DslToken _lookaheadFirst;
        private DslToken _lookaheadSecond;

        // IR class that we will build as we go
        private SQLQueryModel _queryModel;
        //private MatchCondition _currentMatchCondition;

        public SQLQueryModel parse(List<DslToken> tokens)
        {
            // create the stack and load the lookaheads
            LoadSequenceStack(tokens);
            PrepareLookaheads();
            _queryModel = new SQLQueryModel();

            // S -> MATCH
            Match();

            DiscardToken(TokenType.SequenceTerminator);

            return _queryModel;
        }

        private void Match()
        {
            // MATCH -> match MATCH_CONDITION
            DiscardToken(TokenType.Match);
            
            if(IsSelect(_lookaheadFirst))
            {
                DiscardToken();

                DslToken token = ReadToken(TokenType.Identifier);
                _queryModel.Select.Attributes.Add(token.Value);
                DiscardToken();

                ReadToken(TokenType.Comma);
                DiscardToken();

            }
        }

        private void LoadSequenceStack(List<DslToken> tokens)
        {
            _tokenSequence = new Stack<DslToken>();
            int count = tokens.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                _tokenSequence.Push(tokens[i]);
            }
        }

        private void PrepareLookaheads()
        {
            _lookaheadFirst = _tokenSequence.Pop();
            _lookaheadSecond = _tokenSequence.Pop();
        }

        private DslToken ReadToken(TokenType tokenType)
        {
            if (_lookaheadFirst.TokenType != tokenType)
                throw new Exception(string.Format("Expected {0} but found: {1}", tokenType.ToString().ToUpper(), _lookaheadFirst.Value));

            return _lookaheadFirst;
        }

        private void DiscardToken()
        {
            _lookaheadFirst = _lookaheadSecond.Clone();

            if (_tokenSequence.Any())
                _lookaheadSecond = _tokenSequence.Pop();
            else
                _lookaheadSecond = new DslToken(TokenType.SequenceTerminator, string.Empty);
        }

        private void DiscardToken(TokenType tokenType)
        {
            if (_lookaheadFirst.TokenType != tokenType)
                throw new Exception(string.Format("Expected {0} but found: {1}", tokenType.ToString().ToUpper(), _lookaheadFirst.Value));

            DiscardToken();
        }
        private Boolean IsTokenType(DslToken token, TokenType type)
        {
            return token.TokenType == type;
        }

        private Boolean IsSelect(DslToken token)
        {
            return token.TokenType == TokenType.Identifier && token.Value.Equals("select");
        }
        private Boolean IsFrom(DslToken token)
        {
            return token.TokenType == TokenType.Identifier && token.Value.Equals("from");
        }
        private Boolean IsWhere(DslToken token)
        {
            return token.TokenType == TokenType.Identifier && token.Value.Equals("where");
        }
        private Boolean IsJoin(DslToken token)
        {
            return token.TokenType == TokenType.Identifier && token.Value.Equals("from");
        }
    }
}
