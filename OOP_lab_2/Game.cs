using System;
using System.Drawing;

namespace OOP_lab_1
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

        public Game(GameField gameField, int minX, int minY, int maxX, int maxY, int minSpeed, int maxSpeed, int maxBoost)
        {
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.maxBoost = maxBoost;
            _gameField = gameField;
            _minX = minX;
            _minY = minY;
            _maxX = maxX;
            _maxY = maxY;
        }

        public void Update()
        {
            foreach (var i in _gameField.arr)
            {
                i.Move();
                if (i.BehindTheField(_minX, _minY, _maxX, _maxY))
                {
                    int j = GameField.DeleteObject(_gameField.arr, i);
                    Recreate(i, j);
                }
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
        private void Recreate(DisplayObject displayObject, int index)
        {
            Random rand = new Random();
            switch (displayObject) {
                case Section _:
                    GameField.AddSection(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case EquilateralTriangle _:
                    GameField.AddEquilateralTriangle(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case IsoscelesTriangle _:
                    GameField.AddIsoscelesTriangle(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case Square _:
                    GameField.AddSquare(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case Rectangle _:
                    GameField.AddRectangle(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case Triangle _:
                    GameField.AddTriangle(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case Circle _:
                    GameField.AddCircle(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
                case Ellipse _:
                    GameField.AddEllipse(index, _minX, _minY, _maxX, _maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, _gameField.arr, rand);
                    return;
            }
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