using System.Drawing;

namespace OOP_lab_1
{
    public class Section : DisplayObject
    {
        private readonly Point _posEnd = new Point();
        private readonly int _width;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2 + _width))
            {
                using (var pen1 = new Pen(_fillColor, _width))
                {
                    g.DrawLine(pen, _pos, _posEnd);
                    g.DrawLine(pen1,_pos, _posEnd);
                }
            }
        }
        
        public Section(Point pos, Color fillColor, Color borderColor, int borderSize, Point posEnd, int width) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X;
            condRect.posStart.y = pos.Y;
            condRect.posEnd.x = posEnd.X;
            condRect.posEnd.y = posEnd.Y;
            _posEnd = posEnd;
            _width = width;
        }
    }
}