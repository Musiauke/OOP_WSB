namespace Szachy;

public class Bishop : Piece
{
    public Bishop(PieceColor color) : base(color) {}

    public override char Symbol => Color == PieceColor.White ? 'B' : 'b';

    public override bool IsValidMove((int x, int y) from, (int x, int y) to, Board board)
    {
        int dx = Math.Abs(to.x - from.x);
        int dy = Math.Abs(to.y - from.y);

        if (dx != dy) return false;  // tylko ruchy po skosie

        int stepX = (to.x - from.x) / dx;
        int stepY = (to.y - from.y) / dy;

        int x = from.x + stepX;
        int y = from.y + stepY;

        // Sprawdź, czy na drodze nie ma żadnych figur
        while (x != to.x && y != to.y)
        {
            if (board.Squares[x, y] != null)
                return false;

            x += stepX;
            y += stepY;
        }

        // Sprawdź, czy na polu docelowym nie stoi własna figura
        var destinationPiece = board.Squares[to.x, to.y];
        if (destinationPiece != null && destinationPiece.Color == this.Color)
            return false;

        return true;
    }
}