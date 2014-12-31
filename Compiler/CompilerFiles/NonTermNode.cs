using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class NonTermNode : TreeNode
    {
        public readonly NodeType nodeType;
        public NonTermNode(NodeType nodeType, string value) : base(value)
        {
            this.nodeType = nodeType;
        }
        public NodeType getType()
        {
            return nodeType;
        }
    }

}
