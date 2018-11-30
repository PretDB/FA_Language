using System;
using System.Collections;
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

    /// <summary>
    /// Function keep all data.
    /// For simple data type like int and real, data keep in code.
    /// For complex data type like list, tuple and image number, data keeps in parameters,
    ///     and the code keeps empty.
    /// </summary>
    public class Function
    {
        public List<Function> Parameters;
        public HashSet<Function> functions;
        public TYPE FunkcnType { get; private set; }
        public TYPE ReturnType;
        public string Code;
        public string Name { get; private set; }

        public string guid = System.Guid.NewGuid().ToString("N");



        public Function(HashSet<Function> functions)
        {
            this.Code = "";
            this.Name = "";
            this.FunkcnType = TYPE.None;
            this.ReturnType = TYPE.None;
            this.Parameters = new List<Function>();

            this.functions = functions;
        }

        public Function(string name, TYPE ftype, TYPE rettype, string code, List<Function> p, HashSet<Function> functions)
        {
            this.Name = name;
            this.FunkcnType = ftype;
            this.ReturnType = rettype;
            this.Code = code;
            this.Parameters = p;

            this.functions = functions;
        }

        public Function Run(List<Function> p)
        {
            Function function = new Function(this.functions);

            switch(this.FunkcnType)
            {
                case TYPE.Function:
                    if (p.Count<Function>() == this.Parameters.Count<Function>())
                    {
                        switch (this.Name)
                        {
                            case "+":
                                var li = from Function in p where Function.ReturnType == TYPE.List select Function;
                                var tp = from Function in p where Function.ReturnType == TYPE.Tuple select Function;
                                var st = from Function in p where Function.ReturnType == TYPE.String select Function;
                                var im = from Function in p where Function.ReturnType == TYPE.Imag select Function;
                                var re = from Function in p where Function.ReturnType == TYPE.Real select Function;
                                var it = from Function in p where Function.ReturnType == TYPE.Int select Function;
                                if( li.Count<Function>() != 0 )
                                {

                                }
                                else if(tp.Count<Function>() != 0)
                                {

                                }
                                else if(st.Count<Function>() != 0)
                                {

                                }
                                else if ( im.Count<Function>() != 0)
                                {
                                    foreach(Function f in p)
                                    {
                                        switch(f.ReturnType)
                                        {
                                            case TYPE.Int:
                                                
                                                break;

                                            case TYPE.Real:
                                                break;
                                        }
                                    }

                                }
                                else if(re.Count<Function>() != 0)
                                {
                                    Console.WriteLine("real");
                                }
                                else
                                {
                                    int a = int.Parse(p[0].Code);
                                    int b = int.Parse(p[1].Code);

                                    function = new Function("", TYPE.Int, TYPE.Int, (a + b).ToString(), new List<Function>(), this.functions);
                                }
                                switch (this.ReturnType)
                                {
                                    case TYPE.Int:
                                        {
                                            int a = int.Parse(p[0].Code);
                                            int b = int.Parse(p[1].Code);
                                            function = new Function("", TYPE.Int, TYPE.Int, (a + b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Real:
                                        {
                                            double a = double.Parse(p[0].Code);
                                            double b = double.Parse(p[1].Code);
                                            function = new Function("", TYPE.Real, TYPE.Real, (a + b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Imag:
                                        {
                                            double ar = double.Parse(p[0].Parameters[0].Code);
                                            double ai = double.Parse(p[0].Parameters[1].Code);
                                            double br = double.Parse(p[1].Parameters[0].Code);
                                            double bi = double.Parse(p[1].Parameters[1].Code);

                                            List<Function> p_of_image = new List<Function>();
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ar + br).ToString(), new List<Function>(), this.functions));
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ai + bi).ToString(), new List<Function>(), this.functions));
                                            function = new Function("", TYPE.Imag, TYPE.Imag, "", p_of_image, this.functions);
                                        }
                                        break;

                                    case TYPE.Tuple:
                                        break;

                                    case TYPE.List:
                                        break;
                                }
                                break;

                            case "-":
                                switch (this.ReturnType)
                                {
                                    case TYPE.Int:
                                        {
                                            int a = int.Parse(p[0].Code);
                                            int b = int.Parse(p[1].Code);
                                            function = new Function("", TYPE.Int, TYPE.Int, (a - b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Real:
                                        {
                                            double a = double.Parse(p[0].Code);
                                            double b = double.Parse(p[1].Code);
                                            function = new Function("", TYPE.Real, TYPE.Real, (a - b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Imag:
                                        {
                                            double ar = double.Parse(p[0].Parameters[0].Code);
                                            double ai = double.Parse(p[0].Parameters[1].Code);
                                            double br = double.Parse(p[1].Parameters[0].Code);
                                            double bi = double.Parse(p[1].Parameters[1].Code);

                                            List<Function> p_of_image = new List<Function>();
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ar - br).ToString(), new List<Function>(), this.functions));
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ai - bi).ToString(), new List<Function>(), this.functions));
                                            function = new Function("", TYPE.Imag, TYPE.Imag, "", p_of_image, this.functions);
                                        }
                                        break;

                                    case TYPE.Tuple:
                                        break;

                                    case TYPE.List:
                                        break;
                                }
                                break;

                            case "*":
                                switch (this.ReturnType)
                                {
                                    case TYPE.Int:
                                        {
                                            int a = int.Parse(p[0].Code);
                                            int b = int.Parse(p[1].Code);
                                            function = new Function("", TYPE.Int, TYPE.Int, (a * b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Real:
                                        {
                                            double a = double.Parse(p[0].Code);
                                            double b = double.Parse(p[1].Code);
                                            function = new Function("", TYPE.Real, TYPE.Real, (a * b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Imag:
                                        {
                                            double ar = double.Parse(p[0].Parameters[0].Code);
                                            double ai = double.Parse(p[0].Parameters[1].Code);
                                            double br = double.Parse(p[1].Parameters[0].Code);
                                            double bi = double.Parse(p[1].Parameters[1].Code);

                                            List<Function> p_of_image = new List<Function>();
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ar * br - ai * bi).ToString(), new List<Function>(), this.functions));
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, (ar * bi + ai * br).ToString(), new List<Function>(), this.functions));
                                            function = new Function("", TYPE.Imag, TYPE.Imag, "", p_of_image, this.functions);
                                        }
                                        break;
                                }
                                break;

                            case "/":
                                switch (this.ReturnType)
                                {
                                    case TYPE.Int:
                                        {
                                            int a = int.Parse(p[0].Code);
                                            int b = int.Parse(p[1].Code);
                                            function = new Function("", TYPE.Int, TYPE.Int, (a / b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Real:
                                        {
                                            double a = double.Parse(p[0].Code);
                                            double b = double.Parse(p[1].Code);
                                            function = new Function("", TYPE.Real, TYPE.Real, (a / b).ToString(), new List<Function>(), this.functions);
                                        }
                                        break;

                                    case TYPE.Imag:
                                        {
                                            double ar = double.Parse(p[0].Parameters[0].Code);
                                            double ai = double.Parse(p[0].Parameters[1].Code);
                                            double br = double.Parse(p[1].Parameters[0].Code);
                                            double bi = double.Parse(p[1].Parameters[1].Code);

                                            List<Function> p_of_image = new List<Function>();
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, ((ar * br + ai * bi) / (br * br + bi * bi)).ToString(), new List<Function>(), this.functions));
                                            p_of_image.Add(new Function("", TYPE.Real, TYPE.Real, ((ai * br - ar * bi) / (br * br + bi * bi)).ToString(), new List<Function>(), this.functions));
                                            function = new Function("", TYPE.Imag, TYPE.Imag, "", p_of_image, this.functions);
                                        }
                                        break;
                                }
                                break;

                            case "@":
                                break;

                            case "Int":
                                break;

                            case "Real":
                                break;

                            case "Imag":
                                break;

                            default:
                                string code = this.Code;

                                for (int a = 0; a < this.Parameters.Count<Function>(); a++)
                                {
                                    code = code.Replace(this.Parameters[a].Name, p[a].Code);
                                }

                                // Run the code
                                AntlrInputStream runStream = new AntlrInputStream(code);
                                FA_LanguageLexer lexer = new FA_LanguageLexer(runStream);
                                CommonTokenStream tokens = new CommonTokenStream(lexer);
                                FA_LanguageParser parser = new FA_LanguageParser(tokens);
                                IParseTree tree = parser.conversation();
                                //Console.WriteLine("run tree:");
                                //Console.WriteLine(tree.ToStringTree(parser));
                                FA_Visitor visitor = new FA_Visitor(this.functions);

                                function = visitor.Visit(tree);

                                break;
                        }
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
            switch(this.FunkcnType)
            {
                case TYPE.None:
                    ret = "None";
                    break;

                case TYPE.Function:
                    ret = "(";
                    for(int a = 0; a < this.Parameters.Count<Function>(); a++)
                    {
                        ret += this.Parameters[a].FunkcnType.ToString() + " " + this.Parameters[a].Name + ", ";
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
                        ret += this.Parameters[a].ToString() + ", ";
                    }
                    ret += ")";
                    break;

                case TYPE.List:
                    ret = "[";
                    for(int a = 0; a < this.Parameters.Count<Function>(); a++)
                    {
                        ret += this.Parameters[a].ToString() + ", ";
                    }
                    ret += "]";
                    break;

                case TYPE.String:
                    ret = "\"" + this.Code + "\"";
                    break;

                // This is the default situation where returns the value (int or real) itself.
                default:
                    ret = this.Code;
                    break;
            }

            return ret;
        }

    }

}
