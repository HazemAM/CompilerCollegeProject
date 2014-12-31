namespace Compiler
{
    partial class TreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Statements");
            this.treeSyntax = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeSyntax
            // 
            this.treeSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSyntax.Location = new System.Drawing.Point(0, 0);
            this.treeSyntax.Name = "treeSyntax";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Statements";
            this.treeSyntax.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeSyntax.Size = new System.Drawing.Size(424, 394);
            this.treeSyntax.TabIndex = 0;
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 394);
            this.Controls.Add(this.treeSyntax);
            this.Name = "TreeForm";
            this.Text = "TreeForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeSyntax;


    }
}