namespace Szachy;

public class Knight : Piece
{
    public Knight(PieceColor color) : base(color) {}

    public override char Symbol => Color == PieceColor.White ? 'N' : 'n';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        int dx = Math.Abs(to.x - from.x);
        int dy = Math.Abs(to.y - from.y);

        if ((dx == 2 && dy == 1) || (dx == 1 && dy == 2))
        {
            var target = board.Squares[to.x, to.y];
            return target == null || target.Color != this.Color;
        }

        return false;
    }
}