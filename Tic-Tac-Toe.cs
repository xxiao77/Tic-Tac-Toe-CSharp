class MainClass
{
    public static void Main(string[] args)
    {
        char[,] board = new char[3, 3];
        // board[0, 0] = 'X';
        // board[2, 2] = 'O';

        for (int row = 0; row < 3; row++)
        {
            System.Console.Write("| ");
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
                board[0, 0] = 'X';
                board[2, 2] = 'O';
                System.Console.Write(board[row, col]);
                System.Console.Write(" | ");
            }
            System.Console.WriteLine();
        }
    }
}

