using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square newPosition;
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();

            newPosition = Square.At(currentPosition.Row - 1, currentPosition.Col + 2);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row - 1, currentPosition.Col - 2);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row + 1, currentPosition.Col + 2);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row + 1, currentPosition.Col - 2);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row - 2, currentPosition.Col + 1);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row - 2, currentPosition.Col - 1);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row + 2, currentPosition.Col + 1);
            availableSquares.Add(newPosition);

            newPosition = Square.At(currentPosition.Row + 2, currentPosition.Col - 1);
            availableSquares.Add(newPosition);

            return availableSquares;
        }
    }
}