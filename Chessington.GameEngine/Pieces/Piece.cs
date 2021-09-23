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