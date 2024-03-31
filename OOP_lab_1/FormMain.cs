using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        public Graphics g;
        private int width;
        private int height;
        private GameField _gameField;
        
        public FormMain()
        {
            InitializeComponent();
            width = Width;
            height = Height;
        }
        
        private void DrawObjects(GameField drField, Graphics graphic)
        {
            drField.Draw(graphic);
            foreach (var currObj in drField.arr)
            {
                currObj.Draw(graphic);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            int newX = Width - width;
            int newY = Height - height;
            width = Width;
            height = Height;
            if (_gameField != null)
            {
                _gameField.Update(_gameField.GetX + newX, _gameField.GetY + newY);
                for (int i = 0; i < _gameField.arr.Length; i++)
                {
                    var temp = _gameField.arr[i];
                    temp.Update(newX + temp.GetX, newY + temp.GetY);
                }
                g.Clear(Color.White);
                DrawObjects(_gameField, g);
            }
        }

        private void FormMain_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            const int minX = 20;
            const int minY = 20;
            int maxX = this.ClientSize.Width;
            int maxY = this.ClientSize.Height;
            GameField gameField = GameField.GenerateObjects(this.ClientSize.Width, this.ClientSize.Height, minX, minY, maxX, maxY);
            _gameField = gameField;
            DrawObjects(gameField, g);
        }
    }
}