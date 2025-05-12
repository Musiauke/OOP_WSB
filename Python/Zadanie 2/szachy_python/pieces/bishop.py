from piece import Piece

class Bishop(Piece):
    def symbol(self):
        return '♗' if self.color == 'white' else '♝'

    def is_valid_move(self, board, start, end):
        dx = end[0] - start[0]
        dy = end[1] - start[1]
        if abs(dx) != abs(dy):
            return False

        step_x = 1 if dx > 0 else -1
        step_y = 1 if dy > 0 else -1

        x, y = start[0] + step_x, start[1] + step_y
        while (x, y) != end:
            if board.get_piece((x, y)) is not None:
                return False
            x += step_x
            y += step_y

        target = board.get_piece(end)
        return target is None or target.color != self.color