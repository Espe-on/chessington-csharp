using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> listOfPossiblePositions = new List<Square>();
            listOfPossiblePositions.Add(Square.At(currentSquare.Row-1, currentSquare.Col));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row+1, currentSquare.Col));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row, currentSquare.Col-1));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row, currentSquare.Col+1));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row-1, currentSquare.Col+1));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row-1, currentSquare.Col-1));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row+1, currentSquare.Col+1));
            listOfPossiblePositions.Add(Square.At(currentSquare.Row+1, currentSquare.Col-1));

            return listOfPossiblePositions;
        }
    }
}