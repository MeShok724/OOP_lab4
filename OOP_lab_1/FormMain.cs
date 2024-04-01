using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        static public Pen _pen;
        public int borderSizeWindow = 10;
        public Graphics g;
        private int width;
        private int height;
        private GameField _gameField;
        public static void DrawBorder(Form form, Graphics graphics)
        {
            graphics.DrawRectangle(_pen, form.ClientRectangle);
        }
        public FormMain()
        {
            InitializeComponent();
            width = ClientSize.Width - borderSizeWindow;
            height = ClientSize.Height - borderSizeWindow;
            // this.FormBorderStyle = FormBorderStyle.Sizable;
            // this.DesktopBounds = new System.Drawing.Rectangle(0, 0,  DesktopBounds.Width+10,  DesktopBounds.Height+10);
            _pen = new Pen(Color.White, borderSizeWindow) { Alignment = PenAlignment.Inset };
            g = this.CreateGraphics();
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
            int newX = ClientSize.Width - borderSizeWindow - width;
            int newY = ClientSize.Height - borderSizeWindow - height;
            width = ClientSize.Width - borderSizeWindow;
            height = ClientSize.Height - borderSizeWindow;
            if (_gameField != null)
            {
                _gameField.Update(_gameField.GetX + newX, _gameField.GetY + newY);
                for (int i = 0; i < _gameField.arr.Length; i++)
                {
                    var temp = _gameField.arr[i];
                    temp.Update(newX + temp.GetX, newY + temp.GetY);
                }
                g.Clear(Color.FromArgb(240,240,240));
                DrawObjects(_gameField, g);
            }
            DrawBorder(this, g);
        }

        private void FormMain_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.FromArgb(240,240,240));
            int minX = borderSizeWindow;
            int minY = borderSizeWindow;
            int maxX = this.ClientSize.Width - borderSizeWindow;
            int maxY = this.ClientSize.Height - borderSizeWindow;
            GameField gameField = GameField.GenerateObjects(width - 200, height - 200, minX + 200, minY + 200, maxX, maxY);
            _gameField = gameField;
            DrawObjects(gameField, g);
            DrawBorder(this, g);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(this, g);
        }
    }
}