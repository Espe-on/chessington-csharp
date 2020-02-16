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
        private List<Square> _moveList; 

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _king = new King(Player.Black);
            _moveList = new List<Square>();
        }
        
        [Test]
        public void King_CanMoveOneSquareInAnyDirection()
        {
            _board.AddPiece(Square.At(3,3), _king);
            IEnumerable<Square> moves = _king.GetAvailableMoves(_board);
            _moveList.Add(Square.At(4,2 ));
            _moveList.Add(Square.At(4,3 ));
            _moveList.Add(Square.At(4,4 ));
            _moveList.Add(Square.At(3,2 ));
            _moveList.Add(Square.At(3,4 ));
            _moveList.Add(Square.At(2,2 ));
            _moveList.Add(Square.At(2,3 ));
            _moveList.Add(Square.At(2,4 ));
            
            moves.Should().BeEquivalentTo(_moveList);
        }
        
        [Test]
        public void King_CantMoveOffBoard()
        {
            _board.AddPiece(Square.At(7,7), _king);
            IEnumerable<Square> moves = _king.GetAvailableMoves(_board);
            _moveList.Add(Square.At(7,6 ));
            _moveList.Add(Square.At(6,6 ));
            _moveList.Add(Square.At(6,7 ));

            moves.Should().BeEquivalentTo(_moveList);
        }
        
        [Test]
        public void King_CantTakePieceOfSameColour()
        {
            Piece target = new Pawn(Player.Black);
            _board.AddPiece(Square.At(5,5 ), _king);
            _board.AddPiece(Square.At(5,6 ), target);
            IEnumerable<Square> moves = _king.GetAvailableMoves(_board);
            
            moves.Should().NotContain(Square.At(5, 6));
        }
    }
}