using System;

namespace Models
{
    enum ERoundScore
    {
        normal = 1,
        truco = 3,
        seis = 6,
        nove = 9,
        doze = 12,
    }

    public class Score
    {
        public int PlayerScore { get; private set; } = 0;

        public int CpuScore { get; private set; } = 0;

        public void UpdateScore(int roundValue, string winner)
        {
            if("player".Equals(winner))
            {
                PlayerScore += roundValue;
            }
            if("cpu".Equals(winner))
            {
                CpuScore += roundValue;
            }
        }
    }
}