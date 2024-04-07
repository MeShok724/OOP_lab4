namespace OOP_lab_1
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbDraw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDraw
            // 
            this.pbDraw.Location = new System.Drawing.Point(13, 13);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(986, 618);
            this.pbDraw.TabIndex = 0;
            this.pbDraw.TabStop = false;
            this.pbDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDraw_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1012, 644);
            this.Controls.Add(this.pbDraw);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pbDraw;

        #endregion
    }
}