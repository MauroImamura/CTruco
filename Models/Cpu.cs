using System.Linq;

namespace Models
{
    public class EasyCpuStrategy : ICpuStrategy
    {

        public int PlayRound(Card[] cpuHand, char starter, int roundNumber, Card? playerCard = null)
        {
            var choice = 0;

            switch(roundNumber)
            {
                case 0: choice = FirstRound(cpuHand, starter, playerCard); break;
                case 1: choice = SecondRoun(cpuHand, starter, playerCard); break;
                case 2: choice = ThirdRound(cpuHand, starter, playerCard); break;
                default: break;
            }

            return choice;
        }

        public int FirstRound(Card[] cpuHand, char starter, Card? playerCard = null)
        {
            var maxStrength = cpuHand.Max(x => x.Strength);

            if(playerCard is null)
            {
                return Array.IndexOf(cpuHand, cpuHand.Where(x => x.Strength == maxStrength).First());
            }
            else
            {
                return Array.IndexOf(cpuHand, cpuHand.Where(x => x.Strength != maxStrength).First());
            }
        }

        public int SecondRoun(Card[] cpuHand, char starter, Card? playerCard = null)
        {

            var maxStrength = cpuHand.Max(x => x.Strength);

            if(starter == 'c')
            {
                return Array.IndexOf(cpuHand, cpuHand.Where(x => x.Strength != maxStrength && x.Strength != 0).First());
            }
            else
            {
                return Array.IndexOf(cpuHand, cpuHand.Where(x => x.Strength == maxStrength).First());
            }
        }

        public int ThirdRound(Card[] cpuHand, char starter, Card? playerCard = null)
        {
            return Array.IndexOf(cpuHand, cpuHand.Where(x => x.Strength != 0).First());
        }
    }
}