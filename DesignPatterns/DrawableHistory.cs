using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Drawable last = history.First();
            Trace.WriteLine(last);
            last.setVisible(false);
            redoArray.Push(last);
        }

        public void redo()
        {
            if (redoArray.Count == 0 || history.Count == 0)
            {
                return;
            }

            Drawable redoAction = redoArray.First();
            Drawable lastAction = history.First();

            if (redoAction == lastAction) {
                history.Pop();
                redoArray.Pop();

                redoAction.setVisible(true);
                history.Push(redoAction);
            } else
            {
                Trace.WriteLine("Not the same objects...");
            }
        }
    }
}
