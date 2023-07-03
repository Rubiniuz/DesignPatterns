using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DrawableHistory
    {
        Stack<Drawable> history = new Stack<Drawable>();
        Stack<Drawable> redoArray = new Stack<Drawable>();

        public DrawableHistory() { }

        public Stack<Drawable> get()
        {
            return this.history;
        }

        public void push(Drawable drawable)
        {
            history.Push(drawable);
        }

        public void undo()
        {
            if (history.Count == 0)
            {
                return;
            }

            Drawable last = history.Last();
            history.Pop();
            redoArray.Push(last);
        }

        public void redo()
        {
            if (redoArray.Count == 0)
            {

            }
        }
    }
}
