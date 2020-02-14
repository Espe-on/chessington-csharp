﻿using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void King_CanMoveOneSquareUp()
        {
            var board = new Board();
            var king = new King(Player.Black);
            board.AddPiece(Square.At(4,5), king);

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
        }
    }
}