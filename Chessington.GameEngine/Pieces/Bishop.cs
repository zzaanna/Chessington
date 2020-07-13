using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        private bool canMove(Square square, Board board)
        {
            if (square.Row < 0 || square.Row > 7)
                return false;
            if (square.Col < 0 || square.Col > 7)
                return false;
            if (board.GetPiece(square) != null)
                return false;
            return true;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            for (var i = 1; i < 8; i++)
            {
                var square = new Square(currentSquare.Row + i, currentSquare.Col + i);
                if (!canMove(square, board))
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; i < 8; i++)
            {
                var square = new Square(currentSquare.Row + i, currentSquare.Col - i);
                if (!canMove(square, board))
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; i < 8; i++)
            {
                var square = new Square(currentSquare.Row - i, currentSquare.Col - i);
                if (!canMove(square, board))
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; i < 8; i++)
            {
                var square = new Square(currentSquare.Row - i, currentSquare.Col + i);
                if (!canMove(square, board))
                    break;
                availableMoves.Add(square);
            }
            
            return availableMoves;
        }
    }
}