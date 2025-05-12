class Piece:
    def __init__(self, color):
        self.color = color

    def is_valid_move(self, board, start, end):
        raise NotImplementedError()

    def symbol(self):
        raise NotImplementedError()