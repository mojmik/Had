using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Had
{
    class Program
    {
        static void runGame()
        {
            int tick=0;
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Had had = new Had(); // Instance hada
            Zradlo zradlo = new Zradlo(); // Instance hada
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Green; // Nastavení zeleného pozadí
            Console.Clear(); 
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int n=0; n<Console.WindowWidth; n++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("█");
            }
            while (had.Zivy) // Herní smyčka
            {
                tick++;
                
                
                
                if (tick % 5 == 0) zradlo.PridejDilek();
                zradlo.Vykresli();

                had.Vykresli(); // Vykreslení hada
                had.Lez(zradlo); // Posun hada
                had.PrintInfo(); //kde jsme atd.
                

                Thread.Sleep(30); // Čekáme 30 milisekund
                                  // Pokud je stisknuta nějaká klávesa
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klavesa = Console.ReadKey(); // Načtení klávesy
                    if (klavesa.Key == ConsoleKey.Escape)
                    {
                        had.Zivy = false;
                    }
                    if (klavesa.Key == ConsoleKey.RightArrow)
                        had.Smer = 0;
                    if (klavesa.Key == ConsoleKey.LeftArrow)
                        had.Smer = 180;
                    if (klavesa.Key == ConsoleKey.DownArrow)
                        had.Smer = 270;
                    if (klavesa.Key == ConsoleKey.UpArrow)
                        had.Smer = 90;
                }
            }
        }
        static void Main(string[] args)
        {
            bool gameEnd = false;
            while (!gameEnd)
            {
                runGame();
                Console.WriteLine("Hrat znova? a/n");
                char key=Console.ReadKey().KeyChar;
                if (key == 'n') gameEnd = true;
            }
            
        }
    }
}
