using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Checkers
{
    partial class GamingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamingForm));
            this._turnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _turnLabel
            // 
            this._turnLabel.AutoSize = true;
            this._turnLabel.BackColor = Color.DarkGoldenrod;
            this._turnLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            this._turnLabel.ForeColor = Color.Aqua;
            this._turnLabel.Location = new System.Drawing.Point(500, 60);
            this._turnLabel.Name = "_turnLabel";
            this._turnLabel.Size = new System.Drawing.Size(120, 16);
            this._turnLabel.TabIndex = 0;
            this._turnLabel.Text = "Зараз ходять: ";
            this._turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 479);
            this.Controls.Add(this._turnLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GamingForm";
            this.Text = "Шашковий тренажер";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label _turnLabel;

        #endregion
    }
}