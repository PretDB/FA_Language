//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\pret-\Desktop\fa\ANTLRTest\ANTLRTest\Calc.g4 by ANTLR 4.6.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ANTLRTest {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CalcParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.5")]
[System.CLSCompliant(false)]
public interface ICalcListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>ADDSUB</c>
	/// labeled alternative in <see cref="CalcParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterADDSUB([NotNull] CalcParser.ADDSUBContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ADDSUB</c>
	/// labeled alternative in <see cref="CalcParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitADDSUB([NotNull] CalcParser.ADDSUBContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>MUTDIV</c>
	/// labeled alternative in <see cref="CalcParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMUTDIV([NotNull] CalcParser.MUTDIVContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>MUTDIV</c>
	/// labeled alternative in <see cref="CalcParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMUTDIV([NotNull] CalcParser.MUTDIVContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>PAR</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPAR([NotNull] CalcParser.PARContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>PAR</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPAR([NotNull] CalcParser.PARContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>NUMBER</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNUMBER([NotNull] CalcParser.NUMBERContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>NUMBER</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNUMBER([NotNull] CalcParser.NUMBERContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>VAR</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVAR([NotNull] CalcParser.VARContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>VAR</c>
	/// labeled alternative in <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVAR([NotNull] CalcParser.VARContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] CalcParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] CalcParser.ProgContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStat([NotNull] CalcParser.StatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStat([NotNull] CalcParser.StatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] CalcParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] CalcParser.ExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerm([NotNull] CalcParser.TermContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerm([NotNull] CalcParser.TermContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFactor([NotNull] CalcParser.FactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFactor([NotNull] CalcParser.FactorContext context);
}
} // namespace ANTLRTest
