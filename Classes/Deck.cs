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

        /*
         * The various collections used throughout playing the game
         */
        static IList<Card> dealer = new List<Card>();
        static IList<Card> player = new List<Card>();
        static IList<Card> playerSplit = new List<Card>();

        static IList<Card> discard = new List<Card>();

        static IList<Card> deck = BuildDeck();

        public static IList<Card> BuildDeck()
        {
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades"};
            string[] cards = { "Ace", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            IList<Card> deck = new List<Card>();

            foreach (string suit in suits)
            {
                foreach (string card in cards)
                {
                    deck.Add(new Card(GetImageName(suit, card), card, suit, GetValues(card)));
                }
            }

            return deck;
        }

        static string GetImageName(string suit, string card)
        {
            string c = "c", s = suit[0] + "";

            switch (card)
            {
                case "Two":
                    c = "2";
                    break;
                case "Three":
                    c = "3";
                    break;
                case "Four":
                    c = "4";
                    break;
                case "Five":
                    c = "5";
                    break;
                case "Six":
                    c = "6";
                    break;
                case "Seven":
                    c = "7";
                    break;
                case "Eight":
                    c = "8";
                    break;
                case "Nine":
                    c = "9";
                    break;
                case "Ten":
                    c = "10";
                    break;
                default:
                    c = card[0] + "";
                    break;
            }

            return "" + c + s;
        }

        static int[] GetValues(string name)
        {
            int[] value = new int[] { };

            switch (name)
            {
                case "Ace":
                    value = new int[] { 1, 11 };
                    break;
                case "Two":
                    value = new int[] { 2 };
                    break;
                case "Three":
                    value = new int[] { 3 };
                    break;
                case "Four":
                    value = new int[] { 4 };
                    break;
                case "Five":
                    value = new int[] { 5 };
                    break;
                case "Six":
                    value = new int[] { 6 };
                    break;
                case "Seven":
                    value = new int[] { 7 };
                    break;
                case "Eight":
                    value = new int[] { 8 };
                    break;
                case "Nine":
                    value = new int[] { 9 };
                    break;
                default:
                    value = new int[] { 10 };
                    break;
            }

            return value;
        }

        /*
         * Getters for the above collections
         */
        public static IList<Card> GetDeck()
        {
            return deck;
        }

        /**
         * Returns one large deck comprised of however many small decks you choose
         * 
         * Count: The number of decks to put together
         */
        public static IList<Card> GetDecks(int count)
        {
            IList<Card> decks = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                var deck = BuildDeck();
                foreach (Card card in deck)
                {
                    decks.Add(card);
                }
            }

            return decks;
        }

        public static IList<Card> GetDealerHand()
        {
            return dealer;
        }

        public static IList<Card> GetPlayerHand()
        {
            return player;
        }

        public static IList<Card> GetPlayerSplitHand()
        {
            return playerSplit;
        }

        public static IList<Card> GetDiscardPile()
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
