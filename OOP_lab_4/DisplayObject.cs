using System;
using System.Drawing;

namespace OOP_lab_4
{
    public abstract class DisplayObject
    {
        public object _lockObject = new object();
        public DateTime _createTime;
        protected int _speed;
        protected double _angle;
        protected int _boost;
        protected int _XStart, _YStart;   // точка создания 
        protected int _X, _Y;   // точка привзки
        protected int _XPrev, _Yprev;   // предыдущая позиция
        protected int _outRectX1, _outRectY1;  // верхняя левая точка с учетом рамки
        protected int _outRectX2, _outRectY2;  // нижняя правая точка с учетом рамки
        protected int _inRectX1, _inRectY1;  // верхняя левая точка клиентской части
        protected int _inRectX2, _inRectY2;  // нижняя правая точка клиентской части
        protected readonly int[] _fillColor = new int[3];   // цвет заливки
        protected readonly int[] _borderColor = new int[3]; // цвет границы
        protected readonly int _borderSize; // толщина границы
        public DateTime dt; // время до столкновения
        public abstract void Draw(Graphics g);
        protected DisplayObject(int x, int y, int[] fillColor, int[] borderColor, int borderSize, int speed, double angle, int boost)
        {
            _createTime = DateTime.Now;
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

        public virtual void MoveTo(int x, int y)
        {
            int diffX = x - _X;
            int diffY = y - _Y;
            if (diffX + diffY == 0)
            {
                _angle = _angle + 1;
            }
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

        public void Update()
        {
            DateTime currTime = DateTime.Now;
            double diffTimeSec = (currTime - _createTime).TotalMilliseconds/1000;
            double speedX = _speed * Math.Cos(_angle);
            double speedY = _speed * Math.Sin(_angle);
            double boostX = _boost * Math.Cos(_angle);
            double boostY = _boost * Math.Sin(_angle);
            double currX = _XStart + speedX * diffTimeSec + (boostX * Math.Pow(diffTimeSec, 2)) / 2;
            double currY = _YStart + speedY * diffTimeSec + (boostY * Math.Pow(diffTimeSec, 2)) / 2;
            MoveTo((int)Math.Round(currX), (int)Math.Round(currY));
        }
        
        public int GetX => _X;
        public int GetY => _Y;
        public int GetCurrSpeed()
        {
            return (int)Math.Round(_speed + (DateTime.Now - _createTime).TotalMilliseconds / 1000 * _boost);
        }

        public void SetStartPos(int x, int y)
        {
            _XStart = x;
            _YStart = y;
        }

        public void ProcCollBorders(int minX, int minY, int maxX, int maxY) // Обработка столкновений со стенами
        {
            int angle = RadToGrad(_angle);  // Угол в градусах
            if (_outRectX1 < minX)  // Пересечение левой границы
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
                MoveTo(_X + (minX - _outRectX1), _Y);   // Перемещение в игровую зону
                _speed = GetCurrSpeed();
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectX2 > maxX)  // Пересечение правой границы
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
                MoveTo(_X - (_outRectX2 - maxX), _Y);   // Перемещение в игровую зону
                _speed = GetCurrSpeed();
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectY1 < minY)  // Пересечение верхней границы
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
                MoveTo(_X, _Y + (minY - _outRectY1));   // Перемещение в игровую зону
                _speed = GetCurrSpeed();
                angle = RadToGrad(_angle);
                UpdateTime();
            }
            if (_outRectY2 > maxY)  // Пересечение нижней границы
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
                MoveTo(_X, _Y - (_outRectY2 - maxY));   // Перемещение в игровую зону
                _speed = GetCurrSpeed();
                angle = RadToGrad(_angle);
                UpdateTime();
            }
        }

        public void ProcCollObjects(DisplayObject[] arrObj) // Обработка столкновений с другими шарами
        {
            
            foreach (var currObj in arrObj)
            {
                CheckTime(this, currObj);
                if (!DeltaTime(this.dt, DateTime.Now, FormMain.FPS))
                {
                    continue;
                }
                if (currObj == this)
                    continue;
                if (!IntersectsWith(currObj))   // Проверка рамок на пересечение
                    continue;
                
                int r1 = (_outRectX2 - _outRectX1) / 2;
                int r2 = (currObj._outRectX2 - currObj._outRectX1) / 2;
                int dx = (_outRectX1 + _outRectX2)/2 - (currObj._outRectX1 + currObj._outRectX2)/2;
                int dy = (_outRectY1 + _outRectY2)/2 - (currObj._outRectY1 + currObj._outRectY2)/2;
                    
                double d = Math.Sqrt(dx * dx + dy * dy);    // Вычисление расстояния между объектами по теореме Пифагора
                if (d == 0) // Проверка на случай, если расстояние равно 0
                    d = 1;

                double dColMax = r1 + r2;
                double dDiff = dColMax - d;
                if (d > dColMax) // Если расстояние между шарами больше суммы их радиусов
                    continue;
                lock (currObj._lockObject)  // Блокировка второго шара для других потоков
                {
                    double s = dx / d;
                    double e = dy / d;
                    double Vn1 = (currObj.GetCurrSpeed() * Math.Cos(currObj._angle) * s + currObj.GetCurrSpeed() * Math.Sin(currObj._angle) * e);   // проекция скорости второго шара на вектор столкновения
                    double Vn2 = (this.GetCurrSpeed() * Math.Cos(this._angle) * s + this.GetCurrSpeed() * Math.Sin(this._angle) * e);   // проекция скорости первого шара на вектор столкновения
                    double Vt1 = (-1 * currObj.GetCurrSpeed() * Math.Cos(currObj._angle) * e + currObj.GetCurrSpeed() * Math.Sin(currObj._angle) * s);    // проекция скорости второго шара на касательную к вектору столкновения
                    double Vt2 = (-1 * this.GetCurrSpeed() * Math.Cos(this._angle) * e + this.GetCurrSpeed() * Math.Sin(this._angle) * s);    // проекция скорости первого шара на касательную к вектору столкновения
                    double newV1x = (Vn2 * r1 + 2 * r2 * Vn1 - r2 * Vn2) / (r1 + r2);   // компоненты скорости вдоль вектора столкновения
                    double newV2x = Vn2 - Vn1 + newV1x;
                    Vn2 = newV1x;   // обновление проекций скоростей после столкновения
                    Vn1 = newV2x;
                    
                    double dx1 = (Vn2 * s - Vt2 * e); // вычисление изменения позиции для каждого объекта после столкновения
                    double dy1 = (Vn2 * e + Vt2 * s);
                    double dx2 = (Vn1 * s - Vt1 * e);
                    double dy2 = (Vn1 * e + Vt1 * s);
                    
                    // вычисление углов направления после столкновения для каждого объекта
                    double alpha1 = (dx1 == 0) ? Math.PI / 2 : (dy1 == 0) ? 0 : Math.Atan((dy1 + 0.0001) / (dx1 + 0.0001));
                    double alpha2 = (dx2 == 0) ? Math.PI / 2 : (dy2 == 0) ? 0 : Math.Atan((dy2 + 0.0001) / (dx2 + 0.0001));
                    if (dx1 < 0) alpha1 -= Math.PI; // корректирование углов направления после столкновения в зависимости от направления движения
                    if (dx2 < 0) alpha2 -= Math.PI;
                    if (dx1 == 0 && dy1 > 0) alpha1 = -Math.PI / 2;
                    if (dx2 == 0 && dy2 > 0) alpha2 = -Math.PI / 2;
                    
                    //if ((int)(alpha1*100)%1000 ==157)
                    if ((int)dx1 == 0 && (int)dx2 == 0 && (int)dy1 == 0 && (int)dy2 == 0 || (int)Math.Sqrt(dx * dx + dy * dy) < 0.8 * (r1 + r2))
                    {
                        dx1 = 100;
                        dx2 = 100;
                        dy1 = 100;
                        dy2 = 100;
                        alpha1 = Math.PI / 2;
                        alpha2 = -Math.PI / 2;
                    }
                    
                    this.ChangeDir((int)Math.Sqrt(dx1 * dx1 + dy1 * dy1), alpha1);  // изменение направления
                    this.MoveFromCollizion((int)Math.Round(dDiff/2), currObj);

                    // o.R = false;
                    currObj.ChangeDir((int)Math.Sqrt(dx2 * dx2 + dy2 * dy2), alpha2); // изменение направления
                    currObj.MoveFromCollizion((int)Math.Round(dDiff/2), this);
                    // side = -1;
                    // o.side = -1;
                }
            }
        
        }

        private void MoveFromCollizion(int dToMove, DisplayObject obj)
        {
            int dx = _outRectX1 - obj._outRectX1;
            int dy = _outRectY1 - obj._outRectY1;
            double d = Math.Sqrt(dx * dx + dy * dy);
            double k = d / (dToMove + 1);
            double currX = GetX + dx / k;
            double currY = GetY + dy / k;
            MoveTo((int)Math.Round(currX), (int)Math.Round(currY));
            SetStartPos(GetX, GetY);
        }
        
        public void ChangeDir(int newSpeed, double newAngel)
        {
            // dt = DateTime.Now.AddDays(1);
            // side = -1;
            // spX = anX;
            // spY = anY;
            UpdateTime();
            _speed = newSpeed;
            _angle = newAngel;
            while (_angle < 0)
            {
                _angle += 2 * Math.PI;
            }
            //spX += (int)alphaC*v0/1000;
            //spY += (int)alphaS*v0/1000;
            // move((appTime-DateTime.Now).Milliseconds/1000);
        }
        private void UpdateTime()
        {
            _createTime = DateTime.Now;
            SetStartPos(GetX, GetY);
        }
        public bool IntersectsWith(DisplayObject obj)
        {
            bool intersectX = (_outRectX1 < obj._outRectX2) && (_outRectX2 > obj._outRectX1) || (obj._outRectX1 < _outRectX2) && (obj._outRectX2 > _outRectX1);
            bool intersectY = (_outRectY1 < obj._outRectY2) && (_outRectY2 > obj._outRectY1) || (obj._outRectY1 < _outRectY2) && (obj._outRectY2 > _outRectY1);
            return intersectX && intersectY;
        }

        private int RadToGrad(double rad)
        {
            return (int)Math.Round(rad * (180.0 / Math.PI));
        }
        private double GradToRad(int grad)
        {
            return grad * (Math.PI / 180.0);
        }
        public static void CheckTime(DisplayObject o1, DisplayObject o2)
        {
            double dtx = -1;
            double dty = -1;
            double cos1 = Math.Cos(o1._angle);
            double sin1 = Math.Sin(o1._angle);
            double cos2 = Math.Cos(o2._angle);
            double sin2 = Math.Sin(o2._angle);
            int cent1X = (o1._outRectX2 - o1._outRectX1)/2;
            int cent1Y = (o1._outRectY2 - o1._outRectY1)/2;
            int cent2X = (o2._outRectX2 - o2._outRectX1)/2;
            int cent2Y = (o2._outRectY2 - o2._outRectY1)/2;
            if (o1._boost == 0)
            {
                if ((o2._speed * cos2 + o1._speed * cos1 == 0) || (cent2X - cent1X) == 0)
                {
                    dtx = 0;
                }
                else
                {
                    dtx = (cent2X - cent1X) / (o2._speed * cos2 + o1._speed * cos1);
                }
                if ((o2._speed * sin2 + o1._speed * sin1) == 0 || (cent2Y - cent1Y) == 0)
                {
                    dty = 0;
                }
                else
                {
                    dty = (cent2Y - cent1Y) / (o2._speed * sin2 + o1._speed * sin1);
                }
                if (dtx > 10000) dtx = 0;
                if (dty > 10000) dty = 0;
            }
            else
            {
                dtx = (cent2X - cent1X) / (o2._speed * cos2 + o1._speed * cos1);
                double desc = (o1._speed * cos1 - o2._speed * cos2) * (o1._speed * cos1 - o2._speed * cos2) - 2 * (o1._boost * cos1 - o2._boost * cos2) * (cent2X - cent1X);
                double dtx1, dtx2, dty1, dty2;
                if (desc >= 0)
                {
                    dtx1 = (-(o1._speed * cos1 - o2._speed * cos2) - Math.Sqrt(desc)) / 2 * (cent2X - cent1X);
                    dtx2 = (-(o1._speed * cos1 + o2._speed * cos2) - Math.Sqrt(desc)) / 2 * (cent2X - cent1X);
                    if (dtx1 < 0 && dtx2 > 0) dtx = dtx2;
                    if (dtx2 < 0 && dtx1 > 0) dtx = dtx1;
                    if (dtx1 < 0 && dtx2 < 0) dtx = dtx1;
                    if (dtx1 > 0 && dtx2 > 0) dtx = dtx1 < dtx2 ? dtx1 : dtx2;
                }
                else
                {
                    dtx1 = -1;
                }

                desc = (o1._speed * sin1 - o2._speed * sin2) * (o1._speed * sin1 - o2._speed * sin2) - 2 * (o1._boost * sin1 - o2._boost * sin2) * (cent2X - cent1X);
                if (desc >= 0)
                {
                    dty1 = (-(o1._speed * sin1 - o2._speed * sin2) - Math.Sqrt(desc)) / 2 * (cent2X - cent1X);
                    dty2 = (-(o1._speed * sin1 + o2._speed * sin2) - Math.Sqrt(desc)) / 2 * (cent2X - cent1X);
                    if (dty1 < 0 && dty2 > 0) dty = dty2;
                    if (dty2 < 0 && dty1 > 0) dty = dty1;
                    if (dty1 < 0 && dty2 < 0) dty = dty1;
                    if (dty1 > 0 && dty2 > 0) dty = dty1 < dty2 ? dty1 : dty2;
                }
                else
                {
                    dty = -1;
                }


            }
            if (dtx > 0 && dtx < 1000 && o1.dt > DateTime.Now.AddMilliseconds(dtx * 1000))
            {
                o1.dt = DateTime.Now.AddMilliseconds(dtx * 1000);
            }
            if (dty > 0 && dty<1000 && o1.dt > DateTime.Now.AddMilliseconds(dty * 1000))
            {
                o1.dt = DateTime.Now.AddMilliseconds(dty * 1000);
            }
        }
        public bool DeltaTime(DateTime d1, DateTime d2, int FPS)
        {
            int range = 1000 / FPS;
            bool check = false;
            d1 = d2.AddMilliseconds(d1.Millisecond);
            int diff = (int)Math.Round((d1 - d2).TotalMilliseconds);
            if (Math.Abs(diff) < range) 
                check = true; check = true;
            return check;
        }
    }
}