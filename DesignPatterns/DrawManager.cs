using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public class DrawManager {

        private static DrawManager _instance;
        private List<Drawable> commands = new List<Drawable>();
        private List<Drawable> selection = new List<Drawable>();

        private DrawManager() { }

        public static DrawManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DrawManager();
            }
            return _instance;
        }

        public void renderSurface(DrawableHistory history, Graphics graph, Graphics g)
        {
            commands.Clear();

            Stack<Drawable> list = history.get(); // Use select move and scale to alter data.
            foreach (Drawable d in list)
            {
                if (d != null && d.isVisible())
                {
                    //commands.Add(d);
                    // if one command is selection.
                    if (d.GetType() == typeof(SelectionDrawable))
                    {
                        selection.Clear();
                        foreach (var d2 in list)
                        {
                            if (d2 != d)
                            {
                                (Point,Point) bounds = d2.GetNormalBounds();
                                Point topLeft = bounds.Item1;
                                Point bottomRight = bounds.Item2;
                                Point topRight = new Point(bounds.Item2.X, bounds.Item1.Y);
                                Point bottomLeft = new Point(bounds.Item1.X, bounds.Item2.Y);
                                if (d.isInBounds(topLeft) || d.isInBounds(bottomRight) || d.isInBounds(topRight) || d.isInBounds(bottomLeft))
                                {
                                    selection.Add(d2);
                                }
                            }
                        }
                        Trace.WriteLine("Selection: " + selection.Count);
                    }
                    else if (d.GetType() == typeof(MoveDrawable))
                    {
                        Point change = ((MoveDrawable)d).getChange();
                        foreach (var dm in selection)
                        {
                            Point sp = dm.getStartPos();
                            Point ep = dm.getEndPos();
                            sp.X += change.X;
                            sp.Y += change.Y;
                            ep.X += change.X;
                            ep.Y += change.Y;
                            dm.setStartPos(sp);
                            dm.setEndPos(ep);
                        }
                    }
                    else if (d.GetType() == typeof(ScaleDrawable))
                    {
                        Point change = ((ScaleDrawable)d).getChange();
                        foreach (var dm in selection)
                        {
                            Point sp = dm.getStartPos();
                            Point ep = dm.getEndPos();
                            sp.X -= change.X;
                            sp.Y -= change.Y;
                            ep.X += change.X;
                            ep.Y += change.Y;
                            dm.setStartPos(sp);
                            dm.setEndPos(ep);
                        }
                    }
                }
            }

            foreach (var d in list)
            {
                if (d != null && d.isVisible())
                {
                    Type type = d.GetType();
                    if (type == typeof(SelectionDrawable) || type == typeof(MoveDrawable) || type == typeof(ScaleDrawable))
                    {
                        // Do nothing.
                    }
                    else
                    {
                        commands.Add(d);
                    }
                }
            }

            graph.Clear(Color.White);
            g.Clear(Color.White);

            foreach(Drawable d in commands)
            {
                d.draw(graph);
                d.draw(g);
            }
        }

    }
}
