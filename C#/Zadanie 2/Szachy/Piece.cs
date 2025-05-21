namespace Szachy;

public enum PieceColor { White, Black }

public abstract class Piece
{
    public PieceColor Color { get; private set; }

    protected Piece(PieceColor color)
    {
        Color = color;
    }

    public abstract char Symbol { get; }

    public abstract bool IsValidMove((int x, int y) from, (int x, int y) to, Board board);
}