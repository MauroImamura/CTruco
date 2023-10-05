using System;

namespace Models
{
    public interface ICpuStrategy
    {
        char FirstRound((char value, string suit) flipped, (char value, string suit)? playerCard, (char value, string suit)[] cpuHand);

        char SecondRoun();

        char ThirdRound();
    }
}