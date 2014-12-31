using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Compiler
{
    class DrawTree
    {
        public static void DisplayParseTree(TreeNode Node, System.Windows.Forms.TreeNode DisplayNode)
        {
            TreeNode OpNode;

            int count = Node.childs.Count;

            OpNode = (TreeNode)Node;
            DisplayNode.Text = OpNode.value;

            for(int i=0; i<Node.childs.Count; i++)
            {
                System.Windows.Forms.TreeNode newNode = new System.Windows.Forms.TreeNode();
                DisplayParseTree(Node.childs.ElementAt(i), newNode);
                DisplayNode.Nodes.Add(newNode);
            }
        }

    }
}
