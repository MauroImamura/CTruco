using System;

namespace Models
{
    public interface ICpuStrategy
    {
        int FirstRound(Card[] cpuHand, char starter, Card? playerCard = null);

        int SecondRoun(Card[] cpuHand, char starter, Card? playerCard = null);

        int ThirdRound(Card[] cpuHand, char starter, Card? playerCard = null);

        int PlayRound(Card[] cpuHand, char starter, int roundNumber, Card? playerCard = null);
    }
}