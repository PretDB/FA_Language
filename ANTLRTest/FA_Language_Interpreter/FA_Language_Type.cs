using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace FA
{
    public enum TYPE
    {
        None,
        Function,
        Int,
        Real,
        Imag,
        List,
        Tuple,
        String
    }

    public class Function
    {
        public List<Function> Parameters { get; private set; }
        public TYPE Type { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Function()
        {
            this.Code = "";
            this.Name = "";
            this.Type = TYPE.None;
            this.Parameters = new List<Function>();
        }

        public Function(string name, string code, List<Function> p)
        {
            this.Name = name;
            this.Code = code;
            this.Parameters = p;
        }

        public Function Run(List<Function> p)
        {
            Function function;

            switch(this.Type)
            {
                case TYPE.Function:
                    if (p.Count<Function>() == this.Parameters.Count<Function>())
                    {
                        string code = this.Code;

                        for (int a = 0; a < this.Parameters.Count<Function>(); a++)
                        {
                            code.Replace(this.Parameters[a].Name, p[a].Code);
                        }

                        // Run the code
                        AntlrInputStream runStream = new AntlrInputStream(code);
                        //CalcLexer lexer = new CalcLexer(runStream);
                        //CommonTokenStream tokens = new CommonTokenStream(lexer);
                        //CalcParser parser = new CalcParser(tokens);
                        //IParseTree tree = parser.prog();
                        //CalcVisitor visitor = new CalcVisitor(new SortedSet<Variable>(), new SortedSet<Function>());
                        //double res = visitor.Visit(tree);
                    }
                    else
                    {
                        throw new Exception("Function parameter not fit");
                    }
                    break;

                default:
                    function = this;
                    break;
            }

            return function;
        }

        public override string ToString()
        {
            string ret = "";
            switch(this.Type)
            {
                case TYPE.None:
                    ret = "None";
                    break;

                case TYPE.Function:
                    ret = "(";
                    for(int a = 0; a < this.Parameters.Count<Function>(); a++)
                    {
                        ret += this.Parameters[a].Type.ToString() + ", ";
                    }
                    ret += ") -> " + this.Code;
                    break;

                case TYPE.Imag:
                    ret = Parameters[0].ToString() + 'i' + Parameters[1].ToString();
                    break;

                case TYPE.Tuple:
                    ret = "(";
                    for(int a = 0; a < this.Parameters.Count<Function>(); a++)
                    {
                        ret += this.Parameters[a].Code + ", ";
                    }
                    ret += ")";
                    break;

                case TYPE.List:
                    ret = "[";
                    for(int a = 0; a < this.Parameters.Count<Function>(); a++)
                    {
                        ret += this.Parameters[a].Code + ", ";
                    }
                    ret += "]";
                    break;

                case TYPE.String:
                    ret = "\"" + this.Code + "\"";
                    break;

                // This is the default situation where returns the value (int or real) itself.
                default:
                    ret = Parameters[0].Code;
                    break;
            }

            return ret;
        }

    }

    public abstract class Number
    {

    }
}
