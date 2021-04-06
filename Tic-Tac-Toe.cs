using System;
class GUI
{
    private char[,] board;
    private Player oPlayer, xPlayer, curPlayer;
    private int turns;

    public GUI()
    {
        board = new char[3, 3];
        turns = 0;
    }

    public void gameProcess()
    {
        do
        {
            // selectPlayer();
            printBoard();
            return;
            do
            {
                // check current player
                curPlayer = turns % 2 == 0 ? oPlayer : xPlayer;
                curPlayer.Play(board);
                turns++;
                printBoard();
            } while (!hasWinner());
        } while (displayEndGame());
    }
    public static void Main(string[] args)
    {
        new GUI().gameProcess();
    }

    private void selectPlayer()
    {
        oPlayer = setPlayer("O");
        xPlayer = setPlayer("X");
    }

    private Player setPlayer(string playerDisplay)
    {
        Player ret = null;
        do
        {
            Console.WriteLine("Please choose player " + playerDisplay + " (h = human, a = AI): ");
            string p = Console.ReadLine();

            switch (p)
            {
                case "h":
                    ret = new HumanPlayer();
                    break;
                case "a":
                    ret = new AIPlayer();
                    break;
                default:
                    break;
            }
        } while (ret == null);
        return ret;
    }
    // print board
    // | 1 || 2 || 3 |
    // | 4 || 5 || 6 |
    // | 7 || 8 || 9 |
    private void printBoard()
    {
        int n = 1;
        // board[1, 1] = 'X';
        // board[2, 2] = 'O';

        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                switch (board[r, c])
                {
                    case 'X':
                        Console.Write("| " + 'X' + " |");
                        break;
                    case 'O':
                        Console.Write("| " + 'O' + " |");
                        break;
                    default:
                        Console.Write("| " + n + " |");
                        break;
                }
                n++;
            }

            Console.WriteLine();
        }
    }
    private bool hasWinner()
    {
        return true;
    }

    private bool displayEndGame()
    {
        return true;
    }
}

