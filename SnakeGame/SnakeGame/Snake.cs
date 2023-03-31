using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Snake
    {
        // Constant 
        private const int MOVEMENT_DISTANCE = 9;
        private const int LEN_INCREASE = 3;
        private const int INTITAL_SPEED_INCREASE = 100;
        private const int SECONDARY_SPEED_INCREASE = 10;
        private const int SPEED_LIMIT = 50;
        private const int DEFAULT_LENGTH = 5;
        private const int DEFAULT_LOC_X = 306;
        private const int DEFAULT_LOC_Y = 90; 
        private const int DEFAULT_SIZE = 6;
        private const int WALL_COLLISION_OFFSET = 5;
        private const Directions INITIAL_DIRECTION = Directions.Down;

        //Property
        private int speed;
        private int locX;
        private int locY;
        private bool isAlive;
        private Directions direction;
        private bool riding_wall;
        private bool isSelfCollision;
        private Directions collision_direction;
        private bool hit_wall;
        private GraphicsPath item;
        private Pen border;
        private Color borderColor;
        private SolidBrush brush;
        private Rectangle pathRect;

        private LinkedList<GraphicsPath> snakeBod;
        private GraphicsPath tempTail;

        public Snake()
        {
            speed = INTITAL_SPEED_INCREASE;
            locX = DEFAULT_LOC_X;
            locY = DEFAULT_LOC_Y;
            isAlive = false;
            direction = Directions.Down;
            riding_wall = false;
            isSelfCollision = false;
            hit_wall = false;
            direction = INITIAL_DIRECTION;

            borderColor = Color.Blue;
            brush = new SolidBrush(borderColor);
            border = new Pen(borderColor);

            snakeBod = new LinkedList<GraphicsPath>();
            tempTail = new GraphicsPath();

            int tempY = locY;
            for (int i = 0; i < DEFAULT_LENGTH; i++)
            {
                if (i != 0)
                    tempY -= MOVEMENT_DISTANCE;

                pathRect = new Rectangle(locX, tempY, DEFAULT_SIZE, DEFAULT_SIZE);
                snakeBod.AddLast(new GraphicsPath());
                snakeBod.ElementAt(i).AddRectangle(pathRect);
            }
        }

        public bool getIsSelfCollision()
        {
            return isSelfCollision;
        }


        public int getLocX()
        {
            return locX;
        }

        public int getLocY()
        {
            return locY;
        }

        public Directions getDirection()
        {
            return direction;
        }

        public int getSize()
        {
            return DEFAULT_SIZE;
        }

        public int getSnakeMovementDistance()
        {
            return MOVEMENT_DISTANCE;
        }

        public bool getHitWall()
        {
            return hit_wall;
        }

        public Directions getInitialDirection()
        {
            return INITIAL_DIRECTION;
        }

        public int getDefaultLocX()
        {
            return DEFAULT_LOC_X;
        }

        public int getDefaultLocY()
        {
            return DEFAULT_LOC_Y; 
        }

        public void setDirection(Directions direction)
        {
            this.direction = direction;
        }

        public void increaseSpeed(Timer moveSnakeTimer)
        {
            if (moveSnakeTimer.Interval - INTITAL_SPEED_INCREASE > 0 &&
                    moveSnakeTimer.Interval > INTITAL_SPEED_INCREASE)
                moveSnakeTimer.Interval -= INTITAL_SPEED_INCREASE;

            //Increase speed at smaller incrmenets after a certain value
            else
                if (moveSnakeTimer.Interval - SECONDARY_SPEED_INCREASE > 0 &&
                        moveSnakeTimer.Interval > SPEED_LIMIT)
                    moveSnakeTimer.Interval -= SECONDARY_SPEED_INCREASE;
        }

        public void show(PaintEventArgs e)
        {
            isCollidedSelf(e);

            if (isSelfCollision)
                snakeBod.AddLast(tempTail);

            for (int i = 0; i < snakeBod.Count; i++)
            {
                e.Graphics.DrawPath(border, snakeBod.ElementAt(i));
                e.Graphics.FillPath(brush, snakeBod.ElementAt(i));
            }
        }
        
        public void move(Directions inputDirection, int yMin, int xMax, int yMax)
        {
            if (inputDirection.Equals(Directions.Down))
            {
                //Check if near wall
                if (locY + MOVEMENT_DISTANCE >= (yMax - DEFAULT_SIZE - WALL_COLLISION_OFFSET))
                {
                    locY = yMax - DEFAULT_SIZE - WALL_COLLISION_OFFSET;

                    //Check if there was previous contact with this wall, if so... collision!
                    if (riding_wall && collision_direction.Equals(Directions.Down))
                    {
                        hit_wall = true;
                        isAlive = false;

                        //Add a duplicate of final node if hitting wall
                        snakeBod.AddLast(tempTail);
                    }
                    //Flag first contact with wall and note direction
                    riding_wall = true;
                    collision_direction = Directions.Down;
                }
                else
                {
                    locY += MOVEMENT_DISTANCE;
                    
                    //Reset riding wall if now moving in opposite direction
                    if(riding_wall && collision_direction.Equals(Directions.Up))
                        riding_wall = false;
                }
            }
            else if (inputDirection.Equals(Directions.Up))
            {
                //Check if near wall
                if (locY - MOVEMENT_DISTANCE <= yMin)
                {
                    locY = yMin;

                    //Check if there was previous contact with this wall, if so... collision!
                    if (riding_wall && collision_direction.Equals(Directions.Up))
                    { 
                        hit_wall = true;
                        isAlive = false;

                        //Add a duplicate of final node if hitting wall
                        snakeBod.AddLast(tempTail);
                    }
                    //Flag first contact with wall and note direction
                    riding_wall = true;
                    collision_direction = Directions.Up;
                }
                else
                {
                    locY -= MOVEMENT_DISTANCE;

                    //Reset riding wall if now moving in opposite direction
                    if (riding_wall && collision_direction.Equals(Directions.Down))
                        riding_wall = false;
                }
            }
            else if (inputDirection.Equals(Directions.Right))
            {
                //Check if near wall
                if (locX + MOVEMENT_DISTANCE >= xMax - DEFAULT_SIZE - WALL_COLLISION_OFFSET)
                {
                    locX = xMax - DEFAULT_SIZE - WALL_COLLISION_OFFSET;

                    //Check if there was previous contact with this wall, if so... collision!
                    if (riding_wall && collision_direction.Equals(Directions.Right))
                    {
                        hit_wall = true;
                        isAlive = false;

                        //Add a duplicate of final node if hitting wall
                        snakeBod.AddLast(tempTail);
                    }
                    //Flag first contact with wall and note direction
                    riding_wall = true;
                    collision_direction = Directions.Right;
                }
                else
                {
                    locX += MOVEMENT_DISTANCE;
                    
                    //Reset riding wall if now moving in opposite direction
                    if (riding_wall && collision_direction.Equals(Directions.Left))
                        riding_wall = false;
                }
            }
            else if (inputDirection.Equals(Directions.Left))
            {
                //Check if near wall
                if (locX - MOVEMENT_DISTANCE <= 0)
                {
                    locX = 0;

                    //Check if there was previous contact with this wall, if so... collision!
                    if (riding_wall && collision_direction.Equals(Directions.Left))
                    {
                        hit_wall = true;
                        isAlive = false;

                        //Add a duplicate of final node if hitting wall
                        snakeBod.AddLast(tempTail);
                    }
                    //Flag first contact with wall and note direction
                    riding_wall = true;
                    collision_direction = Directions.Left;
                }
                else
                {
                    locX -= MOVEMENT_DISTANCE;
                    
                    //Reset riding wall if now moving in opposite direction
                    if (riding_wall && collision_direction.Equals(Directions.Right))
                        riding_wall = false;
                }
            }
            direction = inputDirection;

            //Create a copy of tail node
            tempTail = new GraphicsPath();
            PointF[] point = new PointF[snakeBod.Count];
            point = snakeBod.ElementAt(snakeBod.Count - 1).PathPoints;
            float pointX = point.ElementAt(0).X;
            float pointY = point.ElementAt(0).Y;
            pathRect = new Rectangle((int)pointX, (int)pointY, DEFAULT_SIZE, DEFAULT_SIZE);
            tempTail.AddRectangle(pathRect);

            //Update snake body
            snakeBod.RemoveLast();
            pathRect = new Rectangle(locX, locY, DEFAULT_SIZE, DEFAULT_SIZE);
            snakeBod.AddFirst(new GraphicsPath());
            snakeBod.ElementAt(0).AddRectangle(pathRect);
        }

        //---------------------------------------------------------------------
        // Adds to the snake body.
        //---------------------------------------------------------------------
        public void increaseLength()
        {
            //Get points of last snake node
            PointF[] point = new PointF[snakeBod.Count];
            point = snakeBod.ElementAt(snakeBod.Count - 1).PathPoints;
            float pointX = point.ElementAt(0).X;
            float pointY = point.ElementAt(0).Y;

            //Create new snake nodes at end of snake body
            int tempIdx = snakeBod.Count;
            for (int i = 0; i < LEN_INCREASE; i++)
            {
                pathRect = new Rectangle((int)pointX, (int)pointY, DEFAULT_SIZE, DEFAULT_SIZE);
                snakeBod.AddLast(new GraphicsPath());
                snakeBod.ElementAt(tempIdx++).AddRectangle(pathRect);
            }
        }

        //---------------------------------------------------------------------
        // Checks if the snake head has collided with any part of the body.
        //---------------------------------------------------------------------
        public void isCollidedSelf(PaintEventArgs e)
        {      
            //Get points of head of snake
            PointF[] point = new PointF[snakeBod.Count];
            point = snakeBod.ElementAt(0).PathPoints;
            float pointX = point.ElementAt(0).X;
            float pointY = point.ElementAt(0).Y;

            //Check for collsion between head and snake body
            for (int i = 3; i < snakeBod.Count; i++)
            {
                if (snakeBod.ElementAt(i).IsVisible(pointX, pointY, e.Graphics))
                    isSelfCollision = true;
            }
        }
    }
}
