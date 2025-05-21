namespace Szachy;

public class Queen : Piece
{
    public Queen(PieceColor color) : base(color) {}

    public override char Symbol => Color == PieceColor.White ? 'Q' : 'q';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        int dx = Math.Abs(to.x - from.x);
        int dy = Math.Abs(to.y - from.y);

        bool diagonal = dx == dy;
        bool straight = from.x == to.x || from.y == to.y;

        if (!diagonal && !straight) return false;

        int stepX = dx == 0 ? 0 : (to.x - from.x) / dx;
        int stepY = dy == 0 ? 0 : (to.y - from.y) / dy;

        int x = from.x + stepX;
        int y = from.y + stepY;

        // Sprawdzenie czy droga wolna
        while (x != to.x || y != to.y)
        {
            if (board.Squares[x, y] != null)
                return false;

            x += stepX;
            y += stepY;
        }

        return true;
    }
}