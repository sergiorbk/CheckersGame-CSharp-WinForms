using System;
using System.Collections.Generic;
using Checkers.CheckersMoveRules;

namespace Checkers
{
    public class GameAgainstHuman : IClickHandler
    {
        private readonly Board _board;
        private GameColor _colorTurn;
        private Cell _selectedCell;
        private readonly BoardPanel _boardPanel;
        private readonly GamingForm _gameForm;
        private bool _canJump;
        private bool _isJumping;

        public GameAgainstHuman(Board board, GamingForm gameForm, BoardPanel boardPanel)
        {
            _gameForm = gameForm;
            _boardPanel = boardPanel;
            _board = board;
            _colorTurn = GameColor.White;
            _gameForm.ChangePlayerTurn(_colorTurn);
            
            if (_board.IsGameOver())
            {
                _gameForm.ShowGameOver(_board.GetGameOverReason());
            }
        }

        void IClickHandler.ProcessClick(Cell touchedCell)
        {
            if (_selectedCell != null && touchedCell != null && (CheckerMoveValidator.IsMoveValid(
            _selectedCell, touchedCell, _board) || 
            CheckerMoveValidator.IsJumpValid(_selectedCell, touchedCell, _board))) {
                
                HandleSelectedChecker(touchedCell);
            }
            else
            {
                // перевіряємо, чи може будь-яка шашка поточного кольору здійснити стрибок зі зрубанням
                List<Cell> cellsFromJumpAvailable = new List<Cell>();
                foreach (Cell cell in _board.GetAllCells())
                {
                    if (!cell.IsEmpty() && cell.GetChecker().GetColor() == _colorTurn)
                    {
                        if (CheckerMoveValidator.IsAnyJumpAvailable(cell, _board))
                        {
                            cellsFromJumpAvailable.Add(cell);
                        }
                    }
                }
                // якщо є шашки поточного кольору, які можуть здійснити стрибок зі зрубанням
                if (cellsFromJumpAvailable.Count > 0)
                {
                    // дозволити обирати лише шашки, які можуть здійснити стрибок зі зрубанням
                    foreach (Cell cell in cellsFromJumpAvailable)
                    {
                        if (cell == touchedCell)
                        {
                            HandleUnselectedChecker(touchedCell);
                            break;
                        }
                    }
                }
                // інакше - дозволити вибір будь-якої шашки поточного кольору
                else
                {
                    HandleUnselectedChecker(touchedCell);
                }

            }
            
            
        }
        
private void HandleSelectedChecker(Cell touchedCell)
{
    if (_canJump)
    {
        if (CheckerMoveValidator.IsJumpValid(_selectedCell, touchedCell, _board))
        {
            _isJumping = true;
            
            RemoveEatenCheckers(touchedCell);
            MoveChecker(_selectedCell, touchedCell);
            _boardPanel.RefreshCell(_selectedCell);
            _boardPanel.RefreshCell(touchedCell);

            if (CheckerMoveValidator.IsAnyJumpAvailable(touchedCell, _board))
            {
                _selectedCell.UnmarkCell();
                _boardPanel.RefreshCell(_selectedCell);

                _selectedCell = touchedCell;
                _selectedCell.MarkCell();
                _boardPanel.RefreshCell(_selectedCell);
            }
            else
            {
                _isJumping = false;
                
                _selectedCell.UnmarkCell();
                _boardPanel.RefreshCell(_selectedCell);
                ChangeTurn();
                _selectedCell = null;
                _canJump = false;
            }
            
        }
        else
        {
            return;
        }
        
    }else if (CheckerMoveValidator.IsMoveValid(_selectedCell, touchedCell, _board)) {
        MoveChecker(_selectedCell, touchedCell);
        _selectedCell.UnmarkCell();
        _boardPanel.RefreshCell(_selectedCell);
        _boardPanel.RefreshCell(touchedCell);
        _selectedCell = null;
        ChangeTurn();
        
    }
    else 
    {
        return;
    }
    
    if (_board.IsGameOver())
    {
        _gameForm.ShowGameOver(_board.GetGameOverReason());
    }

    
    if (CheckerPromotionRule.CheckPromotion(touchedCell, _board))
    {
        touchedCell.GetChecker().SetType(Checker.CheckerType.King);
        _boardPanel.RefreshCell(touchedCell);
    }
    
}

private void HandleUnselectedChecker(Cell touchedCell)
{
    if (_isJumping)
    {
        return;
    }
    
    if (!touchedCell.IsEmpty() && touchedCell.GetChecker().GetColor() == _colorTurn)
    {
        
        if (_selectedCell == null)
        {
            // MARK CELL (choosing figure to make a move)
            _selectedCell = touchedCell;
            _selectedCell.MarkCell();
            _boardPanel.RefreshCell(_selectedCell);
            
            if (CheckerMoveValidator.IsAnyJumpAvailable(touchedCell, _board))
            {
                _canJump = true;
            }
            else
            {
                _canJump = false;
            }
            
        }else if (_selectedCell == touchedCell) {
            _selectedCell.UnmarkCell();
            _boardPanel.RefreshCell(_selectedCell);
            _selectedCell = null;

        }else {
            // UNMARK CELL
            _selectedCell.UnmarkCell();
            Cell lastSelectedCell = _selectedCell;

            _selectedCell = touchedCell;
            _selectedCell.MarkCell();
            
            _boardPanel.RefreshCell(lastSelectedCell);
            _boardPanel.RefreshCell(_selectedCell);
            
            if (CheckerMoveValidator.IsAnyJumpAvailable(touchedCell, _board))
            {
                _canJump = true;
            }
            else
            {
                _canJump = false;
            }
            
            
        }
    }
    
}

private void RemoveEatenCheckers(Cell touchedCell)
{
    int dx = touchedCell.GetRow() - _selectedCell.GetRow();
    int dy = touchedCell.GetColumn() - _selectedCell.GetColumn();

    // Calculate the number of cells to jump
    int jumpCount = Math.Abs(dx);

    
    int rowIncrement = (int)Math.Round((double)dx / jumpCount);
    int columnIncrement = (int)Math.Round((double)dy / jumpCount);

    // Iterate over the cells to be jumped
    for (int i = 1; i < jumpCount; i++)
    {
        int jumpedRow = _selectedCell.GetRow() + i * rowIncrement;
        int jumpedColumn = _selectedCell.GetColumn() + i * columnIncrement;

        Cell jumpedCell = _board.GetCell(jumpedRow, jumpedColumn);

        // Removing the jumped checker
        if (!jumpedCell.IsEmpty())
        {
            if (_colorTurn != jumpedCell.GetChecker().GetColor())
            {
                jumpedCell.RemoveChecker();
                _boardPanel.RefreshCell(jumpedCell);
            }
        }
    }
}

private void MoveChecker(Cell startCell, Cell endCell)
        {
            endCell.PutChecker(startCell.GetChecker());
            _boardPanel.RefreshCell(endCell);
            startCell.RemoveChecker();
            _boardPanel.RefreshCell(startCell);
        }
        
        private void ChangeTurn()
        {
            if (_colorTurn == GameColor.White)
            {
                _colorTurn = GameColor.Black;
            }
            else
            {
                _colorTurn = GameColor.White;
            }
            
            _gameForm.ChangePlayerTurn(_colorTurn);
        }

        
    }
}