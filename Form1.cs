using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditor
{
    public class Form1 : Form
    {
        private Bitmap canvas;
        private Point lastPoint;
        private bool isDrawing = false;
        private Color currentColor = Color.Black;
        
        public Form1()
        {
            SetupEditor();
        }
        
        private void SetupEditor()
        {
            // Configurar ventana
            this.Text = "Graphic Editor / Графический редактор";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Crear lienzo blanco
            canvas = new Bitmap(600, 400);
            using (Graphics g = Graphics.FromImage(canvas))
                g.Clear(Color.White);
            
            // Botones
            var btnClear = new Button
            {
                Text = "Clear",
                Location = new Point(10, 10),
                Size = new Size(60, 30)
            };
            btnClear.Click += (s, e) => ClearCanvas();
            
            var btnBlack = new Button
            {
                Text = "Black",
                Location = new Point(80, 10),
                Size = new Size(60, 30),
                BackColor = Color.Black,
                ForeColor = Color.White
            };
            btnBlack.Click += (s, e) => currentColor = Color.Black;
            
            var btnRed = new Button
            {
                Text = "Red",
                Location = new Point(150, 10),
                Size = new Size(60, 30),
                BackColor = Color.Red
            };
            btnRed.Click += (s, e) => currentColor = Color.Red;
            
            var btnBlue = new Button
            {
                Text = "Blue",
                Location = new Point(220, 10),
                Size = new Size(60, 30),
                BackColor = Color.Blue,
                ForeColor = Color.White
            };
            btnBlue.Click += (s, e) => currentColor = Color.Blue;
            
            var btnGreen = new Button
            {
                Text = "Green",
                Location = new Point(290, 10),
                Size = new Size(60, 30),
                BackColor = Color.Green
            };
            btnGreen.Click += (s, e) => currentColor = Color.Green;
            
            // Agregar controles
            this.Controls.Add(btnClear);
            this.Controls.Add(btnBlack);
            this.Controls.Add(btnRed);
            this.Controls.Add(btnBlue);
            this.Controls.Add(btnGreen);
            
            // Eventos del mouse
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    lastPoint = e.Location;
                    isDrawing = true;
                }
            };
            
            this.MouseMove += (s, e) =>
            {
                if (isDrawing && e.Button == MouseButtons.Left)
                {
                    using (Graphics g = Graphics.FromImage(canvas))
                    using (Pen pen = new Pen(currentColor, 3))
                    {
                        g.DrawLine(pen, lastPoint, e.Location);
                    }
                    lastPoint = e.Location;
                    this.Invalidate();
                }
            };
            
            this.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDrawing = false;
                }
            };
            
            this.Paint += (s, e) =>
            {
                e.Graphics.DrawImage(canvas, 0, 0);
            };
        }
        
        private void ClearCanvas()
        {
            using (Graphics g = Graphics.FromImage(canvas))
                g.Clear(Color.White);
            this.Invalidate();
        }
    }
}