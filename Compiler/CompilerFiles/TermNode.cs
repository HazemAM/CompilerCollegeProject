using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class TermNode : TreeNode
    {
        public readonly TokenType nodeType;
        public TermNode(TokenType nodeType, string value) : base(value)
        {
            this.nodeType = nodeType;
        }
    }
}
