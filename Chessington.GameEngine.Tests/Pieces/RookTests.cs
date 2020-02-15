using System.Collections.Generic;
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
            _board.AddPiece(Square.At(0, 0), _rook);
            IEnumerable<Square> moves = _rook.GetAvailableMoves(_board);
            for (int i = 1; i <= 7; i++)
            {
                _moveList.Add(Square.At(i, 0));
            }

            for (int i = 1; i <= 7; i++)
            {
                _moveList.Add(Square.At(0, i));
            }

            moves.Should().BeEquivalentTo(_moveList);
        }
    }
}