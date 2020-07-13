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
            int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            
            for (int i = 0; i < 4; i++)
            {
                var square = new Square();
                for (var steps = 1; steps < GameSettings.BoardSize; steps++)
                {
                    square = new Square(currentSquare.Row + directions[i,0]*steps, 
                        currentSquare.Col + directions[i,1]*steps);
                    if (!CanMove(square, board))
                        break;
                    availableMoves.Add(square);
                }
                
                // check if there's an opposing piece to take 
                if (InsideBoard(square))
                {
                    var piece = board.GetPiece(square);
                    if (piece.Player != Player)
                    {
                        availableMoves.Add(square);
                    }
                }
            }
            
            return availableMoves;
        }
    }
}