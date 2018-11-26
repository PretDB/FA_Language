//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\PretYoon\source\repos\ANTLRTest\ANTLRTest\Calc.g4 by ANTLR 4.6.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ANTLRTest {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.5")]
[System.CLSCompliant(false)]
public partial class CalcParser : Parser {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, INT=7, ID=8, NEWLINE=9, 
		WS=10;
	public const int
		RULE_prog = 0, RULE_stat = 1, RULE_expr = 2, RULE_term = 3, RULE_factor = 4;
	public static readonly string[] ruleNames = {
		"prog", "stat", "expr", "term", "factor"
	};

	private static readonly string[] _LiteralNames = {
		null, "'+'", "'-'", "'*'", "'/'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, "INT", "ID", "NEWLINE", "WS"
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

	public override string GrammarFileName { get { return "Calc.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public CalcParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class ProgContext : ParserRuleContext {
		public StatContext stat() {
			return GetRuleContext<StatContext>(0);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProg(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_prog);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 10; stat();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public StatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_stat; } }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterStat(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitStat(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStat(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatContext stat() {
		StatContext _localctx = new StatContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_stat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12; expr();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ADDSUBContext : ExprContext {
		public TermContext[] term() {
			return GetRuleContexts<TermContext>();
		}
		public TermContext term(int i) {
			return GetRuleContext<TermContext>(i);
		}
		public ADDSUBContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterADDSUB(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitADDSUB(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitADDSUB(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_expr);
		int _la;
		try {
			_localctx = new ADDSUBContext(_localctx);
			EnterOuterAlt(_localctx, 1);
			{
			State = 14; term();
			State = 19;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==T__0 || _la==T__1) {
				{
				{
				State = 15;
				_la = _input.La(1);
				if ( !(_la==T__0 || _la==T__1) ) {
				_errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 16; term();
				}
				}
				State = 21;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TermContext : ParserRuleContext {
		public TermContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_term; } }
	 
		public TermContext() { }
		public virtual void CopyFrom(TermContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class MUTDIVContext : TermContext {
		public FactorContext[] factor() {
			return GetRuleContexts<FactorContext>();
		}
		public FactorContext factor(int i) {
			return GetRuleContext<FactorContext>(i);
		}
		public MUTDIVContext(TermContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterMUTDIV(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitMUTDIV(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMUTDIV(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TermContext term() {
		TermContext _localctx = new TermContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_term);
		int _la;
		try {
			_localctx = new MUTDIVContext(_localctx);
			EnterOuterAlt(_localctx, 1);
			{
			State = 22; factor();
			State = 27;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==T__2 || _la==T__3) {
				{
				{
				State = 23;
				_la = _input.La(1);
				if ( !(_la==T__2 || _la==T__3) ) {
				_errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 24; factor();
				}
				}
				State = 29;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FactorContext : ParserRuleContext {
		public FactorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_factor; } }
	 
		public FactorContext() { }
		public virtual void CopyFrom(FactorContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class PARContext : FactorContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public PARContext(FactorContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterPAR(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitPAR(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPAR(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NUMBERContext : FactorContext {
		public ITerminalNode INT() { return GetToken(CalcParser.INT, 0); }
		public NUMBERContext(FactorContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterNUMBER(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitNUMBER(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNUMBER(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class VARContext : FactorContext {
		public ITerminalNode ID() { return GetToken(CalcParser.ID, 0); }
		public VARContext(FactorContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.EnterVAR(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICalcListener typedListener = listener as ICalcListener;
			if (typedListener != null) typedListener.ExitVAR(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalcVisitor<TResult> typedVisitor = visitor as ICalcVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVAR(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FactorContext factor() {
		FactorContext _localctx = new FactorContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_factor);
		try {
			State = 36;
			_errHandler.Sync(this);
			switch (_input.La(1)) {
			case T__4:
				_localctx = new PARContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 30; Match(T__4);
				State = 31; expr();
				State = 32; Match(T__5);
				}
				break;
			case INT:
				_localctx = new NUMBERContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 34; Match(INT);
				}
				break;
			case ID:
				_localctx = new VARContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 35; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\f)\x4\x2\t\x2\x4"+
		"\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4"+
		"\x3\x4\x3\x4\a\x4\x14\n\x4\f\x4\xE\x4\x17\v\x4\x3\x5\x3\x5\x3\x5\a\x5"+
		"\x1C\n\x5\f\x5\xE\x5\x1F\v\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x5\x6"+
		"\'\n\x6\x3\x6\x2\x2\x2\a\x2\x2\x4\x2\x6\x2\b\x2\n\x2\x2\x4\x3\x2\x3\x4"+
		"\x3\x2\x5\x6\'\x2\f\x3\x2\x2\x2\x4\xE\x3\x2\x2\x2\x6\x10\x3\x2\x2\x2\b"+
		"\x18\x3\x2\x2\x2\n&\x3\x2\x2\x2\f\r\x5\x4\x3\x2\r\x3\x3\x2\x2\x2\xE\xF"+
		"\x5\x6\x4\x2\xF\x5\x3\x2\x2\x2\x10\x15\x5\b\x5\x2\x11\x12\t\x2\x2\x2\x12"+
		"\x14\x5\b\x5\x2\x13\x11\x3\x2\x2\x2\x14\x17\x3\x2\x2\x2\x15\x13\x3\x2"+
		"\x2\x2\x15\x16\x3\x2\x2\x2\x16\a\x3\x2\x2\x2\x17\x15\x3\x2\x2\x2\x18\x1D"+
		"\x5\n\x6\x2\x19\x1A\t\x3\x2\x2\x1A\x1C\x5\n\x6\x2\x1B\x19\x3\x2\x2\x2"+
		"\x1C\x1F\x3\x2\x2\x2\x1D\x1B\x3\x2\x2\x2\x1D\x1E\x3\x2\x2\x2\x1E\t\x3"+
		"\x2\x2\x2\x1F\x1D\x3\x2\x2\x2 !\a\a\x2\x2!\"\x5\x6\x4\x2\"#\a\b\x2\x2"+
		"#\'\x3\x2\x2\x2$\'\a\t\x2\x2%\'\a\n\x2\x2& \x3\x2\x2\x2&$\x3\x2\x2\x2"+
		"&%\x3\x2\x2\x2\'\v\x3\x2\x2\x2\x5\x15\x1D&";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace ANTLRTest