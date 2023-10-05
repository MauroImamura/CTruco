using System;

namespace Models
{
    public class EasyCpuStrategy : ICpuStrategy
    {
        public char FirstRound((char value, string suit) flipped, (char value, string suit)? playerCard, (char value, string suit)[] cpuHand)
        {
            if(playerCard is null)
            {
                //play highest card
                //return its index
                Console.WriteLine("is null");
                return '1';
            }
            else
            {
                //play highest card if it is enough to win the round
                //play highest card bellow player's card if there is no winner card available in hand
                //return its index
                Console.WriteLine("is not null");
                return '2';
            }
        }

        public char SecondRoun()
        {
            throw new NotImplementedException();
        }

        public char ThirdRound()
        {
            throw new NotImplementedException();
        }
    }
}