﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, i - currentSquare.Row + currentSquare.Col));
            for (var i = 1; i < 8; i++)
                availableMoves.Add(Square.At(i, currentSquare.Row + currentSquare.Col - i));

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == currentSquare);
            return availableMoves;
        }
    }
}