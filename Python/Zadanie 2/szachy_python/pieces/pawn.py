from piece import Piece

class Pawn(Piece):
    def symbol(self):
        return '♙' if self.color == 'white' else '♟'

    def is_valid_move(self, board, start, end):
        direction = -1 if self.color == 'white' else 1
        start_row = 6 if self.color == 'white' else 1
        dx, dy = end[0] - start[0], end[1] - start[1]

        target_piece = board.get_piece(end)
        if dx == direction and dy == 0 and target_piece is None:
            return True
        if dx == 2 * direction and dy == 0 and start[0] == start_row and target_piece is None and board.get_piece((start[0] + direction, start[1])) is None:
            return True
        if dx == direction and abs(dy) == 1 and target_piece is not None and target_piece.color != self.color:
            return True
        return False