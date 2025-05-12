from board import Board
from player import Player
from move_validator import MoveValidator

class Game:
    def __init__(self):
        self.board = Board()
        self.players = [Player("white"), Player("black")]
        self.current_player = 0
        self.validator = MoveValidator(self.board)

    def play(self):
        self.board.display()
        while True:
            player = self.players[self.current_player]
            print(f"\n{player.color.capitalize()} to move (e.g. e2 e4):")
            move = input("> ").strip().split()

            if len(move) != 2:
                print("Invalid input. Use format: e2 e4")
                continue

            start, end = map(self.board.algebraic_to_index, move)
            piece = self.board.get_piece(start)

            if not piece or piece.color != player.color:
                print("No valid piece selected.")
                continue

            if not piece.is_valid_move(start, end, self.board):
                print("Invalid move.")
                continue

            self.board.move_piece(start, end)
            self.board.display()
            self.current_player = 1 - self.current_player