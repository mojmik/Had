using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Had
{
    public class DilekZradla
    {
        public int x;
        public int y;
        static Random rnd=new Random();
        ConsoleColor Barva;
        public DilekZradla()
        {
            this.x = rnd.Next(0, Console.WindowWidth / 2 - 1);
            this.y = rnd.Next(1, Console.WindowHeight);
            Barva = ConsoleColor.Red;
        }
        public void Vykresli()
        {
            Console.CursorLeft = this.x*2;
            Console.CursorTop = this.y;
            Console.ForegroundColor = Barva;
            Console.Write("**");
        }
    }
}
