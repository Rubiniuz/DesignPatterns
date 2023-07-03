namespace DesignPatterns
{
    public class SizeVisitor : Visitor
    {
        public void VisitRectangle(RectangleDrawable rect)
        {
            //TODO Resize Rectangle
        }
        public void VisitEllipse(EllipseDrawable elip)
        {
            //TODO Resize Ellipse
        }
        public void VisitSelection(SelectionDrawable sel)
        {
            //No Implementation
        }
        public void VisitMove(MoveDrawable move)
        {
            //No Implementation
        }
        public void VisitScale(ScaleDrawable size)
        {
            //No Implementation
        }
    }
}