using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        private Board _board;
        private Piece _rook;
        private List<Square> _moveList;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _rook = new Rook(Player.Black);
            _moveList = new List<Square>();
        }

        [Test]
        public void Rook_CanMoveInAStraightLine()
        {
            _board.AddPiece(Square.At(4, 4), _rook);
            IEnumerable<Square> moves = _rook.GetAvailableMoves(_board);
            for (int i = 5; i <= 7; i++)
            {
                _moveList.Add(Square.At(i, 4));
            }

            for (int i = 3; i >= 0; i--)
            {
                _moveList.Add(Square.At(i, 4));
            }

            for (int i = 5; i <= 7; i++)
            {
                _moveList.Add(Square.At(4, i));
            }

            for (int i = 3; i >= 0; i--)
            {
                _moveList.Add(Square.At(4, i));
            }

            moves.Should().BeEquivalentTo(_moveList);
        }

        [Test]
        public void Rook_CantMovePastBlockingPiece()
        {
            Piece blocker = new Pawn(Player.Black);
            _board.AddPiece(Square.At(3,3 ), _rook);
            _board.AddPiece(Square.At(3, 5), blocker);
            IEnumerable<Square> moves = _rook.GetAvailableMoves(_board);
            
            moves.Should().NotContain(Square.At(3, 6));
            moves.Should().NotContain(Square.At(3, 7));
        }

        [Test]
        public void Rook_CantMoveOffBoard()
        {
            _board.AddPiece(Square.At(7,7), _rook);
            IEnumerable<Square> moves = _rook.GetAvailableMoves(_board);

            moves.Should().NotContain(Square.At(7, 8));
            moves.Should().NotContain(Square.At(8, 7));
            moves.Should().NotContain(Square.At(-1, 7));
            moves.Should().NotContain(Square.At(7, -1));
        }

        [Test]
        public Void Rook_CantTakePieceOfSameColour()
        {
            Piece targetOne = new Pawn(Player.Black);
            Piece targetTwo = new Pawn(Player.Black);
            _board.AddPiece(Square.At(5,5), _rook);
            _board.AddPiece(Square.At(5,4), targetOne);
            _board.AddPiece(Square.At(4,5), targetTwo);
            IEnumerable<Square> moves = _rook.GetAvailableMoves(_board);

            moves.Should().NotContain(Square.At(5, 4));
            moves.Should().NotContain(Square.At(4, 5));
        }
    }
}