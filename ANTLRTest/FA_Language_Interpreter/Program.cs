using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Antlr4;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace FA
{
    class Program
    {
        static HashSet<Function> functions = new HashSet<Function>();

        static void Main(string[] args)
        {
            Program.Initiation();

            while(true)
            {
                Console.Write(">> ");

                StreamReader streamReader = new StreamReader(Console.OpenStandardInput());

                try
                {
                    AntlrInputStream inputStream = new AntlrInputStream(streamReader.ReadLine());
                    if(inputStream.ToString().Contains("\u001a") || inputStream.ToString().Contains("\u0004"))
                    {
                        Console.WriteLine("EOF");
                        break;
                    }

                    FA_LanguageLexer fA_LanguageLexer = new FA_LanguageLexer(inputStream);
                    CommonTokenStream commonTokenStream = new CommonTokenStream(fA_LanguageLexer);
                    FA_LanguageParser fA_LanguageParser = new FA_LanguageParser(commonTokenStream);
                    IParseTree parseTree = fA_LanguageParser.conversation();
                    FA_Visitor fA_Visitor = new FA_Visitor(Program.functions);

                    // Print tree and output result
                    Console.WriteLine(parseTree.ToStringTree(fA_LanguageParser));
                    Console.WriteLine(fA_Visitor.Visit(parseTree).ToString());
                }
                catch (System.NullReferenceException e)
                {
                    Console.WriteLine("error: " + e.Message);
                    continue;
                }
            }
        }

        static void Initiation()
        {
            List<Function> solo_params = new List<Function>();
            List<Function> binary_params = new List<Function>();
            HashSet<Function> internal_functions = new HashSet<Function>();

            solo_params.Add(new Function("a", TYPE.None, TYPE.None, "", new List<Function>(), internal_functions));
            binary_params.Add(new Function("a", TYPE.None, TYPE.None, "", binary_params, internal_functions));
            binary_params.Add(new Function("b", TYPE.None, TYPE.None, "", binary_params, internal_functions));

            internal_functions.Add(new Function("pi", TYPE.Real, TYPE.None, "3.1415926", new List<Function>(), internal_functions));

            internal_functions.Add(new Function("+", TYPE.Function, TYPE.None, "+(a, b)", binary_params, internal_functions));
            internal_functions.Add(new Function("-", TYPE.Function, TYPE.None, "-(a, b)", binary_params, internal_functions));
            internal_functions.Add(new Function("*", TYPE.Function, TYPE.None, "*(a, b)", binary_params, internal_functions));
            internal_functions.Add(new Function("/", TYPE.Function, TYPE.None, "/(a, b)", binary_params, internal_functions));

            internal_functions.Add(new Function("swap", TYPE.Function, TYPE.Real, "", binary_params, internal_functions));
            internal_functions.Add(new Function("Int", TYPE.Function, TYPE.Int, "", solo_params, internal_functions));
            internal_functions.Add(new Function("Real", TYPE.Function, TYPE.Int, "", solo_params, internal_functions));
            internal_functions.Add(new Function("Imag", TYPE.Function, TYPE.Int, "", solo_params, internal_functions));

            Program.functions.UnionWith(internal_functions);
        }
    }
}
