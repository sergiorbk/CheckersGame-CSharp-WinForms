namespace Checkers.Strategies
{
    public interface IMoveRule
    {
        bool IsMoveValid(Cell startCell, Cell endCell, Board board);
    }
}