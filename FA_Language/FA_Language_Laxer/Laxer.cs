using System;
using System.Collections.Generic;

namespace FA
{
    public enum TokenType
    {
        Symbol,
        Function
    }

    public class Function
    {
        public string Name
        {
            get;
            private set;
        }

        public List<Function> parameters;

        public Function(string name, List<Function> args)
        {
            this.Name = name;
            this.parameters = args;
        }
    }

    public class SentenceReader
    {
        public string Sentence
        {
            get;
            private set;
        }

        public string TokenSequence
        {
            get;
            private set;
        }

        public void ReadFromString(string inputString)
        {
            this.Sentence = inputString;
        }

        public void ReadFromFile(string fileName)
        {

        }

        public void LexAnalysis()
        {

        }
    }

    public class Token
    {
        public string name
        {
            get;
            private set;
        }

    }
}
