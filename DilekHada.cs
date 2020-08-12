using System;
using System.Collections.Generic;
using System.Text;

namespace Had
{
    public class DilekHada
    {
        public int x;
        public int y;
        ConsoleColor Barva;
        public DilekHada(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Vykresli()
        {
            Console.CursorLeft = this.x * 2;
            Console.CursorTop = this.y;
            Console.ForegroundColor = Barva;
            Console.Write("██");
        }
    }
}
