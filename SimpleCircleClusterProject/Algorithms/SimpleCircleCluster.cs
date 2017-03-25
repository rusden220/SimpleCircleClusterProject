using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SimpleCircleClusterProject.Algorithms
{
	public class SCCData
	{
		public string Class { get; set; }
		public PointF Point { get; set; }
		public int ActionRadius { get; set; } = 50;

	}
	public class DataLine
	{
		public PointF PointSart { get; set; }
		public PointF PointEnd { get; set; }
	}
	public class SimpleCircleCluster
	{
		public SimpleCircleCluster()
		{
			DataList = new List<SCCData>();
			CircleLines = new List<DataLine>();
			IntersectionPoint = new List<PointF>();
		}
		public List<SCCData> DataList { get; set; }
		public List<DataLine> CircleLines { get; set; }
		public List<PointF> IntersectionPoint { get; set; }
		public List<DataLine> SetLinesBetweenCircles()
		{
			CircleLines = new List<DataLine>();
			for (int i = 0; i < DataList.Count; i++)
			{
				for (int j = i+1; j < DataList.Count; j++)
				{
					var first = DataList[i];
					var second = DataList[j];
					if (first.Class != second.Class)
					{
						var t = GetLineBetweenTwoPoints(first, second);
						if (t != null) CircleLines.Add(t);
					}
				}
			}
			return CircleLines;
		}
		private DataLine GetLineBetweenTwoPoints(SCCData first, SCCData second)
		{
			var r0 = first.ActionRadius;
			var r1 = second.ActionRadius;
			//Debug.WriteLine($"r0 = {r0},r1 = { r1 }");
			PointF pc0 = first.Point;
			PointF pc1 = second.Point;
			//Debug.WriteLine($"pc0 = {pc0}, pc1 = { pc1}");
			double len = Math.Sqrt(Math.Pow(pc0.X - pc1.X, 2) + Math.Pow(pc0.Y - pc1.Y, 2));
			double a = (r0 * r0 - r1 * r1 + len * len) / (2 * len);
			double h = Math.Sqrt(r0 * r0 - a * a);
			PointF pm = new PointF(
				(float)(pc0.X + a * (pc1.X - pc0.X) / len),
				(float)(pc0.Y + a * (pc1.Y - pc0.Y) / len));
			//Debug.WriteLine($"pm = {pm}");
			PointF pr1 = new PointF(
				(float)(pm.X + h * (pc1.Y - pc0.Y) / len),
				(float)(pm.Y - h * (pc1.X - pc0.X) / len));
			PointF pr2 = new PointF(
				(float)(pm.X - h * (pc1.Y - pc0.Y) / len),
				(float)(pm.Y + h * (pc1.X - pc0.X) / len));
			if (pr1.X == float.NaN && pr2.X == float.NaN)
				return null;
			return new DataLine() { PointSart = pr1, PointEnd = pr2 };
			//GetGraphicsFromMainBitmap().DrawLine(new Pen(Color.Red, 1), pr1, pr2);
			//mainPanel.Invalidate();
		}
		public List<PointF> SetPointOfIntersection()
		{
			IntersectionPoint = new List<PointF>();
			for (int i = 0; i < CircleLines.Count; i++)
			{
				for (int j = i+1; j < CircleLines.Count; j++)
				{
					var t = GetIntersectionBteweenTwoLines(CircleLines[i], CircleLines[j]);
					if (!IsIntersectionBeyondSegments(CircleLines[i], CircleLines[j], t))
						IntersectionPoint.Add(t);
				}
			}
			return IntersectionPoint;
		}
		private PointF GetIntersectionBteweenTwoLines(DataLine f, DataLine s)
		{
			var t = GetLineParam(f.PointSart, f.PointEnd);
			float k1 = t[0];
			float b1 = t[1];
			t = GetLineParam(s.PointSart, s.PointEnd);
			float k2 = t[0];
			float b2 = t[1];
			float x = (b2 - b1) / (k1 - k2);
			return new PointF(x, x*k1 + b1);
		}
		private float[] GetLineParam(PointF p1, PointF p2)
		{
			float k = (p2.Y - p1.Y) / (p2.X - p1.X);
			return new float[] { k, -p1.X * k + p1.Y };
		}
		private bool IsIntersectionBeyondSegments(DataLine first, DataLine second, PointF point)
		{
			return !((IsPointInSegment(first.PointSart,first.PointEnd, point) || IsPointInSegment(first.PointEnd, first.PointSart, point))
				&& (IsPointInSegment(second.PointSart, second.PointEnd, point) || IsPointInSegment(second.PointEnd, second.PointSart, point)));
		}
		private bool IsPointBetweenTwoPoint(float start, float end, float p)
		{
			return (start < p && p < end) || (start > p && p > end);
		}
		private bool IsPointInSegment(PointF start, PointF end, PointF p)
		{
			return IsPointBetweenTwoPoint(start.X, end.X, p.X)
				&& IsPointBetweenTwoPoint(start.Y, end.Y, p.Y);
		}
	}
}
