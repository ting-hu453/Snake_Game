
namespace SnakeGame
{
    partial class SnakeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.SnakeFormPanel = new System.Windows.Forms.Panel();
            this.scoreboardPanel = new System.Windows.Forms.Panel();
            this.highScoreListLabel = new System.Windows.Forms.Label();
            this.highScoreNameListLabel = new System.Windows.Forms.Label();
            this.restartLabel = new System.Windows.Forms.Label();
            this.highScoreTitleLabel = new System.Windows.Forms.Label();
            this.HighScorePrompt = new System.Windows.Forms.Label();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.splashScreenPrompt = new System.Windows.Forms.Label();
            this.splashScreenText = new System.Windows.Forms.Label();
            this.spaceToContinueLabel = new System.Windows.Forms.Label();
            this.youDiedLabel = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.foodGenerationTimer = new System.Windows.Forms.Timer(this.components);
            this.moveSnakeTimer = new System.Windows.Forms.Timer(this.components);
            this.SnakeFormPanel.SuspendLayout();
            this.scoreboardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SnakeFormPanel
            // 
            this.SnakeFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnakeFormPanel.BackColor = System.Drawing.Color.Black;
            this.SnakeFormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnakeFormPanel.Controls.Add(this.scoreboardPanel);
            this.SnakeFormPanel.Controls.Add(this.splashScreenPrompt);
            this.SnakeFormPanel.Controls.Add(this.splashScreenText);
            this.SnakeFormPanel.Controls.Add(this.spaceToContinueLabel);
            this.SnakeFormPanel.Controls.Add(this.youDiedLabel);
            this.SnakeFormPanel.Controls.Add(this.score);
            this.SnakeFormPanel.Controls.Add(this.scoreLabel);
            this.SnakeFormPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SnakeFormPanel.Location = new System.Drawing.Point(0, 0);
            this.SnakeFormPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SnakeFormPanel.Name = "SnakeFormPanel";
            this.SnakeFormPanel.Size = new System.Drawing.Size(614, 370);
            this.SnakeFormPanel.TabIndex = 0;
            this.SnakeFormPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SnakeFormPanel_Paint);
            // 
            // scoreboardPanel
            // 
            this.scoreboardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreboardPanel.Controls.Add(this.highScoreListLabel);
            this.scoreboardPanel.Controls.Add(this.highScoreNameListLabel);
            this.scoreboardPanel.Controls.Add(this.restartLabel);
            this.scoreboardPanel.Controls.Add(this.highScoreTitleLabel);
            this.scoreboardPanel.Controls.Add(this.HighScorePrompt);
            this.scoreboardPanel.Controls.Add(this.HighScoreLabel);
            this.scoreboardPanel.Controls.Add(this.playerNameTextBox);
            this.scoreboardPanel.Location = new System.Drawing.Point(0, 0);
            this.scoreboardPanel.Name = "scoreboardPanel";
            this.scoreboardPanel.Size = new System.Drawing.Size(614, 370);
            this.scoreboardPanel.TabIndex = 11;
            this.scoreboardPanel.Visible = false;
            // 
            // highScoreListLabel
            // 
            this.highScoreListLabel.BackColor = System.Drawing.Color.Transparent;
            this.highScoreListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreListLabel.ForeColor = System.Drawing.Color.Blue;
            this.highScoreListLabel.Location = new System.Drawing.Point(349, 53);
            this.highScoreListLabel.Name = "highScoreListLabel";
            this.highScoreListLabel.Size = new System.Drawing.Size(75, 278);
            this.highScoreListLabel.TabIndex = 9;
            this.highScoreListLabel.Visible = false;
            // 
            // highScoreNameListLabel
            // 
            this.highScoreNameListLabel.BackColor = System.Drawing.Color.Transparent;
            this.highScoreNameListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreNameListLabel.ForeColor = System.Drawing.Color.Blue;
            this.highScoreNameListLabel.Location = new System.Drawing.Point(204, 53);
            this.highScoreNameListLabel.Name = "highScoreNameListLabel";
            this.highScoreNameListLabel.Size = new System.Drawing.Size(141, 278);
            this.highScoreNameListLabel.TabIndex = 8;
            this.highScoreNameListLabel.Visible = false;
            // 
            // restartLabel
            // 
            this.restartLabel.AutoSize = true;
            this.restartLabel.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartLabel.ForeColor = System.Drawing.Color.Red;
            this.restartLabel.Location = new System.Drawing.Point(219, 344);
            this.restartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.restartLabel.Name = "restartLabel";
            this.restartLabel.Size = new System.Drawing.Size(226, 26);
            this.restartLabel.TabIndex = 4;
            this.restartLabel.Text = "Press Esc to exit or R to restart";
            // 
            // highScoreTitleLabel
            // 
            this.highScoreTitleLabel.AutoSize = true;
            this.highScoreTitleLabel.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreTitleLabel.ForeColor = System.Drawing.Color.White;
            this.highScoreTitleLabel.Location = new System.Drawing.Point(260, 19);
            this.highScoreTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.highScoreTitleLabel.Name = "highScoreTitleLabel";
            this.highScoreTitleLabel.Size = new System.Drawing.Size(107, 26);
            this.highScoreTitleLabel.TabIndex = 3;
            this.highScoreTitleLabel.Text = "High Scores";
            this.highScoreTitleLabel.Visible = false;
            // 
            // HighScorePrompt
            // 
            this.HighScorePrompt.AutoSize = true;
            this.HighScorePrompt.BackColor = System.Drawing.Color.Transparent;
            this.HighScorePrompt.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScorePrompt.ForeColor = System.Drawing.Color.White;
            this.HighScorePrompt.Location = new System.Drawing.Point(4, 30);
            this.HighScorePrompt.Name = "HighScorePrompt";
            this.HighScorePrompt.Size = new System.Drawing.Size(213, 26);
            this.HighScorePrompt.TabIndex = 2;
            this.HighScorePrompt.Text = "Please enter your name:";
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.AutoSize = true;
            this.HighScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.HighScoreLabel.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreLabel.ForeColor = System.Drawing.Color.White;
            this.HighScoreLabel.Location = new System.Drawing.Point(4, 4);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.Size = new System.Drawing.Size(192, 26);
            this.HighScoreLabel.TabIndex = 1;
            this.HighScoreLabel.Text = "You got a High Score!";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.BackColor = System.Drawing.Color.Black;
            this.playerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playerNameTextBox.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameTextBox.ForeColor = System.Drawing.Color.White;
            this.playerNameTextBox.Location = new System.Drawing.Point(227, 30);
            this.playerNameTextBox.MaxLength = 7;
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(142, 26);
            this.playerNameTextBox.TabIndex = 0;
            this.playerNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playerName_KeyDown);
            // 
            // splashScreenPrompt
            // 
            this.splashScreenPrompt.AutoSize = true;
            this.splashScreenPrompt.BackColor = System.Drawing.Color.Transparent;
            this.splashScreenPrompt.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashScreenPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splashScreenPrompt.Location = new System.Drawing.Point(206, 333);
            this.splashScreenPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.splashScreenPrompt.Name = "splashScreenPrompt";
            this.splashScreenPrompt.Size = new System.Drawing.Size(211, 26);
            this.splashScreenPrompt.TabIndex = 10;
            this.splashScreenPrompt.Text = "Press any key to start...";
            this.splashScreenPrompt.Visible = false;
            // 
            // splashScreenText
            // 
            this.splashScreenText.AutoSize = true;
            this.splashScreenText.BackColor = System.Drawing.Color.Transparent;
            this.splashScreenText.Font = new System.Drawing.Font("Viner Hand ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashScreenText.ForeColor = System.Drawing.Color.White;
            this.splashScreenText.Location = new System.Drawing.Point(239, 158);
            this.splashScreenText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.splashScreenText.Name = "splashScreenText";
            this.splashScreenText.Size = new System.Drawing.Size(143, 39);
            this.splashScreenText.TabIndex = 9;
            this.splashScreenText.Text = "Snake 1.0!";
            this.splashScreenText.Visible = false;
            // 
            // spaceToContinueLabel
            // 
            this.spaceToContinueLabel.AutoSize = true;
            this.spaceToContinueLabel.BackColor = System.Drawing.Color.Transparent;
            this.spaceToContinueLabel.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceToContinueLabel.ForeColor = System.Drawing.Color.White;
            this.spaceToContinueLabel.Location = new System.Drawing.Point(206, 333);
            this.spaceToContinueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.spaceToContinueLabel.Name = "spaceToContinueLabel";
            this.spaceToContinueLabel.Size = new System.Drawing.Size(219, 26);
            this.spaceToContinueLabel.TabIndex = 5;
            this.spaceToContinueLabel.Text = "Press space to continue...";
            this.spaceToContinueLabel.Visible = false;
            // 
            // youDiedLabel
            // 
            this.youDiedLabel.AutoSize = true;
            this.youDiedLabel.BackColor = System.Drawing.Color.Transparent;
            this.youDiedLabel.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youDiedLabel.ForeColor = System.Drawing.Color.White;
            this.youDiedLabel.Location = new System.Drawing.Point(260, 158);
            this.youDiedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.youDiedLabel.Name = "youDiedLabel";
            this.youDiedLabel.Size = new System.Drawing.Size(94, 26);
            this.youDiedLabel.TabIndex = 4;
            this.youDiedLabel.Text = "You Died!";
            this.youDiedLabel.Visible = false;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.White;
            this.score.Location = new System.Drawing.Point(75, 4);
            this.score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(20, 26);
            this.score.TabIndex = 3;
            this.score.Text = "0";
            this.score.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Viner Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(1, 0);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(70, 27);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score :";
            this.scoreLabel.Visible = false;
            // 
            // foodGenerationTimer
            // 
            this.foodGenerationTimer.Interval = 5000;
            this.foodGenerationTimer.Tick += new System.EventHandler(this.foodGenerationTimer_Tick);
            // 
            // moveSnakeTimer
            // 
            this.moveSnakeTimer.Interval = 400;
            this.moveSnakeTimer.Tick += new System.EventHandler(this.moveSnakeTimer_Tick);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 370);
            this.Controls.Add(this.SnakeFormPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SnakeForm";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeForm_KeyDown);
            this.SnakeFormPanel.ResumeLayout(false);
            this.SnakeFormPanel.PerformLayout();
            this.scoreboardPanel.ResumeLayout(false);
            this.scoreboardPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SnakeFormPanel;
        private System.Windows.Forms.Timer foodGenerationTimer;
        private System.Windows.Forms.Timer moveSnakeTimer;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label youDiedLabel;
        private System.Windows.Forms.Label spaceToContinueLabel;
        private System.Windows.Forms.Label splashScreenText;
        private System.Windows.Forms.Label splashScreenPrompt;
        private System.Windows.Forms.Panel scoreboardPanel;
        private System.Windows.Forms.Label HighScorePrompt;
        private System.Windows.Forms.Label HighScoreLabel;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Label highScoreTitleLabel;
        private System.Windows.Forms.Label restartLabel;
        private System.Windows.Forms.Label highScoreNameListLabel;
        private System.Windows.Forms.Label highScoreListLabel;
    }
}

