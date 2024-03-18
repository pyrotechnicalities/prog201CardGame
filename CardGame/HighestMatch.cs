using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using static System.Console;

namespace CardGame
{
    public class HighestMatch : Game
    {
        int dealerScore = 0;
        int roundNumber = 0;
        public Player Dealer;
        public HighestMatch(Player placeholder)
        {
            CurrentPlayer = placeholder;
            Dealer = new Player(dealerScore);
            string[] suits = { "Swords", "Shields", "Bows", "Axes" };
            deck = new Deck(52, suits);
        }
        public override void Instructions()
        {
            base.Instructions();
            Clear();
            WriteLine("Here's how to play Highest Match:");
            WriteLine("Your goal is to obtain the highest value of cards that have the same suit. You will be playing against a dealer.");
            WriteLine("You will be given a hand of four cards and ten turns to collect cards with the highest values and matching suits. You can draw one card every turn, and you must discard a card every turn.");
            WriteLine("Keep in mind that Aces are low, and face cards are worth the amount of points that they would be it they didn't have a special name. (Ex: Kings are worth 13 points)");
            WriteLine("If your cards are higher than the dealer's at the end of the game, you win!");
            WriteLine("Press any key to continue when you're ready to start.");
            ReadKey();
        }
        private void GenerateDealerHand()
        {
            Dealer.dealerHand.Add(deck.DrawCard());
        }
        public void StartGame()
        {
            for (int i = 0; i < 4; i++)
            {
                GeneratePlayerHand();
                GenerateDealerHand();
            }
            Clear();
            SeeInstructions();
            Clear();
            WriteLine("The deck has been shuffled, and the dealer has dealt both you and themselves a hand.");
            RoundSetup();
        }
        private void Header()
        {
            WriteLine($"The current round is: {roundNumber}\n");
            WriteLine("Your hand is:\n");
            CurrentPlayer.ShowPlayerHand();
        }
        public void RoundSetup()
        {
            if (roundNumber < 10)
            {
                Header();

                WriteLine("\nIf you would like to end the game and compare your cards to the dealer's, press E and enter.");
                WriteLine("If you would like to continue playing, press C and enter.");
                string gameResponse = ReadLine().Trim().ToUpper();
                if (gameResponse == "E")
                {
                    EndGame();
                }
                else if (gameResponse == "C")
                {
                    roundNumber++;
                    Round();
                }
                else
                {
                    WriteLine("I'm sorry, I didn't recognize that input. Please press any key to continue and try again.");
                    ReadKey();
                    Clear();
                    RoundSetup();
                }
            }
            else
            {
                WriteLine("And that was the last round!");
                EndGame();
            }
        }
        public new void Round()
        {
            Clear();
            Header();

            Card drawnCard = deck.DrawCard();

            WriteLine($"The card you drew is {drawnCard.Name}. Would you like to keep your current hand or switch a card for this one? (type KEEP to keep and SWITCH to switch)");
            string handResponse = ReadLine().Trim().ToUpper();
            if (handResponse == "KEEP")
            {
                WriteLine("Okay!");
                WriteLine("Move on to the next round by pressing any key.");
                ReadKey();
                Clear();
                RoundSetup();
            }
            else if (handResponse == "SWITCH")
            {
                SwitchCard(drawnCard);
            }
            else
            {
                WriteLine("I'm sorry, I didn't recognize that input. Please press any key to continue and try again.");
                ReadKey();
                Clear();
                Round();
            }
        }
        private void SwitchCard(Card drawnCard)
        {
            WriteLine("Which card would you like to switch? Press 1, 2, 3, or 4.");
            string switchResponse = ReadLine();

            if (switchResponse == "1")
            {
                CurrentPlayer.playerHand[0] = drawnCard;
                RoundSetup();
            }
            else if (switchResponse == "2")
            {
                CurrentPlayer.playerHand[1] = drawnCard;
                RoundSetup();
            }
            else if (switchResponse == "3")
            {
                CurrentPlayer.playerHand[2] = drawnCard;
                RoundSetup();
            }
            else if (switchResponse == "4")
            {
                CurrentPlayer.playerHand[3] = drawnCard;
                RoundSetup();
            }
            else
            {
                WriteLine("I'm sorry, I didn't recognize that input. Please press any key to continue and try again.");
                ReadKey();
                Clear();
                SwitchCard(drawnCard);
            }
        }
        public new void ContinueGame()
        {
            WriteLine("Would you like to play again? (yes/no)");
            string continueResponse = ReadLine().Trim().ToLower();

            if (continueResponse == "yes")
            {
                WriteLine("Okay! Press any key to continue.");
                Clear();
                CurrentPlayer.Score = 0;
                dealerScore = 0;
                roundNumber = 0;
                RoundSetup();
            }
            else
            {
                WriteLine("Alright. I'll return you to the main screen. Press any key to continue. Thanks for playing!");
                ReadKey();
                Clear();
                SelectGame();
            }
        }
        public void EndGame()
        {
            WriteLine("Let's see how your points stacked up...");
            WriteLine("\nYour final hand was:");
            CurrentPlayer.ShowPlayerHand();
            WriteLine("\nThe dealer's final hand was:");
            Dealer.ShowDealerHand();

            CheckPlayerHand();
            CheckDealerHand();

            if (CurrentPlayer.Score > dealerScore)
            {
                WriteLine($"Your score was {CurrentPlayer.Score}, beating the dealer's score of {dealerScore}!");
                ContinueGame();
            }
            else if (CurrentPlayer.Score == dealerScore)
            {
                WriteLine($"Your score was {CurrentPlayer.Score}, which tied with the dealer's score of {dealerScore}.");
                ContinueGame();
            }
            else
            {
                // dealer score > player score
                WriteLine($"The dealer's score was {dealerScore}, beating your score of {CurrentPlayer.Score}. Better luck next time.");
                ContinueGame();
            }
        }
        // Help with CheckPlayerHand and CheckDealerHand by Mack Pearson-Muggli
        private void CheckPlayerHand()
        {
            int swordCount = 0;
            int shieldCount = 0;
            int bowCount = 0;
            int axeCount = 0;

            for (int i = 0; i < CurrentPlayer.playerHand.Count; i++)
            {
                switch (CurrentPlayer.playerHand[i].Suit)
                {
                    case "Swords":
                        swordCount++; break;
                    case "Shields":
                        shieldCount++; break;
                    case "Bows":
                        bowCount++; break;
                    case "Axes":
                        axeCount++; break;
                }

                for (int j = 1; j < CurrentPlayer.playerHand.Count; j++)
                {

                    if (swordCount > shieldCount && swordCount > axeCount && swordCount > bowCount)
                    {
                        CurrentPlayer.Score = CurrentPlayer.playerHand[i].Value + CurrentPlayer.playerHand[j].Value;
                        break;
                    }
                    else if (shieldCount > swordCount && shieldCount > axeCount && shieldCount > bowCount)
                    {
                        CurrentPlayer.Score = CurrentPlayer.playerHand[i].Value + CurrentPlayer.playerHand[j].Value;
                        break;
                    }
                    else if (axeCount > swordCount && axeCount > shieldCount && axeCount > bowCount)
                    {
                        CurrentPlayer.Score = CurrentPlayer.playerHand[i].Value + CurrentPlayer.playerHand[j].Value;
                        break;
                    }
                    else
                    {
                        // bow count greater
                        CurrentPlayer.Score = CurrentPlayer.playerHand[i].Value + CurrentPlayer.playerHand[j].Value;
                        break;
                    }
                }
            }
        }
        private void CheckDealerHand()
        {
            int swordCount = 0;
            int shieldCount = 0;
            int bowCount = 0;
            int axeCount = 0;

            for (int i = 0; i < Dealer.dealerHand.Count; i++)
            {
                switch (Dealer.dealerHand[i].Suit)
                {
                    case "Swords":
                        swordCount++; break;
                    case "Shields":
                        shieldCount++; break;
                    case "Bows":
                        bowCount++; break;
                    case "Axes":
                        axeCount++; break;
                }
                for (int j = 1; j < Dealer.dealerHand.Count; j++)
                {
                    if (swordCount > shieldCount && swordCount > axeCount && swordCount > bowCount)
                    {
                        dealerScore = Dealer.dealerHand[i].Value + Dealer.dealerHand[j].Value;
                        break;
                    }
                    else if (shieldCount > swordCount && shieldCount > axeCount && shieldCount > bowCount)
                    {
                        dealerScore = Dealer.dealerHand[i].Value + Dealer.dealerHand[j].Value;
                        break;
                    }
                    else if (axeCount > swordCount && axeCount > shieldCount && axeCount > bowCount)
                    {
                        dealerScore = Dealer.dealerHand[i].Value + Dealer.dealerHand[j].Value;
                        break;
                    }
                    else
                    {
                        // bow count greater
                        dealerScore = Dealer.dealerHand[i].Value + Dealer.dealerHand[j].Value;
                        break;
                    }
                }
            }
        }
    }
}