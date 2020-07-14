using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class TravellingPiece : Piece
    {
        public TravellingPiece(Player player)
            : base(player) { }

        public abstract List<Direction> Directions { get; }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);

            var directions = Directions;
            foreach(var direction in directions) 
            {
                var square = new Square();
                for (var steps = 1; steps < GameSettings.BoardSize; steps++)
                {
                    square = new Square(currentSquare.Row + direction.ChangeInRow*steps, 
                        currentSquare.Col + direction.ChangeInCol*steps);
                    if (!CanMove(square, board))
                        break;
                    availableMoves.Add(square);
                }
                
                // check if there's an opposing piece to take
                if (OpposingPiece(square, board))
                {
                    availableMoves.Add(square);
                }
            }
            
            return availableMoves;
        }
    }
}