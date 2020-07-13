using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        
        public bool CanMove(Square square, Board board)
        {
            if (!InsideBoard(square))
                return false;
            if (board.GetPiece(square) != null)
                return false;
            return true;
        }

        public bool InsideBoard(Square square)
        {
            if (square.Row < 0 || square.Row > 7)
                return false;
            if (square.Col < 0 || square.Col > 7)
                return false;
            return true;
        }

        public bool OpposingPiece(Square square, Board board)
        {
            if (InsideBoard(square))
            {
                var piece = board.GetPiece(square);
                if (piece == null)
                    return false;
                if (piece.Player != Player)
                    return true;
            }

            return false;
        }
        
        public bool FriendlyPiece(Square square, Board board)
        {
            if (InsideBoard(square))
            {
                var piece = board.GetPiece(square);
                if (piece == null)
                    return false;
                if (piece.Player == Player)
                    return true;
            }

            return false;
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);
        
        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}