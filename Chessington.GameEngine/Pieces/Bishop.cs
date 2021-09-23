using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square newPosition;
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();

            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                newPosition = Square.At(currentPosition.Row + i, currentPosition.Col + i);
                if (newPosition.Row < GameSettings.BoardSize && newPosition.Col < GameSettings.BoardSize)
                {
                    availableSquares.Add(newPosition);
                }
            }
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                newPosition = Square.At(currentPosition.Row - i, currentPosition.Col + i);
                if (newPosition.Row >= 0 && newPosition.Col < GameSettings.BoardSize)
                {
                    availableSquares.Add(newPosition);
                }
            }
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                newPosition = Square.At(currentPosition.Row + i, currentPosition.Col - i);
                if (newPosition.Row < GameSettings.BoardSize && newPosition.Col >= 0)
                {
                    availableSquares.Add(newPosition);
                }
            }
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                newPosition = Square.At(currentPosition.Row - i, currentPosition.Col - i);
                if (newPosition.Row >= 0 && newPosition.Col >= 0)
                {
                    availableSquares.Add(newPosition);
                }
            }


            return availableSquares;
        }
    }
}