using PaintApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintBeginner
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap bmp;
        Point prevPoint;
        Point curPoint;
        Pen p;
        string tools;
        bool ok = false;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            gfx = Graphics.FromImage(bmp);
            p = new Pen(Color.Red, 5);
            gfx.Clear(Color.White);

            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
            ok = true;
            if (tools == "Fill")
            {
                MapFill mapfill = new MapFill();
                mapfill.Fill(gfx, e.Location, p.Color, ref bmp);
                pictureBox1.Image = bmp;
                gfx = Graphics.FromImage(bmp);

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ok = false;
            if (tools == "Rectangle")
            {
                curPoint = e.Location;
                gfx.DrawRectangle(p, GetRec(prevPoint, curPoint));
            }
            else if (tools == "Line")
            {
                gfx.DrawLine(p, prevPoint, curPoint);
            }
            else if (tools == "Circle")
            {
                curPoint = e.Location;
                int a = Math.Min(prevPoint.X, curPoint.X);
                int b = Math.Min(prevPoint.Y, curPoint.Y);
                int c = Math.Abs(prevPoint.X - curPoint.X);
                int d = Math.Abs(prevPoint.Y - curPoint.Y);
                gfx.DrawEllipse(p, a, b, c, d);

            }
            else if (tools == "Triangle")
            {
                curPoint = e.Location;
                if (prevPoint.X < curPoint.X && prevPoint.Y < curPoint.Y)
                {
                    gfx.DrawLine(p, prevPoint.X, curPoint.Y, curPoint.X, curPoint.Y);
                    gfx.DrawLine(p, curPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                    gfx.DrawLine(p, prevPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                }
                if (prevPoint.X > curPoint.X && prevPoint.Y > curPoint.Y)
                {
                    gfx.DrawLine(p, prevPoint.X, prevPoint.Y, curPoint.X, prevPoint.Y);
                    gfx.DrawLine(p, curPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                    gfx.DrawLine(p, prevPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                }
                if (prevPoint.X < curPoint.X && prevPoint.Y > curPoint.Y)
                {
                    gfx.DrawLine(p, prevPoint.X, prevPoint.Y, curPoint.X, prevPoint.Y);
                    gfx.DrawLine(p, curPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                    gfx.DrawLine(p, prevPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                }
                if (prevPoint.X > curPoint.X && prevPoint.Y < curPoint.Y)
                {
                    gfx.DrawLine(p, prevPoint.X, curPoint.Y, curPoint.X, curPoint.Y);
                    gfx.DrawLine(p, curPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                    gfx.DrawLine(p, prevPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                }
               
            }
           
        }
        
           private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                label1.Text = e.X.ToString();
                label2.Text = e.Y.ToString();
                curPoint = e.Location;
                if (ok && tools == "Pen")
                {
                    curPoint = e.Location;

                    gfx.DrawLine(p, prevPoint, curPoint);
                    prevPoint = curPoint;

                }
                if (ok && tools == "Eraser")
                {
                    Pen pp = new Pen(Color.White, 20);
                    gfx.DrawLine(pp, prevPoint, curPoint);
                    prevPoint = curPoint;
                    curPoint = e.Location;
                    pp.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pp.EndCap = System.Drawing.Drawing2D.LineCap.Round  ;
            }
                pictureBox1.Refresh();
            }
        
          private  void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                if (ok && tools == "Rectangle")
                {
                    g.DrawRectangle(p, GetRec(prevPoint, curPoint));
                }
                if (ok && tools == "Line")
                {
                    g.DrawLine(p, prevPoint, curPoint);
                }
                if (ok && tools == "Circle")
                {

                    int a = Math.Min(prevPoint.X, curPoint.X);
                    int b = Math.Min(prevPoint.Y, curPoint.Y);
                    int c = Math.Abs(prevPoint.X - curPoint.X);
                    int d = Math.Abs(prevPoint.Y - curPoint.Y);
                    g.DrawEllipse(p, a, b, c, d);
                }
            if (ok && tools == "Triangle")
            {
                if (prevPoint.X < curPoint.X && prevPoint.Y < curPoint.Y)
                {
                    g.DrawLine(p, prevPoint.X, curPoint.Y, curPoint.X, curPoint.Y);
                    g.DrawLine(p, curPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                    g.DrawLine(p, prevPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                }
                if (prevPoint.X > curPoint.X && prevPoint.Y > curPoint.Y)
                {
                    g.DrawLine(p, prevPoint.X, prevPoint.Y, curPoint.X, prevPoint.Y);
                    g.DrawLine(p, curPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                    g.DrawLine(p, prevPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                }
                if (prevPoint.X < curPoint.X && prevPoint.Y > curPoint.Y)
                {
                    g.DrawLine(p, prevPoint.X, prevPoint.Y, curPoint.X, prevPoint.Y);
                    g.DrawLine(p, curPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                    g.DrawLine(p, prevPoint.X, prevPoint.Y, (curPoint.X + prevPoint.X) / 2, curPoint.Y);
                }
                if (prevPoint.X > curPoint.X && prevPoint.Y < curPoint.Y)
                {
                    g.DrawLine(p, prevPoint.X, curPoint.Y, curPoint.X, curPoint.Y);
                    g.DrawLine(p, curPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                    g.DrawLine(p, prevPoint.X, curPoint.Y, (curPoint.X + prevPoint.X) / 2, prevPoint.Y);
                }
            }


            }
            Rectangle GetRec(Point p1, Point p2)
            {
                int a = Math.Min(prevPoint.X, curPoint.X);
                int b = Math.Min(prevPoint.Y, curPoint.Y);
                int c = Math.Abs(prevPoint.X - curPoint.X);
                int d = Math.Abs(prevPoint.Y - curPoint.Y);
                Rectangle rec = new Rectangle(a, b, c, d);
                return rec;
            }

            void Tool_choose(object sender, EventArgs e)
            {
                Button btm = sender as Button;
                tools = btm.Text;

            }

            void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(saveFileDialog1.FileName);
                }
            }

            void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    bmp = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = bmp;
                    gfx = Graphics.FromImage(bmp);
                }
            }

            void colorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    p.Color = colorDialog1.Color;
                }
            }

        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            p.Width = float.Parse(numericUpDown1.Value.ToString());
        }
    }
    }
