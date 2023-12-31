﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        
        public Point current = new Point();
        public Point old = new Point();

        public Graphics g;
        public Graphics graph;
        public List<Graphics> graphics = new List<Graphics>();

        public Pen pen = new Pen(Color.Black, 5);

        Bitmap surface;
        public DrawState drawState = DrawState.RECTANGLE;

        public DrawableHistory history = new DrawableHistory();

        public Form1()
        {
            InitializeComponent();
            AllocConsole(); // enable debug console

            g = canvasPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvasPanel.Width, canvasPanel.Height);

            graph = Graphics.FromImage(surface);

            canvasPanel.BackgroundImage = surface;
            canvasPanel.BackgroundImageLayout = ImageLayout.None;

            pen.Width = (float)paintbrush_size.Value;
            
            graphics.Add(graph);
            graphics.Add(g);

            //Initialize events
            Console.WriteLine("Events initialized");
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            Console.WriteLine("MouseDown");
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
               
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            (Point,Point) normalized = NormalizePoints(old, e.Location);
            Point Minval = normalized.Item1;
            Point Maxval = normalized.Item2;

            if (drawState == DrawState.RECTANGLE) {
                RectangleDrawable rd = new RectangleDrawable(Minval, Maxval, pen);
                DrawCommand command = new DrawCommand(rd, graphics);
                history.push(command);
            } else if (drawState == DrawState.ELLIPSE) {
                EllipseDrawable ed = new EllipseDrawable(Minval, Maxval, pen);
                DrawCommand command = new DrawCommand(ed, graphics);
                history.push(command);
            } else if (drawState == DrawState.SELECT) {
                SelectCommand command = new SelectCommand(Minval, Maxval); 
                history.push(command);
            } else if (drawState == DrawState.MOVE) {
                MoveCommand command = new MoveCommand(old, e.Location);
                history.push(command);
            } else if (drawState == DrawState.SCALE) {
                ResizeCommand command = new ResizeCommand(old, e.Location);
                history.push(command);
            }

            Console.WriteLine("MouseUP. " + "Min & Max: " + Minval + ", " + Maxval + " history size: " + history.get().Count);
            DrawManager.GetInstance().renderSurface(history, graph, g);
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

        private void colorbox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                colorbox.BackColor = cd.Color;
            }
            Console.WriteLine("Color changed to: " + pen.Color);
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            canvasPanel.Invalidate();
            history = new DrawableHistory();
            Console.WriteLine("Clear Canvas and Commands");
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
            drawState = DrawState.RECTANGLE;
            Console.WriteLine("DrawState: " + drawState);
        }

        private void ellipse_button_Click(object sender, EventArgs e)
        {
            pen.Color = colorbox.BackColor;
            drawState = DrawState.ELLIPSE;
            Console.WriteLine("DrawState: " + drawState);
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

        private Boolean bUndoDown = false;
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    if (bUndoDown) break;

                    if (e.Modifiers == (Keys.Control | Keys.Shift))
                    {
                        bUndoDown = true;
                        history.redo();

                        DrawManager.GetInstance().renderSurface(history, graph, g);
                    } else if (Control.ModifierKeys == Keys.Control)
                    {
                        bUndoDown = true;
                        history.undo();

                        DrawManager.GetInstance().renderSurface(history, graph, g);
                    }
                    break;

            }
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (bUndoDown)
            {
                if (e.KeyCode == Keys.Z)
                {
                    bUndoDown = false;
                }
            }
        }

        private (Point,Point) NormalizePoints(Point startPos, Point endPos)
        {
            Point MinVal = new Point();
            Point Maxval = new Point();

            if (startPos.X < endPos.X)
            {
                MinVal.X = startPos.X;
                Maxval.X = endPos.X;
            }
            else
            {
                MinVal.X = endPos.X;
                Maxval.X = startPos.X;
            }
            
            if (startPos.Y < endPos.Y)
            {
                MinVal.Y = startPos.Y;
                Maxval.Y = endPos.Y;
            }
            else
            {
                MinVal.Y = endPos.Y;
                Maxval.Y = startPos.Y;
            }
            
            return (MinVal,Maxval);
        }

        private void move_button_Click(object sender, EventArgs e)
        {
            drawState = DrawState.MOVE;
            Console.WriteLine("DrawState: " + drawState);
        }

        private void resize_button_Click(object sender, EventArgs e)
        {
            drawState = DrawState.SCALE;
            Console.WriteLine("DrawState: " + drawState);
        }
        
        private void select_button_Click(object sender, EventArgs e)
        {
            drawState = DrawState.SELECT;
            Console.WriteLine("DrawState: " + drawState);
        }
    }
}