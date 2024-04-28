using System;
using System.Drawing;

namespace OOP_lab_4
{
    public abstract class DisplayObject
    {
        public double _createTime;
        protected int _speed;
        protected double _angle;
        protected int _boost;
        // protected double _boostCorner ;
        protected int _XStart, _YStart;   // точка создания 
        protected int _X, _Y;   // точка привзки
        protected int _outRectX1, _outRectY1;  // верхняя левая точка с учетом рамки
        protected int _outRectX2, _outRectY2;  // нижняя правая точка с учетом рамки
        protected int _inRectX1, _inRectY1;  // верхняя левая точка клиентской части
        protected int _inRectX2, _inRectY2;  // нижняя правая точка клиентской части
        protected readonly int[] _fillColor = new int[3];   // цвет заливки
        protected readonly int[] _borderColor = new int[3]; // цвет границы
        protected readonly int _borderSize; // толщина границы
        public abstract void Draw(Graphics g);
        protected DisplayObject(int x, int y, int[] fillColor, int[] borderColor, int borderSize, int speed, double angle, int boost)
        {
            _createTime = DateTime.Now.Hour*3600 + DateTime.Now.Minute*60 + DateTime.Now.Second + DateTime.Now.Millisecond*0.001;
            _X = x;
            _Y = y;
            _XStart = x;
            _YStart = y;
            Array.Copy(fillColor, _fillColor, 3);
            Array.Copy(borderColor, _borderColor, 3);
            _borderSize = borderSize;
            _speed = speed;
            _angle = angle;
            _boost = boost;
        }

        public virtual void Update(int x, int y)
        {
            int diffX = x - _X;
            int diffY = y - _Y;
            _X = x;
            _Y = y;
            _outRectX1 += diffX;
            _outRectY1 += diffY;
            _outRectX2 += diffX;
            _outRectY2 += diffY;
            _inRectX1 += diffX;
            _inRectY1 += diffY;
            _inRectX2 += diffX;
            _inRectY2 += diffY;
        }

        public void Move()
        {
            double currTime = DateTime.Now.Hour*3600 + DateTime.Now.Minute*60 + DateTime.Now.Second + DateTime.Now.Millisecond*0.001;
            double diffTime = currTime - _createTime;
            double speedX = _speed * Math.Cos(_angle);
            double speedY = _speed * Math.Sin(_angle);
            double boostX = _boost * Math.Cos(_angle);
            double boostY = _boost * Math.Sin(_angle);
            double currX = _XStart + speedX * diffTime + (boostX * Math.Pow(diffTime, 2)) / 2;
            double currY = _YStart + speedY * diffTime + (boostY * Math.Pow(diffTime, 2)) / 2;
            Update((int)Math.Round(currX), (int)Math.Round(currY));
        }

        public bool BehindTheField(int minX, int minY, int maxX, int maxY)
        {
            return _X < minX || _X > maxX || _Y < minY || _Y > maxY;
        }
        
        public int GetX => _X;
        public int GetY => _Y;

        public void SetStartPos(int x, int y)
        {
            _XStart = x;
            _YStart = y;
        }

        public bool IntersectsWith(DisplayObject obj)
        {
            bool intersectX = (_outRectX1 < obj._outRectX2) && (_outRectX2 > obj._outRectX1) || (obj._outRectX1 < _outRectX2) && (obj._outRectX2 > _outRectX1);
            bool intersectY = (_outRectY1 < obj._outRectY2) && (_outRectY2 > obj._outRectY1) || (obj._outRectY1 < _outRectY2) && (obj._outRectY2 > _outRectY1);
            return intersectX && intersectY;
        }

        public void CheckAndFixIntersects(int minX, int minY, int maxX, int maxY)
        {
            int angle = RadToGrad(_angle);
            if (_outRectX1 < minX)
            {
                if (angle <= 180){
                    angle -= (angle - 90) * 2;
                    _angle = GradToRad(angle);
                }
                else
                {
                    angle += (270 - angle) * 2;
                    _angle = GradToRad(angle);
                }
                Update(_X + (minX - _outRectX1), _Y);
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectX2 > maxX)
            {
                if (angle < 270)
                {
                    angle += (90 - angle) * 2;
                    _angle = GradToRad(angle);
                }
                else
                {
                    angle -= (angle - 270) * 2;
                    _angle = GradToRad(angle);
                }
                Update(_X - (_outRectX2 - maxX), _Y);
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectY1 < minY)
            {
                if (angle <= 270)
                {
                    angle -= (angle - 180) * 2;
                    _angle = GradToRad(angle);
                }
                else
                {
                    angle += ((360 - angle) * 2) % 360;
                    _angle = GradToRad(angle);
                }
                Update(_X, _Y + (minY - _outRectY1));
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectY2 > maxY)
            {
                if (angle > 90)
                {
                    angle += (180 - angle) * 2;
                    _angle = GradToRad(angle);
                }
                else
                {
                    angle = 360 - (angle);
                    _angle = GradToRad(angle);
                }
                Update(_X, _Y - (_outRectY2 - maxY));
                angle = RadToGrad(_angle);
                UpdateTime();
            }
        }

        public void CheckCollizion(DisplayObject[] arrObj)
        {
            
        }
        public void FixCollizion(DisplayObject Obj)
        {
            // float Vn1 = dx2*s + dy2*e;
            // float Vn2 = dx1*s + dy1*e;
            // float dt = (DIAMETER-d)/(Vn1-Vn2);
            // if (dt > 0.6)
            //     dt = 0.6;
            // if (dt < -0.6)
            //     dt = -0.6;
            // x1-=dx1*dt;
            // y1-=dy1*dt;
            // x2-=dx2*dt;
            // y2-=dy2*dt;
            // Dx = x1 - x2;
            // Dy = y1 - y2;
            // d = sqrt(Dx*Dx+Dy*Dy);
            // if (d == 0)
            //     d = 0.01;
            // s = Dx/d; // sin
            // e = Dy/d; // cos
            // Vn1 = dx2*s + dy2*e;
            // Vn2 = dx1*s + dy1*e;
            // float Vt1 = -dx2*e+dy2*s;
            // float Vt2 = -dx1*e+dy1*s;
            //
            // float o = Vn2;
            // Vn2 = Vn1;
            // Vn1 = o;
            //
            // dx1 = Vn2*s-Vt2*e;
            // dy1 = Vn2*e+Vt2*s;
            // dx2 = Vn1*s-Vt1*e;
            // dy2 = Vn1*e+Vt1*s;
            // x1+=dx1*dt;
            // y1+=dy1*dt;
            // x2+=dx2*dt;
            // y2+=dy2*dt;
            //
            // ball->set_pos(x1 - 20, y1 - 20);
            // ball->set_speed(dx1, dy1);
            // temp->set_pos(x2 - 20, y2 - 20);
            // temp->set_speed(dx2, dy2);
        }

        private int RadToGrad(double rad)
        {
            return (int)Math.Round(rad * (180.0 / Math.PI));
        }
        private double GradToRad(int grad)
        {
            return grad * (Math.PI / 180.0);
        }
        private void UpdateTime()
        {
            _createTime = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second + DateTime.Now.Millisecond * 0.001;
            SetStartPos(GetX, GetY);
        }
    }
}