using System;
using System.Runtime.InteropServices;

namespace CTruco
{
    //Jogo de Truco 1 contra 1, player contra CPU
    class Program
    {
        static void Main(string[] args)
        {
            //step 1: create deck cards
            var deck = new (char value, string suit)[40];

            var values = new char[]{'4','5','6','7','Q','J','K','A','2','3'};
            var suits = new string[] {"ouros","espadas","copas","zap"};
            var index = 0;
            foreach(var value in values)
            {
                foreach(var suit in suits)
                {
                    deck[index] = (value, suit);
                    index ++;
                }
            }

            //step 2: sort cards for players
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
            (char value, string suit)[] playerHand = {deck[cardIndexes[0]], deck[cardIndexes[1]], deck[cardIndexes[2]]};
            (char value, string suit)[] CpuHand = {deck[cardIndexes[3]], deck[cardIndexes[4]], deck[cardIndexes[5]]};
            var flipped = deck[cardIndexes[6]];

            //step 3: start round
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"O tombo da rodada é {flipped}");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Suas cartas são:");
            Console.WriteLine("");
            Console.WriteLine($"Carta 1: {playerHand[0]}");
            Console.WriteLine("");
            Console.WriteLine($"Carta 2: {playerHand[1]}");
            Console.WriteLine("");
            Console.WriteLine($"Carta 3: {playerHand[2]}");
        }
    }
}

