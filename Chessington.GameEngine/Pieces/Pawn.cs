using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public bool HaveMoved(Board board)
        {
            int currentRow = board.FindPiece(this).Row;
            if (Player == Player.Black && currentRow == 1)
                return false;
            if (Player == Player.White && currentRow == 7)
                return false;
            return true;
        }

        private Square GetNextSquare(Square currentSquare)
        {
            if (Player == Player.Black)
            {
                return new Square(currentSquare.Row+1, currentSquare.Col);
            }
            return new Square(currentSquare.Row-1, currentSquare.Col);
        }
        
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            
            var currentSquare = board.FindPiece(this);
            var nextSquare = GetNextSquare(currentSquare);
            
            if (board.GetPiece(nextSquare) == null)
                if (nextSquare.Row > 0 && nextSquare.Row <= GameSettings.BoardSize)
                    availableMoves.Add(nextSquare);

            if (!HaveMoved(board))
            {
                nextSquare = GetNextSquare(nextSquare);
                availableMoves.Add(nextSquare);
            }

            return availableMoves;
        }
    }
}