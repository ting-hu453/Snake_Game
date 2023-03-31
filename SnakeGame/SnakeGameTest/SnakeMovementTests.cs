using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SnakeGame;
using System.Windows.Forms;

namespace SnakeGameTest
{
    [TestClass]
    public class SnakeMovementTests
    {
        private SnakeForm snakeForm = new SnakeForm();

        //------------------------------ Get/Set Tests Here ------------------------------------------//

        //---------------------------------------------------------------------
        // This test will verify that the snake getDirection method is
        // working correclty.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testGetSnakeDirectionValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            Directions expectedDirection = snakeObj.getInitialDirection();
            Directions actualDirection = snakeObj.getDirection();

            //Check result of method - P/F
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake setDirection method is
        // working correclty.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testSetSnakeDirectionValid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Left;

            //Setup
            Snake snakeObj = snakeForm.getSnake();
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake getLocX method is
        // working correclty.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testGetSnakeLocationXValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int expectedLocX = snakeObj.getDefaultLocX();
            int actualLocX = snakeObj.getLocX();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake getLocY method is
        // working correclty.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testGetSnakeLocationYValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int expectedLocY = snakeObj.getDefaultLocY();
            int actualLocY = snakeObj.getLocY();


            //Check result of method - P/F
            Assert.AreEqual(expectedLocY, actualLocY);
        }


        //----------------------------- Determine Direction Tests -- Valid --------------------------------//

        //---------------------------------------------------------------------
        // This test will verify that the snake will start travelling left
        // when the button "A" keyCode is passed to determineDirection method.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressAValid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Left;
            Keys LEFT_KEY_CODE = Keys.A;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(Directions.Down);

