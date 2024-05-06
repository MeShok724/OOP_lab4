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
        private const int threadcount = 4;
        private Thread[] _threads = new Thread[threadcount];

        public Game(GameField gameField, int minX, int minY, int maxX, int maxY, int minSpeed, int maxSpeed,
            int maxBoost, int gameFieldBorder)
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
                i.ProcCollBorders(_minX, _minY, _maxX, _maxY);
                i.ProcCollObjects(_gameField.arr);
                i.Update();
            }
            // ThreadProcess();
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
        {
            int ballInThread = _gameField.arr.Length / threadcount;
            int remaining = _gameField.arr.Length % threadcount;
            // int indexStart = 0;
            // int indexEnd = 0;

            for (int l = 0; l < threadcount; l++)
            {
                Thread thread = new Thread(ThreadCheck);
                thread.Start(l);
            }

            // for (int i = 0; i < threadcount; i++)
            // {
            //     indexStart = indexEnd;
            //     indexEnd = indexStart + ballInThread;
            //     if (remaining > 0)
            //     {
            //         indexEnd++;
            //         remaining--;
            //     }
            //
            //     _threads[i] = new Thread(()=>FuncThread(indexStart, indexEnd));
            //     _threads[i].Start();
            // }
            // foreach (var i in _threads)
            // {
            //     i.Join();
            // }
        }

        private void FuncThread(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                DisplayObject curr = _gameField.arr[i];
                lock (curr._lockObject) // Блокировка обрабатываемого шара для остальных потоков
                {
                    curr.ProcCollBorders(_minX, _minY, _maxX, _maxY); // Обработка столкновения с границей
                    curr.ProcCollObjects(_gameField.arr); // Обработка столкновений с другими шарами
                    curr.Update(); // Перемещение объекта под действием скорости
                }
            }
        }

        public void ThreadCheck(object data)
        {
            for (int i = (int)data; i < (_gameField.arr.Length / threadcount) * ((int)data + 1); i++)
            {
                DisplayObject curr = _gameField.arr[i];
                lock (curr._lockObject) // Блокировка обрабатываемого шара для остальных потоков
                {
                    curr.ProcCollBorders(_minX, _minY, _maxX, _maxY); // Обработка столкновения с границей
                    curr.ProcCollObjects(_gameField.arr); // Обработка столкновений с другими шарами
                    curr.Update(); // Перемещение объекта под действием скорости
                }
            }
        }
    }
}