namespace Blackjack
{
    partial class Split
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Split));
            this.winnerAnnounce = new System.Windows.Forms.TextBox();
            this.playerValue = new System.Windows.Forms.TextBox();
            this.buttonHit = new System.Windows.Forms.Button();
            this.playerLabel = new System.Windows.Forms.Label();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonDouble = new System.Windows.Forms.Button();
            this.playerHandSplit = new Blackjack.TransparencyPanel();
            this.SuspendLayout();
            // 
            // winnerAnnounce
            // 
            this.winnerAnnounce.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.winnerAnnounce.Location = new System.Drawing.Point(252, 12);
            this.winnerAnnounce.Name = "winnerAnnounce";
            this.winnerAnnounce.ReadOnly = true;
            this.winnerAnnounce.ShortcutsEnabled = false;
            this.winnerAnnounce.Size = new System.Drawing.Size(167, 20);
            this.winnerAnnounce.TabIndex = 21;
            this.winnerAnnounce.TabStop = false;
            this.winnerAnnounce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.winnerAnnounce.WordWrap = false;
            // 
            // playerValue
            // 
            this.playerValue.Location = new System.Drawing.Point(87, 124);
            this.playerValue.Name = "playerValue";
            this.playerValue.ReadOnly = true;
            this.playerValue.Size = new System.Drawing.Size(59, 20);
            this.playerValue.TabIndex = 9;
            this.playerValue.TabStop = false;
            this.playerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonHit
            // 
            this.buttonHit.Location = new System.Drawing.Point(25, 233);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(206, 46);
            this.buttonHit.TabIndex = 6;
            this.buttonHit.TabStop = false;
            this.buttonHit.Text = "Hit";
            this.buttonHit.UseVisualStyleBackColor = true;
            this.buttonHit.Click += new System.EventHandler(this.buttonHit_Click);
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(15, 127);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(66, 13);
            this.playerLabel.TabIndex = 10;
            this.playerLabel.Text = "Hand Value:";
            // 
            // buttonStand
            // 
            this.buttonStand.Location = new System.Drawing.Point(449, 233);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(206, 46);
            this.buttonStand.TabIndex = 16;
            this.buttonStand.TabStop = false;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = true;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click);
            // 
            // buttonDouble
            // 
            this.buttonDouble.Location = new System.Drawing.Point(237, 233);
            this.buttonDouble.Name = "buttonDouble";
            this.buttonDouble.Size = new System.Drawing.Size(206, 46);
            this.buttonDouble.TabIndex = 13;
            this.buttonDouble.TabStop = false;
            this.buttonDouble.Text = "Double Down";
            this.buttonDouble.UseVisualStyleBackColor = true;
            this.buttonDouble.Click += new System.EventHandler(this.buttonDouble_Click);
            // 
            // playerHandSplit
            // 
            this.playerHandSplit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerHandSplit.Location = new System.Drawing.Point(152, 38);
            this.playerHandSplit.Name = "playerHandSplit";
            this.playerHandSplit.Opacity = 0;
            this.playerHandSplit.Size = new System.Drawing.Size(377, 172);
            this.playerHandSplit.TabIndex = 22;
            // 
            // Split
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blackjack.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(671, 297);
            this.Controls.Add(this.playerHandSplit);
            this.Controls.Add(this.buttonDouble);
            this.Controls.Add(this.winnerAnnounce);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.playerValue);
            this.Controls.Add(this.buttonHit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Split";
            this.Text = "Split";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox winnerAnnounce;
        private System.Windows.Forms.TextBox playerValue;
        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonDouble;
        private TransparencyPanel playerHandSplit;
    }
}