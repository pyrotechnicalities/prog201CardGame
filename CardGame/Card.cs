using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CardGame
{
    public class Card
    {
        public int Value;
        public string Suit;
        public string Name;
        public Card(int value, string suit, string name)
        {
            Value = value;
            Suit = suit;
            Name = name;
        }
        public Card()
        {

        }
        public void ShowCard()
        {
            WriteLine($"{Name}");
        }
    }
}