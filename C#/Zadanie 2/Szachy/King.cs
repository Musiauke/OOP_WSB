namespace Szachy;

public class King : Piece
{
    public King(PieceColor color) : base(color) {}

    public override char Symbol => Color == PieceColor.White ? 'K' : 'k';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        int dx = Math.Abs(to.x - from.x);
        int dy = Math.Abs(to.y - from.y);

        // Król może się poruszyć o 1 pole we wszystkich kierunkach
        if (dx <= 1 && dy <= 1)
        {
            var target = board.Squares[to.x, to.y];
            if (target == null || target.Color != this.Color)
                return true;
        }
        return false;
    }
}