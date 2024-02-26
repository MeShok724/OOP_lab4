using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class DisplayObject
    {
        protected MyPoint _pos = new MyPoint();
        protected readonly Color _fillColor;
        protected readonly Color _borderColor;
        protected readonly int _borderSize;
        public ConditionalRectangle condRect = new ConditionalRectangle();
        public abstract void Draw(Graphics g);
        public abstract void ChangePosition(int x, int y);
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