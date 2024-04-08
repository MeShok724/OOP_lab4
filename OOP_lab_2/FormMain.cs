using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        private Game game;
        private Timer gameTimer;
        public Graphics g;
        public Graphics g1;
        private bool isSubscribed = true;
        
        public int borderSizeWindow = 10;
        private Bitmap backBuffer;
        static public Pen _pen;
        // private int width;
        // private int height;
        public FormMain()
        {
            InitializeComponent();
            _pen = new Pen(Color.White, borderSizeWindow) { Alignment = PenAlignment.Inset };
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.Update();
                game.DrawObjects(g1);
            }
            pbDraw.Invalidate();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            
            // g1 = pbDraw.CreateGraphics();
            // int newX = ClientSize.Width - borderSizeWindow - width;
            // int newY = ClientSize.Height - borderSizeWindow - height;
            // width = ClientSize.Width - borderSizeWindow;
            // height = ClientSize.Height - borderSizeWindow;
            // if (game != null)
            // {
            //      game.UpdateAfterResize(newX, newY, g1);   
            // }
            g = this.CreateGraphics();
            Invalidate();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(this, g);
        }

        private void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backBuffer, 0, 0);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            g = this.CreateGraphics();
            backBuffer = new Bitmap(pbDraw.Width, pbDraw.Height);
            g1 = Graphics.FromImage(backBuffer);
            
            int minX = 0;
            int minY = 0;
            int maxX = pbDraw.Width;
            int maxY = pbDraw.Height;
            int minSpeed = 80;
            int maxSpeed = 100;
            int maxBoost = 20;
            GameField gameField = GameField.GenerateTwoCircles(maxX, maxY, 0, 0, maxX, maxY, minSpeed, maxSpeed, maxBoost);

            game = new Game(gameField, minX, minY, maxX, maxY, minSpeed, maxSpeed, maxBoost);
            game.DrawObjects(g1);
            DrawBorder(this, g);
            
            gameTimer = new Timer();
            gameTimer.Interval = 1000/30;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }
        public static void DrawBorder(Form form, Graphics graphics)
        {
            // graphics.DrawRectangle(_pen, form.ClientRectangle);
        }
        
        void SubscribeToGameTick()
        {
            isSubscribed = true;
            gameTimer.Tick += GameTimer_Tick;
            game.UpdateTime();
        }

        void UnsubscribeFromGameTick()
        {
            gameTimer.Tick -= GameTimer_Tick;
            isSubscribed = false;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (isSubscribed)
                {
                    UnsubscribeFromGameTick();
                }
                else
                {
                    SubscribeToGameTick();
                }
            }
        }
    }
}