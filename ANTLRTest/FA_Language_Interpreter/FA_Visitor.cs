using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace FA
{
    class FA_Visitor : FA_LanguageBaseVisitor<Function>
    {
        public HashSet<Function> functions = new HashSet<Function>();

        public FA_Visitor(HashSet<Function> functions)
        {
            this.functions = functions;
        }

        public override Function VisitConversation([NotNull] FA_LanguageParser.ConversationContext context)
        {
            Function function = Visit(context.sentence());

            //return base.VisitConversation(context);
            return function;
        }

        public override Function VisitSTATEMENT([NotNull] FA_LanguageParser.STATEMENTContext context)
        {
            Function function = Visit(context.statement());
            //return base.VisitSTATEMENT(context);
            return function;
        }

        public override Function VisitORDER([NotNull] FA_LanguageParser.ORDERContext context)
        {
            Function function = Visit(context.order());

            return function;
        }

        public override Function VisitDECLARATION([NotNull] FA_LanguageParser.DECLARATIONContext context)
        {
            Function function = Visit(context.declaration());
            this.functions.Add(function);

            return function;
        }


        public override Function VisitBODYCALL([NotNull] FA_LanguageParser.BODYCALLContext context)
        {
            return base.VisitBODYCALL(context);
        }

        public override Function VisitWORDCALL([NotNull] FA_LanguageParser.WORDCALLContext context)
        {
            FA_LanguageParser.SentenceContext[] sentences = context.sentence();
            Function ret = new Function(this.functions);

            var func_alter = from Function in this.functions where Function.Name == context.WORD().GetText() select Function;

            /// Function call
            if(func_alter.Count<Function>() != 0)
            {
                Function func = func_alter.First<Function>();

                if(sentences.Count<FA_LanguageParser.SentenceContext>() != 0)
                {
                    List<Function> p = new List<Function>();
                    for (int a = 0; a < sentences.Count<FA_LanguageParser.SentenceContext>(); a++)
                    {
                        Function f = Visit(sentences[a]);
                        if(f.ReturnType != func.Parameters[a].ReturnType)
                        {
                            if (func.Parameters[a].ReturnType == TYPE.Imag && (f.ReturnType == TYPE.Real || f.ReturnType == TYPE.Int))
                            {
                                f.ReturnType = TYPE.Imag;
                                List<Function> pp = new List<Function>();
                                pp.Add(new Function("", TYPE.Real, TYPE.Real, f.Code, new List<Function>(), this.functions));
                                pp.Add(new Function("", TYPE.Real, TYPE.Real, f.Code, new List<Function>(), this.functions));
                                f.Code = "";
                                f.Parameters = pp;
                            }
                            else if(func.Parameters[a].ReturnType == TYPE.Real && f.ReturnType == TYPE.Int)
                            {
                                f.ReturnType = TYPE.Real;
                                f.Code = func.Code;
                            }
                            else
                            {

                            }
                        }
                        p.Add(f);
                    }

                    ret = func.Run(p);
                }
                else
                {
                    ret = func_alter.First<Function>();
                }
            }
            /// Var vall
            else
            {
                Console.WriteLine("{0} is not defined.", context.WORD().GetText());
            }

            //return base.VisitCall(context);
            return ret;
        }

        public override Function VisitFUNC_DECLARATION([NotNull] FA_LanguageParser.FUNC_DECLARATIONContext context)
        {
            Function val = Visit(context.func_body());
            Function function = new Function(context.WORD().GetText(), TYPE.Function, val.ReturnType, val.Code, val.Parameters, val.functions);

            //return base.VisitFUNC_DECLARATION(context);
            return function;
        }

        public override Function VisitLIST_DECLARATION([NotNull] FA_LanguageParser.LIST_DECLARATIONContext context)
        {
            Function val = Visit(context.list_body());
            Function function = new Function(context.WORD().GetText(), val.FunkcnType, val.ReturnType, val.Code, val.Parameters, val.functions);
            //return base.VisitLIST_DECLARATION(context);
            return function;
        }

        public override Function VisitTUPLE_DECLARATION([NotNull] FA_LanguageParser.TUPLE_DECLARATIONContext context)
        {
            Function val = Visit(context.tuple_body());
            Function function = new Function(context.WORD().GetText(), val.FunkcnType, val.ReturnType, val.Code, val.Parameters, val.functions);
            //return base.VisitTUPLE_DECLARATION(context);
            return function;
        }

        public override Function VisitNUM_DECLARATION([NotNull] FA_LanguageParser.NUM_DECLARATIONContext context)
        {
            Function val = Visit(context.num_body());
            Function function = new Function(context.WORD().GetText(), val.FunkcnType, val.ReturnType, val.Code, val.Parameters, val.functions);

            //return base.VisitNUM_DECLARATION(context);
            return function;
        }

        public override Function VisitFunc_body([NotNull] FA_LanguageParser.Func_bodyContext context)
        {
            Function func = new Function(this.functions);

            List<Function> p = new List<Function>();
            ITerminalNode[] words = context.WORD();
            ITerminalNode[] types = context.TYPE();

            for(int a = 0; a < words.Length; a++)
            {
                Function function = new Function(words[a].GetText(), (TYPE)(Enum.Parse(typeof(TYPE), types[a].GetText())), (TYPE)(Enum.Parse(typeof(TYPE), types[a].GetText())), "", new List<Function>(), this.functions);
                p.Add(function);
            }

            func = new Function("", TYPE.Function, TYPE.Function, context.sentence().GetText(), p, this.functions);

            //return base.VisitFunc_body(context);
            return func;
        }

        public override Function VisitList_body([NotNull] FA_LanguageParser.List_bodyContext context)
        {
            Function func = new Function(this.functions);

            FA_LanguageParser.SentenceContext[] sentences = context.sentence();
            List<Function> p = new List<Function>();

            for(int a = 0; a < sentences.Length; a++)
            {
                Function f = Visit(sentences[a]);
                p.Add(f);
            }

            func = new Function("", TYPE.List, TYPE.List, "", p, this.functions);

            //return base.VisitList_body(context);
            return func;
        }

        public override Function VisitTuple_body([NotNull] FA_LanguageParser.Tuple_bodyContext context)
        {
            Function func = new Function(this.functions);

            FA_LanguageParser.SentenceContext[] sentences = context.sentence();
            List<Function> p = new List<Function>();

            for(int a = 0; a < sentences.Length; a++)
            {
                Function f = Visit(sentences[a]);
                p.Add(f);
            }

            func = new Function("", TYPE.Tuple, TYPE.Tuple, "", p, this.functions);

            //return base.VisitTuple_body(context);
            return func;
        }

        public override Function VisitNum_body([NotNull] FA_LanguageParser.Num_bodyContext context)
        {
            Function func = new Function(this.functions);
            ITerminalNode node;

            if (context.INT() != null)
            {
                node = context.INT();
                func = new Function(node.ToString(), TYPE.Int, TYPE.Int, node.ToString(), new List<Function>(), this.functions);
            }
            else if (context.REAL() != null)
            {
                node = context.REAL();
                func = new Function(node.ToString(), TYPE.Real, TYPE.Real, node.ToString(), new List<Function>(), this.functions);
            }
            else if (context.IMAG() != null)
            {
                node = context.IMAG();
                var i = node.ToString().IndexOf('i') + 1;
                string r = node.ToString().Substring(0, i - 1);
                string img = node.ToString().Substring(i, node.ToString().Length - i);

                Function real = new Function(r, TYPE.Real, TYPE.Real, r, new List<Function>(), this.functions);
                Function imag = new Function(img, TYPE.Real, TYPE.Real, img, new List<Function>(), this.functions);
                List<Function> p = new List<Function>();
                p.Add(real);
                p.Add(imag);
                func = new Function(node.ToString(), TYPE.Imag, TYPE.Imag, "", p, this.functions);
            }
            else if (context.TYPE() != null)
            {
                node = context.TYPE();

                func = new Function(node.ToString(), TYPE.String, TYPE.String, node.ToString(), new List<Function>(), this.functions);
            }
            //return base.VisitNum_body(context);
            return func;
        }
    }
}
