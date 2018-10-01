using System.Collections.Generic;
using System.Windows.Forms;
using Blackjack.Classes;

using System.Diagnostics;
using System.Threading;

namespace Blackjack
{
    public partial class Main : Form
    {
        Split splitWindow;

        IList<Card> deck;
        IList<Card> dealersHand = Deck.getDealerHand();
        IList<Card> playersHand = Deck.getPlayerHand();
        IList<Card> playersSplitHand = Deck.getPlayerSplitHand();

        Button[] playerControls;

        bool playerBlackjack, dealerBlackjack, gameStarted = false, doubleDown = false, splitPlay = false, standing = false;

        string playerWin = "PLAYER WINS", dealerWin = "DEALER WINS", push = "PUSH", surrender = "PLAYER SURRENDERS", progress = "GAME IN PROGRESS", needBet = "NO BET SUBMITTED", waiting = "WAITING TO START", noMoney = "NOT ENOUGH MONEY TO BET";

        Betting betting;

        private void Form1_Load(object sender, System.EventArgs e) { }

        /*
         * Writes current data to memory before closing the program
         */
        protected override void OnFormClosing(FormClosingEventArgs e) // Add auto saving when X is clicked
        {
            Saving.writeFile(betting);

            Application.Exit();
        }

        public Main()
        {
            InitializeComponent();
            init();
            splitWindow = new Split();
            splitWindow.setMain(this);
        }

        // Set up default values
        void init()
        {
            // Check for save, if exists then load it
            if (Saving.checkForSave())
            {
                betting = Saving.readSave();
            }
            else // Else create new file
            {
                betting = new Betting(2000, 10, 5); // Player starts with $2000
            }
            
            winnerAnnounce.Text = needBet;
            betting.Bet = 10; // Lowest bet allowed is $10
            refreshBets();

            deck = Deck.getDeck();
            Deck.Shuffle(deck);

            playerControls = new Button[] { buttonHit, buttonDouble, buttonSurrender, buttonStand};
            DisablePlayerControls();

            gameStartButton.Enabled = false;
            resetHands.Enabled = false;
            insuranceButton.Enabled = false;
            buttonSplit.Enabled = false;
            borrowMoney.Enabled = false;
        }

        /**
         * Starts the game, by dealing cards out to player, and dealer,
         * and saves rather or not either has a blackjack.
         */
        void StartGame()
        {
            gameStarted = true;
            insuranceButton.Enabled = false;
            winnerAnnounce.Text = progress;

            DealerDeal();
            EnablePlayerControls();
            PlayerDeal();
            CheckForBlackjack();
            CheckForDoubles();
            CheckForHit(playersHand, buttonHit, buttonDouble);

            UpdateHands();
        }

        /**
         * Draws 2 cards for player, and 2 for the dealer, one of which is flipped
         */
        void DealerDeal()
        {
            Card cardDown = Deck.Draw(deck), cardUp = Deck.Draw(deck);
            cardDown.Flipped = true;

            dealersHand.Add(cardUp);
            dealersHand.Add(cardDown);
        }

        void PlayerDeal()
        {
            for (int i = 0; i < 2; i++)
            {
                Card card = Deck.Draw(deck);
                playersHand.Add(card);
            }
        }

        /**
         * Updates the hand value boxes, and pictures
         */
        void UpdateHands()
        {
            Deck.RefreshDisplay(dealerHand, dealersHand);
            Deck.RefreshDisplay(playerHand, playersHand);

            dealerValue.Text = Deck.Value(dealersHand);
            playerValue.Text = Deck.Value(playersHand);
        }

        void FlipDealerCard()
        {
            foreach (Card card in dealersHand)
            {
                if (card.Flipped)
                {
                    card.Flipped = false;
                }
            }

            UpdateHands();
        }

        void EnablePlayerControls()
        {
            foreach (Button button in playerControls)
            {
                button.Enabled = true;
            }
        }

        void DisablePlayerControls()
        {
            foreach (Button button in playerControls)
            {
                button.Enabled = false;
            }
        }

        public void EndPlayerRound()
        {
            DisablePlayerControls();
            FlipDealerCard();
        }

