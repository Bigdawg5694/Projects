using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleCards;

namespace GradedExercise4
{
    /// <summary>
    /// Demonstrates using classes and objects
    /// </summary>
    class Program
    {
        /// <summary>
        /// Builds and prints a hand of cards
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // declare and create deck and hand variables
            Deck deck = new();
            Hand hand = new();

            // deal 5 cards from the deck into the hand
            Card card1 = deck.TakeTopCard();
            Card card2 = deck.TakeTopCard();
            Card card3 = deck.TakeTopCard();
            Card card4 = deck.TakeTopCard();
            Card card5 = deck.TakeTopCard();
            hand.AddCard(card1);
            hand.AddCard(card2);
            hand.AddCard(card3);
            hand.AddCard(card4);
            hand.AddCard(card5);

            // flip over all 5 cards
            card1.FlipOver();
            card2.FlipOver();
            card3.FlipOver();
            card4.FlipOver();
            card5.FlipOver();

            // print the information for each of the 5 cards
            Console.WriteLine(card1.Rank + "," + card1.Suit);
            Console.WriteLine(card2.Rank + "," + card2.Suit);
            Console.WriteLine(card3.Rank + "," + card3.Suit);
            Console.WriteLine(card4.Rank + "," + card4.Suit);
            Console.WriteLine(card5.Rank + "," + card5.Suit);

        }
    }
}