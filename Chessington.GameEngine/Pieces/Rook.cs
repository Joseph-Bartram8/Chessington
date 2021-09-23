using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();
            
            //Movement of Rook
            for (int i = currentPosition.Row + 1; i <= GameSettings.BoardSize; i++)
            {
                availableSquares.Add(Square.At(i, currentPosition.Col));

            }
            for (int i = currentPosition.Row - 1; i >= 0; i--)
            {
                availableSquares.Add(Square.At(i, currentPosition.Col));
            }
            for (int i = currentPosition.Col + 1; i <= GameSettings.BoardSize; i++)
            {
                availableSquares.Add(Square.At(currentPosition.Row, i));

            }
            for (int i = currentPosition.Col - 1; i >= 0; i--)
            {
                availableSquares.Add(Square.At(currentPosition.Row, i));
            }

            return availableSquares;
        }
    }
}