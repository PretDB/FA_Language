using System;
using System.Collections;
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
    interface ICallable
    {

    }
    class Function : IComparer<Function>, IComparable<Function>, ICallable
    {
        public string Name { get; private set; }
        public string Code = "";
        public bool Callable = false;
        public List<Function> parameters { get; }

        public Function(string name,  List<Function> parameters, string code)
        {
            this.Name = name;
            this.Callable = true;
            this.parameters = parameters;
            this.Code = code;
        }

        public Function(string name, double val)
        {
            this.Name = name;
            this.Callable = false;
            this.parameters = new List<Function>();
        }

        public double Run(List<Function> p)
        {
            if(p.Count<Function>() != this.parameters.Count<Function>())
            {
                throw new Exception("parameter error");
            }
            else
            {
                string code = this.Code;
                for(int a = 0; a < this.parameters.Count; a++)
                {
                    code = code.Replace(this.parameters[a].Name, p[a].Code);
                }

                AntlrInputStream runStream = new AntlrInputStream(code);
                CalcLexer lexer = new CalcLexer(runStream);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                CalcParser parser = new CalcParser(tokens);
                IParseTree tree = parser.prog();
                CalcVisitor visitor = new CalcVisitor(new SortedSet<Variable>(), new SortedSet<Function>());
                double res = visitor.Visit(tree);

                return res;

            }
        }

        public int Compare(Function x, Function y)
        {
            return x.Name.CompareTo(y.Name);
        }

        public int CompareTo(Function y)
        {
            return this.Name.CompareTo(y.Name);
        }
    }
    class Variable : IComparer<Variable>, IComparable<Variable>
    {
        public string Name { get; private set; }
        public double Value;

        public Variable(string name, double val)
        {
            this.Name = name;
            this.Value = val;
        }

        public int Compare(Variable x, Variable y)
        {
            return x.Name.CompareTo(y.Name);
        }

        public int CompareTo(Variable other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
    class CalcVisitor: CalcBaseVisitor<double>
    {
        private SortedSet<Variable> variables;
        private SortedSet<Function> functions;

        public CalcVisitor(SortedSet<Variable> variables, SortedSet<Function> functions)
        {
            this.variables = variables;
            this.functions = functions;
        }

        public override double VisitASSIGN([NotNull] CalcParser.ASSIGNContext context)
        {
            double value = Visit(context.expr());
            string name = context.ID().GetText();
            Variable v = new Variable("", 0f);

            if(context.op.Type != CalcParser.ASN)
            {
                Console.WriteLine("If you want to assign a value to a variable, use \"=>\".");
                return 0f;
            }


            var variableEnum = from variable in this.variables where variable.Name == name select variable;

            if (variableEnum.Count<Variable>() != 0)
            {
                v.Value = value;
                variableEnum.First<Variable>().Value = value;
            }
            else
            {
                v = new Variable(name, value);
                this.variables.Add(v);
            }

            return v.Value;
        }

        public override double VisitNUMBER([NotNull] CalcParser.NUMBERContext context)
        {
            return double.Parse(context.GetText());
        }

        public override double VisitADD([NotNull] CalcParser.ADDContext context)
        {
            double left = Visit(context.term());
            double right = Visit(context.expr());

            return left + right;
        }

        public override double VisitSUB([NotNull] CalcParser.SUBContext context)
        {
            double left = Visit(context.term());
            double right = Visit(context.expr());

            return left - right;
        }

        public override double VisitMULT([NotNull] CalcParser.MULTContext context)
        {
            double left = Visit(context.factor());
            double right = Visit(context.term());

            return left * right;
        }

        public override double VisitDIVI([NotNull] CalcParser.DIVIContext context)
        {
            double left = Visit(context.factor());
            double right = Visit(context.term());

            return left / right;
        }

        public override double VisitSINGLE_TERM([NotNull] CalcParser.SINGLE_TERMContext context)
        {
            return Visit(context.term());
        }

        public override double VisitSINGLE_FACTOR([NotNull] CalcParser.SINGLE_FACTORContext context)
        {
            return Visit(context.factor());
        }

        public override double VisitPAR([NotNull] CalcParser.PARContext context)
        {
            return Visit(context.expr());
            //return base.VisitPAR(context.expr());
        }

        public override double VisitVAR([NotNull] CalcParser.VARContext context)
        {
            string varName = context.ID().GetText();

            Variable[] v = (from variable in this.variables where (variable.Name == varName) select variable).ToArray<Variable>();

            if(v.Count<Variable>() != 0)
            {
                return v[0].Value;
            }
            else
            {
                Console.WriteLine("{0} is not defined.", varName);
                return 0f;
            }
        }

        public override double VisitFUNC([NotNull] CalcParser.FUNCContext context)
        {
            List<Function> parameters = new List<Function>();
            string code = context.expr().GetText();
            
            foreach(ITerminalNode name in context.ID())
            {
                parameters.Add(new Function(name.GetText(), new List<Function>(), ""));
            }
            parameters.RemoveAt(0);

            Function func = new Function(context.ID(0).GetText(), parameters, code);
            this.functions.Add(func);

            return 0f;
        }

        public override double VisitFUNC_CALL([NotNull] CalcParser.FUNC_CALLContext context)
        {
            string funcName = context.ID().GetText();
            Function[] fs = (from function in this.functions where (function.Name == funcName) select function).ToArray<Function>();
            double res = 0f;
            
            if(fs.Count<Function>() != 0)
            {
                Function f = fs[0];
                List<Function> parameters =new List<Function>();
                
                foreach(CalcParser.ExprContext expr in context.expr())
                {
                    Function tf = new Function("", new List<Function>(), VisitExpr(expr).ToString());
                    parameters.Add(tf);
                }

                res = f.Run(parameters);
            }

            //return base.VisitFUNC_CALL(context);
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Variable> variables = new SortedSet<Variable>();
            SortedSet<Function> functions = new SortedSet<Function>();

            variables.Add(new Variable("ANS", 666));

            while (true)
            {
                Console.Write(">> ");
                StreamReader inputStream = new StreamReader(Console.OpenStandardInput());
                try
                {
                    AntlrInputStream input = new AntlrInputStream(inputStream.ReadLine());
                    if (input.ToString().Contains("\u001a") || input.ToString().Contains("\u0004"))
                    {
                        break;
                    }
                    CalcLexer lexer = new CalcLexer(input);
                    CommonTokenStream tokens = new CommonTokenStream(lexer);
                    CalcParser parser = new CalcParser(tokens);
                    IParseTree tree = parser.prog();
                    //Console.WriteLine(tree.ToStringTree(parser));
                    CalcVisitor visitor = new CalcVisitor(variables, functions);
                    Console.WriteLine(visitor.Visit(tree));

                }
                catch (System.NullReferenceException e)
                {
                    break;
                }
            }

            Console.WriteLine("end");

        }
    }
}
