using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SimpleCircleClusterProject.Algorithms;

namespace SimpleCircleClusterProject
{
	public interface IRenderableForm
	{
		Bitmap GetMainBitmap();
	}
	public class RenderData
	{
		public SimpleCircleCluster SimpleCircleCluster { get; set; }
		public bool IsDrawPoints { get; set; }
		public bool IsDrawCircle { get; set; }
		public bool IsDrawLines { get; set; }
		public bool IsDrawIntersectionPoints { get; set; }
		public int PointRadius { get; set; }
		public Color IntersectionPointColor { get; set; }
	}
	public class Renderer
	{
		private IRenderableForm _mainForm;
		private Graphics _graphics;
		public Renderer(IRenderableForm form)
		{
			_mainForm = form;
		}
		public void ClearBitmap(Color backColor)
		{
			GetGraphicsFromMainBitmap().Clear(backColor);
		}
		public RenderData RenderData { get; set; }
		public void RedrawForm()
		{
			_graphics = GetGraphicsFromMainBitmap();
			_graphics.Clear(Color.White);
			if(RenderData.IsDrawPoints) DrawPoints();
			if(RenderData.IsDrawCircle)	DrawCircles();
			if (RenderData.IsDrawLines) DrawLines();
			if (RenderData.IsDrawIntersectionPoints) DrawIntersectionPoint();
		}
		private void DrawIntersectionPoint()
		{
			var g = _graphics;
			foreach (var data in RenderData.SimpleCircleCluster.IntersectionPoint)
			{
				float x = data.X;
				float y = data.Y;
				g.FillEllipse(new SolidBrush(RenderData.IntersectionPointColor), x - RenderData.PointRadius, y - RenderData.PointRadius, RenderData.PointRadius * 2, RenderData.PointRadius * 2);
			}
		}
		private void DrawPoints()
		{
			var g = _graphics;
			foreach (var data in RenderData.SimpleCircleCluster.DataList)
			{
				float x = data.Point.X;
				float y = data.Point.Y;
				Color color = data.Class == "Right" ? Color.Green : Color.Blue;
				g.FillEllipse(new SolidBrush(color), x - RenderData.PointRadius, y - RenderData.PointRadius, RenderData.PointRadius * 2, RenderData.PointRadius * 2);
			}
		}
		private void DrawCircles()
		{
			var g = _graphics;
			foreach (var data in RenderData.SimpleCircleCluster.DataList)
			{
				float x = data.Point.X;
				float y = data.Point.Y;
				Color color = data.Class == "Right" ? Color.Green : Color.Blue;
				g.DrawEllipse(new Pen(color, 1), x - data.ActionRadius, y - data.ActionRadius, data.ActionRadius * 2, data.ActionRadius * 2);
			}
		}
		private void DrawLines()
		{
			var g = _graphics;
			var pen = new Pen(Color.Red, 1);
			foreach (var item in RenderData.SimpleCircleCluster.CircleLines)
				g.DrawLine(pen, item.PointSart, item.PointEnd);

		}
		private Graphics GetGraphicsFromMainBitmap()
		{
			Graphics result = Graphics.FromImage(_mainForm.GetMainBitmap());
			result.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			return result;
		}
	}
}
