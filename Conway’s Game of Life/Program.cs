using System;
/*
 
 
 
 
 BUILD IN RELEASE MODE
 Ola
 
 
 
 
 */
class Program
{
    static char[,] Buffer;
    static char[,] NewBuffer;

    public static char NodeChar = '#';

    static void Main(string[] args)
    {
        Console.Title = "Conway´s Game of Life";

        Console.WriteLine("Adjust font size and window size");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        Console.Clear();

        Buffer = new char[Console.WindowWidth, Console.WindowHeight];
        NewBuffer = new char[Buffer.GetLength(0), Buffer.GetLength(1)];

        Console.WriteLine("Arrow keys to move cursor and Enter to set node");
        Console.WriteLine("Escape to start simulation");


        Console.CursorVisible = true;

        //Controller to set nodes
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
                    {
                        //A way to prevent ConsoleCursor to move to the right after writing NodeChar
                        int x = Console.CursorLeft;
                        int y = Console.CursorTop;
                        Console.Write(NodeChar);
                        Console.SetCursorPosition(x, y);

                        //Add to Buffer
                        Buffer[Console.CursorLeft, Console.CursorTop] = NodeChar;
                    }
                    break;
                case ConsoleKey.Escape:
                    runController = false;
                    break;
            }
        }

        Console.Clear();

        Console.CursorVisible = false;

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

                //Go thorugh each node in Buffer and check rule
                if (Buffer[i, j] == NodeChar)
                {
                    int Neighbours = calculateNeighbours(i, j);

                    if (Neighbours == 2 || Neighbours == 3)
                    {
                        //Add to if rules allow it
                        NewBuffer[i, j] = NodeChar;
                    }
                }
                if (Buffer[i, j] == '\0')
                {
                    int Neighbours = calculateNeighbours(i, j);

                    if (Neighbours == 3)
                    {
                        //Add to if rules allow it
                        NewBuffer[i, j] = NodeChar;
                    }
                }

            }

        //Display the next Buffer

        //Either clear console or go through each

        Console.Clear();

        for (int j = 0; j < NewBuffer.GetLength(1); j++)
            for (int i = 0; i < NewBuffer.GetLength(0); i++)
            {
                //Console.SetCursorPosition(i, j);
                //Console.Write(" ");

                Console.SetCursorPosition(i, j);
                Console.Write(NewBuffer[i, j]);
            }


        //
        Array.Copy(NewBuffer, Buffer, NewBuffer.Length);
        Array.Clear(NewBuffer, 0, NewBuffer.Length);
    }

    private static bool test(int i, int j, string calculation)
    {
        try
        {
            //m = minus, p = plus, j or i referes to the iterator
            bool condition = false;

            switch (calculation)
            {
                case "jp":
                    condition = Buffer[i, j + 1] == NodeChar;
                    break;
                case "jm":
                    condition = Buffer[i, j - 1] == NodeChar;
                    break;
                case "im":
                    condition = Buffer[i - 1, j] == NodeChar;
                    break;
                case "ip":
                    condition = Buffer[i + 1, j] == NodeChar;
                    break;
                case "mm":
                    condition = Buffer[i - 1, j - 1] == NodeChar;
                        break;
                case "pp":
                    condition = Buffer[i + 1, j + 1] == NodeChar;
                    break;
                case "pm":
                    condition = Buffer[i + 1, j - 1] == NodeChar;
                    break;
                case "mp":
                    condition = Buffer[i - 1, j + 1] == NodeChar;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            if (condition)
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

        if (test(i, j, "jp"))
            Neighbours++;
        if (test(i, j, "jm"))
            Neighbours++;
        if (test(i, j, "ip"))
            Neighbours++;
        if (test(i, j, "im"))
            Neighbours++;
        if (test(i, j, "mm"))
            Neighbours++;
        if (test(i, j, "pp"))
            Neighbours++;
        if (test(i, j, "pm"))
            Neighbours++;
        if (test(i, j, "mp"))
            Neighbours++;

        return Neighbours;

    }
}

