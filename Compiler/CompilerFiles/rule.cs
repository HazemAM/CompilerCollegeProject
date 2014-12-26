using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class rule
    {
        //left side of the rule
        Token from;
        //reversed right side of the rule
        Token[] to;
        public rule(Token from, Token[] to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
