﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public abstract class Drawable // Strategy Pattern
    {
        protected Point startPos;
        protected Point endPos;
        protected Pen pen;
        protected bool visible = true;

        public Drawable() { }

        public abstract void draw(Graphics graph);
        public abstract bool isInBounds(Point p);
        public abstract void accept(Visitor visitor);

        public bool isVisible()
        {
            return visible;
        }

        public void setVisible(bool visible)
        {
            this.visible = visible;
        }

        public Point getStartPos()
        {
            return startPos;
        }
        
        public Point getEndPos()
        {
            return endPos;
        }
        
        public void setStartPos(Point startPos)
        {
            this.startPos = startPos;
        }
        
        public void setEndPos(Point endPos)
        {
            this.endPos = endPos;
        }
    }

    public class RectangleDrawable : Drawable
    {

        public RectangleDrawable(Point _startPos, Point _endPos, Pen _pen)
        {
            this.startPos = _startPos;
            this.endPos = _endPos;
            this.pen = _pen;
        }
        public override void draw(Graphics graph)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;

            Rectangle rect = new Rectangle(startPos.X, startPos.Y, width * Math.Sign(width), height * Math.Sign(height));
            graph.DrawRectangle(pen, rect);
        }
        
        public override bool isInBounds(Point p)
        {
            Point MinVal = new Point();
            Point Maxval = new Point();

            if (startPos.X < endPos.X)
            {
                MinVal.X = startPos.X;
                Maxval.X = endPos.X;
            }
            else
            {
                MinVal.X = endPos.X;
                Maxval.X = startPos.X;
            }
            
            if (startPos.Y < endPos.Y)
            {
                MinVal.Y = startPos.Y;
                Maxval.Y = endPos.Y;
            }
            else
            {
                MinVal.Y = endPos.Y;
                Maxval.Y = startPos.Y;
            }

            if (p.X > MinVal.X && p.X < Maxval.X && p.Y > MinVal.Y && p.Y < Maxval.Y)
            {
                return true; // Within Bounds
            }
            else
            {
                return false; // Not in Bounds
            }
        }
        
        public override void accept(Visitor visitor)
        {
            visitor.VisitRectangle(this);
        }
    }

    public class EllipseDrawable : Drawable
    {

        public EllipseDrawable(Point _startPos, Point _endPos, Pen _pen)
        {
            this.startPos = _startPos;
            this.endPos = _endPos;
            this.pen = _pen;
        }

        public override void draw(Graphics graph)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;

            Rectangle rect = new Rectangle(startPos.X, startPos.Y, width * Math.Sign(width), height * Math.Sign(height));
            graph.DrawEllipse(pen, rect);
        }
        
        public override bool isInBounds(Point p)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;
            
            
            double res = ((double)Math.Pow((p.X - startPos.X), 2)
                    / (double)Math.Pow(width, 2))
                   + ((double)Math.Pow((p.Y - startPos.Y), 2)
                      / (double)Math.Pow(height, 2));
                      
            return res <= 1 ? true : false;
        }
        
        public override void accept(Visitor visitor)
        {
            visitor.VisitEllipse(this);
        }
    }
}
