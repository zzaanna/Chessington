using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            IEnumerable<Square> availableMoves = Enumerable.Empty<Square>();
            if (Player == Player.White)
            {
                var currentSquare = board.FindPiece(this);
                var nextSquare = new Square(currentSquare.Row+1, currentSquare.Col);
                if (board.GetPiece(currentSquare) == null)
                    if (currentSquare.Row >= 0 && currentSquare.Row <= GameSettings.BoardSize)
                        availableMoves = availableMoves.Concat(new []{nextSquare});
            }
            if (Player == Player.Black)
            {
                var currentSquare = board.FindPiece(this);
                var nextSquare = new Square(currentSquare.Row-1, currentSquare.Col);
                if (board.GetPiece(currentSquare) == null)
                    if (currentSquare.Row >= 0 && currentSquare.Row <= GameSettings.BoardSize)
                        availableMoves = availableMoves.Concat(new []{nextSquare});
            }

            return availableMoves;
        }
    }
}