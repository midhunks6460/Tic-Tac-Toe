using System;
using System.Threading;

public class Class1
{
    static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int flag;

    /// <summary>
    /// Draw the gameboard
    /// </summary>
    static void DrawBoard()
    {
        Console.WriteLine("      |      |     ");
        Console.WriteLine("  {0}   |  {1}   |   {2}  ", spaces[0], spaces[1], spaces[2]);
        Console.WriteLine(" _____|_____ |_____");
        Console.WriteLine("      |      |     ");
        Console.WriteLine("  {0}   |  {1}   |   {2}  ", spaces[3], spaces[4], spaces[5]);
        Console.WriteLine(" _____|_____ |_____");
        Console.WriteLine("      |      |     ");
        Console.WriteLine("  {0}   |  {1}   |   {2}  ", spaces[6], spaces[7], spaces[8]);
        Console.WriteLine("      |      |     ");

    }
    /// <summary>
    /// Used to check who won the match
    /// </summary>
    static int CheckWin()
    {
        if (spaces[0] == spaces[1] && spaces[1] == spaces[2] ||//row1
            spaces[3] == spaces[4] && spaces[4] == spaces[5] ||//row2
            spaces[6] == spaces[7] && spaces[7] == spaces[8] ||//row3
            spaces[0] == spaces[3] && spaces[3] == spaces[6] ||//column1
            spaces[1] == spaces[4] && spaces[4] == spaces[7] ||//column2
            spaces[2] == spaces[5] && spaces[5] == spaces[8] ||//column3
            spaces[0] == spaces[4] && spaces[4] == spaces[8] ||//diagonal1
            spaces[2] == spaces[4] && spaces[4] == spaces[6] //diagonal2
                                                             )
        {
            return 1;
        }
        else if (spaces[0] != '1' &&
                 spaces[1] != '2' &&
                 spaces[2] != '3' &&
                 spaces[3] != '4' &&
                 spaces[4] != '5' &&
                 spaces[5] != '6' &&
                 spaces[6] != '7' &&
                 spaces[7] != '8' &&
                 spaces[8] != '9')
        {
            return -1;
        }

        else
        {
            return 0;
        }

    }
    /// <summary>
    /// Draw of X(Game of X)
    /// </summary>
    /// <param name="pos"></param>

    static void DrawX(int pos)
    {
        spaces[pos] = 'X';
    }
    /// <summary>
    /// Draw of Y(Game of Y)
    /// </summary>
    /// <param name="pos"></param>
    static void DrawO(int pos)
    {
        spaces[pos] = 'O';
    }

    public static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Player1 : X  and  Player2 : O" + "\n");
            if (player % 2 == 0)
            {
                Console.WriteLine("Player 2's turn");
            }
            else
            {
                Console.WriteLine("Player 1's turn");
            }
            Console.WriteLine("\n");
            DrawBoard();
            choice = (int.Parse(Console.ReadLine()) - 1);

            if (spaces[choice] != 'X' && spaces[choice] != 'O')
            {
                if (player % 2 == 0)
                {
                    DrawO(choice);
                }
                else
                {
                    DrawX(choice);
                }
                player++;
            }
            else
            {
                Console.WriteLine("The row {0} is already occupied with {1}\n", choice, spaces[choice]);
                Console.WriteLine("Please wait for 2 seconds");
                Thread.Sleep(2000);
            }

            flag = CheckWin();
        } while (flag != 1 && flag != -1);


        Console.Clear();
        DrawBoard();
        if (flag == 1)
        {
            Console.WriteLine("Player {0} has won", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Match tied");
        }

        Console.ReadLine();
    }
}