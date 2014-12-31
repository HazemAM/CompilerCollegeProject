using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    public partial class MainForm : Form
    {
        Lexical lexical;

        public MainForm()
        {
            InitializeComponent();
            
            //Constructing the Lexical object:
            lexical = new Lexical("..\\..\\DFATable.txt");
        }

        private void btnRun_Click(object sender, EventArgs e){
            tableLog.Items.Clear(); //Clear old log.
            
            /** LEXICAL ANALYSIS */
            //Analyze input code:
            bool lexicalSuccess;
            List<Token> tokens = lexical.analyze(txtCode.Text, out lexicalSuccess);
            
            List<string[]> log = lexical.getLog();
            foreach(string[] row in log)
                tableLog.Items.Add(new ListViewItem(row));
            tableLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            if(!lexicalSuccess){
                MessageBox.Show("This code contains lexical error(s).", "Lexical errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            /** SYNTAX ANALYSIS */
            Syntax syntax = new Syntax(tokens);
            TreeNode tree = syntax.getTree();

            if(syntax.errors.Count != 0){
                string errors = "The following symantic errors found:\n";
                foreach(string error in syntax.errors)
                    errors += error+'\n';
                MessageBox.Show(errors, "Symantic errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Syntax tree:
            TreeForm treeForm = new TreeForm();
            System.Windows.Forms.TreeNode root = treeForm.treeSyntax.GetNodeAt(0,0);
            DrawTree.DisplayParseTree(tree, root);
            treeForm.Text = "Syntax Tree";
            treeForm.Show();


            /** SEMANTIC ANALYSIS */
            Semantic.GetSemanticTree( treeForm.treeSyntax.GetNodeAt(0,0) );
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e){
            if(e.Control && e.KeyCode==Keys.A)
                (sender as TextBox).SelectAll();
        }
    }
}
