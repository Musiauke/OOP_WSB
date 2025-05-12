from board import Board

def parse_move(move):
    move = move.strip().lower()
    if len(move) != 4 or not move[0].isalpha() or not move[2].isalpha() or not move[1].isdigit() or not move[3].isdigit():
        raise ValueError("Nieprawidłowy format")
    col_map = {'a': 0, 'b': 1, 'c': 2, 'd': 3, 'e': 4, 'f': 5, 'g': 6, 'h': 7}
    start = (8 - int(move[1]), col_map[move[0]])
    end = (8 - int(move[3]), col_map[move[2]])
    return start, end

board = Board()
turn = 'white'

while True:
    print("  a b c d e f g h")
    for i, row in enumerate(board.grid):
        print(f"{8 - i} " + " ".join(piece.symbol() if piece else '.' for piece in row) + f" {8 - i}")
    print("  a b c d e f g h")
    print(f"Tura: {turn}")
    move = input("Podaj ruch (np. e2e4): ")
    try:
        start, end = parse_move(move)
        piece = board.get_piece(start)
        if not piece or piece.color != turn:
            print("Nieprawidłowa figura.")
            continue
        if board.move(start, end):
            if board.in_check('black' if turn == 'white' else 'white'):
                if not board.has_valid_moves('black' if turn == 'white' else 'white'):
                    print("Szach mat!")
                    break
                else:
                    print("Szach!")
            turn = 'black' if turn == 'white' else 'white'
        else:
            print("Nieprawidłowy ruch.")
    except Exception as e:
        print("Błąd w formacie ruchu.")