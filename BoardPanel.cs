using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public class BoardPanel : Panel
    {

        private IClickHandler _clickHandler;
        private readonly Board _board;
        private readonly int _cellSize;
        private readonly Color _selectedCellColor = Color.Goldenrod;

        
        public void SetClickHandler(IClickHandler clickHandler)
        {
            _clickHandler = clickHandler;
        }
        
        public BoardPanel(Board board,int cellSize)
        {
            _board = board;
            _cellSize = cellSize;

            Location = new Point(_cellSize, _cellSize);
            Size = new Size(_board.GetRows() * _cellSize, _board.GetColumns() * _cellSize);
            Paint += BoardPanel_Paint;
            MouseClick += BoardPanel_MouseClick;
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // showing cells on a panel (board)
            for (int row = 0; row < _board.GetRows(); row++)
            {
                for (int col = 0; col < _board.GetColumns(); col++)
                {
                    Cell cell = _board.GetCell(row, col);
                    Brush brush = new SolidBrush(cell.GetColor().ToDrawingColor());
                    g.FillRectangle(brush, col * _cellSize, row * _cellSize, _cellSize, _cellSize);
                    
                    // showing checkers on a board (panel)
                    if (!cell.IsEmpty())
                    {
                        Checker checker = cell.GetChecker();
                        Image checkerImage = checker.GetImage();
                        g.DrawImage(checkerImage, col * _cellSize, row * _cellSize, _cellSize, _cellSize);
                    }
                }
            }

        }

        private void BoardPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // Getting click's coordinates
            int row = e.Y / _cellSize;
            int col = e.X / _cellSize;

            // Getting a cell by coordinates
            Cell cell = _board.GetCell(row, col);
            _clickHandler?.ProcessClick(cell);
        }

        public void RefreshCell(Cell cell)
        {
            Rectangle rect = new Rectangle(cell.GetColumn() * _cellSize, cell.GetRow() * _cellSize, _cellSize, _cellSize);
            using (Graphics g = CreateGraphics())
            {
                Brush brush;
                if (cell.IsMarked())
                { // if cell was selected by user
                    brush = new SolidBrush(_selectedCellColor);
                }
                else
                {
                    // if cell is not marked (selected by user)
                    brush = new SolidBrush(cell.GetColor().ToDrawingColor());
                }
                    
                g.FillRectangle(brush, rect);

                if (!cell.IsEmpty())
                {
                    Checker checker = cell.GetChecker();
                    Image checkerImage = checker.GetImage();
                    g.DrawImage(checkerImage, rect);
                }
            }
        }

        public Board GetBoard()
        {
            return _board;
        }

        public int GetCellSize()
        {
            return _cellSize;
        }
        
        
    }
}