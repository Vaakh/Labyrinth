using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Play
    {
        static void Main()
        {
            SurfLab testLab = new SurfLab();
            testLab.x = 20;
            testLab.y = 20;

            testLab.GenerateSimpleLab();
            testLab.DrawSimpleLab();

            Player pl = new Player();
            pl.currentSurface = "testLab";
            

            Console.ReadKey();
        }

        void Move(string command)
        {
            
        }

    }

    class ChleineLab
    {
        void GenerateChleine()
        {
            SurfLab surf1 = new SurfLab();
            SurfLab surf2 = new SurfLab();
            SurfLab surf3 = new SurfLab();
            SurfLab surf4 = new SurfLab();
            SurfLab surf5 = new SurfLab();
            SurfLab surf6 = new SurfLab();
            SurfLab surf7 = new SurfLab();
            SurfLab surf8 = new SurfLab();
            SurfLab surf9 = new SurfLab();


        }
      
         
    }

    class SurfLab
    {
        public int x, y;
        int [,] surf1v;
        int [,] surf1h;
        int [,] minotaurus;
        int [,] portals; // portals[i,0] - x coord; portals[i,1] - y coord;
        int kolvoPortalov;

        void SetAllWalls(int x, int y)
        {
            surf1h = new int[x + 1, y  + 1];
            surf1v = new int[x + 1, y + 1];

            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    surf1h[i, j] = 1;
                    surf1v[i, j] = 1;
                }
            }
        }

        void DeleteRightWall(double xw, double yw)
        {
            xw = xw + 0.5;
            yw = yw + 0.5;
            surf1h[Convert.ToInt32(xw), Convert.ToInt32(yw)] = 0;
        }

        void DeleteUpperWall(double xw, double yw)
        {
            xw = xw + 0.5;
            yw = yw + 0.5;
            surf1v[Convert.ToInt32(xw), Convert.ToInt32(yw)] = 0;
        }

        public void GenerateSimpleLab()
        {
            double x1 = 0.5;
            double y1 = y - 0.5;

            SetAllWalls(x, y);
            Random ran = new Random();

            for (double i = y1; i > 0; i--)
            {
                for(double j = x1; j < x; j++)
                {

                    if (i + 1 > y & j + 1 < x) { DeleteRightWall(j, i); }

                    if (j + 1 > x & i + 1 < y) { DeleteUpperWall(j, i); }

                    if (j + 1 < x & i + 1 < y)
                    {
                        int k = ran.Next(1, 3);
                        //Console.WriteLine(k);

                        if (k == 1) { DeleteRightWall(j, i); }
                        if (k == 2) { DeleteUpperWall(j, i); }
                    }
                }
            }
        }

        public void DrawSimpleLab()
        {
            double x1 = 0.5;
            double y1 = y - 0.5;
            double x2, y2;
            for (double i = y1; i > 0; i--)
            {
                Console.Write(" ");
                for (double j = x1; j < x; j++)
                {
                    x2 = j + 0.5;
                    y2 = i + 0.5;
                    if (surf1v[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 1 ) { Console.Write("_"); }
                    if (surf1v[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 0 ) { Console.Write(" "); }
                    Console.Write(" ");
                }
                Console.WriteLine();

                y2 = i + 0.5;
                if (surf1h[0, Convert.ToInt32(y2)] == 1) { Console.Write("|"); }
                if (surf1h[0, Convert.ToInt32(y2)] == 0) { Console.Write(" "); }
                Console.Write(" ");

                for (double j = x1; j <= x; j++)
                {
                    x2 = j + 0.5;
                    y2 = i + 0.5;

                    if (surf1h[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 1) { Console.Write("|"); }
                    if (surf1h[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 0) { Console.Write(" "); }
                    Console.Write(" ");
                }
                Console.WriteLine();

            }

            Console.Write(" ");
            for (double j = x1; j < x; j++)
            {
                x2 = j + 0.5;
                y2 = 0;
                if (surf1v[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 1) { Console.Write("_"); }
                if (surf1v[Convert.ToInt32(x2), Convert.ToInt32(y2)] == 0) { Console.Write(" "); }
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        int Move(string command, double x, double y)
        {
            double x1, y1;
            int move = 0;
            if (command.Contains("Up"))
            {
                x1 = x + 0.5;
                y1 = y + 0.5;
                if (surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] == 0) { move = 1; }
                if (surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 0 & surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 1) { move = surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)]; }
            }

            if (command.Contains("Down"))
            {
                x1 = x + 0.5;
                y1 = y - 0.5;
                if (surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] == 0) { move = 1; }
                if (surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 0 & surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 1) { move = surf1v[Convert.ToInt32(x1), Convert.ToInt32(y1)]; }
            }

            if (command.Contains("Left"))
            {
                x1 = x - 0.5;
                y1 = y + 0.5;
                if (surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] == 0) { move = 1; }
                if (surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 0 & surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 1) { move = surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)]; }
            }

            if (command.Contains("Right"))
            {
                x1 = x + 0.5;
                y1 = y + 0.5;
                if (surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] == 0) { move = 1; }
                if (surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 0 & surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)] != 1) { move = surf1h[Convert.ToInt32(x1), Convert.ToInt32(y1)]; }
            }

            return move;

        }

        void GenerateMinotaurus(int minMin, int maxMin)
        {
            int mX, mY;
            minotaurus = new int[x + 1, y + 1];
            Random ran = new Random();
            maxMin++;
            int k = ran.Next(minMin, maxMin);

            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    minotaurus[i, j] = 0;
                }
            }

            for (int i = 1; i <= k; i++)
            {
                mX = ran.Next(0, x);
                mY = ran.Next(0, y);
                if (minotaurus[mX, mY] == 0) { minotaurus[mX, mY] = 1; }
                else
                {
                    mX = ran.Next(0, x);
                    mY = ran.Next(0, y);
                    if (minotaurus[mX, mY] == 0) { minotaurus[mX, mY] = 1; }
                }
            }
        }

        bool MinotaurusExist (double mX, double mY)
        {
            bool exists = false;
            double MX = mX - 0.5;
            double MY = mY - 0.5;

            if (minotaurus[Convert.ToInt32(MX), Convert.ToInt32(MY)] == 1) { exists = true; }

            return exists;

        }

        void KillMinotaurus(double mX, double mY)
        {
            double MX = mX - 0.5;
            double MY = mY - 0.5;

            minotaurus[Convert.ToInt32(MX), Convert.ToInt32(MY)] = 0;
        }

        void GeneratePortals(int portMin, int portMax)
        {
            Random ran = new Random();
            int t;

            kolvoPortalov = ran.Next(portMin, portMax);
            portals = new int[kolvoPortalov, 2];

            kolvoPortalov--;

            for(int i = 0; i <= kolvoPortalov; i++)
            {
                t = ran.Next(0, x);
                portals[i, 0] = t;

                t = ran.Next(0, y);
                portals[i, 1] = t;
            }
        }

        bool PortalExists(double pX, double pY)
        {
            pX = pX - 0.5;
            pY = pY - 0.5;
            bool exists = false;

            for(int i = 0; i <= kolvoPortalov; i++)
            {
                if(portals[i,0] == pX & portals[i,1] == pY) { exists = true; }
            }

            return exists;
        }

        int NumberOfPortal (double pX, double pY)
        {
            int number = -1;
            pX = pX - 0.5;
            pY = pY - 0.5;

            for (int i = 0; i <= kolvoPortalov; i++)
            {
                if (portals[i, 0] == pX & portals[i, 1] == pY) { number = i; }
            }

            return number;
        }

        double[] Teleportation(double cX, double cY)
        {
            double[] nCoords = new double[2];
            int k = NumberOfPortal(cX, cY);
            if(k < kolvoPortalov) { k++; }
            if(k == kolvoPortalov) { k = 0; }
            nCoords[0] = portals[k, 0] + 0.5;
            nCoords[1] = portals[k, 1] + 0.5;
            return nCoords;
        }

    }

    class Player
    {
        public double pX;
        public double pY;

        public string currentSurface;
    }
}
