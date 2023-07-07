namespace Checkers.Strategies
{
    public class EmptyCellRule: IMoveRule
    {
        public bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            if (endCell.IsEmpty())
            {
                return true;
            }

            return false;
        }
        
        
    }
}