﻿using System.Collections.Generic;
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
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(currentSquare.Row, i));
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, currentSquare.Col));

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == Square.At(4, 4));
            return availableMoves;
        }
    }
}