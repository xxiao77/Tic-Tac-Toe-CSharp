using System;
class GUI
{
    private char[,] board;
    private Player oPlayer, xPlayer, curPlayer;
    private int turns;
    private char winner;

    // constructor
    public GUI()
    {
        board = new char[3, 3];
        turns = 0;
    }

    public void gameProcess()
    {
        do
        {
            selectPlayer();
            printBoard();
            // return;
            do
            {
                // check current player
                curPlayer = turns % 2 == 0 ? oPlayer : xPlayer;
                curPlayer.Play(board);
                turns++;
                printBoard();
            } while (!isGameEnd());
        } while (displayEndGame());
    }
    public static void Main(string[] args)
    {
        new GUI().gameProcess();
    }

    private void selectPlayer()
    {
        oPlayer = setPlayer('O');
        xPlayer = setPlayer('X');
    }

    private Player setPlayer(char playerDisplay)
    {
        Player ret = null;
        do
        {
            Console.WriteLine("Please choose player " + playerDisplay + " (h = human, a = AI): ");
            string p = Console.ReadLine();

            switch (p)
            {
                case "h":
                    ret = new HumanPlayer(playerDisplay);
                    break;
                case "a":
                    ret = new AIPlayer(playerDisplay);
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

        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                // one line solution
                // Console.Write("| " + (board[r, c] != 0 ? board[r, c] : n) + " |");

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
    private bool isGameEnd()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            {
                return true;
            }
            if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
            {
                return true;
            }
        }

        if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
        {
            return true;
        }
        if (turns == 9)
        {
            return true;
        }
        return false;
    }

    private bool displayEndGame()
    {
        Console.WriteLine("Player" + winner + "Win!");
        Console.WriteLine("Would you like to play again? Y/N");
        string p = Console.ReadLine();

        switch (p)
        {
            case "Y":
                return true;
            default:
                return false;
        }

    }
}

