namespace HLO
{
    partial class Form1
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.columnCheck = new System.Windows.Forms.CheckBox();
            this.framingCheck = new System.Windows.Forms.CheckBox();
            this.wallCheck = new System.Windows.Forms.CheckBox();
            this.slabCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.foundationCheck = new System.Windows.Forms.CheckBox();
            this.shaftCheck = new System.Windows.Forms.CheckBox();
            this.stairsCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(265, 118);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // columnCheck
            // 
            this.columnCheck.AutoSize = true;
            this.columnCheck.Location = new System.Drawing.Point(6, 11);
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.columnCheck.Size = new System.Drawing.Size(114, 17);
            this.columnCheck.TabIndex = 4;
            this.columnCheck.Text = "Structural Columns";
            this.columnCheck.UseVisualStyleBackColor = true;
            this.columnCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // framingCheck
            // 
            this.framingCheck.AutoSize = true;
            this.framingCheck.Location = new System.Drawing.Point(129, 11);
            this.framingCheck.Name = "framingCheck";
            this.framingCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.framingCheck.Size = new System.Drawing.Size(111, 17);
            this.framingCheck.TabIndex = 5;
            this.framingCheck.Text = "Structural Framing";
            this.framingCheck.UseVisualStyleBackColor = true;
            this.framingCheck.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // wallCheck
            // 
            this.wallCheck.AutoSize = true;
            this.wallCheck.Location = new System.Drawing.Point(246, 12);
            this.wallCheck.Name = "wallCheck";
            this.wallCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.wallCheck.Size = new System.Drawing.Size(100, 17);
            this.wallCheck.TabIndex = 6;
            this.wallCheck.Text = "Structural Walls";
            this.wallCheck.UseVisualStyleBackColor = true;
            this.wallCheck.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // slabCheck
            // 
            this.slabCheck.AutoSize = true;
            this.slabCheck.Location = new System.Drawing.Point(188, 44);
            this.slabCheck.Name = "slabCheck";
            this.slabCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.slabCheck.Size = new System.Drawing.Size(52, 17);
            this.slabCheck.TabIndex = 7;
            this.slabCheck.Text = "Slabs";
            this.slabCheck.UseVisualStyleBackColor = true;
            this.slabCheck.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Please indicate which categories";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "you would like to assign. Standard workset names will be used.";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // foundationCheck
            // 
            this.foundationCheck.AutoSize = true;
            this.foundationCheck.Location = new System.Drawing.Point(267, 44);
            this.foundationCheck.Name = "foundationCheck";
            this.foundationCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.foundationCheck.Size = new System.Drawing.Size(79, 17);
            this.foundationCheck.TabIndex = 16;
            this.foundationCheck.Text = "Foundation";
            this.foundationCheck.UseVisualStyleBackColor = true;
            this.foundationCheck.CheckedChanged += new System.EventHandler(this.foundationCheck_CheckedChanged);
            // 
            // shaftCheck
            // 
            this.shaftCheck.AutoSize = true;
            this.shaftCheck.Location = new System.Drawing.Point(64, 44);
            this.shaftCheck.Name = "shaftCheck";
            this.shaftCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.shaftCheck.Size = new System.Drawing.Size(56, 17);
            this.shaftCheck.TabIndex = 17;
            this.shaftCheck.Text = "Shafts";
            this.shaftCheck.UseVisualStyleBackColor = true;
            this.shaftCheck.CheckedChanged += new System.EventHandler(this.shaftCheck_CheckedChanged);
            // 
            // stairsCheck
            // 
            this.stairsCheck.AutoSize = true;
            this.stairsCheck.Location = new System.Drawing.Point(294, 79);
            this.stairsCheck.Name = "stairsCheck";
            this.stairsCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stairsCheck.Size = new System.Drawing.Size(52, 17);
            this.stairsCheck.TabIndex = 18;
            this.stairsCheck.Text = "Stairs";
            this.stairsCheck.UseVisualStyleBackColor = true;
            this.stairsCheck.CheckedChanged += new System.EventHandler(this.stairsCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 161);
            this.Controls.Add(this.stairsCheck);
            this.Controls.Add(this.shaftCheck);
            this.Controls.Add(this.foundationCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.slabCheck);
            this.Controls.Add(this.wallCheck);
            this.Controls.Add(this.framingCheck);
            this.Controls.Add(this.columnCheck);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "Form1";
            this.Text = "Workset Assigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.CheckBox columnCheck;
        private System.Windows.Forms.CheckBox framingCheck;
        private System.Windows.Forms.CheckBox wallCheck;
        private System.Windows.Forms.CheckBox slabCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox foundationCheck;
        private System.Windows.Forms.CheckBox shaftCheck;
        private System.Windows.Forms.CheckBox stairsCheck;
    }
}