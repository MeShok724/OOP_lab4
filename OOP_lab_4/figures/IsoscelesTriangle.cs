using System.Drawing;

namespace OOP_lab_4
{
    public class IsoscelesTriangle : DisplayObject
    {
        protected int _X1, _Y1;
        protected int _X2, _Y2;
        protected int _X3, _Y3;
        override public void Draw(Graphics g)
        {
            Color fillColor = Color.FromArgb(_fillColor[0], _fillColor[1], _fillColor[2]);
            Color borderColor = Color.FromArgb(_borderColor[0], _borderColor[1], _borderColor[2]);
            using (var pen = new Pen(borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(fillColor))
                {
                    g.FillPolygon(brush,new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                    g.DrawPolygon(pen, new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                }
            }
        }
        
        public IsoscelesTriangle(int X, int Y,int x1, int y1,  int speed, double angle, int boost, int[] fillColor, int[] borderColor, int borderSize, int width, int height) : base(X, Y,fillColor, borderColor, borderSize, speed, angle, boost)
        {
            _X1 = x1;
            _Y1 = y1;
            _outRectX1 = _X1 - width / 2 - borderSize / 2;
            _outRectY1 = _Y1 - borderSize / 2;
            _outRectX2 = _X1 + width / 2 + borderSize / 2;
            _outRectY2 = _Y1 + height + borderSize / 2;
            _inRectX1 =  _outRectX1 + borderSize;
            _inRectY1 = _outRectY1 + borderSize;
            _inRectX2 = _outRectX2 - borderSize;
            _inRectY2 = _outRectY2 - borderSize;
            _X2 = _X1 - width / 2;
            _X3 = _X1 + width / 2;
            _Y2 = _Y1 + height;
            _Y3 = _Y2;
        }
        public override void Update(int x, int y)
        {
            int diffX = x - _X;
            int diffY = y - _Y;
            _X = x;
            _Y = y;

            _X1 += diffX;
            _Y1 += diffY;
            _X2 += diffX;
            _Y2 += diffY;
            _X3 += diffX;
            _Y3 += diffY;
            _outRectX1 += diffX;
            _outRectY1 += diffY;
            _outRectX2 += diffX;
            _outRectY2 += diffY;
            _inRectX1 += diffX;
            _inRectY1 += diffY;
            _inRectX2 += diffX;
            _inRectY2 += diffY;
        }
    }
}