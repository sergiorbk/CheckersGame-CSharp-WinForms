using System;

namespace Checkers.Strategies
{
     public class DiagonalMoveRule : IMoveRule
     {
         public bool IsMoveValid(Cell startCell, Cell endCell, Board board)
         {
             if (!IsDiagonalMove(startCell, endCell))
             {
                 return false;
             }
             
             switch (startCell.GetChecker().GetType())
             {
                 case Checker.CheckerType.Simple:
                     return IsSimpleCheckerDiagonalMove(startCell, endCell);

                 case Checker.CheckerType.King:
                     return IsKingCheckerDiagonalMove(startCell, endCell, board);
                 
                 default:
                     return false;
             }
             
         }

         private bool IsSimpleCheckerDiagonalMove(Cell startCell, Cell endCell)
         {
             int dx = endCell.GetRow() - startCell.GetRow();
             int dy = endCell.GetColumn() - startCell.GetColumn();

             switch (startCell.GetChecker().GetColor())
             {
                 case GameColor.White:
                     return dx == -1 && Math.Abs(dy) == 1;
                 
                 case GameColor.Black:
                     return dx == 1 && Math.Abs(dy) == 1;
                 
                 default:
                     return false;
             }
             
         }

         private static bool IsKingCheckerDiagonalMove(Cell startCell, Cell endCell, Board board)
         {
             int dx = endCell.GetRow() - startCell.GetRow();
             int dy = endCell.GetColumn() - startCell.GetColumn();

             // Calculate the number of cells to jump
             int jumpCount = Math.Abs(dx);

             // Calculate the increment for each step
             int rowIncrement = (int)Math.Round((double)dx / jumpCount);
             int columnIncrement = (int)Math.Round((double)dy / jumpCount);

             // Iterate over the cells to be jumped
             for (int i = 1; i < jumpCount; i++)
             {
                 int jumpedRow = startCell.GetRow() + i * rowIncrement;
                 int jumpedColumn = startCell.GetColumn() + i * columnIncrement;

                 Cell jumpedCell = board.GetCell(jumpedRow, jumpedColumn);

                 // Removing the jumped checker
                 if (!jumpedCell.IsEmpty())
                 { 
                     return false;
                 }
             }
             
             return true;
         }

         private static bool IsDiagonalMove(Cell startCell, Cell endCell)
         {
             int dx = Math.Abs(endCell.GetRow() - startCell.GetRow());
             int dy = Math.Abs(endCell.GetColumn() - startCell.GetColumn());
             return dx == dy;
         }
        
         
    }
}