namespace Chessington.GameEngine.Pieces
{
    public class Direction
    {
        public readonly int ChangeInRow;
        public readonly int ChangeInCol;

        public Direction(int row, int col)
        {
            ChangeInRow = row;
            ChangeInCol = col;
        }
    }
}