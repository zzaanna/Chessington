using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : TravellingPiece
    {
        public Rook(Player player)
            : base(player) { }

        public override List<Direction> Directions
        {
            get
            {
                var directions = new List<Direction>();
                directions.Add(new Direction(1, 0));
                directions.Add(new Direction(-1, 0));
                directions.Add(new Direction(0, 1));
                directions.Add(new Direction(0, -1));
                return directions;
            }
        }
    }
}