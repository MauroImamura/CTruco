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
            var offScreenRender = new OffMatchRender();
            var inScreenRender = new InMatchRender();
            while(runApp)
            {
                if(inGame)
                    inGame = InRoundExec(inScreenRender);
                else
                    inGame = OffRoundExec(offScreenRender);
            }
        }

        private static bool OffRoundExec(OffMatchRender offScreenRender)
        {
            var _inGame = false;
            switch(offScreenRender.UserActionKey)
            {
                case '1': _inGame = offScreenRender.StartNewMatch(); break;
                case '2': offScreenRender.ShowInstructions(); break;
                case '3': offScreenRender.ShowCredits(); break;
                case '4': offScreenRender.FinishApp(); break;
                default: offScreenRender.TitleScreen(); break;
            }
            return _inGame;
        }

        private static bool InRoundExec(InMatchRender inScreenRender)
        {
            var _inGame = true;
            var cardHandler = new CardHandler();
            var score = new Score();
            cardHandler.CardSorting();
            var playerHand = cardHandler.PlayerHand;
            var cpuHand = cardHandler.CpuHand;
            var flipped = cardHandler.Flipped;
            var winner = "";
            var rounds = new string[3];
            var roundValue = 1;
            inScreenRender.StartRound(playerHand,cpuHand,flipped,0,0,roundValue);
            inScreenRender.ShowCardOptions(roundValue);
            switch(inScreenRender.UserActionKey)
            {
                case '0': _inGame = false; break;
                case '1': break;
                case '2': break;
                case '3': break;
                case '4': break;
                default: break;
            }
            return _inGame;
        }
    }
}

