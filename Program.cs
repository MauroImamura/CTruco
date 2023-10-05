using System;
using System.Runtime.InteropServices;
using Models;

namespace CTruco
{
    //Jogo de Truco 1 contra 1, player contra CPU
    class Program
    {
        static void Main(string[] args)
        {
            var inGame = false;
            var runApp = true;
            var offMatchRender = new OffMatchRender();
            var inMatchRender = new InMatchRender();
            while(runApp)
            {
                if(inGame)
                    inGame = InRoundExec(inMatchRender);
                else
                    inGame = OffRoundExec(offMatchRender);
            }
        }

        private static bool OffRoundExec(OffMatchRender offMatchRender)
        {
            var _inGame = false;
            switch(offMatchRender.UserActionKey)
            {
                case '1': _inGame = offMatchRender.StartNewMatch(); break;
                case '2': offMatchRender.ShowInstructions(); break;
                case '3': offMatchRender.ShowCredits(); break;
                case '4': offMatchRender.FinishApp(); break;
                default: offMatchRender.TitleScreen(); break;
            }
            return _inGame;
        }

        private static bool InRoundExec(InMatchRender inMatchRender)
        {
            var _inGame = true;
            var cardHandler = new CardHandler();
            var score = new Score();
            var cpuStrategy = new EasyCpuStrategy();
            cardHandler.CardSorting();
            var playerHand = cardHandler.PlayerHand;
            var cpuHand = cardHandler.CpuHand;
            var flipped = cardHandler.Flipped;
            var rounds = new string[3];
            var roundCounter = 0;
            var roundValue = 1;
            inMatchRender.StartRound(playerHand,cpuHand,flipped,0,0,roundValue);
            while(roundCounter < 3)
            {
                inMatchRender.ShowCardOptions(roundValue, playerHand);
                (char value, string suit)? playerCard = null;
                switch(inMatchRender.UserActionKey)
                {
                    case '0': return false;
                    case '1': playerCard = playerHand[0]; inMatchRender.PlayCard(playerHand[0]); playerHand[0] = ('0',""); break;
                    case 'q': inMatchRender.CoverCard(); playerHand[0] = ('0',""); break;
                    case '2': playerCard = playerHand[1]; inMatchRender.PlayCard(playerHand[1]); playerHand[1] = ('0',""); break;
                    case 'w': inMatchRender.CoverCard(); playerHand[1] = ('0',""); break;
                    case '3': playerCard = playerHand[2]; inMatchRender.PlayCard(playerHand[2]); playerHand[2] = ('0',""); break;
                    case 'e': inMatchRender.CoverCard(); playerHand[2] = ('0',""); break;
                    case '4': break;
                    case '5': roundCounter = 3; inMatchRender.Flee(); break;
                    default: break;
                }
                //TODO: get char response from cpu strategy and create messages on render function
                Console.WriteLine(cpuStrategy.FirstRound(flipped,playerCard, cpuHand));
                roundCounter ++;
            }
            return _inGame;
        }
    }
}

