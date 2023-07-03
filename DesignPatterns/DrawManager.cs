using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DrawManager {

        private static DrawManager _instance;
        private List<Drawable> commands = new List<Drawable>();

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
            Stack<Drawable> list = history.get();
            foreach (Drawable d in list)
            {
                if (d != null)
                {
                    commands.Add(d);
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
