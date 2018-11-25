using System;
using System.Collections;
using System.Collections.Generic;


namespace FA
{
    public enum Type
    {
        None,
        Int,
        Real,
        Imag,
        Function,
        String,
        List,
        Tuple
    }

    static public class Syntaxer
    {
    }

    public class SyntaxNode
    {

    }

    public class Function
    {
        public string name;

        private FA.Type returnType;
        private List<FA.Type> paramList;

        public Function(string name, FA.Type retType, List<FA.Type> paramList)
        {
            this.name = name;
            this.returnType = retType;
            this.paramList = paramList;
        }

        public FA.Type Run()
        {

            return FA.Type.None;
        }

    }
}
