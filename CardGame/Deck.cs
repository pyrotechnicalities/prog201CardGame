using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Console;

namespace CardGame
{
    public class Deck
    {
        // Some functionality assistance by Dominic F and Janell Baxter
        public List<Card> Cards = new List<Card>();
        Random Random = new Random();

        public Deck(int deckSize, string[] suits)
        {
            for (int i = 0; i < deckSize / suits.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    if (i == 0)
                    {
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"Ace of {suits[j]}" });
                    }
                    else if (i == 10)
                    {
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"Jack of {suits[j]}" });
                    }
                    else if (i == 11)
                    {
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"Queen of {suits[j]}" });
                    }
                    else if (i == 12)
                    {
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"King of {suits[j]}" });
                    }
                    else
                    {
                        Cards.Add(new Card() { Value = i + 1, Suit = suits[j], Name = $"{i + 1} of {suits[j]}" });
                    }
                }
            }
            Shuffle(Cards);
        }

        public string PrintDeck()
        {
            string output = "Cards in deck: \n";
            foreach (Card card in Cards)
            {
                output += card.Name + Environment.NewLine;
            }
            return output;
        }
        public Card DrawCard()
        {
            Card drawnCard = Cards[0];
            Cards.Remove(Cards[0]);
            return drawnCard;
        }

        public void ShowPlayerCard(Card playerCard)
        {
            WriteLine($"{playerCard.Value} of {playerCard.Suit}");
        }
        // Fisher-Yates shuffle from dotnetpearls and assistance from Stack Overflow
        public void Shuffle(List<Card> cards)
        {
            int n = cards.Count;
            for (int i = 0; i < (n-1); i++) 
            {
                int r = Random.Next(n - 1);
                Card temp = cards[i];
                cards[i] = cards[r];
                cards[r] = temp;
            }
        }
    }
}