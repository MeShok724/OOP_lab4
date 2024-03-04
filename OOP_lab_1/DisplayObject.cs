using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected readonly int _X1;
        protected readonly int _Y1;
        protected int _rectX1;
        protected int _rectY1;
        protected int _rectX2;
        protected int _rectY2;
        protected readonly Color _fillColor;
        protected readonly Color _borderColor;
        protected readonly int _borderSize;
        public abstract void Draw(Graphics g);
        protected DisplayObject(int x1, int y1, Color fillColor, Color borderColor, int borderSize)
        {
            _X1 = x1;
            _Y1 = y1;
            _fillColor = fillColor;
            _borderColor = borderColor;
            _borderSize = borderSize;
        }
    }
}