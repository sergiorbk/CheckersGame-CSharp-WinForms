using System.Drawing;
using System.Windows.Forms;

namespace Checkers.Resources
{
    public class TrainingPanel: Panel
    {
        private readonly TrainingGame _trainingGame;
        private readonly Label _whiteCheckersAmountLabel = new Label();
        private readonly Label _blackCheckersAmountLabel = new Label();
        public TrainingPanel(Point location, Size size, TrainingGame trainingGame)
        {
            _trainingGame = trainingGame;
            Location = location;
            BackColor = Color.DarkGoldenrod;
            Size = size;
            AutoSize = true;
            
            PictureBox whiteCheckerPictureBox = new PictureBox();
            whiteCheckerPictureBox.Image = Image.FromFile(Matherials.whiteSimpleCheckerPath);
            whiteCheckerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            whiteCheckerPictureBox.Location = new Point(10, 0); 
            whiteCheckerPictureBox.Size = new Size(50, 50);
            Controls.Add(whiteCheckerPictureBox);
            
            whiteCheckerPictureBox.MouseClick += whiteCheckerPictureBox_MouseClick;
            
            _whiteCheckersAmountLabel.Text = "0";
            _whiteCheckersAmountLabel.TextAlign = ContentAlignment.MiddleCenter;
            _whiteCheckersAmountLabel.Location = new Point(25, 60);
            _whiteCheckersAmountLabel.AutoSize = true;
            Controls.Add(_whiteCheckersAmountLabel);
            
            
            PictureBox blackCheckerPictureBox = new PictureBox();
            blackCheckerPictureBox.Image = Image.FromFile(Matherials.blackSimpleCheckerPath);
            blackCheckerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            blackCheckerPictureBox.Location = new Point(70, 0);
            blackCheckerPictureBox.Size = new Size(50, 50);
            Controls.Add(blackCheckerPictureBox);
            blackCheckerPictureBox.MouseClick += blackCheckerPictureBox_MouseClick;
            
            
            _blackCheckersAmountLabel.Text = "0";
            _blackCheckersAmountLabel.TextAlign = ContentAlignment.MiddleCenter;
            _blackCheckersAmountLabel.Location = new Point(85, 60);
            _blackCheckersAmountLabel.AutoSize = true;
            Controls.Add(_blackCheckersAmountLabel);
            
            
            // START MODE BUTTONS
            Button startGameAgainstHumanButton = new Button();
            startGameAgainstHumanButton.Text = "Гра проти людини";
            startGameAgainstHumanButton.BackColor = Color.Azure;
            startGameAgainstHumanButton.Location = new Point(15, 80);
            startGameAgainstHumanButton.AutoSize = true;
            Controls.Add(startGameAgainstHumanButton);
            startGameAgainstHumanButton.MouseClick += startGameAgainstHuman_MouseClick;

            Button startGameAgainstComputerButton = new Button();
            startGameAgainstComputerButton.BackColor = Color.Azure;
            startGameAgainstComputerButton.Location = new Point(5, 105);
            startGameAgainstComputerButton.AutoSize = true;
            startGameAgainstComputerButton.Text = "Гра проти комп'ютера";
            Controls.Add(startGameAgainstComputerButton);
            startGameAgainstComputerButton.MouseClick += startGameAgainstComputer_MouseClick;
        }

        private void startGameAgainstHuman_MouseClick(object sender, MouseEventArgs e)
        {
            if (_trainingGame.GetStartWhiteCheckersAmount() > _trainingGame.GetCheckersLeftByColor(GameColor.White) &&
                _trainingGame.GetStartBlackCheckersAmount() > _trainingGame.GetCheckersLeftByColor(GameColor.Black))
            {
                _trainingGame.get_ready(GameMode.AgainstHuman);
            }
            else
            {
                MessageBox.Show("Розставте шашки, щоб почати партію.", "Здійсніть розстановку", MessageBoxButtons.OK);
            }
        }
        
        private void startGameAgainstComputer_MouseClick(object sender, MouseEventArgs e)
        {
            if (_trainingGame.GetStartWhiteCheckersAmount() > _trainingGame.GetCheckersLeftByColor(GameColor.White) &&
                _trainingGame.GetStartBlackCheckersAmount() > _trainingGame.GetCheckersLeftByColor(GameColor.Black))
            {
                _trainingGame.get_ready(GameMode.AgainstComputer);
            }
            else
            {
                MessageBox.Show("Розставте шашки, щоб почати партію.", "Здійсніть розстановку", MessageBoxButtons.OK);
            }
        }
        
        private void whiteCheckerPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _trainingGame.ProcessWhiteCheckerClick();
        }

        private void blackCheckerPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _trainingGame.ProcessBlackCheckerClick();
        }

        public void SetWhiteCheckersAmountLabel(int checkersAmount)
        {
            _whiteCheckersAmountLabel.Text = checkersAmount.ToString();
        }
        
        public void SetBlackCheckersAmountLabel(int checkersAmount)
        {
            _blackCheckersAmountLabel.Text = checkersAmount.ToString();
        }
    }
}