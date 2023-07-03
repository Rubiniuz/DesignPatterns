namespace DesignPatterns
{
    public interface Visitor
    {
        void VisitRectangle(RectangleDrawable rect);
        void VisitEllipse(EllipseDrawable elip);
    }
}