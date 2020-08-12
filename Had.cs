using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Had
{
    public class Had
    {
        public bool Zivy { get; set; }
        public int Smer { get; set; }
        public int Skore { get; set; }
        List<DilekHada> Dilky = new List<DilekHada>();
        public Had()
        {
            Smer = 0;
            Skore = 0;
            Zivy = true;
            PridejDilek(10, 10);
            PridejDilek(11, 10);
            PridejDilek(12, 10);         

        }
        public void PrintInfo()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"{Dilky.Last().x},{Dilky.Last().y},{Console.WindowWidth},{Console.WindowHeight}, skore: {Skore} ");
        }
        public void PridejDilek(int x, int y)
        {
            Dilky.Add(new DilekHada(x,y));
        }
        public void Vykresli()
        {
            int pocetDilku = Dilky.Count();
            for (int n=0;n<pocetDilku;n++)
            {
                Dilky[n].Vykresli();
            }
        }
        public void Chcipni()
        {
            this.Zivy = false;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Had chcipnul, game over");            
        }
        public void Lez(Zradlo z)
        {
            int newX=0, newY=0;
            newX = Dilky.Last().x;
            newY= Dilky.Last().y;
            if (Smer == 0) newX = newX + 1;
            if (Smer == 180) newX = newX - 1;
            if (Smer == 270) newY = newY + 1;
            if (Smer == 90) newY = newY - 1;
            if (Kolize(newX,newY)) {
                Chcipni();
                return;
            }
            //posledni dilek je hlava            
            if (!Zer(newX, newY, z))
            {
                Console.CursorLeft = Dilky.First().x*2;
                Console.CursorTop = Dilky.First().y;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("██");
                Dilky.Remove(Dilky.First());
            }
            PridejDilek(newX, newY);
        }
        public bool Kolize(int x, int y)
        {
            int maxX = Console.WindowWidth/2-1;
            int maxY = Console.WindowHeight;
            if (x < 0 || y < 1 || x > maxX || y > maxY) return true;
            int pocetDilku = Dilky.Count();
            for (int n = 0; n < pocetDilku; n++)
            {
                int curX = Dilky[n].x;
                int curY = Dilky[n].y;
                if ( (curX == x) && (curY == y) ) return true;
            }
            return false;
        }
        public bool Zer(int x , int y,Zradlo z)
        {
            int pocetDilku = z.Dilky.Count();
            for (int n = 0; n < pocetDilku-1; n++)
            {
                int curX = z.Dilky[n].x;
                int curY = z.Dilky[n].y;
                if ((curX == x) && (curY == y))
                {
                    z.Dilky.Remove(z.Dilky[n]);
                    Console.Beep(900, 50);
                    Skore += 50;
                    return true;
                }
            }
            return false;
        }
    }
}
