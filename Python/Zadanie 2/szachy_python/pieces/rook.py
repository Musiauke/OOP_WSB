from piece import Piece

class Rook(Piece):
    def symbol(self):
        return '♖' if self.color == 'white' else '♜'

    def is_valid_move(self, board, start, end):
        if start[0] != end[0] and start[1] != end[1]:
            return False

        step_x = 0 if start[0] == end[0] else (1 if end[0] > start[0] else -1)
        step_y = 0 if start[1] == end[1] else (1 if end[1] > start[1] else -1)

        x, y = start[0] + step_x, start[1] + step_y
        while (x, y) != end:
            if board.get_piece((x, y)) is not None:
                return False
            x += step_x
            y += step_y

        target = board.get_piece(end)
        return target is None or target.color != self.color