using System.Drawing;

namespace WindowsFormsApp1
{
    public class Circle : DisplayObject
    {
        private readonly int _radius;
        override public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(_borderColor, _borderSize), condRect.posStart.x, condRect.posStart.y, condRect.posEnd.x, condRect.posEnd.y);
            g.FillEllipse(new SolidBrush(_fillColor), condRect.posStart.x, condRect.posStart.y, condRect.posEnd.x, condRect.posEnd.y);
        }
        
        override public void ChangePosition(int x, int y)
        {
            _pos.x = x;
            _pos.y = y;
            condRect.posStart.x = _pos.x - _radius;
            condRect.posStart.y = _pos.y - _radius;
            condRect.posEnd.x = _pos.x + _radius;
            condRect.posEnd.y = _pos.y + _radius;
        }
        
        public Circle(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int radius) : base(pos, fillColor, borderColor, borderSize)
        {
            _radius = radius;
            condRect.posStart.x = pos.x - radius;
            condRect.posStart.y = pos.y - radius;
            condRect.posEnd.x = pos.x + radius;
            condRect.posEnd.y = pos.y + radius;
        }
    }
}