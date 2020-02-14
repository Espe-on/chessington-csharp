using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        private Board _board;
        private Piece _Rook;
        private List<Square> _moveList; 

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _Rook = new Rook(Player.Black);
            _moveList = new List<Square>();
        }
    }
}