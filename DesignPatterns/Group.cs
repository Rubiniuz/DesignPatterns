using System.Collections.Generic;

namespace DesignPatterns
{
    public class Group<T>
    {
        private List<Group<T>> Children = new List<Group<T>>();

        public List<Group<T>> GroupObject(Group<T> group)
        {
            Children.Add(group);
            return Children;
        }
        
        public List<Group<T>> GroupObjects(List<Group<T>> groups)
        {
            Children.AddRange(groups);
            return Children;
        }

        public List<Group<T>> GetChildren()
        {
            return Children;
        }
        
        public List<Group<T>> RemoveObject(Group<T> group)
        {
            Children.Remove(group);
            return Children;
        }
        
        public List<Group<T>> RemoveObjects(List<Group<T>> groups)
        {
            Children.RemoveAll(groups.Contains);
            return Children;
        }
    }
}