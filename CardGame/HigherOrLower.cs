using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static System.Console;

namespace CardGame
{
    public class HigherOrLower : Game
    {
        public HigherOrLower(Player placeholder) 
        {
            CurrentPlayer = placeholder;
            string[] suits = { "Swords", "Shields", "Bows", "Axes" };
            deck = new Deck(52, suits);
        }
        public override void Instructions()
        {
            base.Instructions();
            Clear();
            WriteLine("Here's how to play Higher or Lower:");
            WriteLine("I'm going to draw a card, and you have to tell me if the next card's value will be higher or lower. That being said, both cards have to be the same suit in order for you to get a point.");
            WriteLine("Press any key to continue when you're ready to start.");
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
            WriteLine("Will the next card be higher or lower? (type true for higher and false for lower)");
            string gameResponse = ReadLine().Trim().ToLower();
            bool playerAnswer = Convert.ToBoolean(gameResponse);
            WriteLine($"\nThe next card is {cardB.Name}, so...");

            if (cardA.Value <= cardB.Value && cardA.Suit == cardB.Suit && playerAnswer == true)
            {
                // guessed higher correctly
                WriteLine("You guessed correctly!");
                IncrementPlayerScore();
            }
            else if (cardA.Value <= cardB.Value && cardA.Suit != cardB.Suit && playerAnswer == true)
            {
                // guessed higher correctly, but the suits don't match
                WriteLine("You were correct about the value, but the suits don't match, so no point for you :(");
                CanContinueGame();
            }
            else if (cardA.Value >= cardB.Value && cardA.Suit == cardB.Suit && playerAnswer == false)
            {
                // guessed lower correctly
                WriteLine("You guessed correctly!");
                IncrementPlayerScore();
            }
            else if (cardA.Value >= cardB.Value && cardA.Suit != cardB.Suit && playerAnswer == false)
            {
                // guessed lower correctly but the suits don't match
                WriteLine("You were correct about the value, but the suits don't match, so no point for you :(");
                CanContinueGame();
            }
            else if (cardA.Value <= cardB.Value && cardA.Suit == cardB.Suit && playerAnswer == false 
                || cardA.Value >= cardB.Value && cardA.Suit == cardB.Suit && playerAnswer == true
                || cardA.Value <= cardB.Value && cardA.Suit != cardB.Suit && playerAnswer == false
                || cardA.Value >= cardB.Value && cardA.Suit != cardB.Suit && playerAnswer == true)
            {
                // did not guess higher/lower correctly
                WriteLine("You didn't guess correctly :(");
                CanContinueGame();
            }
        }
    }
}