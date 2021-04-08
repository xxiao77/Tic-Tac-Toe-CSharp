using System;
class AIPlayer : Player
{
    Random random;
    public AIPlayer(char p) : base(p)
    {
        random = new Random();
    }
    public override void Play(char[,] board)
    {
        int r;
        int c;

        do
        {
            int randomNum = random.Next(0, 8);
            r = randomNum / 3;
            c = randomNum % 3;
        } while (board[r, c] != 0);

        board[r, c] = PSymbol;
    }
}