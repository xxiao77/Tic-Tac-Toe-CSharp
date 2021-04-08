using System;

abstract class Player
{
    private char pSymbol;

    public char PSymbol
    {
        get { return pSymbol; }
    }
    protected Player(char p)
    {
        pSymbol = p;
        // Console.WriteLine(PSymbol);
    }
    public abstract void Play(char[,] board);
}