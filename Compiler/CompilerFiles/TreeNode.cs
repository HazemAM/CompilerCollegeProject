using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class TreeNode
    {
        
        public readonly List<TreeNode> childs;
        public readonly string value;
        
        public TreeNode(string value)
        {
            this.childs = new List<TreeNode>();
            this.value = value;
        }
        public void addChilds(TreeNode child)
        {
            childs.Add(child);
        }
    }
}
