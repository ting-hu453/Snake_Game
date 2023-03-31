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
    class Food
    {
        //---------------------------------------------------------------------
        // Constants
        //---------------------------------------------------------------------
        private const int DEFAULT_SIZE = 6;
        private const int SCORE_INC = 5;

        //---------------------------------------------------------------------
        // Variables
        //---------------------------------------------------------------------
        private int locX;
        private int locY;
        private GraphicsPath item;
        private Pen border;
        private Color borderColor;
        private SolidBrush brush;
        private Rectangle pathRect;
        private bool isVisible;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public Food()
        {
            locX = 20;
            locY = 80;
            borderColor = Color.Red;
            brush = new SolidBrush(borderColor);
            border = new Pen(borderColor);
            item = new GraphicsPath();
            pathRect = new Rectangle(locX, locY, DEFAULT_SIZE, DEFAULT_SIZE);
            item.AddRectangle(pathRect);
            isVisible = false;
        }

        //---------------------------------------------------------------------
        // Returns x coordinate of upper left corner of food rectangle.
        //---------------------------------------------------------------------
        public int getLocX()
        {
            return locX;
        }

        //---------------------------------------------------------------------
        // Returns y coordinate of upper left corner of food rectangle.
        //---------------------------------------------------------------------
        public int getLocY()
        {
            return locY;
        }

        //---------------------------------------------------------------------
        // Returns constant score increment for eating Food objects.
        //---------------------------------------------------------------------
        public int getScoreIncrement()
        {
            return SCORE_INC;
        }

        //---------------------------------------------------------------------
        // Returns side length of box to make Food object.
        //---------------------------------------------------------------------
        public int getSize()
        {
            return DEFAULT_SIZE;
        }

        //---------------------------------------------------------------------
        // Returns bool that is dependent on if the Food object is drawn on the panel.
        //---------------------------------------------------------------------
        public bool getIsVisible()
        {
            return isVisible;
        }

        //---------------------------------------------------------------------
        // Sets x coordinate of upper left corner of food rectangle.
        //---------------------------------------------------------------------
        public void setLocX(int locX)
        {
            this.locX = locX;
        }

        //---------------------------------------------------------------------
        // Sets y coordinate of upper left corner of food rectangle.
        //---------------------------------------------------------------------
        public void setLocY(int locY)
        {
            this.locY = locY;
        }

        //---------------------------------------------------------------------
        // Sets Food object to visible.
        //---------------------------------------------------------------------
        public void show()
        {
            this.isVisible = true;
        }

        //---------------------------------------------------------------------
        // Paints Food object to the panel.
        //---------------------------------------------------------------------
        public void show(PaintEventArgs e)
        {
            item.Reset();
            pathRect = new Rectangle(locX, locY, DEFAULT_SIZE, DEFAULT_SIZE);
            item.AddRectangle(pathRect);
            e.Graphics.DrawPath(border, item);
            e.Graphics.FillPath(brush, item);
        }

        //---------------------------------------------------------------------
        // Removes Food object from panel.
        //---------------------------------------------------------------------
        public void hide()
        {
            item.Reset();
            isVisible = false;
        }
    }
}