using System;

namespace Models
{
    public class Card
    {
        public char Value { get; set; } = '0';

        public string Suit { get; set; } = "";

        public int Strength { get; set; } = 0;

        public override string ToString()
        {
            return $"{Value} de {Suit}";
        }
    }
}