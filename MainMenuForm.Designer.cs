using System.ComponentModel;

namespace Checkers
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.AgainstHumanButton = new System.Windows.Forms.Button();
            this.AgainstComputerButton = new System.Windows.Forms.Button();
            this.TrainingButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.copyrightLabel1 = new System.Windows.Forms.LinkLabel();
            this.copyrightLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // AgainstHumanButton
            // 
            this.AgainstHumanButton.Location = new System.Drawing.Point(183, 162);
            this.AgainstHumanButton.Name = "AgainstHumanButton";
            this.AgainstHumanButton.Size = new System.Drawing.Size(135, 44);
            this.AgainstHumanButton.TabIndex = 0;
            this.AgainstHumanButton.Text = "Грати проти людини";
            this.AgainstHumanButton.UseVisualStyleBackColor = true;
            this.AgainstHumanButton.Click += new System.EventHandler(this.AgainstHumanButton_Click);
            // 
            // AgainstComputerButton
            // 
            this.AgainstComputerButton.Location = new System.Drawing.Point(183, 227);
            this.AgainstComputerButton.Name = "AgainstComputerButton";
            this.AgainstComputerButton.Size = new System.Drawing.Size(135, 36);
            this.AgainstComputerButton.TabIndex = 1;
            this.AgainstComputerButton.Text = "Грати проти комп\'ютера";
            this.AgainstComputerButton.UseVisualStyleBackColor = true;
            this.AgainstComputerButton.Click += new System.EventHandler(this.AgainstComputerButton_Click);
            // 
            // TrainingButton
            // 
            this.TrainingButton.Location = new System.Drawing.Point(183, 285);
            this.TrainingButton.Name = "TrainingButton";
            this.TrainingButton.Size = new System.Drawing.Size(135, 39);
            this.TrainingButton.TabIndex = 2;
            this.TrainingButton.Text = "Персональна розстановка";
            this.TrainingButton.UseVisualStyleBackColor = true;
            this.TrainingButton.Click += new System.EventHandler(this.TrainingButton_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label1.ForeColor = System.Drawing.Color.Gold;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(473, 73);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Шашковий тренажер";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Marigold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(99, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Головне меню";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyrightLabel1
            // 
            this.copyrightLabel1.AutoSize = true;
            this.copyrightLabel1.BackColor = System.Drawing.Color.Transparent;
            this.copyrightLabel1.Font = new System.Drawing.Font("Onyx", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyrightLabel1.LinkColor = System.Drawing.Color.Cyan;
            this.copyrightLabel1.Location = new System.Drawing.Point(12, 330);
            this.copyrightLabel1.Name = "copyrightLabel1";
            this.copyrightLabel1.Size = new System.Drawing.Size(152, 14);
            this.copyrightLabel1.TabIndex = 5;
            this.copyrightLabel1.TabStop = true;
            this.copyrightLabel1.Text = "© Рибак Сергій Миколайович";
            this.copyrightLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyrightLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyrightLabel1_LinkClicked);
            // 
            // copyrightLabel2
            // 
            this.copyrightLabel2.AutoSize = true;
            this.copyrightLabel2.BackColor = System.Drawing.Color.Transparent;
            this.copyrightLabel2.Font = new System.Drawing.Font("Onyx", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyrightLabel2.LinkColor = System.Drawing.Color.Cyan;
            this.copyrightLabel2.Location = new System.Drawing.Point(404, 330);
            this.copyrightLabel2.Name = "copyrightLabel2";
            this.copyrightLabel2.Size = new System.Drawing.Size(72, 14);
            this.copyrightLabel2.TabIndex = 6;
            this.copyrightLabel2.TabStop = true;
            this.copyrightLabel2.Text = "© НТУУ \"КПІ\"";
            this.copyrightLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyrightLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyrightLabel2_LinkClicked);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 352);
            this.Controls.Add(this.copyrightLabel2);
            this.Controls.Add(this.copyrightLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TrainingButton);
            this.Controls.Add(this.AgainstComputerButton);
            this.Controls.Add(this.AgainstHumanButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.Text = "Шашковий тренажер";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.LinkLabel copyrightLabel2;

        private System.Windows.Forms.LinkLabel copyrightLabel1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button AgainstHumanButton;
        private System.Windows.Forms.Button AgainstComputerButton;
        private System.Windows.Forms.Button TrainingButton;
        private System.Windows.Forms.Label Label1;
        

        #endregion
    }
}