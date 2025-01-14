﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square newPosition;
            Square currentPosition = board.FindPiece(this);
            var availableSquares = new List<Square>();


            if (Player == Player.White)
            {
                newPosition = Square.At(currentPosition.Row - 1, currentPosition.Col);
                availableSquares.Add(newPosition);
            }
            else
            {
                newPosition = Square.At(currentPosition.Row + 1, currentPosition.Col);
                availableSquares.Add(newPosition);
            }

            if (currentPosition.Row == 6 || currentPosition.Row == 1)
            {
                if (Player == Player.White)
                {
                    newPosition = Square.At(currentPosition.Row - 2, currentPosition.Col);
                    availableSquares.Add(newPosition);
                }
                else
                {
                    newPosition = Square.At(currentPosition.Row + 2, currentPosition.Col);
                    availableSquares.Add(newPosition);
                }
            }

            return availableSquares;
        }
    }
}