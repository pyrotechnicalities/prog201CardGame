using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Player
    {
        public List<Card> playerHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        public string Name;
        public int Score;

        public Player(string playerName, int playerScore)
        {
            Name = playerName;
            Score = playerScore;
        }
        public Player(int dealerScore)
        {
            Score = dealerScore;
        }
        public void ShowPlayerHand()
        {
            for (int i = 0; i < playerHand.Count; i++)
            {
                playerHand[i].ShowCard();
            }
        }
        public void ShowDealerHand()
        {
            for (int i = 0; i < dealerHand.Count; i++)
            {
                dealerHand[i].ShowCard();
            }
        }
    }
}