        /**
         *  Controls the dealer drawing cards.
         *  Will stop if player has busted, or if hand is at 17,
         *  otherwise will draw cards until over 17, or busted.
         */
        public void DealerRound()
        {
            int playerScore = cardToPlay(Deck.Values(Deck.getPlayerHand())),
                splitScore = cardToPlay(Deck.Values(Deck.getPlayerSplitHand())),
                dealerScore = cardToPlay(Deck.Values(Deck.getDealerHand()));

            if (playerBlackjack) { }
            // If the player busts, don't draw
            else if (!splitPlay && playerScore > 21) { }
            else if (splitPlay && playerScore > 21 && splitScore > 21) { }
            // If dealer has 17 or higher, don't draw
            else if (dealerScore >= 17) { }
            // Else, dealer plays
            else
            {
                bool dealerPlays = true;

                while (dealerPlays)
                {
                    dealersHand.Add(Deck.Draw(deck));
                    dealerScore = cardToPlay(Deck.Values(Deck.getDealerHand()));

                    // If dealer goes over 17, stop playing
                    if (dealerScore >= 17)
                    {
                        dealerPlays = false;
                    }
                }

            }

            UpdateHands();
            ScoreGame(playerScore, splitScore, dealerScore);
        }

        /**
         * Scores main hand, and if the hand was split, will score that seperately
         */
        void ScoreGame(int playerScore, int splitScore, int dealerScore)
        {
            // Instant conditions
            if (playerBlackjack && !dealerBlackjack)
            {
                Winner("playerBlackjack", true);
            }
            else if (dealerBlackjack && !playerBlackjack)
            {
                Winner("dealer", true);
            }
            else if (playerBlackjack && dealerBlackjack)
            {
                Winner("dealer", true);
            }
            else if (!splitPlay)
            {
                if (playerScore > 21)
                {
                    Winner("dealer", true);
                }
                else if (dealerScore > 21)
                {
                    Winner("player", true);
                }
                else if (playerScore > dealerScore && playerScore <= 21)
                {
                    Winner("player", true);
                }
                else if (playerScore == dealerScore && playerScore <= 21)
                {
                    Winner("push", true);
                }
                else
                {
                    Winner("dealer", true);
                }
            }
            else if (splitPlay)
            {
                if (playerScore > 21)
                {
                    Winner("dealer", true);
                }
                else if (dealerScore > 21)
                {
                    Winner("player", true);
                }
                else if (playerScore > dealerScore && playerScore <= 21)
                {
                    Winner("player", true);
                }
                else if (playerScore == dealerScore && playerScore <= 21)
                {
                    Winner("push", true);
                }
                else
                {
                    Winner("dealer", true);
                }

                // ------------------------- Split Hand -------------------------- \\
                if (splitScore > 21)
                {
                    Winner("dealer", false);
                }
                else if (dealerScore > 21)
                {
                    Winner("player", false);
                }
                else if (splitScore > dealerScore && splitScore <= 21)
                {
                    Winner("player", false);
                }
                else if (splitScore == dealerScore && splitScore <= 21)
                {
                    Winner("push", false);
                }
                else
                {
                    Winner("dealer", false);
                }
            }

            EndGame();
        }

        void EndGame()
        {
            EndPlayerRound();
            FlipDealerCard();
            betting.Bet = betting.OriginalBet;
            refreshBets();

            betConfirmButton.Enabled = true;
            increaseBetButton.Enabled = true;
            decreaseBetButton.Enabled = true;

            doubleDown = false;

            betting.Insurance = false;
            betting.PlayCount++;
        }

        void NextRound()
        {
            Deck.ClearHands();
            UpdateHands();
            StartGame();
            resetHands.Enabled = false;
        }

        /**
         * Checks and saves if the player, and dealer have blackjack.
         * Also enables split, if the player was delt doubles,
         * and disables hitting if the player was dealt a 20, or 21
         */
        void CheckForBlackjack()
        {
            playerBlackjack = Deck.Blackjack(Deck.getPlayerHand());
            dealerBlackjack = Deck.Blackjack(Deck.getDealerHand());

            foreach (Card card in dealersHand)
            {
                if (!card.Flipped)
                {
                    if (card.CharacterValue.Equals("Ace"))
                    {
                        insuranceButton.Enabled = true;
                    }
                }
            }

            int playerScore = cardToPlay(Deck.Values(Deck.getPlayerHand()));

            if (playerBlackjack)
            {
                buttonHit.Enabled = false;
                buttonDouble.Enabled = false;
                buttonSurrender.Enabled = false;
            }
        }

        void CheckForDoubles()
        {
            if (Deck.Doubles(playersHand))
            {
                buttonSplit.Enabled = true;
            }
            else
            {
                buttonSplit.Enabled = false;
            }
        }

