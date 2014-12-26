using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Compiler
{
    class Syntax
    {
        List<string> terminals;
        List<string> nonTerminals;
        List<Token> input;
        const string LL1Table = "..\\..\\LL1.txt";
        public Syntax(List<Token>input)
        {
            this.input = input;
            readTxt();
        }

        private void readTxt()
        {
            StreamReader sr = new StreamReader(LL1Table);
            string terms = sr.ReadLine();
            terminals=terms.Split(',').ToList<string>();
            terms = sr.ReadLine();
            nonTerminals = terms.Split(',').ToList<string>();
            sr.Close();
        }
    }
}
