using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DesignPatterns
{
    public interface Command
    {
        bool ShouldExecute
        {
            get;
            set;
        }
        void Execute();
        void Undo();
    } // Command Pattern
    
    public class DrawCommand : Command
    {
        Drawable drawable;
        List<Graphics> graphics;
        public DrawCommand(Drawable drawable, List<Graphics> graphics)
        {
            ShouldExecute = true;
            this.drawable = drawable;
            this.graphics = graphics;
        }
        public bool ShouldExecute
        {
            get;
            set;
        }
        public void Execute()
        {
            if (!ShouldExecute) return;
            foreach (var g in graphics)
            {
                drawable.draw(g);
            }
        }
        public void Undo()
        {
            ShouldExecute = !ShouldExecute; // switch the state
        }
        
        public Drawable getDrawable()
        {
            return drawable;
        }
    }
    
    public class SelectCommand : Command
    {
        List<Drawable> drawables;
        public Point startPos { get; set; }
        public Point endPos { get; set; }
        public bool ShouldExecute { get; set; }
        public SelectCommand(Point startPos, Point endPos)
        {
            ShouldExecute = true;
            this.startPos = startPos;
            this.endPos = endPos;
        }
        public void Execute()
        {
            if (!ShouldExecute) return;
        }
        public void Undo()
        {
            ShouldExecute = !ShouldExecute; // switch the state
        }
        
        public void SetSelected(List<Drawable> drawables)
        {
            //Console.WriteLine("Drawables to check in region: " + drawables.Count + " Start: " + startPos + " End: " + endPos);
            List<Drawable> tmp = new List<Drawable>();
            foreach (Drawable d in drawables)
            {
                if (!d.isVisible())
                {
                    // exit early if not visible
                    Console.WriteLine("Not visible");
                    continue;
                }
                //Console.WriteLine("Visible");
                // check if in bounds
                Point TL = d.getStartPos();
                Point BR = d.getEndPos();
                Point TR = new Point(BR.X, TL.Y);
                Point BL = new Point(TL.X, BR.Y);
                //Console.WriteLine("Drawable corners: TL: " + TL + " BR: " + BR + " TR: " + TR + " BL: " + BL);
                if (CommandHelper.isInBounds(startPos, endPos, TL) ||
                    CommandHelper.isInBounds(startPos, endPos, BR) ||
                    CommandHelper.isInBounds(startPos, endPos, TR) ||
                    CommandHelper.isInBounds(startPos, endPos, BL))
                {
                    tmp.Add(d); 
                }
            }
            //Console.WriteLine("Drawables in Region: " + tmp.Count);
            this.drawables = tmp;
        }
        
        public List<Drawable> GetSelected()
        {
            //Console.WriteLine("Selected Drawables: " + drawables.Count);
            return drawables;
        }
    }

    public class MoveCommand : Command
    {
        List<Drawable> drawables;
        private Point change;
        public bool ShouldExecute { get; set; }
        public MoveCommand(Point startPos, Point EndPos)
        {
            ShouldExecute = true;
            change = new Point(EndPos.X - startPos.X, EndPos.Y - startPos.Y);
        }
        public void Execute()
        {
            if (!ShouldExecute) return;
            foreach (var drawable in drawables)
            {
                if (drawable.isVisible())
                {
                    Point start = drawable.getStartPos();
                    Point end = drawable.getEndPos();
            
                    Point newStart = new Point(start.X + change.X, start.Y + change.Y);
                    Point newEnd = new Point(end.X + change.X, end.Y + change.Y);

                    drawable.setStartPos(newStart);
                    drawable.setEndPos(newEnd);
                }
            }
        }
        public void Undo()
        {
            ShouldExecute = !ShouldExecute; // switch the state
            foreach (var drawable in drawables)
            {
                if (drawable.isVisible())
                {
                    Point start = drawable.getStartPos();
                    Point end = drawable.getEndPos();
            
                    Point newStart = new Point(start.X - change.X, start.Y - change.Y);
                    Point newEnd = new Point(end.X - change.X, end.Y - change.Y);

                    drawable.setStartPos(newStart);
                    drawable.setEndPos(newEnd);
                }
            }
        }
        
        public void SetDrawables(List<Drawable> drawables)
        {
            this.drawables = drawables;
        }
    }
    
    public class ResizeCommand : Command
    {
        List<Drawable> drawables;
        private Point change;
        public bool ShouldExecute { get; set; }
        public ResizeCommand(Point startPos, Point EndPos)
        {
            ShouldExecute = true;
            change = new Point(EndPos.X - startPos.X, EndPos.Y - startPos.Y);
        }
        public void Execute()
        {
            if (!ShouldExecute) return;
            
            foreach (var drawable in drawables)
            {
                if (drawable.isVisible())
                {
                    Point start = drawable.getStartPos();
                    Point end = drawable.getEndPos();
            
                    Point newStart = new Point(start.X - change.X, start.Y - change.Y);
                    Point newEnd = new Point(end.X + change.X, end.Y + change.Y);

                    drawable.setStartPos(newStart);
                    drawable.setEndPos(newEnd);
                }
            }
        }
        public void Undo()
        {
            ShouldExecute = !ShouldExecute; // switch the state
            
            foreach (var drawable in drawables)
            {
                if (drawable.isVisible())
                {
                    Point start = drawable.getStartPos();
                    Point end = drawable.getEndPos();
            
                    Point newStart = new Point(start.X + change.X, start.Y + change.Y);
                    Point newEnd = new Point(end.X - change.X, end.Y - change.Y);

                    drawable.setStartPos(newStart);
                    drawable.setEndPos(newEnd);
                }
            }
        }
        
        public void SetDrawables(List<Drawable> drawables)
        {
            this.drawables = drawables;
        }
    }

    public class CommandHelper
    {
        public static (Point, Point) GetNormalBounds(Point startPos, Point endPos)
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
            
            return (MinVal,Maxval);
        }
        
        public static bool isInBounds(Point startPos, Point endPos, Point p)
        {
            if (p.X > startPos.X && p.X < endPos.X && p.Y > startPos.Y && p.Y < endPos.Y)
            {
                return true; // Within Bounds
            }
            else
            {
                return false; // Not in Bounds
            }
        }
    }
}