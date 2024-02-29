using System.Drawing;

namespace OOP_lab_1
{
    public class Section : DisplayObject
    {
        private readonly MyPoint _posEnd = new MyPoint();
        private readonly int _width;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2 + _width))
            {
                using (var pen1 = new Pen(_fillColor, _width))
                {
                    g.DrawLine(pen, _pos.x, _pos.y, _posEnd.x, _posEnd.y);
                    g.DrawLine(pen1,_pos.x, _pos.y, _posEnd.x, _posEnd.y);
                }
            }
        }
        
        public Section(MyPoint pos, Color fillColor, Color borderColor, int borderSize, MyPoint posEnd, int width) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x;
            condRect.posStart.y = pos.y;
            condRect.posEnd.x = posEnd.x;
            condRect.posEnd.y = posEnd.y;
            _posEnd = posEnd;
            _width = width;
        }
    }
}