using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public abstract class Drawable
    {
        protected Point startPos;
        protected Point endPos;
        protected Pen pen;

        public abstract void draw(Graphics graph);
    }

    public class LineDrawable : Drawable
    {
        public override void draw(Graphics graph)
        {
            graph.DrawLine(pen, startPos, endPos);
        }
    }

    public class RectangleDrawable : Drawable
    {
        public override void draw(Graphics graph)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;

            Rectangle rect = new Rectangle(startPos.X, startPos.Y, width * Math.Sign(width), height * Math.Sign(height));
            graph.DrawEllipse(pen, rect);
        }
    }

    public class EllipseDrawable : Drawable
    {
        public override void draw(Graphics graph)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;

            Rectangle rect = new Rectangle(startPos.X, startPos.Y, width * Math.Sign(width), height * Math.Sign(height));
            graph.DrawEllipse(pen, rect);
        }
    }
}
