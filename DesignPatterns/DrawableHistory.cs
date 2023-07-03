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
        public void push(Drawable drawable)
        {
            history.Push(drawable);
        }

        public void pop()
        {
            history.Pop();
        }
    }
}
