from pieces.pawn import Pawn
from pieces.rook import Rook
from pieces.knight import Knight
from pieces.bishop import Bishop
from pieces.queen import Queen
from pieces.king import King

class Board:
    def __init__(self):
        self.grid = [[None for _ in range(8)] for _ in range(8)]
        self.setup()

    def setup(self):
        for i in range(8):
            self.grid[1][i] = Pawn('black')
            self.grid[6][i] = Pawn('white')

        placement = [Rook, Knight, Bishop, Queen, King, Bishop, Knight, Rook]
        for i, cls in enumerate(placement):
            self.grid[0][i] = cls('black')
            self.grid[7][i] = cls('white')

    def move(self, start, end):
        piece = self.get_piece(start)
        if piece and piece.is_valid_move(self, start, end):
            self.grid[end[0]][end[1]] = piece
            self.grid[start[0]][start[1]] = None
            return True
        return False

    def get_piece(self, position):
        x, y = position
        return self.grid[x][y]

    def in_check(self, color):
        for x in range(8):
            for y in range(8):
                piece = self.grid[x][y]
                if piece and isinstance(piece, King) and piece.color == color:
                    king_pos = (x, y)
        for x in range(8):
            for y in range(8):
                piece = self.grid[x][y]
                if piece and piece.color != color:
                    if piece.is_valid_move(self, (x, y), king_pos):
                        return True
        return False

    def has_valid_moves(self, color):
        for x in range(8):
            for y in range(8):
                piece = self.grid[x][y]
                if piece and piece.color == color:
                    for dx in range(8):
                        for dy in range(8):
                            end = (dx, dy)
                            if piece.is_valid_move(self, (x, y), end):
                                backup = self.grid[dx][dy]
                                self.grid[dx][dy] = piece
                                self.grid[x][y] = None
                                if not self.in_check(color):
                                    self.grid[x][y] = piece
                                    self.grid[dx][dy] = backup
                                    return True
                                self.grid[x][y] = piece
                                self.grid[dx][dy] = backup
        return False