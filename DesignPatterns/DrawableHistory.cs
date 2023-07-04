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
        Stack<Command> history = new Stack<Command>();
        List<Command> redoArray = new List<Command>();

        public DrawableHistory() { }

        public Stack<Command> get()
        {
            return this.history;
        }

        public void push(Command command)
        {
            history.Push(command);
        }

        public void undo()
        {

            Command last = this.getNextCommand(history, true);
            if (last == null) return;

            Console.WriteLine(last);
            last.Undo();
            redoArray.Add(last);
        }

        public void redo()
        {
            Command redoAction = redoArray.Last();
            Command lastAction = this.getNextCommand(history, false);
            if (redoAction == null || lastAction == null) return;

            if (redoAction == lastAction) {
                history.Pop();
                redoArray.RemoveAt(redoArray.Count - 1);

                redoAction.ShouldExecute = true;
                history.Push(redoAction);
            } else
            {
                Console.WriteLine("Not the same objects...");
            }
        }

        private Command getNextCommand(Stack<Command> array, bool ShouldExecute)
        {
            foreach(Command command in array)
            {
                if (command != null && (command.ShouldExecute == ShouldExecute))
                {
                    return command;
                }
            }

            return null;
        }
    }
}
