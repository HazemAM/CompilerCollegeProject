using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class Rule
    {
        int num;
        //left side of the rule
       public readonly Token LHS;
        //reversed right side of the rule
        public readonly Token[] RHS;
        public Rule(int num,Token from, Token[] to)
        {
            this.num = num;
            this.LHS = from;
            this.RHS = to;
        }
    }
}
