using System;

namespace Blackjack.Classes
{
    /**
     * Holds the information on how much a player is betting, and how much they have
     * in the "bank" as well as how much should be payed back, on a winning hand.
     * 
     * Is serializable so we can store the player's money, and the times played
     * into a file, to load back later.
     */
    [Serializable()]
    public class Betting
    {
        char display = '$';
        double bet, splitBet, unchangedBet, currency, payout, increment;
        long timesplayed = 0;
        bool insurance;
        
        /*
         * Bet is default bet when loaded, and current bet while playing
         * 
         * SplitBet is how much is bet, when splitting. We store it seperatly instead of
         * changing the bet display. Double the bet is implied.
         * 
         * Unchanged bet is the original bet, before double down is applied.
         * 
         * Currency is how much the player currently has
         * 
         * Increment is how much the bet should increase or decrease by, each click
         * 
         * Times played is the amount of hands played
         * 
         * Insurance is rather or not the player has purchased insurance for a particular round
         */

        public Betting()
        {
            currency = 2000;
            bet = 10;
            increment = 10;
        }

        public Betting(double value)
        {
            currency = value;
            bet = 10;
            increment = 10;
        }

        public Betting(double value, double bet)
        {
            currency = value;
            this.bet = bet;
            increment = 10;
        }

        public Betting(double value, double bet, double increment)
        {
            currency = value;
            this.bet = bet;
            this.increment = increment;
        }

        public string betDisplay()
        {
            return display + "" + bet;
        }

        public string currencyDisplay()
        {
            return display + "" + currency;
        }

        /*
         * Gets how much the player should be paid for winning
         */
        public double getStandardPayout()
        {
            return bet * 2;
        }

        public double getBlackjackPayout()
        {
            return bet + (bet * 1.5);
        }

        /*
         * Getters and setters for each value stored in betting class 
         */

        public double Bet
        {
            get
            {
                return bet;
            }
            set
            {
                bet = value;
            }
        }

        public double SplitBet
        {
            get
            {
                return splitBet;
            }
            set
            {
                splitBet = value;
            }
        }

        public double OriginalBet
        {
            get
            {
                return unchangedBet;
            }
            set
            {
                unchangedBet = value;
            }
        }

        public double Money
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
            }
        }

        public double Payout
        {
            get
            {
                return payout;
            }
            set
            {
                payout = value;
            }
        }

        public double Increment
        {
            get
            {
                return increment;
            }
            set
            {
                increment = value;
            }
        }

        public long PlayCount
        {
            get
            {
                return timesplayed;
            }
            set
            {
                timesplayed = value;
            }
        }

        public bool Insurance
        {
            get
            {
                return insurance;
            }
            set
            {
                insurance = value;
            }
        }
    }
}
