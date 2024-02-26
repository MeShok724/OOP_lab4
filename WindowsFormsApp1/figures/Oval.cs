using System.Drawing;

namespace WindowsFormsApp1
{
    public class Oval : DisplayObject
    {
        private readonly int _radiusX;
        private readonly int _radiusY;
        override public void Draw(Graphics g)
        {
            
        }
        
        override public void ChangePosition(int x, int y)
        {
            _pos.x = x;
            _pos.y = y;
            condRect.posStart.x = _pos.x - _radiusX;
            condRect.posStart.y = _pos.y - _radiusY;
            condRect.posEnd.x = _pos.x + _radiusX;
            condRect.posEnd.y = _pos.y + _radiusY;
        }
        
        public Oval(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int rx, int ry) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x - rx;
            condRect.posStart.y = pos.y - ry;
            condRect.posEnd.x = pos.x + rx;
            condRect.posEnd.y = pos.y + ry;
            _radiusX = rx;
            _radiusY = ry;
        }
    }
}