using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class EquilateralHexagon : Shape
    {
        // Sáu đỉnh của ngũ giác đều tính từ trên xuống
        private Point topPoint;
        private Point leftTopPoint;
        private Point rightTopPoint;
        private Point leftBottomPoint;
        private Point rightBottomPoint;
        private Point bottomPoint;

        public EquilateralHexagon(Point _pStart, Point _pEnd)
        {
            base.SetPoint(_pStart, _pEnd);
            // Tìm tâm của hình chữ nhật tạo ra từ 2 điểm đầu vào, đó là tâm của hình tròn ngoại tiếp lục giác đều
            int centerX = (int)Math.Round((_pStart.X + _pEnd.X) * 1.0 / 2);
            int centerY = (int)Math.Round((_pStart.Y + _pEnd.Y) * 1.0 / 2);
            // Tìm độ dài ngắn hơn giữa 2 cạnh kề của hình chữ nhật, đó là đường kính của hình tròn ngoại tiếp lục giác đều
            // Từ đó suy ra độ dài tâm tới mỗi đỉnh của lục giác đều (bán kính đường tròn ngoại tiếp)
            int dx = Math.Abs(_pStart.X - _pEnd.X);
            int dy = Math.Abs(_pStart.Y - _pEnd.Y);
            int length;
            if (dx < dy)
                length = (int)Math.Round(dx * 1.0 / 2);
            else length = (int)Math.Round(dy * 1.0 / 2);

            // Gán 6 đỉnh của hình ngũ giác đều khi đã biết tâm, bán kính đường tròn ngoại tiếp
            topPoint.X = centerX;
            topPoint.Y = centerY - length;

            bottomPoint.X = centerX;
            bottomPoint.Y = centerY + length;

            leftTopPoint.X = (int)Math.Round(centerX - length * Math.Sqrt(3) / 2);
            leftTopPoint.Y = (int)Math.Round(centerY - length * 1.0 / 2);

            rightTopPoint.X = (int)Math.Round(centerX + length * Math.Sqrt(3) / 2);
            rightTopPoint.Y = (int)Math.Round(centerY - length * 1.0 / 2);

            leftBottomPoint.X = (int)Math.Round(centerX - length * Math.Sqrt(3) / 2);
            leftBottomPoint.Y = (int)Math.Round(centerY + length * 1.0 / 2);

            rightBottomPoint.X = (int)Math.Round(centerX + length * Math.Sqrt(3) / 2);
            rightBottomPoint.Y = (int)Math.Round(centerY + length * 1.0 / 2);
        }

        public override void SetControlPoint()
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            max_x = rightTopPoint.X;
            max_y = bottomPoint.Y;
            min_x = leftTopPoint.X;
            min_y = topPoint.Y;
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
            // Vẽ 6 đoạn thẳng nối 6 đỉnh
            Shape line1 = new Line(topPoint, leftTopPoint);
            Shape line2 = new Line(leftTopPoint, leftBottomPoint);
            Shape line3 = new Line(leftBottomPoint, bottomPoint);
            Shape line4 = new Line(bottomPoint, rightBottomPoint);
            Shape line5 = new Line(rightBottomPoint, rightTopPoint);
            Shape line6 = new Line(rightTopPoint, topPoint);

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

            line5.SetLineWidth(lineWidth);
            line5.SetBorderColor(borderColor);
            line5.SetFillingColor(fillingColor);
            line5.DrawShape(gl);

            line6.SetLineWidth(lineWidth);
            line6.SetBorderColor(borderColor);
            line6.SetFillingColor(fillingColor);
            line6.DrawShape(gl);
        }
    }
}
