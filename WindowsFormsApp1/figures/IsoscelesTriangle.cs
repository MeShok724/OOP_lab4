using System.Drawing;

namespace WindowsFormsApp1
{
    public class IsoscelesTriangle : DisplayObject
    {
        private readonly int _width;
        private readonly int _height;
        override public void Draw(Graphics g)
        {
            
        }
        
        override public void ChangePosition(int x, int y)
        {
            _pos.x = x;
            _pos.y = y;
            condRect.posStart.x = _pos.x;
            condRect.posStart.y = _pos.y;
            condRect.posEnd.x = _pos.x + _width;
            condRect.posEnd.y = _pos.y + _height;
        }
        
        public IsoscelesTriangle(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int width, int height) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x;
            condRect.posStart.y = pos.y;
            condRect.posEnd.x = pos.x + width;
            condRect.posEnd.y = pos.y + height;
            _width = width;
            _height = height;
        }
    }
}