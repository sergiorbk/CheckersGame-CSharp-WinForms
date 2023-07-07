using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Checkers
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AgainstHumanButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(GameMode.AgainstHuman, null);
            Hide();
            game.GetGameForm().FormClosed += (s, args) => Show();
            game.GetGameForm().Show();
        }

        private void AgainstComputerButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(GameMode.AgainstComputer, null);
            Hide();
            game.GetGameForm().FormClosed += (s, args) => Show();
            game.GetGameForm().Show();
        }

        private void TrainingButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(GameMode.Training, null);
            Hide();
            game.GetGameForm().FormClosed += (s, args) => Show();
            game.GetGameForm().Show();
        }

        private void copyrightLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.sergosoft.com");
        }

        private void copyrightLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.kpi.ua");
        }
    }
}