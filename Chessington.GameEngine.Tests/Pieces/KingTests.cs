﻿using System.Collections.Generic;
 using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        private Board _board;
        private Piece _king;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _king = new King(Player.Black);
        }
        [Test]
        public void King_CanMoveOneSquareInAnyDirection()
        {
            _board.AddPiece(Square.At(3,3), _king);
            var moves = _king.GetAvailableMoves(_board);
            List<Square> moveList = new List<Square>();
            moveList.Add(Square.At(4,2 ));
            moveList.Add(Square.At(4,3 ));
            moveList.Add(Square.At(4,4 ));
            moveList.Add(Square.At(3,2 ));
            moveList.Add(Square.At(3,4 ));
            moveList.Add(Square.At(2,2 ));
            moveList.Add(Square.At(2,3 ));
            moveList.Add(Square.At(2,4 ));
            moves.Should().BeEquivalentTo(moveList);
        }
        [Test]
        public void King_CantMoveOffBoard()
        {
            _board.AddPiece(Square.At(7,7), _king);
            var moves = _king.GetAvailableMoves(_board);

            moves.Should().NotContain(Square.At(7, 8));
            moves.Should().NotContain(Square.At(8, 7));
            moves.Should().NotContain(Square.At(8, 8));
        }

        /*[Test]
        public void King_CantTakePieceOfSameColour()
        {
            Piece target = new Pawn(Player.Black);
            _board.AddPiece(Square.At(5,5 ), _king);
            _board.AddPiece(Square.At(5,6 ), target);
        }*/
    }
}