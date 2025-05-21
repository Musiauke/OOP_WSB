namespace Szachy;

public class Board
{
    public Piece?[,] Squares { get; private set; }

    public Board()
    {
        Squares = new Piece?[8, 8];
        Initialize();
    }

    public void Initialize()
    {
        // Pionki
        for (int x = 0; x < 8; x++)
        {
            Squares[x, 1] = new Pawn(PieceColor.Black);
            Squares[x, 6] = new Pawn(PieceColor.White);
        }

        // Wieże (ROOK)
        Squares[0, 0] = new Rook(PieceColor.Black);
        Squares[7, 0] = new Rook(PieceColor.Black);
        Squares[0, 7] = new Rook(PieceColor.White);
        Squares[7, 7] = new Rook(PieceColor.White);

        // Skoczki (Knight)
        Squares[1, 0] = new Knight(PieceColor.Black);
        Squares[6, 0] = new Knight(PieceColor.Black);
        Squares[1, 7] = new Knight(PieceColor.White);
        Squares[6, 7] = new Knight(PieceColor.White);

        // Gońce (Bishop)
        Squares[2, 0] = new Bishop(PieceColor.Black);
        Squares[5, 0] = new Bishop(PieceColor.Black);
        Squares[2, 7] = new Bishop(PieceColor.White);
        Squares[5, 7] = new Bishop(PieceColor.White);

        // Hetmany (Queen)
        Squares[3, 0] = new Queen(PieceColor.Black);
        Squares[3, 7] = new Queen(PieceColor.White);

        Squares[4, 0] = new King(PieceColor.Black);
        Squares[4, 7] = new King(PieceColor.White);
    }

    public void Display()
    {
        Console.WriteLine("  a b c d e f g h");

        for (int y = 0; y < 8; y++)
        {
            Console.Write(8 - y + " ");
            for (int x = 0; x < 8; x++)
            {
                var piece = Squares[x, y];
                Console.Write(piece != null ? piece.Symbol : '.');
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    public bool MovePiece((int x, int y) from, (int x, int y) to)
    {
        var piece = Squares[from.x, from.y];
        if (piece == null)
            return false;

        // Czy ruch jest poprawny wg zasady figury?
        if (!piece.IsValidMove(from, to, this))
            return false;

        var target = Squares[to.x, to.y];

        // Jeśli na celu jest figura tego samego koloru – błąd
        if (target != null && target.Color == piece.Color)
            return false;

        // Wykonanie ruchu
        Squares[to.x, to.y] = piece;
        Squares[from.x, from.y] = null;

        return true;
    }

    public bool IsKingInCheck(PieceColor kingColor)
    {
        (int x, int y)? kingPos = null;

        // Znajdź pozycję króla
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                var piece = Squares[x, y];
                if (piece is King && piece.Color == kingColor)
                {
                    kingPos = (x, y);
                    break;
                }
            }
            if (kingPos != null) break;
        }

        if (kingPos == null) return false; // Król nie znaleziony (błąd)

        // Sprawdź, czy jakakolwiek figura przeciwnika może zaatakować króla
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                var piece = Squares[x, y];
                if (piece != null && piece.Color != kingColor)
                {
                    if (piece.IsValidMove((x, y), kingPos.Value, this))
                        return true; // Szach!
                }
            }
        }

        return false; 
    }

    public bool IsMoveSafe((int x, int y) from, (int x, int y) to, PieceColor playerColor)
    {
        var movingPiece = Squares[from.x, from.y];
        var capturedPiece = Squares[to.x, to.y];

        Squares[to.x, to.y] = movingPiece;
        Squares[from.x, from.y] = null;

        bool kingInCheck = IsKingInCheck(playerColor);

        Squares[from.x, from.y] = movingPiece;
        Squares[to.x, to.y] = capturedPiece;

        return !kingInCheck;
    }

    public bool CanPlayerMove(PieceColor color)
    {
        for (int fromX = 0; fromX < 8; fromX++)
        {
            for (int fromY = 0; fromY < 8; fromY++)
            {
                var piece = Squares[fromX, fromY];
                if (piece == null || piece.Color != color) continue;

                for (int toX = 0; toX < 8; toX++)
                {
                    for (int toY = 0; toY < 8; toY++)
                    {
                        var from = (fromX, fromY);
                        var to = (toX, toY);

                        if (piece.IsValidMove(from, to, this) && IsMoveSafe(from, to, color))
                        {
                            return true; // Jest choć jeden legalny ruch
                        }
                    }
                }
            }
        }
        return false; // Brak legalnych ruchów
    }
}