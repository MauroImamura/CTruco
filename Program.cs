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
                case '0': offMatchRender.FinishApp(); break;
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
            var rounds = new char[3]; //p, c or d
            var starter = 'p'; //p, c
            var roundCounter = 0;
            var roundValue = 1;
            inMatchRender.StartRound(playerHand,cpuHand,flipped,0,0,roundValue);
            while(roundCounter < 3)
            {
                //TODO: organize round flow into smaller blocks
                var playerCard = new Card();
                var cpuCard = new Card();
                if (starter == 'p')
                {
                    inMatchRender.ShowCardOptions(roundValue, playerHand);
                    switch(inMatchRender.UserActionKey)
                    {
                        case '0': return false;
                        case '1': playerCard = playerHand[0]; inMatchRender.PlayCard(playerHand[0]); playerHand[0] = new Card(); break;
                        case 'q': inMatchRender.CoverCard(); playerHand[0] = new Card(); break;
                        case '2': playerCard = playerHand[1]; inMatchRender.PlayCard(playerHand[1]); playerHand[1] = new Card(); break;
                        case 'w': inMatchRender.CoverCard(); playerHand[1] = new Card(); break;
                        case '3': playerCard = playerHand[2]; inMatchRender.PlayCard(playerHand[2]); playerHand[2] = new Card(); break;
                        case 'e': inMatchRender.CoverCard(); playerHand[2] = new Card(); break;
                        case '4': break;
                        case '5': roundCounter = 3; inMatchRender.Flee(); break;
                        default: break;
                    }

                    var cpuChoice = cpuStrategy.PlayRound(cpuHand, starter, roundCounter, playerCard: playerCard);
                    switch(cpuChoice)
                    {
                        case 0: cpuCard = cpuHand[0]; inMatchRender.CpuCard(cpuHand[0]); cpuHand[0] = new Card(); break;
                        case 1: cpuCard = cpuHand[1]; inMatchRender.CpuCard(cpuHand[1]); cpuHand[1] = new Card(); break;
                        case 2: cpuCard = cpuHand[2]; inMatchRender.CpuCard(cpuHand[2]); cpuHand[2] = new Card(); break;
                        default: break;
                    }
                }
                else
                {
                    var cpuChoice = cpuStrategy.PlayRound(cpuHand, starter, roundCounter);
                    switch(cpuChoice)
                    {
                        case 0: cpuCard = cpuHand[0]; inMatchRender.CpuCard(cpuHand[0]); cpuHand[0] = new Card(); break;
                        case 1: cpuCard = cpuHand[1]; inMatchRender.CpuCard(cpuHand[1]); cpuHand[1] = new Card(); break;
                        case 2: cpuCard = cpuHand[2]; inMatchRender.CpuCard(cpuHand[2]); cpuHand[2] = new Card(); break;
                        default: break;
                    }
                    
                    inMatchRender.ShowCardOptions(roundValue, playerHand);
                    switch(inMatchRender.UserActionKey)
                    {
                        case '0': return false;
                        case '1': playerCard = playerHand[0]; inMatchRender.PlayCard(playerHand[0]); playerHand[0] = new Card(); break;
                        case 'q': inMatchRender.CoverCard(); playerHand[0] = new Card(); break;
                        case '2': playerCard = playerHand[1]; inMatchRender.PlayCard(playerHand[1]); playerHand[1] = new Card(); break;
                        case 'w': inMatchRender.CoverCard(); playerHand[1] = new Card(); break;
                        case '3': playerCard = playerHand[2]; inMatchRender.PlayCard(playerHand[2]); playerHand[2] = new Card(); break;
                        case 'e': inMatchRender.CoverCard(); playerHand[2] = new Card(); break;
                        case '4': break;
                        case '5': roundCounter = 3; inMatchRender.Flee(); break;
                        default: break;
                    }
                }

                if(playerCard.Strength > cpuCard.Strength)
                {
                    starter = 'p';
                    rounds[roundCounter] = 'p';
                }
                else if(playerCard.Strength < cpuCard.Strength)
                {
                    starter = 'c';
                    rounds[roundCounter] = 'c';
                }
                else
                {
                    rounds[roundCounter] = 'd';
                }

                roundCounter ++;
            }

            //round winner
            //TODO - make an abstraction 
            if(rounds.Where(x => x == 'p').Count() > 1)
            {
                Console.WriteLine("Você venceu a rodada!");
            }
            else if(rounds.Where(x => x == 'c').Count() > 1)
            {
                Console.WriteLine("O CPU venceu a rodada.");
            }
            else if(rounds.Where(x => x == 'p').Count() == rounds.Where(x => x == 'p').Count())
            {
                if(rounds[0] == 'p')
                {
                    Console.WriteLine("Você venceu a rodada!");
                }
                else if(rounds[0] == 'd' && rounds[1] == 'p')
                {
                    Console.WriteLine("Você venceu a rodada!");
                }
                else if(rounds[1] == 'd' && rounds[2] == 'p')
                {
                    Console.WriteLine("Você venceu a rodada!");
                }
                else if(rounds[2] == 'd')
                {
                    Console.WriteLine("A rodada terminou empatada!");
                }
                else
                {
                    Console.WriteLine("O CPU venceu a rodada.");
                }
            }

            return _inGame;
        }
    }
}

