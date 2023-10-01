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
            UserActionKey = Console.ReadKey().KeyChar;
            return;
        }

        public void FinishApp()
        {
            //TODO request confirmation before quitting
            Environment.Exit(0);
        }

        public void ShowInstructions()
        {
            //TODO write instructions
            Console.WriteLine("Instructions");
            ReturnToTitle();
        }

        public void ShowCredits()
        {
            //TODO write credits
            Console.WriteLine("Credits");
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