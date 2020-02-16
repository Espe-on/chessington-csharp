using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        private Board _board;
        private Piece _bishop;
        private List<Square> _moveList; 

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
            _bishop = new Bishop(Player.Black);
            _moveList = new List<Square>();
        }
    }
}