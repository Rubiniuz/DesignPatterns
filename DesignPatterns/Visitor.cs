namespace DesignPatterns
{
    public interface Visitor // Visitor Pattern
    {
        void VisitRectangle(RectangleDrawable rect);
        void VisitEllipse(EllipseDrawable elip);
    }
}