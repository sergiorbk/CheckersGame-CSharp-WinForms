using System.Collections.Generic;
using Checkers.CheckersMoveRules;
using Checkers.Strategies;

namespace Checkers
{
    public class CheckerMoveValidator
    {
        private static List<IMoveRule> _basicMoveRules = new List<IMoveRule>
        {
            new EmptyCellRule(),
            new BlackColorCellRule(),
            new DiagonalMoveRule()
        };

        private static bool CheckBasicMoveRules(Cell startCell, Cell endCell, Board board)
        {
            if (startCell == null || endCell == null) { return false; }
            
            foreach (IMoveRule rule in _basicMoveRules)
            {
                if (!rule.IsMoveValid(startCell, endCell, board))
                {
                    return false;
                }
            }
            
            return true;
        }
        
        
        public static bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            if (startCell == null || endCell == null)
            {
                return false;
            }
            
            if (startCell.IsEmpty())
            {
                return false;
            }
            
            if (!CheckBasicMoveRules(startCell, endCell, board))
            {
                return false;
            }

            return true;
        }
        
        
        // MOVES VALIDATION METHODS
        public static bool IsAnyMoveAvailable(Cell startCell, Board board)
        {
            switch (startCell.GetChecker().GetType())
            {
                case Checker.CheckerType.Simple:
                    return IsAnyMoveForSimpleCheckerAvailable(startCell, board);
                
                case Checker.CheckerType.King:
                    return IsAnyMoveForKingCheckerValid(startCell, board);
                
                default: return false;
            }
        }

        private static bool IsAnyMoveForSimpleCheckerAvailable(Cell startCell, Board board)
        {
            int cellX = startCell.GetRow();
            int cellY = startCell.GetColumn();
            
            int[,] moveCoordinates =
            {
                { cellX - 1, cellY + 1 },
                { cellX + 1, cellY + 1 },
                { cellX - 1, cellY - 1 },
                { cellX + 1, cellY - 1 }
            };

            
            for (int i = 0; i < 4; i++)
            {
                
                Cell endCell;
                if(board.IsValidCell(moveCoordinates[i, 0], moveCoordinates[i, 1]))
                {
                    endCell = board.GetCell(moveCoordinates[i, 0], moveCoordinates[i, 1]);

                    if (IsMoveValid(startCell, endCell, board))
                    {
                        return true;
                    }
                    
                }

            }
            
            return false;
        }
        
        private static bool IsAnyMoveForKingCheckerValid(Cell startCell, Board board)
        {
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
                    //foreach (IMoveRule rule in _basicMoveRules)
                    //{
                        if (IsMoveValid(startCell, cellToCheck, board))
                        {
                            return true;
                        }
                    //}

                    currentX += directions[i, 0];
                    currentY += directions[i, 1];
                }
                while (true);
            }

            return false;
        }
        
        
        // JUMP VALIDATION METHODS
        public static bool IsJumpValid(Cell startCell, Cell endCell, Board board)
        {
            if (startCell == null || endCell == null) {
                return false;
            }
            
            if (startCell.IsEmpty() || !endCell.IsEmpty()) {
                return false;
            }

            if (endCell.GetColor() != GameColor.Black) {
                return false;
            }

            if (!CheckerJumpRule.CanJump(startCell, endCell, board)) {
                return false;
            }

            return true;
        }
        
        public static bool IsAnyJumpAvailable(Cell startCell, Board board)
        {
            if (startCell == null) {return false;}
            
            switch (startCell.GetChecker().GetType()) {
                case Checker.CheckerType.Simple:
                    return IsAnyJumpForSimpleCheckerAvailable(startCell, board);
                
                case Checker.CheckerType.King:
                    return IsAnyJumpValidForKingChecker(startCell, board);
                
                default: return false;
            }
        }

        private static bool IsAnyJumpForSimpleCheckerAvailable(Cell startCell, Board board)
        {
            int startCellX = startCell.GetColumn();
            int startCellY = startCell.GetRow();

            int[,] jumpCoordinates =
            {
                { startCellX - 2, startCellY - 2 },
                { startCellX - 2, startCellY + 2 },
                { startCellX + 2, startCellY - 2 },
                { startCellX + 2, startCellY + 2}
            };

            

            for (int i = 0; i < 4; i++)
            {
                Cell endCell;
                if(board.IsValidCell(jumpCoordinates[i, 1], jumpCoordinates[i, 0]))
                {
                    endCell = board.GetCell(jumpCoordinates[i, 1], jumpCoordinates[i, 0]);
                    if (IsJumpValid(startCell, endCell, board))
                    {
                        return true;
                    }
                }

            }
            
            return false;
        }

        private static bool IsAnyJumpValidForKingChecker(Cell startCell, Board board)
        {
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
                        return true;
                    }

                    currentX += directions[i, 0];
                    currentY += directions[i, 1];
                }
                while (true);
            }

            return false;
        }
        

    }
}