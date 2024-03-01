using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected readonly Point _pos = new Point();
        protected readonly Color _fillColor;
        protected readonly Color _borderColor;
        protected readonly int _borderSize;
        public readonly ConditionalRectangle condRect = new ConditionalRectangle();
        public abstract void Draw(Graphics g);
        protected DisplayObject(Point pos, Color fillColor, Color borderColor, int borderSize)
        {
            _pos.X = pos.X;
            _pos.Y = pos.Y;
            _fillColor = fillColor;
            _borderColor = borderColor;
            _borderSize = borderSize;
        }
    }
}