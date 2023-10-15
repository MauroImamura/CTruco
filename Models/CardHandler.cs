using System;

namespace Models
{
    public class CardHandler
    {
        private readonly char[] _values = new char[]{'4','5','6','7','Q','J','K','A','2','3'};
        private readonly string[] _suits = new string[] {"ouros","espadas","copas","paus"};
        public Card[] Deck { get; private set; }
        public Card[] PlayerHand {get; private set;} = new Card[3];
        public Card[] CpuHand {get; private set;} = new Card[3];
        public Card Flipped {get; private set;} = new Card();

        public CardHandler()
        {
            Deck = new Card[40];
            
            var index = 0;
            var strength = 1;
            foreach(var value in _values)
            {
                foreach(var suit in _suits)
                {
                    Deck[index] = new Card(){Value=value, Suit=suit, Strength=strength};
                    index ++;
                }
                strength ++;
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

            Flipped = deck[cardIndexes[6]]; 
            var manilhaPosition = (Flipped.Strength + 1) * 4;
            if(manilhaPosition >= 40)
            {
                manilhaPosition = 0;
            }

            for (int m = 0; m < 4 ; m++)
            {
                deck[manilhaPosition + m].Strength += deck.Length + m;
            }

            // foreach (var item in deck)
            // {
            //     Console.WriteLine($"{item} - {item.Strength}");
            // }
            
            PlayerHand[0] = deck[cardIndexes[0]];
            PlayerHand[1] = deck[cardIndexes[1]];
            PlayerHand[2] = deck[cardIndexes[2]];
            CpuHand[0] = deck[cardIndexes[3]];
            CpuHand[1] = deck[cardIndexes[4]];
            CpuHand[2] = deck[cardIndexes[5]];
        }
    }
}