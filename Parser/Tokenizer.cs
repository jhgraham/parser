using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    public enum TokenType
    {
        NotDefined,
        And,
        Application,
        As,
        Between,
        CloseParenthesis,
        Comma,
        DateTimeValue,
        Equals,
        ExceptionType,
        From,
        GreaterThan,
        Identifier,
        In,
        Invalid,
        Join,
        LessThan,
        Like,
        Limit,
        Match,
        Message,
        NotEquals,
        NotIn,
        NotLike,
        NumberValue,
        On,
        Or,
        OpenParenthesis,
        Select,
        StackFrame,
        StringValue,
        SequenceTerminator,
        Where
    }

    public class TokenDefinition
    {
        private Regex _regex;
        private readonly TokenType _returnsToken;
        private readonly int _precedence;

        public TokenDefinition(TokenType returnsToken, string regexPattern, int precedence)
        {
            _regex = new Regex(regexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            _returnsToken = returnsToken;
            _precedence = precedence;
        }

        public IEnumerable<TokenMatch> FindMatches(string inputString)
        {
            var matches = _regex.Matches(inputString);
            for (int i = 0; i < matches.Count; i++)
            {
                yield return new TokenMatch()
                {
                    StartIndex = matches[i].Index,
                    EndIndex = matches[i].Index + matches[i].Length,
                    TokenType = _returnsToken,
                    Value = matches[i].Value,
                    Precedence = _precedence
                };
            }
        }
    }

    public class TokenMatch
    {
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Precedence { get; set; }
    }


    class Tokenizer
    {
        private List<TokenDefinition> _tokenDefinitions;

        public Tokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition>();

            _tokenDefinitions.Add(new TokenDefinition(TokenType.And, "and", 4));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.CloseParenthesis, "\\)", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Comma, ",", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Equals, "=", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.From, "from", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.GreaterThan, ">", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.LessThan, "<", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.NotEquals, "!=", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.OpenParenthesis, "\\(", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Or, "or", 4));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.On, "on", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.StackFrame, "sf|stackframe", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.DateTimeValue, "\\d\\d\\d\\d-\\d\\d-\\d\\d \\d\\d:\\d\\d:\\d\\d", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.StringValue, "'([^']*)'", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.NumberValue, "\\d+", 2));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Where, "where", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Identifier, "[\\S]+", 3));

        }

        public class DslToken
        {
            public DslToken(TokenType tokenType)
            {
                TokenType = tokenType;
                Value = string.Empty;
            }

            public DslToken(TokenType tokenType, string value)
            {
                TokenType = tokenType;
                Value = value;
            }

            public TokenType TokenType { get; set; }
            public string Value { get; set; }

            public DslToken Clone()
            {
                return new DslToken(TokenType, Value);
            }
        }

        public IEnumerable<DslToken> Tokenize(string errorMessage)
        {
            var tokenMatches = FindTokenMatches(errorMessage);

            var groupedByIndex = tokenMatches.GroupBy(x => x.StartIndex)
                .OrderBy(x => x.Key)
                .ToList();

            TokenMatch lastMatch = null;
            for (int i = 0; i < groupedByIndex.Count; i++)
            {
                var bestMatch = groupedByIndex[i].OrderBy(x => x.Precedence).First();
                if (lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
                    continue;

                yield return new DslToken(bestMatch.TokenType, bestMatch.Value);

                lastMatch = bestMatch;
            }

            yield return new DslToken(TokenType.SequenceTerminator);
        }

        private List<TokenMatch> FindTokenMatches(string errorMessage)
        {
            var tokenMatches = new List<TokenMatch>();

            foreach (var tokenDefinition in _tokenDefinitions)
                tokenMatches.AddRange(tokenDefinition.FindMatches(errorMessage).ToList());

            return tokenMatches;
        }
    }
}
