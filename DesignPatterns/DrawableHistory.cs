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
        List<Drawable> redoArray = new List<Drawable>();

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

            Drawable last = this.getNextCommand(history, true);
            if (last == null) return;

            Trace.WriteLine(last);
            last.setVisible(false);
            redoArray.Add(last);
        }

        public void redo()
        {
            Drawable redoAction = redoArray.Last();
            Drawable lastAction = this.getNextCommand(history, false);
            if (redoAction == null || lastAction == null) return;

            if (redoAction == lastAction) {
                history.Pop();
                redoArray.RemoveAt(redoArray.Count - 1);

                redoAction.setVisible(true);
                history.Push(redoAction);
            } else
            {
                Trace.WriteLine("Not the same objects...");
            }
        }

        private Drawable getNextCommand(Stack<Drawable> array, bool isVisible)
        {
            foreach(Drawable drawable in array)
            {
                if (drawable != null && (drawable.isVisible() == isVisible))
                {
                    return drawable;
                }
            }

            return null;
        }
    }
}
