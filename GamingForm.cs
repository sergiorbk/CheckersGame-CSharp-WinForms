using System;
using System.Drawing;

using System.Windows.Forms;

namespace Checkers
{
    public partial class GamingForm : Form
    {
        private ControlPanel _controlPanel = new ControlPanel(new Size(155, 400), new Point(500, 50));
        public GamingForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Controls.Add(_controlPanel);
        }

        public ControlPanel GetControlPanel()
        {
            return _controlPanel;
        }
        
        public void ChangePlayerTurn(GameColor playerColor)
        {
            string currentPlayerColor;
            
            if (playerColor == GameColor.White)
            {
                currentPlayerColor = "Білі";
            }
            else if (playerColor == GameColor.Black)
            {
                currentPlayerColor = "Чорні";
            }
            else
            {
                currentPlayerColor = playerColor.ToString();
            }
            
            _turnLabel.Text = "Зараз ходять: " + currentPlayerColor;
        }

        public void ShowGameOver(string victoryReason)
        {
            MessageBox.Show(victoryReason, "Кінець гри", MessageBoxButtons.OK);
            Close();
        }

        
    }
}