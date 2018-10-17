using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Blackjack.Classes;

namespace Blackjack
{
    /**
     * Class for handling the GUI of the Split window,
     * Is set up to be similar to main class
     */
    public partial class Split : Form
    {
        Main main;
        IList<Card> playerHand = Deck.GetPlayerSplitHand();
        bool standing = false;

        public Split()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) // Add auto saving when X is clicked
        {
            e.Cancel = true;

            standing = true;
            this.Hide();

        }

        private void buttonHit_Click(object sender, EventArgs e)
        {
            main.DrawCard(playerHand, buttonHit, buttonDouble);
            UpdateHands();
        }

        private void buttonDouble_Click(object sender, EventArgs e)
        {
            main.DrawCard(playerHand, buttonHit, buttonDouble);
            UpdateHands();
            buttonHit.Enabled = false;
            buttonDouble.Enabled = false;
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            buttonHit.Enabled = false;
            buttonDouble.Enabled = false;
            buttonStand.Enabled = false;

            standing = true;

            if (standing && main.getStanding())
            {
                main.EndPlayerRound();
                main.DealerRound();
            }
        }

        public void resetButtons()
        {
            buttonHit.Enabled = true;
            buttonDouble.Enabled = true;
            buttonStand.Enabled = true;
        }

        public void UpdateHands()
        {
            Deck.RefreshDisplay(playerHandSplit, playerHand);

            playerValue.Text = Deck.Value(playerHand);
        }

        public TransparencyPanel getPlayerHand()
        {
            return playerHandSplit;
        }

        public TextBox getSplitHandValue()
        {
            return playerValue;
        }

        public Button getHitButton()
        {
            return buttonHit;
        }

        public Button getDoubleButton()
        {
            return buttonDouble;
        }

        public Button getStandButton()
        {
            return buttonStand;
        }

        public TextBox getAnnounce()
        {
            return winnerAnnounce;
        }

        public bool getStanding()
        {
            return standing;
        }

        public void setStanding(bool newValue)
        {
            standing = newValue;
        }

        public void setMain(Main provided)
        {
            main = provided;
        }
    }
}
