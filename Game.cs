using System.Windows.Forms;

namespace Checkers
{
    public class Game
    {
        private GamingForm _gameForm;

        private const int CellSize = 50;
        private const int Rows = 8;
        private const int Columns = 8;

        public Game(GameMode gameMode, Board board)
        {
            switch (gameMode)
            {
                case GameMode.AgainstHuman:
                    StartGameAgainstHuman(board);
                    break;
                
                case GameMode.AgainstComputer:
                    StartGameAgainstComputer(board);
                    break;
                
                case GameMode.Training:
                    StartTraining();
                    break;
            }
        }
        
        private void StartGameAgainstHuman(Board inputBoard)
        {
            _gameForm = new GamingForm();

            Board board;
            if (inputBoard == null)
            {
               board = new Board(Rows, Columns);
               board.PlaceCheckers();
            }
            else if (inputBoard.IsGameOver())
            {
                MessageBox.Show("Неможливо розпочати партію з поточним розташуванням шашок.", "Помилка", MessageBoxButtons.OK);
                return;
            }
            else
            {
                board = inputBoard;
            }

            BoardPanel boardPanel = new BoardPanel(board, CellSize);
            
            _gameForm.Controls.Add(boardPanel);
            
            GameAgainstHuman gameAgainstHuman = new GameAgainstHuman(board, _gameForm, boardPanel);
            boardPanel.SetClickHandler(gameAgainstHuman);
            
            _gameForm.Show();
        }

        private void StartGameAgainstComputer(Board inputBoard)
        {
            _gameForm = new GamingForm();

            Board board;
            if (inputBoard == null)
            {
                board = new Board(Rows, Columns);
                board.PlaceCheckers();
            }
            else if (inputBoard.IsGameOver())
            {
                MessageBox.Show("Неможливо розпочати партію з поточним розташуванням шашок.", "Помилка", MessageBoxButtons.OK);
                return;
            }
            else
            {
                board = inputBoard;
            }
            
            BoardPanel boardPanel = new BoardPanel(board, CellSize);
            _gameForm.Controls.Add(boardPanel);
            GameAgainstComputer gameAgainstComputer = new GameAgainstComputer(board, _gameForm, boardPanel);
            boardPanel.SetClickHandler(gameAgainstComputer);
            _gameForm.Show();
        }
        
        private void StartTraining()
        {
            _gameForm = new GamingForm();
            Board board = new Board(Rows, Columns);
            BoardPanel boardPanel = new BoardPanel(board, CellSize);
            _gameForm.Controls.Add(boardPanel);
            TrainingGame trainingGame = new TrainingGame(_gameForm, boardPanel);
             boardPanel.SetClickHandler(trainingGame);
             _gameForm.Show();
        }

        public GamingForm GetGameForm()
        {
            return _gameForm;
        }
       
        
    }
}