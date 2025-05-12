from piece import Piece

class King(Piece):
    def symbol(self):
        return '♔' if self.color == 'white' else '♚'

    def is_valid_move(self, board, start, end):
        dx = abs(end[0] - start[0])
        dy = abs(end[1] - start[1])
        if max(dx, dy) > 1:
            return False
        target = board.get_piece(end)
        return target is None or target.color != self.color