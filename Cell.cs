using System;

namespace Checkers
{
    public class Cell
    {
        
        private readonly int _row;
        private readonly int _column;
        private readonly GameColor _color;
        private Checker _checker;
        private bool _isMarked;
        
        public Cell(int row, int column, GameColor color)
        {
            _row = row;
            _column = column;
            _checker = null;
            _color = color;
        }

        public void MarkCell()
        {
            _isMarked = true;
        }

        public void UnmarkCell()
        {
            _isMarked = false;
        }

        public bool IsMarked()
        {
            return _isMarked;
        }
        
        // GETTERS
        public int GetRow()
        {
            return _row;
        }

        public int GetColumn()
        {
            return _column;
        }

        public GameColor GetColor()
        {
            return _color;
        }

        public Checker GetChecker()
        {
            if (IsEmpty())
            {
                throw new Exception("This cell is empty");
            }
            return _checker;
        }

        public void PutChecker(Checker checker)
        {
            _checker = checker;
        }
        
        public bool IsEmpty()
        {
            if (_checker == null)
            {
                return true;
            }
            return false;
        }

        public void RemoveChecker()
        {
            _checker = null;
            
        }
        
        
    }
}