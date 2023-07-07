namespace Checkers
{
    public class Move
    {
        private Cell _startCell;
        private Cell _endCell;
        private bool _isJump;

        public Move(Cell startCell, Cell endCell, bool isJump)
        {
            _startCell = startCell;
            _endCell = endCell;
            _isJump = isJump;
        }

        public Cell GetStartCell()
        {
            return _startCell;
        }

        public Cell GetEndCell()
        {
            return _endCell;
        }

        public bool IsJump()
        {
            return _isJump;
        }
     
        
    }
}