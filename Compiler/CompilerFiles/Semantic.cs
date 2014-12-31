using NCalc;
namespace Compiler
{
    class Semantic
    {
        public static void GetSemanticTree(System.Windows.Forms.TreeNode Node)
        {
            //Recurse;
            for(int i=0; i<Node.Nodes.Count; i++)
            {
                GetSemanticTree(Node.Nodes[i]);
            }

            //Do it:
            if(Node.Text == "assignSt")
            {
                Node.Text += ' '+(string)Node.Tag;
            }
            else if(Node.Text == "Smpexp")
            {
                string summary = (string)Node.Tag;
                //double result = 0;

                //if(summary != string.Empty)
                //    result = (int) new Expression(summary).Evaluate();

                //if(summary.Contains("+"))
                //    result = sum(summary.Split('+'));
                //else if(summary.Contains("-"))
                //    result = mul(summary.Split('-'));
                //else if(summary.Contains("*"))
                //    result = mul(summary.Split('*'));
                //else if(summary.Contains("/"))
                //    result = mul(summary.Split('/'));
                //else{
                //    try { result = int.Parse(summary); }
                //    catch { }
                //}

                //if(result!=0)
                    Node.Text += ' '+(string)Node.Tag; //+" = "+result.ToString()
            }
            else if (Node.Nodes.Count == 0)
            {
                try
                {
                    int num = int.Parse(Node.Text);
                    Node.Parent.Tag += num.ToString();
                    return;
                }
                catch { }
            }
           
            if (Node.Text.StartsWith("addOp") || Node.Text.StartsWith("mulOp"))
                Node.Parent.Tag += Node.Nodes[0].Text;
            else
                if(Node.Parent != null)
                    Node.Parent.Tag += (string)Node.Tag;

        }

        private static double sum(string[] arr)
        {
            double result = double.Parse(arr[0]);
            for(int i=1; i<arr.Length; i++)
                result += double.Parse(arr[i]);
            
            return result;
        }

        private static double neg(string[] arr)
        {
            double result = double.Parse(arr[0]);
            for(int i=1; i<arr.Length; i++)
                result -= double.Parse(arr[i]);
            
            return result;
        }

        private static double mul(string[] arr)
        {
            double result = double.Parse(arr[0]);
            for(int i=1; i<arr.Length; i++)
                result *= double.Parse(arr[i]);
            
            return result;
        }

        private static double div(string[] arr)
        {
            double result = double.Parse(arr[0]);
            for(int i=1; i<arr.Length; i++)
                result /= double.Parse(arr[i]);
            
            return result;
        }
    }
}
