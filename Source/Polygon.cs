using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Polygon : Shape
    {
        // Danh sách các đỉnh của đa giác
        private List<Point> listPoint = new();

        // Constructor with parameter list points
        public Polygon(List<Point> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                listPoint.Add(list[i]);
            }
        }

        public override void SetControlPoint()
        {
            if (listPoint.Count < 2)
                return;

            int max_x = listPoint[0].X;
            int max_y = listPoint[0].Y;
            int min_x = listPoint[0].X;
            int min_y = listPoint[0].Y;
            int mid_x;
            int mid_y;

            for (int i = 1; i < listPoint.Count; i++)
            {
                if (listPoint[i].X > max_x)
                    max_x = listPoint[i].X;
                if (listPoint[i].X < min_x)
                    min_x = listPoint[i].X;
                if (listPoint[i].Y > max_y)
                    max_y = listPoint[i].Y;
                if (listPoint[i].Y < min_y)
                    min_y = listPoint[i].Y;
            }
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
            // Vẽ các đoạn nối các đỉnh của đa giác
            for (int i = 0; i < listPoint.Count - 1; i++)
            {
                Shape line = new Line(listPoint[i], listPoint[i + 1]);
                line.SetLineWidth(lineWidth);
                line.SetBorderColor(borderColor);
                line.SetFillingColor(fillingColor);
                line.DrawShape(gl);
            }
            if (listPoint.Count > 2)
            {
                // Vẽ đoạn nối điểm đầu và điểm cuối của danh sách
                Shape line_last = new Line(listPoint[listPoint.Count() - 1], listPoint[0]);
                line_last.SetLineWidth(lineWidth);
                line_last.SetBorderColor(borderColor);
                line_last.SetFillingColor(fillingColor);
                line_last.DrawShape(gl);
            }
        }

        public override List<Point> GetListPoint()
        {
            return listPoint;
        }
    }
}
