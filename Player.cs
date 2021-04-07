abstract class Player
{
    protected char player;

    protected Player(char p)
    {
        player = p;
    }
    public abstract void Play(char[,] board);
}