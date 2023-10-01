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
            var cardHandler = new CardHandler();
            var screenRender = new OffGameRender();
            var inGame = false;

            //step 1: sort cards for players
            cardHandler.CardSorting();
            var playerHand = cardHandler.PlayerHand;
            var cpuHand = cardHandler.CpuHand;
            var flipped = cardHandler.Flipped;

            //step 2: start game
            screenRender.TitleScreen();

            while(!inGame)
            {
                switch(screenRender.UserActionKey)
                {
                    case '0': screenRender.TitleScreen(); break;
                    case '1': inGame = true; break;
                    case '2': screenRender.ShowInstructions(); break;
                    case '3': screenRender.ShowCredits(); break;
                    case '4': screenRender.FinishApp(); break;
                    default: screenRender.TitleScreen(); break;
                }
            }

            //sample code
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

