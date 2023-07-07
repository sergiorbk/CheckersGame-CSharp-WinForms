namespace Checkers.Strategies
{
    public class BlackColorCellRule : IMoveRule
    {
        public bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            if (endCell.GetColor() == GameColor.Black)
            {
                return true;
            }

            return false;
        }
        
        
    }
}