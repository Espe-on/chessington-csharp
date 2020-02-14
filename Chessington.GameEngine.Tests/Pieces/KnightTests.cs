﻿using System.Collections.Generic;
 using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        private Board _board;
        private Piece _knight;
        private List<Square> _moveList; 

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _knight = new Knight(Player.White);
            _moveList = new List<Square>();
        }
        [Test]
        public void Knight_CanMoveCorrectly() // RENAME
        {
            _board.AddPiece(Square.At(3,3), _knight);
            IEnumerable<Square> moves = _knight.GetAvailableMoves(_board);
            _moveList.Add(Square.At(1,2 ));
            _moveList.Add(Square.At(1,4 ));
            _moveList.Add(Square.At(2,1 ));
            _moveList.Add(Square.At(2,5 ));
            _moveList.Add(Square.At(4,1 ));
            _moveList.Add(Square.At(4,5 ));
            _moveList.Add(Square.At(5,2 ));
            _moveList.Add(Square.At(5,4 ));
            
            moves.Should().BeEquivalentTo(_moveList);
        }

        [Test]
        public void Knight_CantMoveOffBoard()
        {
            _board.AddPiece(Square.At(6,6), _knight);
            IEnumerable<Square> moves = _knight.GetAvailableMoves(_board);
            _moveList.Add(Square.At(7,4 ));
            _moveList.Add(Square.At(5,4 ));
            _moveList.Add(Square.At(4,5 ));
            _moveList.Add(Square.At(4,7 ));

            moves.Should().BeEquivalentTo(_moveList);
        }

        [Test]
        public void Knight_CantTakePieceOfSameColour()
        {
            Piece target = new Pawn(Player.White);
            _board.AddPiece(Square.At(2,2 ), _knight);
            _board.AddPiece(Square.At(0,3 ), target);
            IEnumerable<Square> moves = _knight.GetAvailableMoves(_board);
            
            moves.Should().NotContain(Square.At(0, 3));
        }

        [Test]
        public void Knight_CanJumpOverOtherPieces()
        {
            Piece targetWhite = new Pawn(Player.White);
            Piece targetBlack = new Pawn(Player.Black);
            _board.AddPiece(Square.At(5,5 ), _knight);
            _board.AddPiece(Square.At(4,5 ), targetWhite);
            _board.AddPiece(Square.At(3,5 ), targetBlack);
            IEnumerable<Square> moves = _knight.GetAvailableMoves(_board);

            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(3, 6));
        }
    }
}