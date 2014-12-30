using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class TreeNode
    {
        public readonly NodeType nodeType;
        public readonly TokenType nodeType2;
        public readonly List<TreeNode> childs;
        public readonly string value;
        public TreeNode(NodeType nodeType,string value)
        {
            this.nodeType = nodeType;
            this.childs = new List<TreeNode>();
            this.value = value;
        }
        public TreeNode(TokenType nodeType, string value)
        {
            this.nodeType2 = nodeType;
            this.childs = new List<TreeNode>();
            this.value = value;
        }
        public void addChilds(TreeNode child)
        {
            childs.Add(child);
        }
    }
}
