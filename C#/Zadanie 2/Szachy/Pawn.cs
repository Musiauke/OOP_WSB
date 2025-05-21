namespace Szachy;

public class Pawn : Piece
{
    public Pawn(PieceColor color) : base(color) { }

    public override char Symbol => Color == PieceColor.White ? 'P' : 'p';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        int direction = Color == PieceColor.White ? -1 : 1;
        int startRow = Color == PieceColor.White ? 6 : 1;

        int dx = to.x - from.x;
        int dy = to.y - from.y;

        var target = board.Squares[to.x, to.y];

        // Ruch do przodu o 1 pole
        if (dx == 0 && dy == direction && target == null)
        {
            return true;
        }

        // Ruch do przodu o 2 pola z pozycji startowej (jeśli oba pola wolne)
        if (dx == 0 && dy == 2 * direction && from.y == startRow &&
            board.Squares[from.x, from.y + direction] == null &&
            target == null)
        {
            return true;
        }

        // Bicie po skosie
        if (Math.Abs(dx) == 1 && dy == direction && target != null && target.Color != Color)
        {
            return true;
        }

        return false;
    }
}