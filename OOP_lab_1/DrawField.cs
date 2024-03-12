using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class DrawField : DisplayObject
    {
        private readonly int _X2;
        private readonly int _Y2;
        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(_fillColor))
            {
                using (var pen = new Pen(_borderColor, _borderSize))
                {
                    g.FillRectangle(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawRectangle(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        public DrawField(int X1, int Y1, Color fillColor, Color borderColor, int borderSize, int width, int heigth) : base(X1, Y1, fillColor, borderColor, borderSize)
        {
            _X2 = X1 + width;
            _Y2 = Y1 + heigth;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X2 + borderSize / 2;
            _rectY2 = _Y2 + borderSize / 2;
        }
    }
}