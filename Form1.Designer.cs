namespace MoodleExamConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            txtSource = new TextBox();
            txtDest = new TextBox();
            btnConvert = new Button();
            btnRemoveBlankLine = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtSource);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtDest);
            splitContainer1.Size = new Size(1527, 719);
            splitContainer1.SplitterDistance = 747;
            splitContainer1.TabIndex = 0;
            // 
            // txtSource
            // 
            txtSource.Dock = DockStyle.Fill;
            txtSource.Location = new Point(0, 0);
            txtSource.Multiline = true;
            txtSource.Name = "txtSource";
            txtSource.ScrollBars = ScrollBars.Both;
            txtSource.Size = new Size(747, 719);
            txtSource.TabIndex = 0;
            txtSource.Text = resources.GetString("txtSource.Text");
            // 
            // txtDest
            // 
            txtDest.Dock = DockStyle.Fill;
            txtDest.Location = new Point(0, 0);
            txtDest.Multiline = true;
            txtDest.Name = "txtDest";
            txtDest.ScrollBars = ScrollBars.Both;
            txtDest.Size = new Size(776, 719);
            txtDest.TabIndex = 1;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Bottom;
            btnConvert.Location = new Point(617, 745);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(297, 34);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert to Moodle Format";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // btnRemoveBlankLine
            // 
            btnRemoveBlankLine.Location = new Point(1174, 744);
            btnRemoveBlankLine.Name = "btnRemoveBlankLine";
            btnRemoveBlankLine.Size = new Size(226, 34);
            btnRemoveBlankLine.TabIndex = 2;
            btnRemoveBlankLine.Text = "Remove Blank Line";
            btnRemoveBlankLine.UseVisualStyleBackColor = true;
            btnRemoveBlankLine.Click += btnRemoveBlankLine_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 791);
            Controls.Add(btnRemoveBlankLine);
            Controls.Add(btnConvert);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtSource;
        private TextBox txtDest;
        private Button btnConvert;
        private Button btnRemoveBlankLine;
    }
}