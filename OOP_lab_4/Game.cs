using System;
using System.Drawing;

namespace OOP_lab_4
{
    public class Game
    {
        private GameField _gameField;
        private int _minX, _minY;
        private int _maxX, _maxY;
        const int minB = 1;
        const int maxB = 10;
        int minSpeed = 30;
        int maxSpeed = 50;
        const int minBoost = 0;
        int maxBoost = 3;
        const int maxCorner = 360;

        public Game(GameField gameField, int minX, int minY, int maxX, int maxY, int minSpeed, int maxSpeed, int maxBoost, int gameFieldBorder)
        {
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.maxBoost = maxBoost;
            _gameField = gameField;
            _minX = minX + gameFieldBorder;
            _minY = minY + gameFieldBorder;
            _maxX = maxX - gameFieldBorder;
            _maxY = maxY - gameFieldBorder;
        }

        public void Update()
        {
            foreach (var i in _gameField.arr)
            {
                i.Move();
                i.CheckAndFixIntersects(_minX, _minY, _maxX, _maxY);
                // COLLIZION
            }
        }

        public void DrawObjects(Graphics g)
        {
            _gameField.Draw(g);
            foreach (var i in _gameField.arr)
            {
                i.Draw(g);
            }
        }

        public void UpdateAfterResize(int newX, int newY, Graphics g)
        {
            _gameField.Update(_gameField.GetX + newX, _gameField.GetY + newY);
            for (int i = 0; i < _gameField.arr.Length; i++)
            {
                var temp = _gameField.arr[i];
                temp.Update(newX + temp.GetX, newY + temp.GetY);
            }
            g.Clear(Color.FromArgb(240,240,240));
            DrawObjects(g);
        }
        

        public void UpdateTime()
        {
            foreach (var i in _gameField.arr)
            {
                i._createTime = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second + DateTime.Now.Millisecond * 0.001;
                i.SetStartPos(i.GetX, i.GetY);
            }
        }
    }
}