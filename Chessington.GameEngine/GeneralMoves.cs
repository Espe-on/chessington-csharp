namespace Chessington.GameEngine
{
    public class GeneralMoves
    {
        public Square MoveNorth(Square currentSquare, int distance)
        {
           return Square.At(currentSquare.Row-distance, currentSquare.Col);
        }
        
        public Square MoveSouth(Square currentSquare, int distance)
        {
            return Square.At(currentSquare.Row+distance, currentSquare.Col);
        }
        
        public Square MoveWest(Square currentSquare, int distance)
        {
            return Square.At(currentSquare.Row, currentSquare.Col-distance);
        }
        
        public Square MoveEast(Square currentSquare, int distance)
        {
            return Square.At(currentSquare.Row, currentSquare.Col+distance);
        }

        public Square MoveNorthEast(Square currentSquare, int distance)
        {
            var midSquare = MoveNorth(currentSquare, distance);
            return MoveEast(midSquare, distance);
        }
        
        public Square MoveNorthWest(Square currentSquare, int distance)
        {
            var midSquare = MoveNorth(currentSquare, distance);
            return MoveWest(midSquare, distance);
        }
        
        public Square MoveSouthEast(Square currentSquare, int distance)
        {
            var midSquare = MoveSouth(currentSquare, distance);
            return MoveEast(midSquare, distance);
        }
        
        public Square MoveSouthWest(Square currentSquare, int distance)
        {
            var midSquare = MoveSouth(currentSquare, distance);
            return MoveWest(midSquare, distance);
        }
    }
}