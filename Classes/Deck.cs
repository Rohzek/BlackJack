using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Blackjack.Classes
{
    /**
     * Holds collections of cards; Not just the deck of playing cards,
     * but also the different types of hands, and the discard pile.
     * 
     * Has various functions for handling collections of cards, such 
     * as drawing a card from one collection to another, shuffling
     * a particular collection, and determing the value of a
     * collection based on the values stored in the cards it holds
     */
    public static class Deck
    {
        static readonly Random random = new Random(); // Used for shuffling

        // Our deck of 52 playing cards
        static IList<Card> deck = new List<Card>
        {
            new Card("AC", "Ace", "Clubs", new int[] {1, 11}),
            new Card("AD", "Ace", "Diamonds", new int[] {1, 11}),
            new Card("AH", "Ace", "Hearts", new int[] {1, 11}),
            new Card("AS", "Ace", "Spades", new int[] {1, 11}),
            new Card("2C", "Two", "Clubs", new int[] {2}),
            new Card("2D", "Two", "Diamonds", new int[] {2}),
            new Card("2H", "Two", "Hearts", new int[] {2}),
            new Card("2S", "Two", "Spades", new int[] {2}),
            new Card("3C", "Three", "Clubs", new int[] {3}),
            new Card("3D", "Three", "Diamonds", new int[] {3}),
            new Card("3H", "Three", "Hearts", new int[] {3}),
            new Card("3S", "Three", "Spades", new int[] {3}),
            new Card("4C", "Four", "Clubs", new int[] {4}),
            new Card("4D", "Four", "Diamonds", new int[] {4}),
            new Card("4H", "Four", "Hearts", new int[] {4}),
            new Card("4S", "Four", "Spades", new int[] {4}),
            new Card("5C", "Five", "Clubs", new int[] {5}),
            new Card("5D", "Five", "Diamonds", new int[] {5}),
            new Card("5H", "Five", "Hearts", new int[] {5}),
            new Card("5S", "Five", "Spades", new int[] {5}),
            new Card("6C", "Six", "Clubs", new int[] {6}),
            new Card("6D", "Six", "Diamonds", new int[] {6}),
            new Card("6H", "Six", "Hearts", new int[] {6}),
            new Card("6S", "Six", "Spades", new int[] {6}),
            new Card("7C", "Seven", "Clubs", new int[] {7}),
            new Card("7D", "Seven", "Diamonds", new int[] {7}),
            new Card("7H", "Seven", "Hearts", new int[] {7}),
            new Card("7S", "Seven", "Spades", new int[] {7}),
            new Card("8C", "Eight", "Clubs", new int[] {8}),
            new Card("8D", "Eight", "Diamonds", new int[] {8}),
            new Card("8H", "Eight", "Hearts", new int[] {8}),
            new Card("8S", "Eight", "Spades", new int[] {8}),
            new Card("9C", "Nine", "Clubs", new int[] {9}),
            new Card("9D", "Nine", "Diamonds", new int[] {9}),
            new Card("9H", "Nine", "Hearts", new int[] {9}),
            new Card("9S", "Nine", "Spades", new int[] {9}),
            new Card("10C", "Ten", "Clubs", new int[] {10}),
            new Card("10D", "Ten", "Diamonds", new int[] {10}),
            new Card("10H", "Ten", "Hearts", new int[] {10}),
            new Card("10S", "Ten", "Spades", new int[] {10}),
            new Card("JC", "Jack", "Clubs", new int[] {10}),
            new Card("JD", "Jack", "Diamonds", new int[] {10}),
            new Card("JH", "Jack", "Hearts", new int[] {10}),
            new Card("JS", "Jack", "Spades", new int[] {10}),
            new Card("QC", "Queen", "Clubs", new int[] {10}),
            new Card("QD", "Queen", "Diamonds", new int[] {10}),
            new Card("QH", "Queen", "Hearts", new int[] {10}),
            new Card("QS", "Queen", "Spades", new int[] {10}),
            new Card("KC", "King", "Clubs", new int[] {10}),
            new Card("KD", "King", "Diamonds", new int[] {10}),
            new Card("KH", "King", "Hearts", new int[] {10}),
            new Card("KS", "King", "Spades", new int[] {10}),
        };

        /*
         * The various collections used throughout playing the game
         */
        static IList<Card> dealer = new List<Card>();
        static IList<Card> player = new List<Card>();
        static IList<Card> playerSplit = new List<Card>();

        static IList<Card> discard = new List<Card>();

        /*
         * Getters for the above collections
         */
        public static IList<Card> getDeck()
        {
            return deck;
        }

        public static IList<Card> getDealerHand()
        {
            return dealer;
        }

        public static IList<Card> getPlayerHand()
        {
            return player;
        }

        public static IList<Card> getPlayerSplitHand()
        {
            return playerSplit;
        }

        public static IList<Card> getDiscardPile()
        {
            return discard;
        }

        /**
         * Re-orders the collection to a random order
         */
        public static void Shuffle(this IList<Card> list)
        {
            int count = list.Count;

            while (count > 1)
            {
                int n = (random.Next(0, count) % count);
                count--;

                Card value = list[n];
                list[n] = list[count];
                list[count] = value;
            }
        }

        /**
         * Moves a card object from one collection, to another
         */
        public static Card Draw(this IList<Card> list)
        {
            if (deck.Count == 0)
            {
                foreach (Card crd in discard)
                {
                    deck.Add(crd);
                    Shuffle(deck);
                }
            }

            var card = list.FirstOrDefault();
            list.Remove(card);

            return card;
        }

        /**
         * Determines if the hand is a blackjack, by checking to see 
         * if it contains one ace, and one ten value card
         */
        public static Boolean Blackjack(IList<Card> list)
        {
            bool ace = false, ten = false;
            foreach (Card card in list)
            {
                if (card.CharacterValue.Equals("Ace"))
                {
                    ace = true;
                }
                else if (card.CharacterValue.Equals("Ten") || card.CharacterValue.Equals("Jack") || card.CharacterValue.Equals("Queen") || card.CharacterValue.Equals("King"))
                {
                    ten = true;
                }
            }

            return ace && ten ? true : false;
        }

        /**
         * Checks to see if the two cards are doubles, EG: two 5s
         * Is suit independant
         */
        public static Boolean Doubles(IList<Card> list)
        {
            Card[] cards = list.ToArray();

            return cards[0].CharacterValue.Equals(cards[1].CharacterValue);
        }

        /**
         * Moves cards from all 3 holders, to the discard pile, after a round is over
         */
        public static void ClearHands()
        {
            foreach (Card card in dealer)
            {
                discard.Add(card);
            }

            foreach (Card card in player)
            {
                discard.Add(card);
            }

            foreach (Card card in playerSplit)
            {
                discard.Add(card);
            }

            dealer.Clear();
            player.Clear();
            playerSplit.Clear();
        }

        /**
         * Puts the cards back into the deck, and empties discard pile
         */
        public static void ClearDiscard()
        {
            foreach (Card card in discard)
            {
                deck.Add(card);
            }

            discard.Clear();
        }

        /*
         * Controls for filling and clearing the panels that hold the images 
         */
        public static void ClearDisplay(TransparencyPanel panel)
        {
            panel.Controls.Clear();
        }

        public static void RefreshDisplay(TransparencyPanel panel, IList<Card> hand)
        {
            ClearDisplay(panel);

            if (hand.Count > 0)
            {
                foreach (Card card in hand)
                {
                    panel.Controls.Add(card.getDisplay());
                }
            }
        }

        /*
         * Handles the value of the cards in a particular collection
         * in String or int[] format
         */

        public static String Value(IList<Card> list)
        {
            int value = 0, value2 = 0;
            bool ace = false;

            foreach (Card card in list)
            {
                int[] num = {0, 0};

                if (card.Flipped)
                {}
                else
                {
                    num = card.Values;
                }

                if (card.Values.Length > 1)
                {
                    if (!card.Flipped)
                    {
                        ace = true;
                    }

                    value2 += num[1];
                }
                else
                {
                    value2 += num[0];
                }

                value += num[0];
            }

            return ace == true && value2 < 22 ? value + " or " + value2 : "" + value;
        }

        public static int[] Values(IList<Card> list)
        {
            int[] num = { 0, 0 }, values = { 0, 0};

            int value = 0, value2 = 0;

            foreach (Card card in list)
            {
                if (card.Flipped)
                { }
                else
                {
                    num = card.Values;
                }

                if (card.Values.Length > 1)
                {
                    value2 += num[1];
                }
                else
                {
                    value2 += num[0];
                }

                value += num[0];
            }

            values[0] = value;
            values[1] = value2;

            return values;
        }
    }
}
