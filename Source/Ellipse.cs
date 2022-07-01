using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Ellipse : Shape
    {
        // Tâm và hai bán trục x,y
        private Point center;
        private int rx;
        private int ry;

        public Ellipse(Point _pStart, Point _pEnd)
        {
            base.SetPoint(_pStart, _pEnd);
            // Tìm tâm của hình chữ nhật tạo ra từ 2 điểm đầu vào, đó là tâm của hình ellipse
            center.X = (int)Math.Round((_pStart.X + _pEnd.X) * 1.0 / 2);
            center.Y = (int)Math.Round((_pStart.Y + _pEnd.Y) * 1.0 / 2);
            // Độ dài bán trục tính từ tâm tới cạnh của hình chữ nhật
            rx = Math.Abs(center.X - _pStart.X);
            ry = Math.Abs(center.Y - _pStart.Y);
        }

        public override void SetControlPoint()
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            max_x = center.X + rx;
            max_y = center.Y + ry;
            min_x = center.X - rx;
            min_y = center.Y - ry;
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

            // Giả sử hình đang vẽ là hình Ellipse tâm (0, 0)
            int X = 0;
            int Y = ry;

            // Giá trị vẽ thật là hình Ellipse tâm (X, Y)
            int X_draw = X + center.X;
            int Y_draw = Y + center.Y;
            gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

            // Vẽ điểm (0, -ry)
            {
                X_draw = X + center.X;
                Y_draw = -Y + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
            }

            double rx2 = rx * rx;
            double ry2 = ry * ry;
            double p = ry2 - rx2 * ry + rx2 * 1.0 / 4;
            // Vẽ đường Ellipse bằng thuật toán Bresenham 
            while ((2 * ry2 * X) < (2 * rx2 * Y))
            {
                // Vẽ phần trên của góc phần tư đầu tiên
                X++;
                if (p < 0)
                {
                    p += 2 * ry2 * X + ry2;
                }
                else
                {
                    Y--;
                    p += 2 * ry2 * X + ry2 - 2 * rx2 * Y;
                }
                X_draw = X + center.X;
                Y_draw = Y + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

                // Vẽ các điểm đối xứng
                // Điểm đối xứng với (X, Y) qua x = center.X;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị X
                    _X = -_X;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua y = center.Y;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị Y
                    _Y = -_Y;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua x = center.X và y = center.Y;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị X
                    _X = -_X;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị Y
                    _Y = -_Y;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
            }

            // Vẽ phần dưới của góc phần tư đầu tiên
            p = ry2 * (X + 0.5) * (X + 0.5) + rx2 * (Y - 1) * (Y - 1) - rx2 * ry2;
            while (Y != 0)
            {
                Y--;
                if (p > 0)
                {
                    p += rx2 - 2 * rx2 * Y;
                }
                else
                {
                    X++;
                    p += 2 * ry2 * X + rx2 - 2 * rx2 * Y;
                }
                X_draw = X + center.X;
                Y_draw = Y + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

                // Vẽ các điểm đối xứng
                // Điểm đối xứng với (X, Y) qua x = center.X;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị X
                    _X = -_X;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua y = center.Y;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị Y
                    _Y = -_Y;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua x = center.X và y = center.Y;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị X
                    _X = -_X;

                    // Đưa toạ độ tâm về (0,0) và đổi dấu giá trị Y
                    _Y = -_Y;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
            }

            gl.End();
        }
    }
}
