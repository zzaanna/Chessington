using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : TravellingPiece
    {
        public Bishop(Player player)
            : base(player) { }

        public override List<Direction> Directions
        {
            get
            {
                var directions = new List<Direction>();
                directions.Add(new Direction(1, 1));
                directions.Add(new Direction(1, -1));
                directions.Add(new Direction(-1, 1));
                directions.Add(new Direction(-1, -1));
                return directions;
            }
        }
    }
}