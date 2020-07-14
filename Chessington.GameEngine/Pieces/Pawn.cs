using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }
        
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
            
            if (!InsideBoard(nextSquare) || board.GetPiece(nextSquare) != null)
                return availableMoves; 
            availableMoves.Add(nextSquare);

            if (!HasMoved)
            {
                nextSquare = GetNextSquare(nextSquare);
                if (board.GetPiece(nextSquare) != null)
                    return availableMoves; 
                availableMoves.Add(nextSquare);
            }
            
            for (var i = -1; i <= 1; i+=2)
            for (var j = -1; j <= 1; j+=2)
            {
                var square = new Square(currentSquare.Row + i, currentSquare.Col + j);
                if (OpposingPiece(square, board))
                {
                    availableMoves.Add(square);
                }
            }

            availableMoves.RemoveAll(s => !InsideBoard(s));
            return availableMoves;
        }
    }
}