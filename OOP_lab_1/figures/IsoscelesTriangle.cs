using System.Drawing;

namespace OOP_lab_1
{
    public class IsoscelesTriangle : DisplayObject
    {
        private readonly int _X2;
        private readonly int _Y2;
        private readonly int _X3;
        private readonly int _Y3;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillPolygon(brush,new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                    g.DrawPolygon(pen, new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                }
            }
        }
        
        public IsoscelesTriangle(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int width, int height) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _rectX1 = _X1 - width / 2 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X1 + width / 2 + borderSize / 2;
            _rectY2 = _Y1 + height + borderSize / 2;
            _X2 = _X1 - width / 2;
            _X3 = _X1 + width / 2;
            _Y2 = _Y1 + height;
            _Y3 = _Y2;
        }
    }
}