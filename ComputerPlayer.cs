using System;
using System.Collections.Generic;
using Checkers.CheckersMoveRules;

namespace Checkers
{
    public class ComputerPlayer
    {
        private readonly GameColor _computerPlayerColor;
        private readonly Board _board;
        private readonly GameAgainstComputer _game;
        private bool _isJumping;

        public ComputerPlayer(GameColor computerPlayerColor, Board board, GameAgainstComputer game)
        {
            _computerPlayerColor = computerPlayerColor;
            _board = board;
            _game = game;
        }
        
        
        private Move SelectMove(List<Move> moves)
        {
            if (moves.Count > 0)
            {
                Random random = new Random();
                int selectedIndex = random.Next(0, moves.Count);
                Move selectedMove = moves[selectedIndex];
        
                return selectedMove;
            }
            
            return null;
        }

        public void MakeMove()
        {
            List<Move> possibleMoves = GetPossibleMoves();
            if (possibleMoves.Count > 0)
            {
                Move selectedMove = SelectMove(possibleMoves);
                _game.ProcessComputerMove(selectedMove);
        
                if (selectedMove.IsJump())
                {
                    _isJumping = true;
                    
                    List<Move> availableJumps = GetAvailableJumps(selectedMove.GetEndCell(), _board);
                    if (availableJumps.Count > 0)
                    {
                        MakeMove();
                    }
                    else
                    {
                        _isJumping = false;
                        _game.ChangeTurn();
                    }
                }
                else
                {
                    _isJumping = false;
                    _game.ChangeTurn();
                }
            }
            
            // game over
        }
        
        private List<Move> GetPossibleMoves()
        {
            List<Move> possibleMoves = new List<Move>();
            bool mustJump = false;
            foreach (Cell cell in _board.GetAllCells())
            {
                if (!cell.IsEmpty() && cell.GetChecker().GetColor() == _computerPlayerColor)
                {
                    if (CheckerMoveValidator.IsAnyJumpAvailable(cell, _board))
                    {
                        mustJump = true;
                        break;
                    }
                }
            }

            foreach (Cell cell in _board.GetAllCells())
            {
                if (!cell.IsEmpty() && cell.GetChecker().GetColor() == _computerPlayerColor)
                {
                    if (mustJump)
                    {
                        if (CheckerMoveValidator.IsAnyJumpAvailable(cell, _board))
                        {
                            foreach (Move jumpMove in GetAvailableJumps(cell, _board))
                            {
                                possibleMoves.Add(jumpMove);
                            }
                        }  
                        
                    } else if (CheckerMoveValidator.IsAnyMoveAvailable(cell, _board)) {

                        foreach (Move simpleMove in GetAvailableSimpleMoves(cell, _board))
                        {
                            possibleMoves.Add(simpleMove);
                        }
                    }
                    
                }
            }
            return possibleMoves;
        }

        
        public List<Move> GetAvailableSimpleMoves(Cell startCell, Board board)
        {
            List<Move> simpleMovesAvailable = new List<Move>();
            switch (startCell.GetChecker().GetType())
            {
                case Checker.CheckerType.Simple:
                    int cellX = startCell.GetRow();
                    int cellY = startCell.GetColumn();

                    int[,] moveCoordinates =
                    {
                        { cellX - 1, cellY - 1 },
                        { cellX + 1, cellY - 1 },
                        { cellX - 1, cellY + 1 },
                        { cellX + 1, cellY + 1 }
                    };

                    for (int i = 0; i < 4; i++)
                    {
                        Cell endCell;
                        if(board.IsValidCell(moveCoordinates[i, 0], moveCoordinates[i, 1]))
                        {
                            endCell = board.GetCell(moveCoordinates[i, 0], moveCoordinates[i, 1]);
                            
                            if (CheckerMoveValidator.IsMoveValid(startCell, endCell, board))
                            {
                                simpleMovesAvailable.Add(new Move(startCell, endCell, false));
                            }
                        }
                    }

                    break;
                
                case Checker.CheckerType.King:
                    int startX = startCell.GetColumn();
                    int startY = startCell.GetRow();
                
                    // Diagonal directions: Up-left, Up-right, Down-left, Down-right
                    int[,] directions = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
                
                    for (int i = 0; i < 4; i++)
                    {
                        int currentX = startX + directions[i, 0];
                        int currentY = startY + directions[i, 1];
                
                        do
                        {
                            if (!board.IsValidCell(currentY, currentX))
                                break;
                
                            // Process the cell at currentX, currentY
                            Cell cellToCheck = board.GetCell(currentY, currentX);
                            
                            if (CheckerMoveValidator.IsMoveValid(startCell, cellToCheck, board))
                            {
                                simpleMovesAvailable.Add(new Move(startCell, cellToCheck, false));
                            }

                            currentX += directions[i, 0];
                            currentY += directions[i, 1];
                        } while (true);
                    }
                    break;
            }

            return simpleMovesAvailable;
        }

        public List<Move> GetAvailableJumps(Cell startCell, Board board) {
            List<Move> jumpsAvailable = new List<Move>();

            switch (startCell.GetChecker().GetType())
            {
                case Checker.CheckerType.Simple:

                    int startCellX = startCell.GetColumn();
                    int startCellY = startCell.GetRow();

                    int[,] jumpCoordinates =
                    {
                        { startCellX - 2, startCellY - 2 },
                        { startCellX - 2, startCellY + 2 },
                        { startCellX + 2, startCellY - 2 },
                        { startCellX + 2, startCellY + 2 }
                    };
                    
                    for (int i = 0; i < 4; i++)
                    {
                        Cell endCell;

                        if (board.IsValidCell(jumpCoordinates[i, 1], jumpCoordinates[i, 0]))
                        {
                            endCell = board.GetCell(jumpCoordinates[i, 1], jumpCoordinates[i, 0]);
                            if (CheckerMoveValidator.IsJumpValid(startCell, endCell, board))
                            {
                                jumpsAvailable.Add(new Move(startCell, endCell, true));
                            }
                        }
                        
                    }

                    break;

                case Checker.CheckerType.King:
                    int startX = startCell.GetColumn();
                    int startY = startCell.GetRow();

                    // Diagonal directions: Up-left, Up-right, Down-left, Down-right
                    int[,] directions = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

                    for (int i = 0; i < 4; i++)
                    {
                        int currentX = startX + directions[i, 0];
                        int currentY = startY + directions[i, 1];

                        do
                        {
                            if (!board.IsValidCell(currentY, currentX))
                                break;

                            // Process the cell at currentX, currentY
                            Cell cellToCheck = board.GetCell(currentY, currentX);
                            if (CheckerJumpRule.CanJump(startCell, cellToCheck, board))
                            {
                                jumpsAvailable.Add(new Move(startCell, cellToCheck, true));
                            }

                            currentX += directions[i, 0];
                            currentY += directions[i, 1];
                        } while (true);
                    }
                    break;
            }

            return jumpsAvailable;
        }
        
        
        public GameColor GetColor()
        {
            return _computerPlayerColor;
        }
        

    }
}