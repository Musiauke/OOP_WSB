namespace Szachy;

public class Rook : Piece
{
    public Rook(PieceColor color) : base(color) {}

    public override char Symbol => Color == PieceColor.White ? 'R' : 'r';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        if (from.x != to.x && from.y != to.y)
            return false; // Ruch nie jest w linii

        // Sprawdzenie, czy droga jest wolna
        int dx = Math.Sign(to.x - from.x);
        int dy = Math.Sign(to.y - from.y);

        int x = from.x + dx;
        int y = from.y + dy;

        while ((x, y) != to)
        {
            if (board.Squares[x, y] != null)
                return false;

            x += dx;
            y += dy;
        }

        return true;
    }
}