using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        public Graphics g;
        
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void DrawObjects(GameField drField, Graphics graphic)
        {
            drField.Draw(graphic);
            foreach (var currObj in drField.arr)
            {
                currObj.Draw(graphic);
            }
        }

        private void pbDrawField_Click(object sender, EventArgs e)
        {
            g = pbDrawField.CreateGraphics();
            g.Clear(Color.White);
            const int minX = 20;
            const int minY = 20;
            const int maxX = 1100;
            const int maxY = 700;
            GameField gameField = GameField.GenerateObjects(1158, 724, minX, minY, maxX, maxY);
            DrawObjects(gameField, g);
        }
        
    }
}