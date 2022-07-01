using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Rectangle : Shape
    {
        // Bốn đỉnh của hình chữ nhật
        private Point topLeftPoint;
        private Point topRightPoint;
        private Point bottomRightPoint;
        private Point bottomLeftPoint;

        public Rectangle(Point _pStart, Point _pEnd)
        {
            base.SetPoint(_pStart, _pEnd);

            topRightPoint.X = pEnd.X;
            bottomRightPoint.X = pEnd.X;
            topLeftPoint.X = pStart.X;
            bottomLeftPoint.X = pStart.X;

            if (pStart.Y > pEnd.Y)
            {
                topRightPoint.Y = pEnd.Y;
                bottomRightPoint.Y = pStart.Y;
                topLeftPoint.Y = pEnd.Y;
                bottomLeftPoint.Y = pStart.Y;
            }
            else
            {
                topRightPoint.Y = pStart.Y;
                bottomRightPoint.Y = pEnd.Y;
                topLeftPoint.Y = pStart.Y;
                bottomLeftPoint.Y = pEnd.Y;
            }
        }

        public override void SetControlPoint()
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            max_x = topRightPoint.X;
            max_y = bottomRightPoint.Y;
            min_x = topLeftPoint.X;
            min_y = topLeftPoint.Y;
            mid_x = (max_x + min_x) / 2;
            mid_y = (max_y + min_y) / 2;

            Point point_0 = new Point(mid_x, min_y - 30);

            Point point_1 = new Point(min_x - 10, max_y + 10);
            Point point_2 = new Point(mid_x, max_y + 10);
            Point point_3 = new Point(max_x + 10, max_y + 10);

            Point point_4 = new Point(min_x - 10, mid_y);
            Point point_5 = new Point(max_x + 10, mid_y);

            Point point_6 = new Point(min_x - 10, min_y - 10);
            Point point_7 = new Point(mid_x, min_y - 10);
            Point point_8 = new Point(max_x + 10, min_y - 10);

            Point point_9 = new Point(mid_x, mid_y);

            controlPoints.Add(point_0);
            controlPoints.Add(point_1);
            controlPoints.Add(point_2);
            controlPoints.Add(point_3);
            controlPoints.Add(point_4);
            controlPoints.Add(point_5);
            controlPoints.Add(point_6);
            controlPoints.Add(point_7);
            controlPoints.Add(point_8);
            controlPoints.Add(point_9);
        }

        public override void DrawShape(OpenGL gl)
        {
            // Vẽ 4 đoạn thẳng nối 4 góc
            Shape line1 = new Line(topLeftPoint, topRightPoint);
            Shape line2 = new Line(topRightPoint, bottomRightPoint);
            Shape line3 = new Line(bottomRightPoint, bottomLeftPoint);
            Shape line4 = new Line(bottomLeftPoint, topLeftPoint);

            line1.SetLineWidth(lineWidth);
            line1.SetBorderColor(borderColor);
            line1.SetFillingColor(fillingColor);
            line1.DrawShape(gl);

            line2.SetLineWidth(lineWidth);
            line2.SetBorderColor(borderColor);
            line2.SetFillingColor(fillingColor);
            line2.DrawShape(gl);

            line3.SetLineWidth(lineWidth);
            line3.SetBorderColor(borderColor);
            line3.SetFillingColor(fillingColor);
            line3.DrawShape(gl);

            line4.SetLineWidth(lineWidth);
            line4.SetBorderColor(borderColor);
            line4.SetFillingColor(fillingColor);
            line4.DrawShape(gl);
        }
    }
}
