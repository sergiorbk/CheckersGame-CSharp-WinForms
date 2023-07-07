namespace Checkers.CheckersMoveRules
{
    public class CheckerPromotionRule
    {
        public static bool CheckPromotion(Cell cell, Board board)
        {
            if (cell.GetChecker().GetType() == Checker.CheckerType.King)
            {
                return false;
            }

            if (cell.GetChecker().GetColor() == GameColor.White && cell.GetRow() == 0)
            {
                return true;
            }

            if (cell.GetChecker().GetColor() == GameColor.Black && cell.GetRow() == board.GetRows() - 1)
            {
                return true;
            }

            return false;
        }
        
        
    }
}