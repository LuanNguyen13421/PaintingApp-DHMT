using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Square : Shape
    {
        // Bốn đỉnh của hình vuông
        private Point topLeftPoint;
        private Point topRightPoint;
        private Point bottomRightPoint;
        private Point bottomLeftPoint;

        public Square(Point _pStart, Point _pEnd)
        {
            base.SetPoint(_pStart, _pEnd);
            // Tìm tâm của hình chữ nhật tạo ra từ 2 điểm đầu vào, đó là tâm hình vuông
            int centerX = (int)Math.Round((_pStart.X + _pEnd.X) * 1.0 / 2);
            int centerY = (int)Math.Round((_pStart.Y + _pEnd.Y) * 1.0 / 2);
            // Tìm độ dài ngắn hơn giữa 2 cạnh kề của hình chữ nhật, đó là cạnh của hình vuông
            int dx = Math.Abs(_pStart.X - _pEnd.X);
            int dy = Math.Abs(_pStart.Y - _pEnd.Y);
            int edge;
            if (dx < dy)
                edge = dx;
            else edge = dy;
            // Gán 4 đỉnh của hình vuông khi đã biết tâm và độ dài cạnh
            topLeftPoint.X = (int)Math.Round(centerX - edge * 1.0 / 2);
            topLeftPoint.Y = (int)Math.Round(centerY - edge * 1.0 / 2);

            topRightPoint.X = (int)Math.Round(centerX + edge * 1.0 / 2);
            topRightPoint.Y = (int)Math.Round(centerY - edge * 1.0 / 2);

            bottomLeftPoint.X = (int)Math.Round(centerX - edge * 1.0 / 2);
            bottomLeftPoint.Y = (int)Math.Round(centerY + edge * 1.0 / 2);

            bottomRightPoint.X = (int)Math.Round(centerX + edge * 1.0 / 2);
            bottomRightPoint.Y = (int)Math.Round(centerY + edge * 1.0 / 2);
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
