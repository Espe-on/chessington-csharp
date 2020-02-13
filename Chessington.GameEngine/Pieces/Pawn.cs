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
            var currentSquare = board.FindPiece(this);
            List <Square> listOfPossiblePositions = new List<Square>(); 
            if (Player == Player.White)
            {
                listOfPossiblePositions.Add(Square.At(currentSquare.Row-1, currentSquare.Col));
                if (currentSquare.Row == 6)
                {
                    listOfPossiblePositions.Add(Square.At(currentSquare.Row-2, currentSquare.Col));
                }
            }
            if (Player == Player.Black)
            {
                listOfPossiblePositions.Add(Square.At(currentSquare.Row+1, currentSquare.Col));
                if (currentSquare.Row == 1)
                {
                    listOfPossiblePositions.Add(Square.At(currentSquare.Row+2, currentSquare.Col));
                }
            }

            return listOfPossiblePositions;
        }
    }
}