        public void CheckForHit(IList<Card> hand, Button hit, Button doubleDown)
        {
            int playerScore = cardToPlay(Deck.Values(hand));

            if (playerScore >= 20) // Can't hit on 20 or 21
            {
                hit.Enabled = false;
                doubleDown.Enabled = false;
            }
        }

        /**
         * Announces the winner to the announce box, and awards money as required.
         * Does not remove money, as the money was removed upon confirming the bet.
         * Handles split victories, as well.
         * 
         * String winner : The text code of the winner. "player" for player, and "playerBlackJack" for if the
         * player won via blackjack. These reward accordingly. "push" gives back the original bet, and "surrender"
         * gives back half of the original bet. "dealer" does nothing, outside of changing the announce text.
         */
        public void Winner(string winner, bool mainHand)
        {
            switch (winner)
            {
                case "player":
                    if (mainHand)
                    {
                        winnerAnnounce.Text = playerWin;
                        // Player wins the standard payout, not just their bet.
                        changeCurrency(betting.getStandardPayout(), true);
                    }
                    else
                    {
                        splitWindow.getAnnounce().Text = playerWin;
                        // Player wins the standard payout, not just their bet.
                        changeCurrency(betting.getStandardPayout(), true);
                    }
                    break;
                case "playerBlackjack":
                    if (mainHand)
                    {
                        winnerAnnounce.Text = playerWin;
                        // Player wins the standard payout, not just their bet.
                        changeCurrency(betting.getBlackjackPayout(), true);
                    }
                    else{} // Split can't blackjack
                    break;
                case "dealer":
                    if (mainHand)
                    {
                        winnerAnnounce.Text = dealerWin;
                        // If the player played insurance, betting that the dealer has a blackjack
                        if (betting.Insurance)
                        {
                            // Player technically wins their money back, or breaks even.
                            changeCurrency(betting.Bet, true);
                        }
                        else { } // Otherwise, they just lose their money and get nothing back
                    }
                    else
                    {
                        splitWindow.getAnnounce().Text = dealerWin;
                    }
                   
                    break;
                case "push":
                    if (mainHand)
                    {
                        winnerAnnounce.Text = push;
                        // Since a push is an even event, we just return the bet.
                        changeCurrency(betting.Bet, true);
                    }
                    else
                    {
                        splitWindow.getAnnounce().Text = push;
                        // Since a push is an even event, we just return the bet.
                        changeCurrency(betting.Bet, true);
                    }   
                    break;
                case "surrender":
                    winnerAnnounce.Text = surrender;
                    // If you surrender, you get half of your bet back.
                    changeCurrency(betting.Bet / 2, true);
                    break;
            }   
        }

        // Attempts to auto-update the value text when drawing cards; Doesn't work correctly
    
        private void dealerHand_Paint(object sender, PaintEventArgs e)
        {
            dealerValue.Text = Deck.Value(dealersHand);
        }

        private void playerHand_Paint(object sender, PaintEventArgs e)
        {
            playerValue.Text = Deck.Value(playersHand);
        }

        /*
         * The logic for our buttons being pressed 
         */
        private void gameStartButton_Click(object sender, System.EventArgs e)
        {
            StartGame();
            gameStartButton.Enabled = false;
        }

        private void buttonHit_Click(object sender, System.EventArgs e)
        {
            buttonSurrender.Enabled = false;
            DrawCard(playersHand, buttonHit, buttonDouble);
            UpdateHands();
        }

        private void buttonDouble_Click(object sender, System.EventArgs e)
        {
            buttonSurrender.Enabled = false;
            doubleDown = true;

            changeCurrency(betting.Bet, false);
            betting.Bet = betting.Bet * 2;

            DrawCard(playersHand, buttonHit, buttonDouble);
            UpdateHands();
            EndPlayerRound();
            DealerRound();
        }

        private void buttonSplit_Click(object sender, System.EventArgs e)
        {
            buttonSplit.Enabled = false;
            buttonSurrender.Enabled = false;

            splitPlay = true;
            changeCurrency(betting.Bet, false);

            UpdateHands();

            playersSplitHand.Add(Deck.Draw(playersHand));

            playersSplitHand.Add(Deck.Draw(deck));
            playersHand.Add(Deck.Draw(deck));

            CheckForHit(playersHand, buttonHit, buttonDouble);
            splitWindow.resetButtons();
            CheckForHit(playersSplitHand, splitWindow.getHitButton(), splitWindow.getDoubleButton());

            splitWindow.Show();
            splitWindow.getAnnounce().Text = progress;
            splitWindow.UpdateHands();
            UpdateHands();
        }

