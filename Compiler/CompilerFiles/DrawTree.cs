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
            System.Windows.Forms.TreeNode T1 = new System.Windows.Forms.TreeNode();
            System.Windows.Forms.TreeNode T2 = new System.Windows.Forms.TreeNode();
            //switch (Node.nodeType)
            //{
            //    case NodeType.Statements:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Statements";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.If:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "If";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Then:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Then";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        if (OpNode.rightNode != null)
            //            DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Else:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Else";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        //if (OpNode.rightNode != null)
            //        //    DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        // DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Add:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "+";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Sub:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "-";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Mul:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "*";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Divide:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "/";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Assign:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = ":=";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Equal:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "=";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.GreaterThan:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = ">";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.LessThan:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "<";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Exp:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Exp";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        // DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.factor:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Factor";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.SimpleExp:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Simple Exp";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.TermMul:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Term Mul";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Term:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Term";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Read:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Read";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Write:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Write";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Repeat:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Repeat";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        DisplayParseTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Until:
            //        OpNode = (TreeNode)Node;
            //        DisplayNode.Text = "Until";
            //        DisplayParseTree((TreeNode)OpNode.leftNode, T1);
            //        // DisplayTree((TreeNode)OpNode.rightNode, T2);
            //        DisplayNode.Nodes.Add(T1);
            //        //DisplayNode.Nodes.Add(T2);
            //        break;
            //    case NodeType.Number:
            //        DisplayNode.Text = Node.value;
            //        break;
            //    //case NodeType.Float:
            //    //    DisplayNode.Text = Node.value;
            //    //    break;
            //    case NodeType.ID:
            //        DisplayNode.Text = Node.value;
            //        break;

            //}
        }

    }
}
