using System;
using System.Collections.Generic;

namespace Checkers
{
    public class Board
    {
        private readonly Cell[,] _cells;
        private readonly int _rows;
        private readonly int _columns;

        public Board(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _cells = new Cell[_rows, _columns];
            FillBoard();
        }

        public Board(Board board)
        {
            _rows = board.GetRows();
            _columns = board.GetColumns();
            _cells = board._cells;
        }

        public void MakeMove(Move move)
        {
            Cell startCell = move.GetStartCell();
            Cell endCell = move.GetEndCell();
            endCell.PutChecker(startCell.GetChecker());
            startCell.RemoveChecker();
        }

        public int GetRows()
        {
            return _rows;
        }

        public int GetColumns()
        {
            return _columns;
        }

        public Cell GetCell(int row, int column)
        {
            if (row < 0 || row >= _rows || column < 0 || column >= _columns)
            {
                throw new ArgumentOutOfRangeException();
                //return null;
            } 
            
            return _cells[row, column];
            
        }

        private void FillBoard()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    bool isDark = (i + j) % 2 == 1;
                    GameColor color = isDark ? GameColor.Black : GameColor.White;
                    _cells[i, j] = new Cell(i, j, color);
                }
            }
        }
        
        
        public void PlaceCheckers()
        {
            // розстановка чорних шашок
            for (int row = 0; row < _rows / 2 - 1; row++)
            {
                for (int col = (row + 1) % 2; col < _columns; col += 2)
                {
                    Checker checker = new Checker(GameColor.Black);
                    _cells[row, col].PutChecker(checker);
                }
            }
            
            // Розстановка білих шашок
            for (int row = _rows / 2 + 1; row < _rows; row++)
            {
                for (int col = (row + 1) % 2; col < _columns; col += 2)
                {
                    Checker checker = new Checker(GameColor.White);
                    _cells[row, col].PutChecker(checker);
                }
            }
            
        }
        
        public List<Cell> GetAllCells()
        {
            List<Cell> allCells = new List<Cell>();

            int numRows = _cells.GetLength(0);
            int numColumns = _cells.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int column = 0; column < numColumns; column++)
                {
                    allCells.Add(GetCell(row, column));
                }
            }

            return allCells;
        }
        
        public bool IsValidCell(int x, int y)
        {
            try
            {
                GetCell(x, y);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }
        
        public bool HasCheckers(GameColor color)
        {
            foreach (Cell cell in _cells)
            {
                if (cell.IsEmpty())
                {
                    continue;
                }

                if (cell.GetChecker().GetColor() == color)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetGameOverReason()
        {
            string gameOverText = "Гру завершено перемогою ";
            if (!HasCheckers(GameColor.White) && HasCheckers(GameColor.Black))
            {
                gameOverText += " ЧОРНИХ : на дошці не залишилося шашок БІЛОГО кольору.";
                return gameOverText;
            }
            else if(HasCheckers(GameColor.White) && !HasCheckers(GameColor.Black))
            {
                gameOverText += "БІЛИХ : на дошці не залишилося шашок ЧОРНОГО кольору.";
                return gameOverText;
            }

            GameColor checkerColorUnableToMakeAnyMove = GetWhoCanNotMakeAnyMove();
            if (checkerColorUnableToMakeAnyMove != GameColor.None)
            {
                switch (GetWhoCanNotMakeAnyMove())
                {
                    case GameColor.White:
                        gameOverText += " ЧОРНИХ : усі БІЛІ шашки заблоковані.";
                        return gameOverText;
                    case GameColor.Black:
                        gameOverText += " БІЛИХ : усі ЧОРНІ шашки заблоковані.";
                        return gameOverText;
                }
            }

            return null;
        }
        public bool IsGameOver()
        {
            bool hasWhiteCheckers = HasCheckers(GameColor.White);
            bool hasBlackCheckers = HasCheckers(GameColor.Black);
            
            if (!hasWhiteCheckers || !hasBlackCheckers)
            {
                return !hasWhiteCheckers || !hasBlackCheckers;
            }

            if (GetWhoCanNotMakeAnyMove() != GameColor.None)
            {
                return true;
            }

            return false;
        }

        private GameColor GetWhoCanNotMakeAnyMove()
        {
            bool canWhiteMove = false;
            bool canBlackMove = false;
            
            foreach (Cell cell in GetAllCells())
            {
                if (!cell.IsEmpty())
                {
                    if (CheckerMoveValidator.IsAnyJumpAvailable(cell, this) ||
                        CheckerMoveValidator.IsAnyMoveAvailable(cell, this))
                    {
                        switch (cell.GetChecker().GetColor())
                        {
                            case GameColor.White:
                                canWhiteMove = true;
                                break;
                            
                            case GameColor.Black:
                                canBlackMove = true;
                                break;
                        }
                    }
                }
            }

            if (canWhiteMove && !canBlackMove)
            {
                return GameColor.Black;
            }else if (!canWhiteMove && canBlackMove)
            {
                return GameColor.White;
            }
            else
            {
                return GameColor.None;
            }
        }

        
    }
}