        private void buttonSurrender_Click(object sender, System.EventArgs e)
        {
            Winner("surrender", true);
            EndGame();
        }

        private void buttonStand_Click(object sender, System.EventArgs e)
        {
            UpdateHands();

            if (!splitPlay)
            {
                EndPlayerRound();
                DealerRound();
            }
            else
            {
                standing = true;
                buttonStand.Enabled = false;
                if (standing && splitWindow.getStanding())
                {
                    EndPlayerRound();
                    DealerRound();
                }
            }
        }

        private void insuranceButton_Click(object sender, System.EventArgs e)
        {
            betting.Insurance = true;
            insuranceButton.Enabled = false;
            changeCurrency(betting.Bet / 2, false);
            changeBet(betting.Bet / 2, true);
        }

        private void betConfirmButton_Click(object sender, System.EventArgs e)
        {
            if (betting.Money < betting.Bet)
            {
                winnerAnnounce.Text = noMoney;
                borrowMoney.Enabled = true;
                return;
            }
            else
            {
                betConfirmButton.Enabled = false;
                increaseBetButton.Enabled = false;
                decreaseBetButton.Enabled = false;

                if (gameStarted)
                {
                    resetHands.Enabled = true;
                }
                else
                {
                    winnerAnnounce.Text = waiting;
                    gameStartButton.Enabled = true;
                }
            }

            changeCurrency(betting.Bet, false);
            refreshBets();
            betting.OriginalBet = betting.Bet;
        }

        private void increaseBetButton_Click(object sender, System.EventArgs e)
        {
            changeBet(betting.Increment, true);
        }

        private void decreaseBetButton_Click(object sender, System.EventArgs e)
        {
            changeBet(betting.Increment, false);
        }

        private void resetHands_Click(object sender, System.EventArgs e)
        {
            if (splitPlay)
            {
                splitWindow.Hide();

                splitPlay = false;
                splitWindow.setStanding(false);
            }

            NextRound();
        }

        private void borrowMoney_Click(object sender, System.EventArgs e)
        {
            borrowMoney.Enabled = false;
            changeCurrency(200, true);
        }

        /*
         * Logic for changing the bet, and currency values, also updates the displays
         */
        void changeBet(double change, bool increm)
        {
            string holder = betting.betDisplay();
            holder = holder.Substring(1, holder.Length - 1);
            double temp = double.Parse(holder);

            if (increm)
            {
                temp += change;
            }
            else
            {
                if (temp > betting.Increment)
                {
                    temp -= change;
                }
                else
                {
                    temp = change;
                }
            }

            betting.Bet = temp;
            refreshBets();
        }

        void changeCurrency(double change, bool increm)
        {
            string holder = betting.currencyDisplay();
            holder = holder.Substring(1, holder.Length - 1);
            double temp = double.Parse(holder);

            if (increm)
            {
                temp += change;
            }
            else
            {
                temp -= change;
            }

            betting.Money = temp;
            refreshBets();
        }

        /*
         *  Determines which of the soft values, if applicable, is the current highest
         */
        int cardToPlay(int[] values)
        {
            return values[1] > values[0] && values[1] < 22 ? values[1] : values[0];
        }

        /*
         * Draws a card, and disables hit and double down if busted.
         */
        public void DrawCard(IList<Card> hand, Button hit, Button doubleDown)
        {
            int play = cardToPlay(Deck.Values(hand));

            if (play < 20) // Can draw as long as you're not at hard 20
            {
                hand.Add(Deck.Draw(deck));
            }

            play = cardToPlay(Deck.Values(hand));

            if (play > 20)
            {
                hit.Enabled = false;
                doubleDown.Enabled = false;
            }
        }

        /*
         * Changes the display showing bet value, and current player money
         */
        void refreshBets()
        {
            betDisplay.Text = betting.betDisplay();
            playerMoneyDisplay.Text = betting.currencyDisplay();
        }

        /*
         * A getter and setter for rather or not the particular hand is standing
         * Both split hand, and main hand must be standing to continue,
         * if split was activated
         */
        public bool getStanding()
        {
            return standing;
        }

        public void setStanding(bool newValue)
        {
            standing = newValue;
        }
    }
}
