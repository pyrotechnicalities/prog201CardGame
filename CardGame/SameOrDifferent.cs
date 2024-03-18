using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using static System.Console;

namespace CardGame
{
    public class SameOrDifferent : Game
    {
        // Some functionality assistance by Janell Baxter
        public SameOrDifferent(Player placeholder) 
        {
            CurrentPlayer = placeholder;
            string[] suits = { "Swords", "Shields" };
            deck = new Deck(26, suits);
        }
        public override void Instructions()
        {
            base.Instructions();
            Clear();
            WriteLine("Here's how to play Same or Different:");
            WriteLine("I'm going to draw a card, and then all you have to do is tell me if the next card I'm going to draw will match the first card's suit or not. If you're correct, you get a point!");
            WriteLine("When you're ready to start the game, press any key to continue.");
            ReadKey();

        }
        public void StartGame()
        {
            Clear();
            SeeInstructions();
            Round();
        }

        public override void Round()
        {
            base.Round();

            Card cardA = deck.DrawCard();
            Card cardB = deck.DrawCard();

            WriteLine($"\nThe starting card is {cardA.Name}.");
            WriteLine("Will the next card be the same or different? (type true for same or false for different)");
            string gameResponse = ReadLine().Trim().ToLower();
            bool playerAnswer = Convert.ToBoolean(gameResponse);
            WriteLine($"\nThe next card is {cardB.Name}, so...");

            if (cardA.Suit == cardB.Suit && playerAnswer)
            {
                WriteLine("The cards do match. You guessed correctly!");
                IncrementPlayerScore();
            }
            else if (playerAnswer == false & cardA.Suit != cardB.Suit)
            {
                // player answered correctly that the next card won't match 
                WriteLine("The cards don't match. You guessed correctly!");
                IncrementPlayerScore();
            }
            else
            {
                WriteLine("I'm sorry, that wasn't correct.");
                CanContinueGame();
            }
        }
    }
}