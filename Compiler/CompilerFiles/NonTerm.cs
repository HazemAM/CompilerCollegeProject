using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class NonTerm
    {
        public readonly string name;
        public readonly SortedList<string, int> content;
        public NonTerm(string name)
        {
            this.name = name;
            content = new SortedList<string, int>();
        }
        public void AddContent(string terminal, int ruleNum)
        {
            content.Add(terminal, ruleNum);
        }

    }
}
