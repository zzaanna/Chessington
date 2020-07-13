using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            // movements
            foreach(var sign1 in new List<int> { 1, -1})
                foreach (var sign2 in new List<int> {1, -1})
                {
                    availableMoves.Add(Square.At(currentSquare.Row + sign1*1, currentSquare.Col + sign2*2));
                    availableMoves.Add(Square.At(currentSquare.Row + sign1*2, currentSquare.Col + sign2*1));
                }

            return availableMoves;

        }
    }
}