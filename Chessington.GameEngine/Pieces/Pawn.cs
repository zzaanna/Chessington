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
            var currentSquare = board.FindPiece(this);
            var nextSquare = new Square();
            if (Player == Player.Black)
            {
                nextSquare = new Square(currentSquare.Row+1, currentSquare.Col);
            }
            if (Player == Player.White)
            {
                nextSquare = new Square(currentSquare.Row-1, currentSquare.Col);
            }
            if (board.GetPiece(nextSquare) == null)
                if (nextSquare.Row > 0 && nextSquare.Row <= GameSettings.BoardSize)
                    availableMoves = availableMoves.Concat(new []{nextSquare});

            return availableMoves;
        }
    }
}