using System;

namespace Checkers.CheckersMoveRules
{
    public class CheckerJumpRule
    {
        public static bool CanJump(Cell startCell, Cell endCell, Board board)
        {
            switch (startCell.GetChecker().GetType())
            {
                case Checker.CheckerType.Simple:
                    return CanSimpleCheckerJump(startCell, endCell, board);

                case Checker.CheckerType.King:
                    return CanKingCheckerJump(startCell, endCell, board);
                
                default:
                    return false;
            }
        }

        private static bool CanSimpleCheckerJump(Cell startCell, Cell endCell, Board board)
        {
            int dx = endCell.GetRow() - startCell.GetRow();
            int dy = endCell.GetColumn() - startCell.GetColumn();

            // Перевірка того, що рух відбувається на дві клітинки по діагоналі вперед
            if (Math.Abs(dx) == 2 && Math.Abs(dy) == 2)
            {
                
                int jumpedRow = startCell.GetRow() + dx / 2;
                int jumpedColumn = startCell.GetColumn() + dy / 2;
                Cell jumpedCell = board.GetCell(jumpedRow, jumpedColumn);

                // Перевіряємо, чи містить проміжна клітина шашку іншого кольору
                if (!jumpedCell.IsEmpty() && jumpedCell.GetChecker().GetColor() != startCell.GetChecker().GetColor())
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CanKingCheckerJump(Cell startCell, Cell endCell, Board board)
        {
            int dx = endCell.GetRow() - startCell.GetRow();
            int dy = endCell.GetColumn() - startCell.GetColumn();
            // Перевіряємо, чи хід діагональний
            if (Math.Abs(dx) == Math.Abs(dy))
            {
                int steps = Math.Abs(dx);
                int stepX = dx > 0 ? 1 : -1; // Напрямок руху по осі Х
                int stepY = dy > 0 ? 1 : -1; // Напрямок руху по осі Y

                bool foundOpponentChecker = false; // Індикатор того, що було знайдено шашку іншого кольору
                int opponentCheckerRow = -1; // Координати клітини із шашкою іншого кольору

                for (int i = 1; i < steps; i++)
                {
                    int jumpedRow = startCell.GetRow() + i * stepX;
                    int jumpedColumn = startCell.GetColumn() + i * stepY;
                    Cell jumpedCell = board.GetCell(jumpedRow, jumpedColumn);

                    // Перевірка того, що проміжна клітина містить шашку іншого кольору
                    if (!jumpedCell.IsEmpty() &&
                        jumpedCell.GetChecker().GetColor() != startCell.GetChecker().GetColor())
                    {
                        if (foundOpponentChecker)
                        {
                            // Якщо на шляху королівської шашки є більше однієї шашки протилежного кольору,
                            // або якщо клітина з шашкою протилежного кольору не є наступною після шашки, що зрубується,
                            // хід неможливий
                            return false;
                        }

                        foundOpponentChecker = true;
                        opponentCheckerRow = jumpedRow;
                    }
                    else if (!jumpedCell.IsEmpty())
                    {
                        return false;
                    }
                }

                if (foundOpponentChecker)
                {
                    if (endCell.IsEmpty() && (endCell.GetRow() == opponentCheckerRow + stepX))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        
    }
}
