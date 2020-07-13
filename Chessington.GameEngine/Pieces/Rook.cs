using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (var i = 1; currentSquare.Col+i < 8; i++)
            {
                var square = new Square(currentSquare.Row, currentSquare.Col + i);
                if (board.GetPiece(square) != null)
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; currentSquare.Col-i >= 0; i++)
            {
                var square = new Square(currentSquare.Row, currentSquare.Col - i);
                if (board.GetPiece(square) != null)
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; currentSquare.Row+i < 8; i++)
            {
                var square = new Square(currentSquare.Row + i, currentSquare.Col);
                if (board.GetPiece(square) != null)
                    break;
                availableMoves.Add(square);
            }
            for (var i = 1; currentSquare.Row-i >= 0; i++)
            {
                var square = new Square(currentSquare.Row - i, currentSquare.Col);
                if (board.GetPiece(square) != null)
                    break;
                availableMoves.Add(square);
            }
            
            return availableMoves;
        }
    }
}