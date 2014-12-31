using System.Linq;

namespace Compiler
{
    class DrawTree
    {
        public static void DisplayParseTree(TreeNode Node, System.Windows.Forms.TreeNode DisplayNode)
        {
            DisplayNode.Text = Node.value;

            for(int i=0; i<Node.childs.Count; i++)
            {
                System.Windows.Forms.TreeNode newNode = new System.Windows.Forms.TreeNode();
                DisplayParseTree(Node.childs.ElementAt(i), newNode);
                DisplayNode.Nodes.Add(newNode);
            }
        }
    }
}
