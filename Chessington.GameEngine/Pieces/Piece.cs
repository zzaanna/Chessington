using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public virtual IEnumerable<Square> GetAvailableMoves(Board board)
        {
            IEnumerable<Square> availableSquares = Enumerable.Empty<Square>();
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                {
                    var currentSquare = new Square(row, col);
                    if (board.GetPiece(currentSquare) == null)
                        availableSquares = availableSquares.Concat(new []{currentSquare});
                }
            return availableSquares;
        }

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}