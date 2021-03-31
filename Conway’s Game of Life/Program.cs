using System;
using System.Text;

namespace Conway_s_Game_of_Life
{
    class Program
    {
        static char[,] Buffer = new char[Console.WindowWidth, Console.WindowHeight];
        static char[,] NextFrame = new char[Buffer.GetLength(0), Buffer.GetLength(1)];

        static void Main(string[] args)
        {

            //for (int j = 0; j < Buffer.GetLength(1); j++)
            //    for (int i = 0; i < Buffer.GetLength(0); i++)
            //    {
            //        Buffer[i, j] = '+';
            //    }
            Buffer[0 + 1, 0 + 1] = '#';
            Buffer[2 + 1, 0 + 1] = '#';
            Buffer[1 + 1, 1 + 1] = '#';
            Buffer[2 + 1, 1 + 1] = '#';
            Buffer[1 + 1, 2 + 1] = '#';

            while (true)
            {
                test();
            }
        }

        private static void test()
        {
            Write();


            Calculate();


            WriteNextFrame();


            Array.Copy(NextFrame, Buffer, NextFrame.Length);
            Array.Clear(NextFrame, 0, NextFrame.Length);
        }

        private static void WriteNextFrame()
        {
            Console.Clear();

            for (int j = 0; j < NextFrame.GetLength(1); j++)
                for (int i = 0; i < NextFrame.GetLength(0); i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(NextFrame[i, j]);
                }
        }

        private static void Calculate()
        {
            for (int j = 0; j < Buffer.GetLength(1); j++)
                for (int i = 0; i < Buffer.GetLength(0); i++)
                {
                    if (Buffer[i, j] == '#')
                    {
                        int Neighbours = 0;

                        if (Buffer[i, j + 1] == '#')
                            Neighbours++;
                        if (Buffer[i, j - 1] == '#')
                            Neighbours++;
                        if (Buffer[i + 1, j] == '#')
                            Neighbours++;
                        if (Buffer[i - 1, j] == '#')
                            Neighbours++;
                        if (Buffer[i - 1, j - 1] == '#')
                            Neighbours++;
                        if (Buffer[i + 1, j + 1] == '#')
                            Neighbours++;
                        if (Buffer[i - 1, j + 1] == '#')
                            Neighbours++;
                        if (Buffer[i + 1, j - 1] == '#')
                            Neighbours++;

                        if (Neighbours == 2 || Neighbours == 3)
                        {
                            NextFrame[i, j] = '#';
                        }
                    }
                    if (Buffer[i, j] == '\0')
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

                        if (Neighbours == 3)
                        {
                            NextFrame[i, j] = '#';
                        }
                    }
                }
        }

        private static void Write()
        {
            for (int j = 0; j < Buffer.GetLength(1); j++)
                for (int i = 0; i < Buffer.GetLength(0); i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(Buffer[i, j]);
                }

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




    }
}
