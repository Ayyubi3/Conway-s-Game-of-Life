using System;
using System.Text;

namespace Conway_s_Game_of_Life
{
    class Program
    {
        static char[,] Buffer;
        static char[,] NextFrame;

        static void Main(string[] args)
        {
            Console.ReadKey();
            Buffer = new char[Console.WindowWidth, Console.WindowHeight];
            NextFrame = new char[Buffer.GetLength(0), Buffer.GetLength(1)];
            bool runController = true;
            while (runController)
            {
                ConsoleKeyInfo cKI = Console.ReadKey(true);
                switch (cKI.Key)
                {
                    case ConsoleKey.DownArrow:
                        try { Console.CursorTop++; } catch (Exception) { }
                        break;
                    case ConsoleKey.UpArrow:
                        try { Console.CursorTop--; } catch (Exception) { }
                        break;
                    case ConsoleKey.LeftArrow:
                        try { Console.CursorLeft--; } catch (Exception) { }
                        break;
                    case ConsoleKey.RightArrow:
                        try { Console.CursorLeft++; } catch (Exception) { }
                        break;
                    case ConsoleKey.Enter:
                        Console.Write('#');
                        Buffer[Console.CursorLeft, Console.CursorTop] = '#';
                        break;
                    case ConsoleKey.Escape:
                        runController = false;
                        break;
                }
            }
            //Write Buffer to Console
            for (int j = 0; j < Buffer.GetLength(1); j++)
                for (int i = 0; i < Buffer.GetLength(0); i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(Buffer[i, j]);
                }

            while (true)
            {
                Conway();
            }
        }

        private static void Conway()
        {
            //Calculate the next Buffer
            for (int j = 0; j < Buffer.GetLength(1); j++)
                for (int i = 0; i < Buffer.GetLength(0); i++)
                {
                    if (Buffer[i, j] == '#')
                    {
                        int Neighbours = calculateNeighbours(i, j);

                        if (Neighbours == 2 || Neighbours == 3)
                        {
                            NextFrame[i, j] = '#';
                        }
                    }
                    if (Buffer[i, j] == '\0')
                    {
                        int Neighbours = calculateNeighbours(i, j);

                        if (Neighbours == 3)
                        {
                            NextFrame[i, j] = '#';
                        }
                    }
                }

            //Display the next Buffer
            Console.Clear();

            for (int j = 0; j < NextFrame.GetLength(1); j++)
                for (int i = 0; i < NextFrame.GetLength(0); i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(NextFrame[i, j]);
                }



            Array.Copy(NextFrame, Buffer, NextFrame.Length);
            Array.Clear(NextFrame, 0, NextFrame.Length);
        }

        private static bool testjp(int i, int j)
        {
            try
            {
                if (Buffer[i, j + 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private static bool testjm(int i, int j)
        {

            try
            {
                if (Buffer[i, j - 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private static bool testim(int i, int j)
        {

            try
            {
                if (Buffer[i - 1, j] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private static bool testip(int i, int j)
        {

            try
            {
                if (Buffer[i + 1, j] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private static bool testmm(int i, int j)
        {
            try
            {
                if (Buffer[i - 1, j - 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private static bool testpp(int i, int j)
        {
            try
            {
                if (Buffer[i + 1, j + 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private static bool testpm(int i, int j)
        {
            try
            {
                if (Buffer[i + 1, j - 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private static bool testmp(int i, int j)
        {
            try
            {
                if (Buffer[i - 1, j + 1] == '#')
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private static int calculateNeighbours(int i, int j)
        {
            int Neighbours = 0;

            if (testjp(i, j))
                Neighbours++;
            if (testjm(i, j))
                Neighbours++;
            if (testip(i, j))
                Neighbours++;
            if (testim(i, j))
                Neighbours++;
            if (testmm(i, j))
                Neighbours++;
            if (testpp(i, j))
                Neighbours++;
            if (testpm(i, j))
                Neighbours++;
            if (testmp(i, j))
                Neighbours++;

            return Neighbours;

        }




    }
}
