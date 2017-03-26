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
	
	public partial class MainForm : Form, IRenderableForm
	{
		private Bitmap _mainBitmap;
		private int _pointRadius = 3;
		private SimpleCircleCluster _scc;
		private Renderer _render;
		public MainForm()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			mainPanel.MouseDown += MainPanel_MouseDown;
			mainPanel.Paint += MainPanel_Paint;
			mainPanel.Click += MainPanel_Click;			
			Init();
			_render.RenderData = new RenderData() {IntersectionPointColor = Color.Black, PointRadius = 3, SimpleCircleCluster = _scc };
			_render.RedrawForm();	
		}
		private void Init()
		{
			_mainBitmap = new Bitmap(mainPanel.Width, mainPanel.Height);		
			_scc = new SimpleCircleCluster();
			circleToolStripMenuItem.Checked = true;
			linesToolStripMenuItem.Checked = true;
			intersectionPointToolStripMenuItem.Checked = true;
			_render = new Renderer(this);
			_render.ClearBitmap(Color.White);			
			//GetGraphicsFromMainBitmap().DrawRectangle(new Pen(Color.Black,1),  0, 0, _mainBitmap.Width-1, _mainBitmap.Height-1);
		}
		public Bitmap GetMainBitmap()
		{
			return _mainBitmap;
		}
		private void MainPanelInvalidate()
		{
			_render.RenderData.IsDrawPoints = true;
			_render.RenderData.IsDrawCircle = circleToolStripMenuItem.Checked;
			_render.RenderData.IsDrawLines = linesToolStripMenuItem.Checked;
			_render.RenderData.IsDrawIntersectionPoints = intersectionPointToolStripMenuItem.Checked;
			_render.RedrawForm();
			mainPanel.Invalidate();
		}
		private void MainPanel_Click(object sender, EventArgs e)
		{
			MainPanelInvalidate();
		}
		private void MainPanel_Paint(object sender, PaintEventArgs e)
		{
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
		
		private void processToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_scc.SetLinesBetweenCircles();
			_scc.SetPointOfIntersection();
			MainPanelInvalidate();
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
		private void intersectionPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			intersectionPointToolStripMenuItem.Checked = !intersectionPointToolStripMenuItem.Checked;
		}

		
	}
}
