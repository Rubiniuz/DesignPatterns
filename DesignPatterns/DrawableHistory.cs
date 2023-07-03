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
        Stack<Drawable> redo = new Stack<Drawable>();

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
            Drawable last = history.Last();
            history.Pop();
            redo.Push(last);
        }
    }
}
