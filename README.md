ASCII Chess Console Game
Welcome to ASCII Chess Console Game! This console-based chess game offers a classic gaming experience with a minimalist ASCII art style. Dive into the world of strategy, tactics, and foresight as you command your pieces on the board.

Features
ASCII Art: Enjoy a visually appealing chess experience with ASCII representations of chess pieces.
Move Validation: Ensure that all moves are valid according to the rules of chess.
Interactive Console: Play the game directly in your console window, no need for additional interfaces.
Turn-based Gameplay: Take turns making moves against either another player or an AI opponent.
Castling: Perform the special move of castling to protect your king and position your rook for attack.
Check and Checkmate Detection: Be alerted when your king is under threat and strategize to avoid checkmate.
Piece Promotion: Experience the excitement of pawn promotion when reaching the opponent's back rank.
Castling
Castling is a special move involving the king and either of the player's original rooks. The following conditions must be met for castling to be possible:

The king and the chosen rook must not have previously moved.
There must be no pieces between the king and the chosen rook.
The king must not be in check, nor may the king pass through or end up in a square attacked by an enemy piece.
To perform castling, move the king two squares towards the chosen rook, then place the rook on the square adjacent to the king.

Check and Checkmate
Check occurs when the king is under threat of capture by an opponent's piece. The player must then make a move to remove the king from danger.

Checkmate occurs when the king is in check and there is no legal move to remove the threat. The game ends, and the player whose king is checkmated loses the game. [in progress]

Xunit Tests
To ensure the correctness of the features, Xunit tests have been implemented for the following services:

Move Validation: Tests are written to verify that all moves adhere to the rules of chess.
Castling: Tests validate the conditions and correctness of castling moves.
Check and Checkmate Detection: Tests ensure that the game accurately detects when a king is in check and when checkmate occurs.
