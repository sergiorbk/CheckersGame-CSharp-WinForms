using System;
using System.Collections.Generic;

namespace Checkers
{
    public class MinimaxAlgorithm
    {
        private readonly ComputerPlayer _computerPlayer;

        public MinimaxAlgorithm(ComputerPlayer computerPlayer)
        {
            _computerPlayer = computerPlayer;
        }

        public Move FindBestMove(Board board, GameColor maximizingPlayerColor, int depth)
        {
            List<Move> possibleMoves = GenerateMoves(board, maximizingPlayerColor);
            Move bestMove = null;
            int bestScore = int.MinValue;

            foreach (Move move in possibleMoves)
            {
                Board newBoard = new Board(board);
                newBoard.MakeMove(move);

                int score = Minimax(newBoard, depth - 1, false, maximizingPlayerColor);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private int Minimax(Board board, int depth, bool isMaximizingPlayer, GameColor maximizingPlayerColor)
        {
            if (depth == 0 || board.IsGameOver())
            {
                return EvaluatePosition(board, maximizingPlayerColor);
            }

            List<Move> possibleMoves = GenerateMoves(board, maximizingPlayerColor);
            int bestScore = isMaximizingPlayer ? int.MinValue : int.MaxValue;

            foreach (Move move in possibleMoves)
            {
                Board newBoard = new Board(board);
                newBoard.MakeMove(move);

                int score = Minimax(newBoard, depth - 1, !isMaximizingPlayer, maximizingPlayerColor);

                if (isMaximizingPlayer)
                {
                    bestScore = Math.Max(bestScore, score);
                }
                else
                {
                    bestScore = Math.Min(bestScore, score);
                }
            }

            return bestScore;
        }

        private int EvaluatePosition(Board board, GameColor maximizingPlayerColor)
        {
            int score = 0;
            
            int maximizingPlayerCount = CountPieces(board, maximizingPlayerColor);
            int opponentCount = CountPieces(board, GetOpponentColor(maximizingPlayerColor));
            score = maximizingPlayerCount - opponentCount;

            return score;
        }

        private int CountPieces(Board board, GameColor playerColor)
        {
            int count = 0;
            foreach (Cell cell in board.GetAllCells())
            {
                if (!cell.IsEmpty() && cell.GetChecker().GetColor() == playerColor)
                {
                    count++;
                }
            }

            return count;
        }

        private List<Move> GenerateMoves(Board board, GameColor playerColor)
        {
            List<Move> possibleMoves = new List<Move>();
            bool mustJump = false;

            foreach (Cell cell in board.GetAllCells())
            {
                if (!cell.IsEmpty() && cell.GetChecker().GetColor() == playerColor)
                {
                    if (CheckerMoveValidator.IsAnyJumpAvailable(cell, board))
                    {
                        mustJump = true;
                        break;
                    }
                }
            }

            foreach (Cell cell in board.GetAllCells())
            {
                if (!cell.IsEmpty() && cell.GetChecker().GetColor() == playerColor)
                {
                    if (mustJump)
                    {
                        if (CheckerMoveValidator.IsAnyJumpAvailable(cell, board))
                        {
                            foreach (Move jumpMove in _computerPlayer.GetAvailableJumps(cell, board))
                            {
                                possibleMoves.Add(jumpMove);
                            }
                        }
                    }
                    else if (CheckerMoveValidator.IsAnyMoveAvailable(cell, board))
                    {
                        foreach (Move simpleMove in _computerPlayer.GetAvailableSimpleMoves(cell, board))
                        {
                            possibleMoves.Add(simpleMove);
                        }
                    }
                }
            }

            return possibleMoves;
        }

        private GameColor GetOpponentColor(GameColor playerColor)
        {
            return playerColor == GameColor.White ? GameColor.Black : GameColor.White;
        }
        
        
    }
}
