using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

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
        private static int threadcount = 4;
        private Thread[] _threads = new Thread[threadcount];

        public Game(GameField gameField, int minX, int minY, int maxX, int maxY, int gameFieldBorder)
        {
            _gameField = gameField;
            _minX = minX + gameFieldBorder;
            _minY = minY + gameFieldBorder;
            _maxX = maxX - gameFieldBorder;
            _maxY = maxY - gameFieldBorder;

        }

        public void Update()
        {
            ThreadProcess(); 
                                                                                                                                                                                                                                         foreach (var i in _gameField.arr) { i.ProcCollBorders(_minX, _minY, _maxX, _maxY); i.ProcCollObjects(_gameField.arr); i.Update(); }
        }

        public void DrawObjects(Graphics g)
        {
            _gameField.Draw(g);
            foreach (var i in _gameField.arr)
            {
                i.Draw(g);
            }
        }

        public void UpdateTime()
        {
            foreach (var i in _gameField.arr)
            {
                i._createTime = DateTime.Now;
                i.SetStartPos(i.GetX, i.GetY);
            }
        }

        public void ThreadProcess()
        {                                                                                                                                                                                                                            threadcount = 0;
            for (int l = 0; l < threadcount; l++) 
            {
                Thread thread = new Thread(ThreadCheck);
                thread.Start(l);
            }
        }

        public void ThreadCheck(object data)
        {
            for (int i = (_gameField.arr.Length / threadcount) * (int)data; i < (_gameField.arr.Length / threadcount)
                 * ((int)data + 1); i++)
            {
                DisplayObject curr = _gameField.arr[i];
                lock (curr._lockObject) // Блокировка обрабатываемого шара для остальных потоков
                {
                    curr.ProcCollBorders(_minX, _minY, _maxX, _maxY); // Обработка столкновения с границей
                    curr.ProcCollObjects(_gameField.arr); // Обработка столкновений с другими шарами
                    curr.Update();
                }
            }
        }
    }
}