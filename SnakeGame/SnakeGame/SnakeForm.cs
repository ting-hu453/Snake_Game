using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SnakeGame
{
    public partial class SnakeForm : Form
    {
        //Flags for phases of game
        bool inSplashScreen;
        bool inGame;
        bool inGameEnd;
        bool inScoreBoard;
        bool keyPressAllowed;

        //Game objects
        Snake snakeObj;
        Food apple;
        Player player;
        Random rng;
        Scoreboard scores;

        //Constants for game components
        int INITIAL_SCORE = 0;
        int INITIAL_SPEED_INTERVAL = 450;
        int RNG_SEED = 95;

        //Constants for creating green lines
        int NUM_LINES_SPLASH = 2;
        int NUM_LINES_GAME = 1;
        int INITIAL_LINE_Y_LOC = 50;
        int LINE_Y_INCREMENT = 80;

        //Tools for painting green lines
        private int lineLocX1, lineLocX2;
        private Pen lineSketch;
        private Color sketchColor;
        private int lineWeight;
        private List<GraphicsPath> listOfLines;

        //---------------------------------------------------------------------
        // Default constructor
        //---------------------------------------------------------------------
        public SnakeForm()
        {
            InitializeComponent();

            //Set phase flags
            inSplashScreen = true;
            inGame = false;
            inGameEnd = false;
            inScoreBoard = false;
            keyPressAllowed = true;

            //Create game objects
            snakeObj = new Snake();
            apple = new Food();
            rng = new Random(RNG_SEED);
            scores = new Scoreboard();
            player = new Player();


            //Setup tools for painting green lines
            lineLocX1 = 0;
            lineLocX2 = SnakeFormPanel.Width;
            lineWeight = 1;
            sketchColor = Color.Green;
            lineSketch = new Pen(sketchColor, lineWeight);
            listOfLines = new List<GraphicsPath>();

            //Start with the splash screen
            startSplashScreen();
        }

        //---------------------------------------------------------------------
        // Returns the snake object.
        //---------------------------------------------------------------------
        public Snake getSnake()
        {
            return snakeObj;
        }

        //---------------------------------------------------------------------
        // Returns the minimum Y value for the snake game panel.
        //---------------------------------------------------------------------
        public int getGamePanelYMin()
        {
            return scoreLabel.Height;
        }

        //---------------------------------------------------------------------
        // Returns the minimum X value for the snake game panel.
        //---------------------------------------------------------------------
        public int getGamePanelXMax()
        {
            return SnakeFormPanel.Width;
        }

        //---------------------------------------------------------------------
        // Returns the maximum Y value for the snake game panel.
        //---------------------------------------------------------------------
        public int getGamePanelYMax()
        {
            return SnakeFormPanel.Height;
        }


        //---------------------------------------------------------------------
        // Sets the inGame phase flag.
        //---------------------------------------------------------------------
        public void setInGame(bool gameStatus)
        {
            inGame = gameStatus;
        }

        //---------------------------------------------------------------------
        // Sets up and displays the splash screen at startup.
        //---------------------------------------------------------------------
        public void startSplashScreen()
        {
            splashScreenText.Visible = true;
            splashScreenPrompt.Visible = true;

            //Setup green lines
            int lineLocY = INITIAL_LINE_Y_LOC;
            for (int i = 0; i < NUM_LINES_SPLASH; i++)
            {
                lineLocY += LINE_Y_INCREMENT;

                listOfLines.Add(new GraphicsPath());
                listOfLines[i].AddLine(lineLocX1, lineLocY, lineLocX2, lineLocY);
            }
        }

        //---------------------------------------------------------------------
        // Sets up the game for play, hides the splash screen, and makes the
        // necessary components visible.
        // Used at initial startup and for restarting the game.
        //---------------------------------------------------------------------
        public void startGamePlay()
        {
            //Set phase flags to reflect playing game
            inSplashScreen = false;
            inGame = true;
            keyPressAllowed = true;
            inGameEnd = false;
            inScoreBoard = false;

            //Create game objects
            snakeObj = new Snake();
            apple = new Food();
            rng = new Random(RNG_SEED);

            setupGameplayDisplay();

            //Setup and start the movement and food timers
            moveSnakeTimer.Interval = INITIAL_SPEED_INTERVAL;
            moveSnakeTimer.Start();
            foodGenerationTimer.Start();
        }

        //---------------------------------------------------------------------
        // Ensures correct UI components are visible at the start of gameplay.
        //---------------------------------------------------------------------
        public void setupGameplayDisplay()
        {
            //Reset UI components
            scoreboardPanel.Visible = false;
            HighScoreLabel.Visible = false;
            SnakeFormPanel.Visible = true;
            SnakeFormPanel.BackColor = Color.Black;
            youDiedLabel.Visible = false;
            spaceToContinueLabel.Visible = false;
            score.Text = INITIAL_SCORE.ToString();

            //Clear splash screen
            splashScreenText.Visible = false;
            splashScreenPrompt.Visible = false;
            listOfLines.Clear();

            //Setup green lines 
            score.Visible = true;
            scoreLabel.Visible = true;
            int lineLocY = scoreLabel.Height - lineWeight;
            for (int i = 0; i < NUM_LINES_GAME; i++)
            {
                listOfLines.Add(new GraphicsPath());
                listOfLines[0].AddLine(lineLocX1, lineLocY, lineLocX2, lineLocY);
            }

            SnakeFormPanel.Refresh();
        }

        //---------------------------------------------------------------------
        // Every 5 seconds, update location and show food object when
        // applicable.
        //---------------------------------------------------------------------
        private void foodGenerationTimer_Tick(object sender, EventArgs e)
        {
            //Show Apple at a random location if not already visible
            if (!apple.getIsVisible())
            {
                generateRanFoodCoordinates();
                apple.show();
            }
        }

        //---------------------------------------------------------------------
        // Creates random x,y coordinate values for a Food object and updates
        // the location properties for that object.
        // Gathers the size of the Food object to guarantee it is within
        // the range of the display panel.
        //---------------------------------------------------------------------
        public void generateRanFoodCoordinates()
        {
            //Add offset to guarantee proper random range
            int foodSize = apple.getSize() + 1;
            int snakeMovement = snakeObj.getSnakeMovementDistance();

            //Range: 0 -> (SnakeFormPanel - foodsize) - 1
            int tempX = rng.Next(SnakeFormPanel.Width - foodSize);
            int tempY = rng.Next(scoreLabel.Height, SnakeFormPanel.Height - foodSize);

            //Guarantee apple coordinates is multiple of the snake movement
            while (tempX % snakeMovement != 0)
            {
                tempX = rng.Next(SnakeFormPanel.Width - foodSize);
            }
            while(tempY % snakeMovement != 0)
            {
                tempY = rng.Next(scoreLabel.Height, SnakeFormPanel.Height - foodSize);
            }

            apple.setLocX(tempX);
            apple.setLocY(tempY);
        }

        //---------------------------------------------------------------------
        // Handles key presses from the game.
        //---------------------------------------------------------------------
        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool madeSelection = false;

            //Determine if in splash screen and any key has been pressed to start game
            if (inSplashScreen)
            {
                startGamePlay();
                madeSelection = true;
            }

            //Guarantee direction of snake is not set from button press in splash screen
            if (!madeSelection && keyPressAllowed)
                determineDirection(e.KeyCode);

            //Start scoreboard procedure if user selects space after dieing
            if (inGameEnd && e.KeyCode == Keys.Space)
                scoreboardStartup();

            //Determine action when user presses key while viewing scoreboard
            if (inScoreBoard && e.KeyCode == Keys.R)
                startGamePlay();
            if (inScoreBoard && e.KeyCode == Keys.Escape)
                Close();
        }

        //---------------------------------------------------------------------
        // Decides the direction of the Snake based off the passed keyCode.
        //---------------------------------------------------------------------
        public void determineDirection(Keys keyCode)
        {
            //Determine direction to move snake
            if (inGame && keyCode == Keys.A && snakeObj.getDirection() != Directions.Right)
                snakeObj.setDirection(Directions.Left);
            else if (inGame && keyCode == Keys.W && snakeObj.getDirection() != Directions.Down)
                snakeObj.setDirection(Directions.Up);
            else if (inGame && keyCode == Keys.S && snakeObj.getDirection() != Directions.Up)
                snakeObj.setDirection(Directions.Down);
            else if (inGame && keyCode == Keys.D && snakeObj.getDirection() != Directions.Left)
                snakeObj.setDirection(Directions.Right);
            keyPressAllowed = false;
        }

        //---------------------------------------------------------------------
        // Handles the timing of the snake movement.
        //---------------------------------------------------------------------
        public void moveSnakeTimer_Tick(object sender, EventArgs e)
        {
            moveSnake(snakeObj.getDirection());
            SnakeFormPanel.Refresh();
            keyPressAllowed = true;
        }

        //---------------------------------------------------------------------
        // Returns true if the snake has collided with the Food object.
        //---------------------------------------------------------------------
        public void moveSnake(Directions direction)
        {
            //Move the snake in specified direction and pass Bounds for movement
            snakeObj.move(direction, scoreLabel.Height, SnakeFormPanel.Width, SnakeFormPanel.Height);

            //Check for collision between snake and apple
            if (isFoodCollision())
            {
                //Grow the snake and speed it up
                snakeObj.increaseLength();
                snakeObj.increaseSpeed(moveSnakeTimer);

                //Reset the food timer and hide the food
                foodGenerationTimer.Stop();
                foodGenerationTimer.Start();
                apple.hide();

                //Update the score
                score.Text = (Int32.Parse(score.Text) + apple.getScoreIncrement()).ToString();
            }

            //Check for collision between wall or snake
            if (snakeObj.getHitWall() || snakeObj.getIsSelfCollision())
            {
                apple.hide();
                deadEnd();
            }
        }

        //---------------------------------------------------------------------
        // Returns true if the snake has collided with the Food object.
        //---------------------------------------------------------------------
        public bool isFoodCollision()
        {
            bool isCollided = false;

            //Get the location of snake and apple
            int snakeLocX = snakeObj.getLocX();
            int snakeLocY = snakeObj.getLocY();
            int snakeSize = snakeObj.getSize();
            int appleLocX = apple.getLocX();
            int appleLocY = apple.getLocY();
            int appleSize = apple.getSize();

            //Check if snake and apple have collided
            if (apple.getIsVisible() && ((appleLocX <= (snakeLocX + snakeSize) && appleLocX >= snakeLocX
                && appleLocY <= (snakeLocY + snakeSize) && appleLocY >= snakeLocY) ||
                (appleLocX + appleSize) <= (snakeLocX + snakeSize) && (appleLocX + appleSize) >= snakeLocX
                && (appleLocY + appleSize) <= (snakeLocY + snakeSize) && (appleLocY + appleSize) >= snakeLocY))
            { 
                isCollided = true;
            }

            return isCollided;
        }

        //---------------------------------------------------------------------
        // Handles ending the game.
        //---------------------------------------------------------------------
        public void deadEnd()
        {
            //Disable timers and display end-game lingo
            foodGenerationTimer.Stop();
            moveSnakeTimer.Stop();
            SnakeFormPanel.BackColor = Color.Red;
            youDiedLabel.Visible = true;
            spaceToContinueLabel.Visible = true;

            //Set end of game phase flag
            inGameEnd = true;
        }

        //---------------------------------------------------------------------
        // Make sure the scoreboard to show up.
        //---------------------------------------------------------------------
        public void scoreboardStartup()/*******************/
        {
            //Setup and show scoreboard
            scoreboardPanel.Visible = true;
            scoreboardPanel.BackColor = Color.Black;
            highScoreTitleLabel.Visible = false;
            restartLabel.Visible = false;
            highScoreListLabel.Visible = false;
            highScoreListLabel.ResetText();
            highScoreListLabel.Visible = false;
            highScoreListLabel.ResetText();

            //Determine if high score
            if (scores.checkIfHighScore(Int32.Parse(score.Text)))
            {
                HighScoreLabel.Visible = true;
                HighScorePrompt.Visible = true;
                playerNameTextBox.Visible = true;
                playerNameTextBox.Enabled = true;
                playerNameTextBox.Select();
            }
            else
                listHighScores();

            //Set scoreboard phase flags
            inScoreBoard = true;
            inGameEnd = false;
            inGame = false;
        }

        //---------------------------------------------------------------------
        // Accept the user input while entering the user name in the scoreboard.
        //---------------------------------------------------------------------
        private void playerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                player.setName(playerNameTextBox.Text);
                player.setScore(Int32.Parse(score.Text));
                scores.updateHighScores(player);
                listHighScores();
            }
        }

        //---------------------------------------------------------------------
        // Display the top 10 high scores with the user name. 
        //---------------------------------------------------------------------
        private void listHighScores()
        {
            scoreboardPanel.Visible = true;
            HighScoreLabel.Visible = false;
            HighScorePrompt.Visible = false;
            playerNameTextBox.Visible = false;
            playerNameTextBox.Enabled = false;

            highScoreTitleLabel.Visible = true;
            restartLabel.Visible = true;
            highScoreNameListLabel.Visible = true;
            highScoreListLabel.Visible = true;

            for (int i = 0; i < scores.getHighScores().Count; i++)
            {
                highScoreNameListLabel.Text += (scores.getHighScores()[i].getName() + "\n");
                highScoreListLabel.Text += (scores.getHighScores()[i].getScore() + "\n");
            }
        }

        //---------------------------------------------------------------------
        // Handles the paint event and calls the show method for all the
        // objects that should be displayed.
        //---------------------------------------------------------------------
        private void SnakeFormPanel_Paint(object sender, PaintEventArgs e)
        {
            //Draw any required lines
            for (int i = 0; i < listOfLines.Count(); i++)
                e.Graphics.DrawPath(lineSketch, listOfLines[i]);

            //Show snake during gameplay only
            if (inGame)
            {
                snakeObj.show(e);
                if (snakeObj.getIsSelfCollision())
                {
                    apple.hide();
                    deadEnd();
                }
            }

            //Show apple if visible
            if (apple.getIsVisible())
                apple.show(e);
        }
    }
}
