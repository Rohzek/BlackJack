namespace Blackjack
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gameStartButton = new System.Windows.Forms.Button();
            this.resetHands = new System.Windows.Forms.Button();
            this.winnerAnnounce = new System.Windows.Forms.TextBox();
            this.betDisplay = new System.Windows.Forms.TextBox();
            this.decreaseBetButton = new System.Windows.Forms.Button();
            this.increaseBetButton = new System.Windows.Forms.Button();
            this.betConfirmButton = new System.Windows.Forms.Button();
            this.playerMoneyLabel = new System.Windows.Forms.Label();
            this.playerMoneyDisplay = new System.Windows.Forms.TextBox();
            this.buttonSplit = new System.Windows.Forms.Button();
            this.playerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDouble = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.playerLabel = new System.Windows.Forms.Label();
            this.buttonHit = new System.Windows.Forms.Button();
            this.buttonSurrender = new System.Windows.Forms.Button();
            this.playerValue = new System.Windows.Forms.TextBox();
            this.dealerLabel = new System.Windows.Forms.Label();
            this.dealerValue = new System.Windows.Forms.TextBox();
            this.dealerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.insuranceButton = new System.Windows.Forms.Button();
            this.borrowMoney = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameStartButton
            // 
            this.gameStartButton.Location = new System.Drawing.Point(12, 12);
            this.gameStartButton.Name = "gameStartButton";
            this.gameStartButton.Size = new System.Drawing.Size(206, 46);
            this.gameStartButton.TabIndex = 11;
            this.gameStartButton.TabStop = false;
            this.gameStartButton.Text = "Start Game";
            this.gameStartButton.UseVisualStyleBackColor = true;
            this.gameStartButton.Click += new System.EventHandler(this.gameStartButton_Click);
            // 
            // resetHands
            // 
            this.resetHands.Location = new System.Drawing.Point(1046, 12);
            this.resetHands.Name = "resetHands";
            this.resetHands.Size = new System.Drawing.Size(206, 46);
            this.resetHands.TabIndex = 12;
            this.resetHands.TabStop = false;
            this.resetHands.Text = "Next Hand";
            this.resetHands.UseVisualStyleBackColor = true;
            this.resetHands.Click += new System.EventHandler(this.resetHands_Click);
            // 
            // winnerAnnounce
            // 
            this.winnerAnnounce.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.winnerAnnounce.Location = new System.Drawing.Point(549, 65);
            this.winnerAnnounce.Name = "winnerAnnounce";
            this.winnerAnnounce.ReadOnly = true;
            this.winnerAnnounce.ShortcutsEnabled = false;
            this.winnerAnnounce.Size = new System.Drawing.Size(167, 20);
            this.winnerAnnounce.TabIndex = 20;
            this.winnerAnnounce.TabStop = false;
            this.winnerAnnounce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.winnerAnnounce.WordWrap = false;
            // 
            // betDisplay
            // 
            this.betDisplay.Location = new System.Drawing.Point(12, 64);
            this.betDisplay.Name = "betDisplay";
            this.betDisplay.ReadOnly = true;
            this.betDisplay.Size = new System.Drawing.Size(65, 20);
            this.betDisplay.TabIndex = 21;
            this.betDisplay.TabStop = false;
            this.betDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // decreaseBetButton
            // 
            this.decreaseBetButton.Location = new System.Drawing.Point(83, 64);
            this.decreaseBetButton.Name = "decreaseBetButton";
            this.decreaseBetButton.Size = new System.Drawing.Size(65, 20);
            this.decreaseBetButton.TabIndex = 22;
            this.decreaseBetButton.TabStop = false;
            this.decreaseBetButton.Text = "Decrease";
            this.decreaseBetButton.UseVisualStyleBackColor = true;
            this.decreaseBetButton.Click += new System.EventHandler(this.decreaseBetButton_Click);
            // 
            // increaseBetButton
            // 
            this.increaseBetButton.Location = new System.Drawing.Point(153, 64);
            this.increaseBetButton.Name = "increaseBetButton";
            this.increaseBetButton.Size = new System.Drawing.Size(65, 20);
            this.increaseBetButton.TabIndex = 23;
            this.increaseBetButton.TabStop = false;
            this.increaseBetButton.Text = "Increase";
            this.increaseBetButton.UseVisualStyleBackColor = true;
            this.increaseBetButton.Click += new System.EventHandler(this.increaseBetButton_Click);
            // 
            // betConfirmButton
            // 
            this.betConfirmButton.Location = new System.Drawing.Point(12, 90);
            this.betConfirmButton.Name = "betConfirmButton";
            this.betConfirmButton.Size = new System.Drawing.Size(206, 20);
            this.betConfirmButton.TabIndex = 24;
            this.betConfirmButton.Text = "Confirm Bet";
            this.betConfirmButton.UseVisualStyleBackColor = true;
            this.betConfirmButton.Click += new System.EventHandler(this.betConfirmButton_Click);
            // 
            // playerMoneyLabel
            // 
            this.playerMoneyLabel.AutoSize = true;
            this.playerMoneyLabel.Location = new System.Drawing.Point(12, 119);
            this.playerMoneyLabel.Name = "playerMoneyLabel";
            this.playerMoneyLabel.Size = new System.Drawing.Size(74, 13);
            this.playerMoneyLabel.TabIndex = 25;
            this.playerMoneyLabel.Text = "Player Money:";
            // 
            // playerMoneyDisplay
            // 
            this.playerMoneyDisplay.Location = new System.Drawing.Point(92, 116);
            this.playerMoneyDisplay.Name = "playerMoneyDisplay";
            this.playerMoneyDisplay.ReadOnly = true;
            this.playerMoneyDisplay.Size = new System.Drawing.Size(126, 20);
            this.playerMoneyDisplay.TabIndex = 26;
            this.playerMoneyDisplay.TabStop = false;
            // 
            // buttonSplit
            // 
            this.buttonSplit.Location = new System.Drawing.Point(741, 517);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(206, 46);
            this.buttonSplit.TabIndex = 17;
            this.buttonSplit.TabStop = false;
            this.buttonSplit.Text = "Split";
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // playerHand
            // 
            this.playerHand.AutoScroll = true;
            this.playerHand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerHand.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.playerHand.BackgroundImage = global::Blackjack.Properties.Resources.transparency;
            this.playerHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerHand.Location = new System.Drawing.Point(444, 322);
            this.playerHand.Name = "playerHand";
            this.playerHand.Size = new System.Drawing.Size(377, 172);
            this.playerHand.TabIndex = 4;
            this.playerHand.WrapContents = false;
            this.playerHand.Paint += new System.Windows.Forms.PaintEventHandler(this.playerHand_Paint);
            // 
            // buttonDouble
            // 
            this.buttonDouble.Location = new System.Drawing.Point(529, 517);
            this.buttonDouble.Name = "buttonDouble";
            this.buttonDouble.Size = new System.Drawing.Size(206, 46);
            this.buttonDouble.TabIndex = 13;
            this.buttonDouble.TabStop = false;
            this.buttonDouble.Text = "Double Down";
            this.buttonDouble.UseVisualStyleBackColor = true;
            this.buttonDouble.Click += new System.EventHandler(this.buttonDouble_Click);
            // 
            // buttonStand
            // 
            this.buttonStand.Location = new System.Drawing.Point(637, 569);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(206, 46);
            this.buttonStand.TabIndex = 16;
            this.buttonStand.TabStop = false;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = true;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click);
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(307, 411);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(66, 13);
            this.playerLabel.TabIndex = 10;
            this.playerLabel.Text = "Hand Value:";
            // 
            // buttonHit
            // 
            this.buttonHit.Location = new System.Drawing.Point(317, 517);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(206, 46);
            this.buttonHit.TabIndex = 6;
            this.buttonHit.TabStop = false;
            this.buttonHit.Text = "Hit";
            this.buttonHit.UseVisualStyleBackColor = true;
            this.buttonHit.Click += new System.EventHandler(this.buttonHit_Click);
            // 
            // buttonSurrender
            // 
            this.buttonSurrender.Location = new System.Drawing.Point(425, 569);
            this.buttonSurrender.Name = "buttonSurrender";
            this.buttonSurrender.Size = new System.Drawing.Size(206, 46);
            this.buttonSurrender.TabIndex = 15;
            this.buttonSurrender.TabStop = false;
            this.buttonSurrender.Text = "Surrender";
            this.buttonSurrender.UseVisualStyleBackColor = true;
            this.buttonSurrender.Click += new System.EventHandler(this.buttonSurrender_Click);
            // 
            // playerValue
            // 
            this.playerValue.Location = new System.Drawing.Point(379, 408);
            this.playerValue.Name = "playerValue";
            this.playerValue.ReadOnly = true;
            this.playerValue.Size = new System.Drawing.Size(59, 20);
            this.playerValue.TabIndex = 9;
            this.playerValue.TabStop = false;
            this.playerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dealerLabel
            // 
            this.dealerLabel.AutoSize = true;
            this.dealerLabel.Location = new System.Drawing.Point(307, 213);
            this.dealerLabel.Name = "dealerLabel";
            this.dealerLabel.Size = new System.Drawing.Size(66, 13);
            this.dealerLabel.TabIndex = 12;
            this.dealerLabel.Text = "Hand Value:";
            // 
            // dealerValue
            // 
            this.dealerValue.Location = new System.Drawing.Point(379, 210);
            this.dealerValue.Name = "dealerValue";
            this.dealerValue.ReadOnly = true;
            this.dealerValue.Size = new System.Drawing.Size(59, 20);
            this.dealerValue.TabIndex = 11;
            this.dealerValue.TabStop = false;
            this.dealerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dealerHand
            // 
            this.dealerHand.AutoScroll = true;
            this.dealerHand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dealerHand.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.dealerHand.BackgroundImage = global::Blackjack.Properties.Resources.transparency;
            this.dealerHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dealerHand.Location = new System.Drawing.Point(444, 144);
            this.dealerHand.Name = "dealerHand";
            this.dealerHand.Size = new System.Drawing.Size(377, 172);
            this.dealerHand.TabIndex = 10;
            this.dealerHand.WrapContents = false;
            // 
            // insuranceButton
            // 
            this.insuranceButton.Location = new System.Drawing.Point(853, 209);
            this.insuranceButton.Name = "insuranceButton";
            this.insuranceButton.Size = new System.Drawing.Size(75, 20);
            this.insuranceButton.TabIndex = 13;
            this.insuranceButton.TabStop = false;
            this.insuranceButton.Text = "Insurance";
            this.insuranceButton.UseVisualStyleBackColor = true;
            this.insuranceButton.Click += new System.EventHandler(this.insuranceButton_Click);
            // 
            // borrowMoney
            // 
            this.borrowMoney.Location = new System.Drawing.Point(1164, 649);
            this.borrowMoney.Name = "borrowMoney";
            this.borrowMoney.Size = new System.Drawing.Size(88, 20);
            this.borrowMoney.TabIndex = 27;
            this.borrowMoney.TabStop = false;
            this.borrowMoney.Text = "Borrow $200";
            this.borrowMoney.UseVisualStyleBackColor = true;
            this.borrowMoney.Click += new System.EventHandler(this.borrowMoney_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blackjack.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.borrowMoney);
            this.Controls.Add(this.buttonSplit);
            this.Controls.Add(this.insuranceButton);
            this.Controls.Add(this.playerHand);
            this.Controls.Add(this.buttonDouble);
            this.Controls.Add(this.playerMoneyDisplay);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.dealerHand);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.dealerValue);
            this.Controls.Add(this.buttonHit);
            this.Controls.Add(this.playerMoneyLabel);
            this.Controls.Add(this.buttonSurrender);
            this.Controls.Add(this.dealerLabel);
            this.Controls.Add(this.playerValue);
            this.Controls.Add(this.betConfirmButton);
            this.Controls.Add(this.increaseBetButton);
            this.Controls.Add(this.decreaseBetButton);
            this.Controls.Add(this.betDisplay);
            this.Controls.Add(this.winnerAnnounce);
            this.Controls.Add(this.resetHands);
            this.Controls.Add(this.gameStartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Blackjack";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel playerHand;
        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.TextBox playerValue;
        private System.Windows.Forms.Button gameStartButton;
        private System.Windows.Forms.Button resetHands;
        private System.Windows.Forms.Button buttonDouble;
        private System.Windows.Forms.Button buttonSurrender;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.TextBox winnerAnnounce;
        private System.Windows.Forms.TextBox betDisplay;
        private System.Windows.Forms.Button decreaseBetButton;
        private System.Windows.Forms.Button increaseBetButton;
        private System.Windows.Forms.Button betConfirmButton;
        private System.Windows.Forms.Label playerMoneyLabel;
        private System.Windows.Forms.TextBox playerMoneyDisplay;
        private System.Windows.Forms.Button buttonSplit;
        private System.Windows.Forms.Label dealerLabel;
        private System.Windows.Forms.TextBox dealerValue;
        private System.Windows.Forms.FlowLayoutPanel dealerHand;
        private System.Windows.Forms.Button insuranceButton;
        private System.Windows.Forms.Button borrowMoney;
    }
}

