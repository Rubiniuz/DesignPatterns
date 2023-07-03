namespace DesignPatterns
{
    public class MoveVisitor : Visitor
    {
        public void VisitRectangle(RectangleDrawable rect)
        {
            //TODO Move Rectangle
        }
        public void VisitEllipse(EllipseDrawable elip)
        {
            //TODO Move Ellipse
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