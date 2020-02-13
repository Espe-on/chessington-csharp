﻿using System;
 using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List <Square> postion = new List<Square>(); 
            if (Player == Player.White)
            {
                postion.Add(Square.At(3, 0));
            }
            else
            {
                postion.Add(Square.At(5, 0));
            }

            return postion;
        }
    }
}