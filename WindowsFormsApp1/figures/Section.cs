using System.Drawing;

namespace WindowsFormsApp1
{
    public class Section : DisplayObject
    {
        private readonly MyPoint _posEnd;
        override public void Draw(Graphics g)
        {
            
        }
        
        override public void ChangePosition(int x, int y)
        {
            int diffX = _pos.x - x, diffY = _pos.y - y;
            _pos.x = x;
            _pos.y = y;
            condRect.posStart.x = _pos.x;
            condRect.posStart.y = _pos.y;
            condRect.posEnd.x = _pos.x - diffX;
            condRect.posEnd.y = _pos.y - diffY;
        }
        
        public Section(MyPoint pos, Color fillColor, Color borderColor, int borderSize, MyPoint posEnd) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x;
            condRect.posStart.y = pos.y;
            condRect.posEnd.x = posEnd.x;
            condRect.posEnd.y = posEnd.y;
            _posEnd = posEnd;
        }
    }
}