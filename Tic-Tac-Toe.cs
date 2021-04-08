using System;
class GUI
{
    private char[,] board;
    private Player oPlayer, xPlayer, curPlayer;
    private int turns;
    private char winner;

    // constructor
    public GUI() { }

    public void gameProcess()
    {
        do
        {
            initGame();
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
    private void initGame()
    {
        board = new char[3, 3];
        turns = 0;
        winner = (char)0;
        oPlayer = null;
        xPlayer = null;
        curPlayer = null;
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
    private void printBoard()
    {
        Console.WriteLine();
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                // one line solution
                // Console.Write("| " + (board[r, c] != 0 ? board[r, c] : ' ') + " |");

                switch (board[r, c])
                {
                    case 'X':
                        Console.Write("| " + 'X' + " |");
                        break;
                    case 'O':
                        Console.Write("| " + 'O' + " |");
                        break;
                    default:
                        Console.Write("| " + ' ' + " |");
                        break;
                }
            }

            Console.WriteLine();
        }
    }
    private bool isGameEnd()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            {
                winner = board[i, 0];
                return true;
            }
            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[0, i] == board[2, i])
            {
                winner = board[0, i];
                return true;
            }
        }

        if ((board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) ||
            (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
        {
            winner = board[1, 1];
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
        if (winner == 0)
        {
            Console.WriteLine("The game is a draw!");
        }
        else
        {
            Console.WriteLine("Player " + winner + " Win!");
        }
        Console.WriteLine("Would you like to play again? Y/N");
        string p = Console.ReadLine();

        switch (p)
        {
            case "y":
            case "Y":
                return true;
            default:
                return false;
        }

    }

    public static void Main(string[] args)
    {
        new GUI().gameProcess();
    }
}

