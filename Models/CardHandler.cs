using System;

namespace Models
{
    public class CardHandler
    {
        private readonly char[] _values = new char[]{'4','5','6','7','Q','J','K','A','2','3'};
        private readonly string[] _suits = new string[] {"ouros","espadas","copas","paus"};
        public (char value, string suit)[] Deck { get; private set; }
        public (char value, string suit)[] PlayerHand {get; private set;} = new(char value, string suit)[3] {(' ',""),(' ',""),(' ',"")};
        public (char value, string suit)[] CpuHand {get; private set;} = new(char value, string suit)[3] {(' ',""),(' ',""),(' ',"")};
        public (char value, string suit) Flipped {get; private set;} = (' ',"");

        public CardHandler()
        {
            Deck = new (char value, string suit)[40];
            
            var index = 0;
            foreach(var value in _values)
            {
                foreach(var suit in _suits)
                {
                    Deck[index] = (value, suit);
                    index ++;
                }
            }
        }

        public void CardSorting()
        {
            var deck = Deck;
            var cardIndexes = new int[7]; //3 cards for each player and a flipped card on table
            var i = 0;
            while(i < 7)
            {
                var random = new Random();
                int cardIndex = random.Next(40);
                if(!cardIndexes.Contains(cardIndex))
                {
                    cardIndexes[i] = cardIndex;
                    i++;
                }
            }
            PlayerHand[0] = deck[cardIndexes[0]];
            PlayerHand[1] = deck[cardIndexes[1]];
            PlayerHand[2] = deck[cardIndexes[2]];
            CpuHand[0] = deck[cardIndexes[3]];
            CpuHand[1] = deck[cardIndexes[4]];
            CpuHand[2] = deck[cardIndexes[5]];
            Flipped = deck[cardIndexes[6]];
        }
    }
}