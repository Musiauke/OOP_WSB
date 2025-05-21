using Szachy;

Board board = new Board();

PieceColor currentPlayer = PieceColor.White;

while (true)
{
    Console.Clear();
    board.Display();
    Console.WriteLine($"Ruch gracza: {(currentPlayer == PieceColor.White ? "BIAŁE" : "CZARNE")}");

    if (!board.CanPlayerMove(currentPlayer))
        {
            if (board.IsKingInCheck(currentPlayer))
            {
                Console.Clear();
                board.Display();
                Console.WriteLine("Szach-mat! Wygrywa " + (currentPlayer == PieceColor.White ? "Czarne" : "Białe"));
                break;
            }
            else
            {
                Console.Clear();
                board.Display();
                Console.WriteLine("Pat! Remis.");
                break;
            }
        }


    Console.WriteLine("Podaj ruch (np. a2 a3): ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) continue;

    var parts = input.Split();
    if (parts.Length != 2) continue;

    var from = ParsePosition(parts[0]);
    var to = ParsePosition(parts[1]);

    var movingPiece = board.Squares[from.x, from.y];

    if (movingPiece == null)
    {
        Console.WriteLine("Brak figury na tym polu!");
        Console.ReadKey();
        continue;
    }

    if (movingPiece.Color != currentPlayer)
    {
        Console.WriteLine("To nie jest Twoja figura!");
        Console.ReadKey();
        continue;
    }

    if (!movingPiece.IsValidMove(from, to, board))
    {
        Console.WriteLine("Nieprawidłowy ruch!");
        Console.ReadKey();
        continue;
    }

    // Sprawdzenie: czy ten ruch nie zostawia króla w szachu
    if (!board.IsMoveSafe(from, to, currentPlayer))
    {
        Console.WriteLine("Ten ruch zostawia twojego króla w szachu!");
        Console.ReadKey();
        continue;
    }

    // Jeśli wszystko OK, wykonujemy ruch
    board.MovePiece(from, to);

    // Sprawdzenie szacha
    if (board.IsKingInCheck(currentPlayer))
    {
        Console.WriteLine("Szach! Musisz się obronić.");
        Console.ReadKey();
    }
    // Zmiana gracza
    currentPlayer = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
}
    



static (int x, int y) ParsePosition(string pos)
{
    // np. "a2" -> (0, 6)
    int x = pos[0] - 'a';
    int y = 8 - int.Parse(pos[1].ToString());
    return (x, y);
}