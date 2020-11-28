namespace Qwiz
{
    partial class QwizForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QwizForm));
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.txtQuest = new System.Windows.Forms.TextBox();
            this.lstGroups = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsHome = new System.Windows.Forms.ToolStripButton();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnA.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.ForeColor = System.Drawing.Color.Black;
            this.btnA.Location = new System.Drawing.Point(115, 435);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(469, 39);
            this.btnA.TabIndex = 1;
            this.btnA.Text = "תשובה א";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnB
            // 
            this.btnB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnB.ForeColor = System.Drawing.Color.Black;
            this.btnB.Location = new System.Drawing.Point(115, 495);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(469, 39);
            this.btnB.TabIndex = 2;
            this.btnB.Text = "Answer B";
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnD
            // 
            this.btnD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnD.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnD.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnD.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD.ForeColor = System.Drawing.Color.Black;
            this.btnD.Location = new System.Drawing.Point(115, 615);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(469, 39);
            this.btnD.TabIndex = 4;
            this.btnD.Text = "Answer D";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnC
            // 
            this.btnC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.ForeColor = System.Drawing.Color.Black;
            this.btnC.Location = new System.Drawing.Point(115, 555);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(469, 39);
            this.btnC.TabIndex = 3;
            this.btnC.Text = "Answer C";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // txtQuest
            // 
            this.txtQuest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuest.BackColor = System.Drawing.Color.White;
            this.txtQuest.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuest.ForeColor = System.Drawing.Color.Black;
            this.txtQuest.Location = new System.Drawing.Point(13, 40);
            this.txtQuest.Multiline = true;
            this.txtQuest.Name = "txtQuest";
            this.txtQuest.Size = new System.Drawing.Size(703, 376);
            this.txtQuest.TabIndex = 5;
            this.txtQuest.Text = "זו השאלה";
            this.txtQuest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstGroups
            // 
            this.lstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGroups.GridLines = true;
            this.lstGroups.HideSelection = false;
            this.lstGroups.Location = new System.Drawing.Point(734, 40);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(350, 614);
            this.lstGroups.TabIndex = 7;
            this.lstGroups.UseCompatibleStateImageBehavior = false;
            this.lstGroups.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHome,
            this.tsNext,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1097, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsHome
            // 
            this.tsHome.Image = ((System.Drawing.Image)(resources.GetObject("tsHome.Image")));
            this.tsHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHome.Name = "tsHome";
            this.tsHome.Size = new System.Drawing.Size(74, 24);
            this.tsHome.Text = "Home";
            this.tsHome.Click += new System.EventHandler(this.tsHome_Click);
            // 
            // tsNext
            // 
            this.tsNext.Image = ((System.Drawing.Image)(resources.GetObject("tsNext.Image")));
            this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(118, 24);
            this.tsNext.Text = "Next (Space)";
            this.tsNext.Click += new System.EventHandler(this.tsNext_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(108, 24);
            this.toolStripLabel1.Text = "© Inbar Rotem";
            // 
            // QwizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 678);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.txtQuest);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "QwizForm";
            this.Text = "Qwiz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuestForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuestForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.TextBox txtQuest;
        private System.Windows.Forms.ListView lstGroups;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsHome;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

