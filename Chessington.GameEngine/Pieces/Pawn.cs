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
                var possibleMove = Square.At(currentSquare.Row-1, currentSquare.Col);
                if (board.GetPiece(possibleMove) == null)
                {
                    listOfPossiblePositions.Add(possibleMove);
                }
                if (currentSquare.Row == 6)
                {
                    var possibleDoubleMove = Square.At(currentSquare.Row - 2, currentSquare.Col);
                    if (board.GetPiece(possibleDoubleMove) == null && board.GetPiece(possibleMove) == null)
                    {
                        listOfPossiblePositions.Add(possibleDoubleMove);    
                    }
                }
            }
            if (Player == Player.Black)
            {
                var possibleMove = Square.At(currentSquare.Row+1, currentSquare.Col);
                if (board.GetPiece(possibleMove) == null)
                {
                    listOfPossiblePositions.Add(possibleMove);
                }
                if (currentSquare.Row == 1)
                {
                    var possibleDoubleMove = Square.At(currentSquare.Row +2, currentSquare.Col);
                    if (board.GetPiece(possibleDoubleMove) == null && board.GetPiece(possibleMove) == null)
                    {
                        listOfPossiblePositions.Add(possibleDoubleMove);    
                    }
                }
            }

            return listOfPossiblePositions;
        }
    }
}