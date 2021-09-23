using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected IEnumerable<Square> GetAvailableDiagonalMoves(Board board)
        {
            var moves = GetAvailableMovesInDirection(board, s => Square.At(s.Row + 1, s.Col + 1)).ToList();
            moves.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row - 1, s.Col + 1)));
            moves.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row + 1, s.Col - 1)));
            moves.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row - 1, s.Col - 1)));
            return moves;
        }

        public IEnumerable<Square> GetlateralMoves (Board board)
        {
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();

            for (int i = currentPosition.Row + 1; i < GameSettings.BoardSize; i++)
            {
                availableSquares.Add(Square.At(i, currentPosition.Col));

            }
            for (int i = currentPosition.Row - 1; i >= 0; i--)
            {
                availableSquares.Add(Square.At(i, currentPosition.Col));
            }
            for (int i = currentPosition.Col + 1; i < GameSettings.BoardSize; i++)
            {
                availableSquares.Add(Square.At(currentPosition.Row, i));

            }
            for (int i = currentPosition.Col - 1; i >= 0; i--)
            {
                availableSquares.Add(Square.At(currentPosition.Row, i));
            }

            return availableSquares;
        }

        public IEnumerable<Square> GetDiagonalMoves (Board board)
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

        private IEnumerable<Square> GetAvailableMovesInDirection(Board board, Func<Square, Square> iterator)
        {
            var location = board.FindPiece(this);
            var square = iterator(location);
            while (board.SquareIsAvailable(square)
                || (board.SquareIsOccupied(square) && board.GetPiece(square).Player != Player))
            {
                yield return square;
                if (board.GetPiece(square) != null)
                {
                    break;
                }
                square = iterator(square);
            }
        }
    }
}