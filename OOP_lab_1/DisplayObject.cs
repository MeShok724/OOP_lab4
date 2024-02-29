using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected readonly MyPoint _pos = new MyPoint();
        protected readonly Color _fillColor;
        protected readonly Color _borderColor;
        protected readonly int _borderSize;
        public readonly ConditionalRectangle condRect = new ConditionalRectangle();
        public abstract void Draw(Graphics g);
        protected DisplayObject(MyPoint pos, Color fillColor, Color borderColor, int borderSize)
        {
            _pos.x = pos.x;
            _pos.y = pos.y;
            _fillColor = fillColor;
            _borderColor = borderColor;
            _borderSize = borderSize;
        }
    }
}