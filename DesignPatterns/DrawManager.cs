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
    public class DrawManager { // Singleton Pattern

        private static DrawManager _instance;
        //private List<Drawable> commands = new List<Drawable>();
        private List<Command> commands = new List<Command>();
        List<Drawable> selection = new List<Drawable>();
        SelectCommand currentSelect;
        List<Drawable> currentDrawables = new List<Drawable>();

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
            Stack<Command> list = history.get(); // Use select move and scale to alter data.
            foreach (Command d in list)
            {
                if (d != null && d.ShouldExecute)
                {
                    switch (d)
                    {
                        case DrawCommand draw:
                            if(!currentDrawables.Contains(draw.getDrawable()))
                                currentDrawables.Add(draw.getDrawable());
                            break;
                        case SelectCommand select:
                            selection = new List<Drawable>(); // clear old selection after adding the drawables back to available drawables
                            select.SetSelected(currentDrawables); // is execute in this case. uses current available drawables
                            selection.AddRange(select.GetSelected()); // set selection for other commands
                            currentSelect = select;
                            Console.WriteLine("Selection: " + selection.Count);
                            break;
                        case MoveCommand move:
                            move.SetDrawables(selection);
                            move.Execute();
                            selection.Clear();
                            Console.WriteLine("Moved: " + selection.Count);
                            break;
                        case ResizeCommand resize:
                            resize.SetDrawables(selection);
                            resize.Execute();
                            selection.Clear();
                            Console.WriteLine("Resized: " + selection.Count);
                            break;
                    }
                }
                commands.Add(d);
            }

            graph.Clear(Color.White);
            g.Clear(Color.White);

            foreach(Command c in commands)
            {
                if(c.GetType() == typeof(DrawCommand))
                {
                    c.Execute();
                }
            }
        }

    }
}
