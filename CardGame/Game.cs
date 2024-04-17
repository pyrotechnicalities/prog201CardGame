using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CardGame
{
    public class Game
    {
        public Player CurrentPlayer;
        public Deck deck;
        private SameOrDifferent SameOrDifferent;
        private HigherOrLower HigherOrLower;
        private HighestMatch HighestMatch;
        private Credits credits;
        public Game()
        {
            string[] Suits = { "Swords", "Shields", "Bows", "Axes" };
            new Deck(52, Suits);
        }
        public void Start()
        {
            PlayerCreate();
        }

        void PlayerCreate()
        {
            WriteLine("Enter your name.");
            string playerName = ReadLine();
            int playerScore = 0;
            WriteLine($"Is {playerName} correct? (yes/no)");
            string creatorResponse = ReadLine().Trim().ToLower();

            CurrentPlayer = new Player(playerName, playerScore);

            if (creatorResponse == "yes")
            {
                WriteLine($"Welcome to the game, {playerName}! Your score is currently: {playerScore}\n");
                SelectGame();
            }
            else
            {
                Clear();
                PlayerCreate();
            }
        }
        public void SelectGame()
        {
            // Some functionality assistance by Janell Baxter
            WriteLine("What game would you like to play? 1: Same or Different 2: Higher or Lower 3: Highest Match. If you would like to see the credits, press 4.");
            string gameResponse = ReadLine();
            
            if (gameResponse == "1")
            {
                SameOrDifferent = new SameOrDifferent(CurrentPlayer);
                SameOrDifferent.StartGame();
            }
            else if (gameResponse == "2")
            {
                HigherOrLower = new HigherOrLower(CurrentPlayer);
                HigherOrLower.StartGame();

            }
            else if (gameResponse == "3")
            {
                HighestMatch = new HighestMatch(CurrentPlayer);
                HighestMatch.StartGame();
            }
            else if (gameResponse == "4")
            {
                credits = new Credits();
                credits.ShowCredits();
            }
            else
            {
                WriteLine("Sorry, I couldn't recognize that input. Try again.");
                ReadKey();
                Clear();
                SelectGame();
            }
        }
        public void SeeInstructions()
        {
            WriteLine("Would you like to see the instructions for this game? (yes/no)");
            string instructionsResponse = ReadLine().Trim().ToLower();

            if (instructionsResponse == "yes")
            {
                Instructions();
            }
            else
            {
                WriteLine("Okay! Have fun with the game. Press any key to continue!");
                ReadKey();
            }
        }
        public virtual void Instructions()
        {
            WriteLine("Game-specific instructions go here");
        }
        public virtual void Round()
        {
            WriteLine($"Your score is: {CurrentPlayer.Score}");
        }
        public void CanContinueGame()
        {
            while (deck.Cards.Count > 0)
            {
                ContinueGame();
            }
        }
        public virtual void ContinueGame()
        {
            WriteLine("Would you like to play again? (yes/no)");
            string continueResponse = ReadLine().Trim().ToLower();

            if (continueResponse == "yes")
            {
                WriteLine("Okay! Press any key to continue.");
                Clear();
                Round();
            }
            else
            {
                WriteLine("Alright. I'll return you to the main screen. Press any key to continue. Thanks for playing!");
                ReadKey();
                Clear();
                SelectGame();
            }
        }
        public void IncrementPlayerScore()
        {
            CurrentPlayer.Score++;
            WriteLine($"Your score is now: {CurrentPlayer.Score}");
            CanContinueGame();
        }
        public void GeneratePlayerHand()
        {
            CurrentPlayer.playerHand.Add(deck.DrawCard());
        }
    }
}