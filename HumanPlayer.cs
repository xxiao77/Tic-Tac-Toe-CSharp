using System;

class HumanPlayer : Player
{
    //constructor
    public HumanPlayer(char p) : base(p) { }

    public override void Play(char[,] board)
    {
        int r = 0;
        int c = 0;
        bool valid;
        // System.FormatException
        do
        {
            valid = true;
            Console.WriteLine("Player " + PSymbol + ", please enter number 1 - 9: ");
            try
            {
                int n = Int32.Parse(Console.ReadLine()) - 1;
                r = n / 3;
                c = n % 3;
            }
            catch (FormatException e)
            {
                valid = false;
            }
        } while (!valid || board[r, c] != 0);
        board[r, c] = PSymbol;
    }
}