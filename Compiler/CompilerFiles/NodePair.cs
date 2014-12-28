using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    struct NodePair
    {
        public int FromNode;
        public string Input;

        public NodePair(int FromNode, string Input)
        {
            this.FromNode = FromNode;
            this.Input = Input;
        }
    }
}