            //Call method under test
            snakeForm.determineDirection(LEFT_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake will start travelling up
        // when the W button keyCode is passed to determineDirection method.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressWValid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Up;
            Keys UP_KEY_CODE = Keys.W;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(Directions.Right);

            //Call method under test
            snakeForm.determineDirection(UP_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake will start travelling down
        // when the S button keyCode is passed to determineDirection method.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressSValid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Down;
            Keys DN_KEY_CODE = Keys.S;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(Directions.Right);

            //Call method under test
            snakeForm.determineDirection(DN_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake will start travelling right
        // when the D button keyCode is passed to determineDirection method.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressDValid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Right;
            Keys RIGHT_KEY_CODE = Keys.D;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(Directions.Down);

            //Call method under test
            snakeForm.determineDirection(RIGHT_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }


        // -------------------------Determine Direction Tests -- Invalid ---------------------------- //

        //---------------------------------------------------------------------
        // This test will verify that the snake cannot go Left while currently
        // travelling Right.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressAInvalid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Right;
            Keys LEFT_KEY_CODE = Keys.A;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Call method under test
            snakeForm.determineDirection(LEFT_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake cannot go Up while currently
        // travelling Down.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressWInvalid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Down;
            Keys UP_KEY_CODE = Keys.W;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Call method under test
            snakeForm.determineDirection(UP_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake cannot go Down while currently
        // travelling Up.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressSInvalid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Up;
            Keys DN_KEY_CODE = Keys.S;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Call method under test
            snakeForm.determineDirection(DN_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake cannot go Right while currently
        // travelling Left.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressDInvalid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Left;
            Keys RIGHT_KEY_CODE = Keys.D;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Call method under test
            snakeForm.determineDirection(RIGHT_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //---------------------------------------------------------------------
        // This test will verify that the space bar does not affect the
        // direction of the snake.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testDetermineDirectionKeyPressSpaceInvalid()
        {
            //Declare constants for unit test
            Directions EXPECTED_DIRECTION = Directions.Down;
            Keys SPACE_KEY_CODE = Keys.Space;

            //Setup
            bool inGame = true;
            Snake snakeObj = snakeForm.getSnake();
            snakeForm.setInGame(inGame);
            snakeObj.setDirection(EXPECTED_DIRECTION);

            //Call method under test
            snakeForm.determineDirection(SPACE_KEY_CODE);

            //Check result of method - P/F
            Directions actualDirection = snakeObj.getDirection();
            Assert.AreEqual(EXPECTED_DIRECTION, actualDirection);
        }

        //----------------------------- Timer Tests -- Valid --------------------------------//

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each timer
        // tick when the snake direction is Left.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testMoveSnakeTimer_TickLeftValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            snakeObj.setDirection(Directions.Left);
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();

            int expectedLocX = initLocX - movementDistance;
            int expectedLocY = initLocY;

            snakeForm.moveSnakeTimer_Tick(null, null);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each timer
        // tick when the snake direction is Up.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testMoveSnakeTimer_TickUpValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            snakeObj.setDirection(Directions.Up);
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();

            int expectedLocX = initLocX;
            int expectedLocY = initLocY - movementDistance;

            snakeForm.moveSnakeTimer_Tick(null, null);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }  
        
        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each timer
        // tick when the snake direction is Down.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testMoveSnakeTimer_TickDownValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            snakeObj.setDirection(Directions.Down);
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();

            int expectedLocX = initLocX;
            int expectedLocY = initLocY + movementDistance;

            snakeForm.moveSnakeTimer_Tick(null, null);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each timer
        // tick when the snake direction is Right.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testMoveSnakeTimer_TickRightValid()
        {
            //Setup
            Snake snakeObj = snakeForm.getSnake();
            snakeObj.setDirection(Directions.Right);
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();

            int expectedLocX = initLocX + movementDistance;
            int expectedLocY = initLocY;

            snakeForm.moveSnakeTimer_Tick(null, null);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }

        //----------------------------- Move Tests -- Valid --------------------------------//

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each call
        // to move when the snake direction is Left and the movement is
        // within the bounds of the game panel.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testSnakeMoveLeftValid()
        {
            Directions snakeDirection = Directions.Left;
            int yMin = snakeForm.getGamePanelYMin();
            int yMax = snakeForm.getGamePanelYMax();
            int xMax = snakeForm.getGamePanelXMax();

            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();
            int expectedLocX = initLocX - movementDistance;
            int expectedLocY = initLocY;

            snakeObj.move(snakeDirection, yMin, xMax, yMax);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }


        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each call
        // to move when the snake direction is Up and the movement is
        // within the bounds of the game panel.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testSnakeMoveUpValid()
        {
            Directions snakeDirection = Directions.Up;
            int yMin = snakeForm.getGamePanelYMin();
            int yMax = snakeForm.getGamePanelYMax();
            int xMax = snakeForm.getGamePanelXMax();

            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();
            int expectedLocX = initLocX;
            int expectedLocY = initLocY - movementDistance;

            snakeObj.move(snakeDirection, yMin, xMax, yMax);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each call
        // to move when the snake direction is Down and the movement is
        // within the bounds of the game panel.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testSnakeMoveDownValid()
        {
            Directions snakeDirection = Directions.Down;
            int yMin = snakeForm.getGamePanelYMin();
            int yMax = snakeForm.getGamePanelYMax();
            int xMax = snakeForm.getGamePanelXMax();

            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();
            int expectedLocX = initLocX;
            int expectedLocY = initLocY + movementDistance;

            snakeObj.move(snakeDirection, yMin, xMax, yMax);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }

        //---------------------------------------------------------------------
        // This test will verify that the snake moves correctly with each call
        // to move when the snake direction is Right and the movement is
        // within the bounds of the game panel.
        //---------------------------------------------------------------------
        [TestMethod]
        public void testSnakeMoveRightValid()
        {
            Directions snakeDirection = Directions.Right;
            int yMin = snakeForm.getGamePanelYMin();
            int yMax = snakeForm.getGamePanelYMax();
            int xMax = snakeForm.getGamePanelXMax();

            //Setup
            Snake snakeObj = snakeForm.getSnake();
            int initLocX = snakeObj.getLocX();
            int initLocY = snakeObj.getLocY();
            int movementDistance = snakeObj.getSnakeMovementDistance();
            int expectedLocX = initLocX + movementDistance;
            int expectedLocY = initLocY;

            snakeObj.move(snakeDirection, yMin, xMax, yMax);

            int actualLocX = snakeObj.getLocX();
            int actualLocY = snakeObj.getLocY();

            //Check result of method - P/F
            Assert.AreEqual(expectedLocX, actualLocX);
            Assert.AreEqual(expectedLocY, actualLocY);
        }
    }
}
