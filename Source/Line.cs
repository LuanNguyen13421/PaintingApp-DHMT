using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Line : Shape
    {
        public Line(Point point1, Point point2)
        {
            base.SetPoint(point1, point2);
        }

        public override void SetControlPoint()
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            if (pStart.X > pEnd.X)
            {
                max_x = pStart.X;
                min_x = pEnd.X;
            }
            else
            {
                max_x = pEnd.X;
                min_x = pStart.X;
            }

            if (pStart.Y > pEnd.Y)
            {
                max_y = pStart.Y;
                min_y = pEnd.Y;
            }
            else
            {
                max_y = pEnd.Y;
                min_y= pStart.Y;
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
            // Áp dụng màu viền người dùng chọn vào hình vẽ
            gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
            // Áp dụng kích thước
            gl.PointSize(lineWidth);
            // Làm mịn pixel để vẽ tròn hơn
            gl.Enable(OpenGL.GL_POINT_SMOOTH);
            // Bắt đầu vẽ
            gl.Begin(OpenGL.GL_POINTS);

            // Điểm hiện tại đang xét
            int X = pStart.X;
            int Y = pStart.Y;

            //  stepX, stepX là dấu của dx, dy và để xác định hướng đi của đoạn thăng
            int dx = pEnd.X - pStart.X;
            int dy = pEnd.Y - pStart.Y;
            int stepX, stepY;

            // Gắn dấu cho stepX, stepY
            if (dx < 0)
            {
                stepX = -1;
                dx = -dx;
            }
            else stepX = 1;
            if (dy < 0)
            {
                stepY = -1;
                dy = -dy;
            }
            else stepY = 1;

            // Vẽ đoạn thẳng bằng thuật toán Bresenham
            gl.Vertex(X, gl.RenderContextProvider.Height - Y);
            if (dx > dy)
            {
                int p = 2 * dy - dx;
                while (X != pEnd.X)
                {
                    if (p >= 0)
                    {
                        Y += stepY;
                        p += 2 * (dy - dx);
                    }
                    else p += 2 * dy;
                    X += stepX;
                    gl.Vertex(X, gl.RenderContextProvider.Height - Y);
                }
            }
            else
            {
                int p = 2 * dx - dy;
                while (Y != pEnd.Y)
                {
                    if (p >= 0)
                    {
                        X += stepX;
                        p += 2 * (dx - dy);
                    }
                    else p += 2 * dx;
                    Y += stepY;
                    gl.Vertex(X, gl.RenderContextProvider.Height - Y);
                }
            }

            gl.End();
        }
    }
}
