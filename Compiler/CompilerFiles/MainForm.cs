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
            
            //Analyze input code:
            lexical.analyze(txtCode.Text);
            
            List<string[]> log = lexical.getLog();
            foreach(string[] row in log)
                tableLog.Items.Add(new ListViewItem(row));
            tableLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e){
            if(e.Control && e.KeyCode==Keys.A)
                (sender as TextBox).SelectAll();
        }
    }
}
