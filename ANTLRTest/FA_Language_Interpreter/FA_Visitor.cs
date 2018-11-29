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
        public override Function VisitSENTENCE([NotNull] FA_LanguageParser.SENTENCEContext context)
        {
            return base.VisitSENTENCE(context);
        }

        public override Function VisitSTATEMENT([NotNull] FA_LanguageParser.STATEMENTContext context)
        {
            return base.VisitSTATEMENT(context);
        }

        public override Function VisitORDER([NotNull] FA_LanguageParser.ORDERContext context)
        {
            return base.VisitORDER(context);
        }

        public override Function VisitDECLARATION([NotNull] FA_LanguageParser.DECLARATIONContext context)
        {
            return base.VisitDECLARATION(context);
        }

        public override Function VisitFUNC_CALL([NotNull] FA_LanguageParser.FUNC_CALLContext context)
        {
            return base.VisitFUNC_CALL(context);
        }

        public override Function VisitVAR_CALL([NotNull] FA_LanguageParser.VAR_CALLContext context)
        {
            return base.VisitVAR_CALL(context);
        }

        public override Function VisitSHOW_VAR([NotNull] FA_LanguageParser.SHOW_VARContext context)
        {
            return base.VisitSHOW_VAR(context);
        }

        public override Function VisitFUNC_DECLARATION([NotNull] FA_LanguageParser.FUNC_DECLARATIONContext context)
        {
            return base.VisitFUNC_DECLARATION(context);
        }

        public override Function VisitLIST_DECLARATION([NotNull] FA_LanguageParser.LIST_DECLARATIONContext context)
        {
            return base.VisitLIST_DECLARATION(context);
        }

        public override Function VisitTUPLE_DECLARATION([NotNull] FA_LanguageParser.TUPLE_DECLARATIONContext context)
        {
            return base.VisitTUPLE_DECLARATION(context);
        }

        public override Function VisitNUM_DECLARATION([NotNull] FA_LanguageParser.NUM_DECLARATIONContext context)
        {
            return base.VisitNUM_DECLARATION(context);
        }

        public override Function VisitFunc_body([NotNull] FA_LanguageParser.Func_bodyContext context)
        {
            return base.VisitFunc_body(context);
        }

        public override Function VisitList_body([NotNull] FA_LanguageParser.List_bodyContext context)
        {
            return base.VisitList_body(context);
        }

        public override Function VisitTuple_body([NotNull] FA_LanguageParser.Tuple_bodyContext context)
        {
            return base.VisitTuple_body(context);
        }

        public override Function VisitINT_BODY([NotNull] FA_LanguageParser.INT_BODYContext context)
        {
            return base.VisitINT_BODY(context);
        }

        public override Function VisitREAL_BODY([NotNull] FA_LanguageParser.REAL_BODYContext context)
        {
            return base.VisitREAL_BODY(context);
        }

        public override Function VisitIMAG_BODY([NotNull] FA_LanguageParser.IMAG_BODYContext context)
        {
            return base.VisitIMAG_BODY(context);
        }
    }
}
