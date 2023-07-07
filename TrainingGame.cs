using System.Drawing;
using System.Windows.Forms;
using Checkers.Resources;

namespace Checkers
{
    public class TrainingGame : IClickHandler
    {
        private GamingForm _gameForm;
        private TrainingPanel _trainingPanel;
        private BoardPanel _boardPanel;
        private CheckersAmount _whiteCheckersAmount;
        private CheckersAmount _blackCheckersAmount;
        private GameColor _currentColor = GameColor.White;
        private int _startWhiteCheckersAmount;
        private int _startBlackCheckersAmount;

        public TrainingGame(GamingForm gameForm, BoardPanel boardPanel)
        {
            _trainingPanel = new TrainingPanel(new Point(7, 50), new Size(100, 100), this);
            _gameForm = gameForm;
            _boardPanel = boardPanel;

            _gameForm.GetControlPanel().Controls.Add(_trainingPanel);

            int whiteCheckersLeft = boardPanel.GetBoard().GetColumns() / 2 * 3;
            int blackCheckersLeft = whiteCheckersLeft;

            _whiteCheckersAmount = new CheckersAmount(GameColor.White, whiteCheckersLeft);
            _blackCheckersAmount = new CheckersAmount(GameColor.Black, blackCheckersLeft);

            _startWhiteCheckersAmount = whiteCheckersLeft;
            _startBlackCheckersAmount = blackCheckersLeft;

            _trainingPanel.SetWhiteCheckersAmountLabel(whiteCheckersLeft);
            _trainingPanel.SetBlackCheckersAmountLabel(blackCheckersLeft);

        }

        public void get_ready(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.AgainstHuman:
                    //_gameForm.Close();
                    //new Game(GameMode.AgainstHuman, _boardPanel.GetBoard());
                    _trainingPanel.Hide();
                    GameAgainstHuman gameAgainstHuman = new GameAgainstHuman(_boardPanel.GetBoard(), _gameForm, _boardPanel);
                    _boardPanel.SetClickHandler(gameAgainstHuman);
                    break;
                
                case GameMode.AgainstComputer:
                    //_gameForm.Close();
                    //new Game(GameMode.AgainstComputer, _boardPanel.GetBoard());
                    _trainingPanel.Hide();
                    GameAgainstComputer gameAgainstComputer = new GameAgainstComputer(_boardPanel.GetBoard(), _gameForm, _boardPanel);
                    _boardPanel.SetClickHandler(gameAgainstComputer);
                    break;
            }
        }

        public void ProcessClick(Cell cell)
        {
            if (cell.GetColor() != GameColor.Black)
            {
                return;
            }

            if (cell.IsEmpty())
            {
                if (GetCheckersLeftByColor(_currentColor) > 0)
                {
                    cell.PutChecker(new Checker(_currentColor));
                    GetCheckersAmountByColor(_currentColor).Decrease();
                    UpdateCheckersAmountOnLabelByColor(_currentColor);
                }
            }
            else if (cell.GetChecker().GetType() == Checker.CheckerType.Simple)
            {
                cell.GetChecker().SetType(Checker.CheckerType.King);
            }
            else
            {
                GetCheckersAmountByColor(cell.GetChecker().GetColor()).Increase();
                UpdateCheckersAmountOnLabelByColor(_currentColor);
                cell.RemoveChecker();
            }


            _boardPanel.RefreshCell(cell);
        }

        private void UpdateCheckersAmountOnLabelByColor(GameColor color)
        {
            switch (color)
            {
                case GameColor.White:
                    _trainingPanel.SetWhiteCheckersAmountLabel(_whiteCheckersAmount.Amount);
                    break;

                case GameColor.Black:
                    _trainingPanel.SetBlackCheckersAmountLabel(_blackCheckersAmount.Amount);
                    break;
            }
        }

        public int GetCheckersLeftByColor(GameColor color)
        {
            return GetCheckersAmountByColor(color).Amount;
        }

        private CheckersAmount GetCheckersAmountByColor(GameColor color)
        {
            return color == GameColor.White ? _whiteCheckersAmount : _blackCheckersAmount;
        }

        public GameColor GetCurrentColor()
        {
            return _currentColor;
        }

        public void ProcessWhiteCheckerClick()
        {
            _currentColor = GameColor.White;
        }

        public void ProcessBlackCheckerClick()
        {
            _currentColor = GameColor.Black;
        }

        public int GetStartWhiteCheckersAmount()
        {
            return _startWhiteCheckersAmount;
        }
        
        public int GetStartBlackCheckersAmount()
        {
            return _startBlackCheckersAmount;
        }
        
        // CLASS CHECKERS AMOUNT
        private class CheckersAmount
        {
            public GameColor Color;
            public int Amount { get; private set; }

            public CheckersAmount(GameColor color, int amount)
            {
                Color = color;
                Amount = amount;
            }

            public void Decrease()
            {
                if (Amount > 0)
                    Amount--;
            }

            public void Increase()
            {
                Amount++;
            }
        }
        

    }
}
