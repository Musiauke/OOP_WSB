from piece import Piece
from pieces.rook import Rook
from pieces.bishop import Bishop

class Queen(Piece):
    def symbol(self):
        return '♕' if self.color == 'white' else '♛'

    def is_valid_move(self, board, start, end):
        return Rook(self.color).is_valid_move(board, start, end) or Bishop(self.color).is_valid_move(board, start, end)