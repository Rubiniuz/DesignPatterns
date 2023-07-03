using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {

        public enum DrawState
        {
            Brush,
            Rectangle,
            Elipse
        }

        public Point current = new Point();
        public Point old = new Point();

        public Graphics g;
        public Graphics graph;
        public List<>

        public Pen pen = new Pen(Color.Black, 5);

        Bitmap surface;
        public DrawState drawState = DrawState.Brush;

        public Form1()
        {
            InitializeComponent();

            g = canvasPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvasPanel.Width, canvasPanel.Height);

            graph = Graphics.FromImage(surface);

            canvasPanel.BackgroundImage = surface;
            canvasPanel.BackgroundImageLayout = ImageLayout.None;

            pen.Width = (float)paintbrush_size.Value;
        }

        private Boolean isRectangleMoving = false;
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            isRectangleMoving = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (drawState == DrawState.Brush) {
                    current = e.Location;
                    g.DrawLine(pen, old, current);
                    graph.DrawLine(pen, old, current);

                    old = current;
                }
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isRectangleMoving = false;

            int width = e.X - old.X;
            int height = e.Y - old.Y;

            Rectangle rect = new Rectangle(old.X, old.Y, width * Math.Sign(width), height * Math.Sign(height));

            if (drawState == DrawState.Rectangle) {
                g.DrawRectangle(pen, rect);
                graph.DrawRectangle(pen, rect);
            } else if (drawState == DrawState.Elipse) {
                g.DrawEllipse(pen, rect);
                graph.DrawEllipse(pen, rect);
            }
        }

        private Point mouseOffsetPos;
        private Boolean isMouseDown = false;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                mouseOffsetPos = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffsetPos.X, mouseOffsetPos.Y);
                this.Location = mousePos;
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eraser_button_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
            drawState = DrawState.Brush;

        }

        private void paintbrush_button_Click(object sender, EventArgs e)
        {
            pen.Color = colorbox.BackColor;
            drawState = DrawState.Brush;
        }

        private void colorbox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                colorbox.BackColor = cd.Color;
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            canvasPanel.Invalidate();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Png Bestanden (*png) | *.png";
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                surface.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void paintbrushsize_change(object sender, EventArgs e)
        {
            pen.Width = (float)paintbrush_size.Value;
        }

        private void rectangle_button_Click(object sender, EventArgs e)
        {
            pen.Color = colorbox.BackColor;
            drawState = DrawState.Rectangle;
        }

        private void ellipse_button_Click(object sender, EventArgs e)
        {
            pen.Color = colorbox.BackColor;
            drawState = DrawState.Elipse;
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png Bestanden (*png) | *.png";
            ofd.DefaultExt = "png";
            ofd.AddExtension = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Load Image to bitmap
                Image img = Image.FromFile(ofd.FileName);
                surface = new Bitmap(img);
                
                // Update Drawing area
                graph = Graphics.FromImage(surface);
                canvasPanel.BackgroundImage = surface;
                canvasPanel.BackgroundImageLayout = ImageLayout.None;
                g = canvasPanel.CreateGraphics();

            }
        }
    }
}
