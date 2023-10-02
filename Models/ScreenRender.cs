using System;

namespace Models
{
    public class OffGameRender
    {
        public char UserActionKey { get; private set; } = ' ';

        public void TitleScreen()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|                      CONSOLE TRUCO                         |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Boas vindas ao Console Truco!");
            Console.WriteLine("1 - Start");
            Console.WriteLine("2 - Instruções");
            Console.WriteLine("3 - Créditos");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("");
            Console.WriteLine("Selecione uma ação (1/2/3/4)");
            UserActionKey = Console.ReadKey(false).KeyChar;
            return;
        }

        public void FinishApp()
        {
            //TODO request confirmation before quitting
            Environment.Exit(0);
        }

        public void ShowInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("    Instruções    ");
            Console.WriteLine();
            Console.WriteLine("    O Truco é disputado em três rodadas (“melhor de três”), para ver quem tem as cartas mais “fortes” (de valor simbólico mais alto).");
            Console.WriteLine("    Sequência da maior para a menor: 3 2 A K J Q 7 6 5 4 (de todos os naipes).");
            Console.WriteLine("    A manilha é nova ou variável, sendo determinada pelo tombo/vira.");
            Console.WriteLine("    Tombo/Vira é a carta que o embaralhador vira quando distribui as cartas. É a carta que definirá as 4 manilhas.");
            Console.WriteLine("    A carta que de acordo com a sequência é a próxima do tombo/vira, em seus 4 diferentes naipes, são definidas como as Manilhas.");
            Console.WriteLine("    Dentre elas, a ordem de “força” obedece o naipe, da seguinte maneira (do maior para o menor): Paus(Zap) > Copas > Espadas > Ouros");
            Console.WriteLine("    Manilhas são as cartas mais fortes do jogo, mais fortes do que o 3.");
            Console.WriteLine("    Cada mão é uma fração da partida, vale 1 ponto e poderá ter seu valor aumentado para 3, 6, 9 e 12 pontos. É disputada em melhor de 3 rodadas.");
            Console.WriteLine("    Em cada rodada, os jogadores mostram uma carta. A carta mais forte ganha a rodada.");
            Console.WriteLine("    O jogo se encerra quando um dos jogadores atinge 12 pontos.");
            Console.WriteLine("    Truco é um pedido de “aumento de aposta” que só pode ser feito na vez de cada jogador.");
            Console.WriteLine("    Se nenhum jogador fizer o pedido, a partida valerá 1 ponto. Se o Truco for pedido e o adversário aceitar, a partida passa a valer 3 pontos.");
            Console.WriteLine("    Se o adversário não aceitar, o jogador que fez o pedido ganha um ponto.");
            Console.WriteLine("    Depois do pedido de truco, o valor da mão pode ser aumentado pelo adversário ao pedir Seis.");
            Console.WriteLine("    Ao pedir Seis, se o adversário não aceitar, o jogador que fez o pedido ganha 3 ponto.");
            Console.WriteLine("    Depois do pedido de Seis, o valor da mão pode ser aumentado pelo adversário ao pedir Nove.");
            Console.WriteLine("    Ao pedir Nove, se o adversário não aceitar, o jogador que fez o pedido ganha 6 ponto.");
            Console.WriteLine("    Depois do pedido de Nove, o valor da mão pode ser aumentado pelo adversário ao pedir Doze.");
            Console.WriteLine("    Ao pedir Doze, se o adversário não aceitar, o jogador que fez o pedido ganha 9 ponto.");
            Console.WriteLine("    Cada mão é uma melhor de 3 rodadas, sendo que em caso de empate o jogador que venceu a primeira rodada é o vencedor.");
            Console.WriteLine("    Caso a primeira rodada tenha empatado, é verificada a segunda rodada, e após ela a terceira. Caso todas as rodadas tenham empatado, nenhum ponto é dados aos jogadores.");
            ReturnToTitle();
        }

        public void ShowCredits()
        {
            Console.WriteLine();
            Console.WriteLine("    Créditos    ");
            Console.WriteLine();
            Console.WriteLine("    Jogo desenvolvido por Mauro Imamura -> https://github.com/MauroImamura");
            Console.WriteLine("    Outubro de 2023.");
            Console.WriteLine();
            ReturnToTitle();
        }

        public void ReturnToTitle()
        {
            Console.WriteLine("");
            Console.Write("Pressione qualquer tecla para retornar.");
            Console.ReadKey();
            TitleScreen();
        }
    }

    //TODO new class for inGame status
}