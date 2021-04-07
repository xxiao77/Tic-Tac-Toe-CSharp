using System;

class HumanPlayer : Player
{
    public HumanPlayer(char p) : base(p)
    {

    }
    public override void Play(char[,] board)
    {
        Console.WriteLine("Please enter number 1 - 9: ");
        int n = Int32.Parse(Console.ReadLine()) - 1;
        int r = n / 3;
        int c = n % 3;
        board[r, c] = player;
    }
}
