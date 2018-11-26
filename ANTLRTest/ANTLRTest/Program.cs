using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ANTLRTest
{
    class CalcVisitor: CalcBaseVisitor<int>
    {
        public override int VisitNUMBER([NotNull] CalcParser.NUMBERContext context)
        {
            return int.Parse(context.GetText());
        }

        public override int VisitADDSUB([NotNull] CalcParser.ADDSUBContext context)
        {
            int left = Visit(context.term(0));
            int right = 0;
            try
            {
                right = Visit(context.term(1));
            }
            catch(System.NullReferenceException e)
            {
                return left;
            }

            if(context.op.Type == CalcParser.ADD)
            {
                return left + right;
            }
            else if(context.op.Type == CalcParser.SUB)
            {
                return left - right;
            }
            else
            {
                return base.VisitADDSUB(context);
            }
        }

        public override int VisitMUTDIV([NotNull] CalcParser.MUTDIVContext context)
        {
            int left = Visit(context.factor(0));
            int right = 1;
            try
            {
                right = Visit(context.factor(1));
            }
            catch(System.NullReferenceException e)
            {
                return left;
            }

            if(context.op.Type == CalcParser.MUL)
            {
                return left * right;
            }
            else if(context.op.Type == CalcParser.DIV)
            {
                return left / right;
            }
            else
            {
                return base.VisitMUTDIV(context);
            }
        }

        public override int VisitPAR([NotNull] CalcParser.PARContext context)
        {
            return Visit(context.expr());
            //return base.VisitPAR(context.expr());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input:");
            StreamReader inputStream = new StreamReader(Console.OpenStandardInput());
            AntlrInputStream input = new AntlrInputStream(inputStream.ReadToEnd());
            CalcLexer lexer = new CalcLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalcParser parser = new CalcParser(tokens);
            IParseTree tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));
            CalcVisitor visitor = new CalcVisitor();
            Console.WriteLine(visitor.Visit(tree));
            Console.WriteLine("end");
        }
    }
}
