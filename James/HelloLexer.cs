//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\James\source\repos\SQLParser\James\Hello.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace James {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class HelloLexer : Lexer {
	public const int
		T__0=1, ID=2, WS=3;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "ID", "WS"
	};


	public HelloLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'hello'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "ID", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Hello.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x5\x1B\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3"+
		"\x3\x6\x3\x11\n\x3\r\x3\xE\x3\x12\x3\x4\x6\x4\x16\n\x4\r\x4\xE\x4\x17"+
		"\x3\x4\x3\x4\x2\x2\x2\x5\x3\x2\x3\x5\x2\x4\a\x2\x5\x3\x2\x4\x3\x2\x63"+
		"|\x5\x2\v\f\xF\xF\"\"\x1C\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3"+
		"\x2\x2\x2\x3\t\x3\x2\x2\x2\x5\x10\x3\x2\x2\x2\a\x15\x3\x2\x2\x2\t\n\a"+
		"j\x2\x2\n\v\ag\x2\x2\v\f\an\x2\x2\f\r\an\x2\x2\r\xE\aq\x2\x2\xE\x4\x3"+
		"\x2\x2\x2\xF\x11\t\x2\x2\x2\x10\xF\x3\x2\x2\x2\x11\x12\x3\x2\x2\x2\x12"+
		"\x10\x3\x2\x2\x2\x12\x13\x3\x2\x2\x2\x13\x6\x3\x2\x2\x2\x14\x16\t\x3\x2"+
		"\x2\x15\x14\x3\x2\x2\x2\x16\x17\x3\x2\x2\x2\x17\x15\x3\x2\x2\x2\x17\x18"+
		"\x3\x2\x2\x2\x18\x19\x3\x2\x2\x2\x19\x1A\b\x4\x2\x2\x1A\b\x3\x2\x2\x2"+
		"\x5\x2\x12\x17\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace James