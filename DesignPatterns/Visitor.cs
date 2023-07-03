namespace DesignPatterns
{
    public interface Visitor
    {
        void VisitRectangle(RectangleDrawable rect);
        void VisitEllipse(EllipseDrawable elip);
        void VisitSelection(SelectionDrawable sel);
        void VisitMove(MoveDrawable move);
        void VisitScale(ScaleDrawable size);
    }
}