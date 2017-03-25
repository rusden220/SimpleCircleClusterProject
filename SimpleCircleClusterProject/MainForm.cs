using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCircleClusterProject.Algorithms;
using System.Diagnostics;

namespace SimpleCircleClusterProject
{
	
	public partial class MainForm : Form
	{
		private Bitmap _mainBitmap;
		private int _pointRadius = 3;
		private SimpleCircleCluster _scc;
		public MainForm()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			mainPanel.MouseDown += MainPanel_MouseDown;
			mainPanel.Paint += MainPanel_Paint;
			mainPanel.Click += MainPanel_Click;

			Init();
		}
		private void Init()
		{
			_mainBitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
			GetGraphicsFromMainBitmap().Clear(Color.White);
			_scc = new SimpleCircleCluster();
			circleToolStripMenuItem.Checked = true;
			linesToolStripMenuItem.Checked = true;
			mainPanel.Invalidate();
			//GetGraphicsFromMainBitmap().DrawRectangle(new Pen(Color.Black,1),  0, 0, _mainBitmap.Width-1, _mainBitmap.Height-1);
		}
		private void MainPanel_Click(object sender, EventArgs e)
		{
			mainPanel.Invalidate();
		}
		private void MainPanel_Paint(object sender, PaintEventArgs e)
		{
			Render();
			e.Graphics.DrawImage(_mainBitmap, 0, 0);
		}
		private void MainPanel_MouseDown(object sender, MouseEventArgs e)
		{
			var sccD = new SCCData() { Point = new PointF(e.X, e.Y) };
			if (e.Button == MouseButtons.Left)			
				sccD.Class = "Left";			
			else if (e.Button == MouseButtons.Right)	
				sccD.Class = "Right";
			_scc.DataList.Add(sccD);			
		}
		private void Render()
		{
			GetGraphicsFromMainBitmap().Clear(Color.White);
			DrawPoints();
			if (circleToolStripMenuItem.Checked)
				DrawCircles();
			if (linesToolStripMenuItem.Checked)
				DrawLines();

			var g = GetGraphicsFromMainBitmap();
			foreach (var data in _scc.IntersectionPoint)
			{
				float x = data.X;
				float y = data.Y;
				float r = 2;
				g.FillEllipse(new SolidBrush(Color.Black), x - r, y - r, r * 2, r * 2);
			}
		}
		private void DrawPoints()
		{
			var g = GetGraphicsFromMainBitmap();
			foreach (var data in _scc.DataList)
			{
				float x = data.Point.X;
				float y = data.Point.Y;
				Color color = data.Class == "Right" ? Color.Green : Color.Blue;
				g.FillEllipse(new SolidBrush(color), x - _pointRadius, y - _pointRadius, _pointRadius * 2, _pointRadius * 2);
			}
		}
		private void DrawCircles()
		{
			var g = GetGraphicsFromMainBitmap();
			foreach (var data in _scc.DataList)
			{
				float x = data.Point.X;
				float y = data.Point.Y;
				Color color = data.Class == "Right" ? Color.Green : Color.Blue;
				g.DrawEllipse(new Pen(color, 1), x - data.ActionRadius, y - data.ActionRadius, data.ActionRadius * 2, data.ActionRadius * 2);
			}
		}
		private void DrawLines()
		{
			var g = GetGraphicsFromMainBitmap();
			var pen = new Pen(Color.Red, 1);
			foreach (var item in _scc.CircleLines)
				g.DrawLine(pen, item.PointSart, item.PointEnd);

		}
		private Graphics GetGraphicsFromMainBitmap()
		{
			Graphics result = Graphics.FromImage(_mainBitmap);
			result.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;			
			return result;
		}
		private void processToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_scc.SetLinesBetweenCircles();
			_scc.SetPointOfIntersection();
			mainPanel.Invalidate();	
		}	
		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Init();
		}
		private void circleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			circleToolStripMenuItem.Checked = !circleToolStripMenuItem.Checked;
			mainPanel.Invalidate();
		}
		private void linesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			linesToolStripMenuItem.Checked = !linesToolStripMenuItem.Checked;
			mainPanel.Invalidate();
		}
	}
}
