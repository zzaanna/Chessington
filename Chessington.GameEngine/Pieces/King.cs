using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            // diagonal movements
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++)
                availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + j));

            //Get rid of starting location, moves outside board and squares occupied by self
            availableMoves.RemoveAll(s => s == currentSquare || !InsideBoard(s) || FriendlyPiece(s, board));
            return availableMoves;
        }
    }
}