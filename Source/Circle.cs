using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Circle : Shape
    {
        // Tâm và bán kính
        private Point center;
        private double radius;

        public Circle(Point _pStart, Point _pEnd)
        {
            base.SetPoint(_pStart, _pEnd);
            // Tìm tâm của hình vuông tạo ra từ 2 điểm đầu vào, đó là tâm của hình tròn
            center.X = (int)Math.Round((_pStart.X + _pEnd.X) * 1.0 / 2);
            center.Y = (int)Math.Round((_pStart.Y + _pEnd.Y) * 1.0 / 2);
            // Tìm độ dài cạnh của hình, đó là đường kính của hình tròn
            int dx = Math.Abs(_pStart.X - _pEnd.X);
            int dy = Math.Abs(_pStart.Y - _pEnd.Y);
            if (dx < dy)
                radius = dx * 1.0 / 2;
            else radius = dy * 1.0 / 2;
        }

        public override void SetControlPoint()
        {
            int max_x;
            int max_y;
            int min_x;
            int min_y;
            int mid_x;
            int mid_y;

            max_x = (int)Math.Round(center.X + radius);
            max_y = (int)Math.Round(center.Y + radius);
            min_x = (int)Math.Round(center.X - radius);
            min_y = (int)Math.Round(center.Y - radius);
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

            // Giả sử hình đang vẽ là hình tròn tâm (0, 0)
            int X = 0;
            int Y = (int)Math.Round(radius);

            // Giá trị vẽ thật là hình tròn tâm (X, Y)
            int X_draw = X + center.X;
            int Y_draw = Y + center.Y;
            gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

            // Vẽ 3 điểm (0, -radius), (radius, 0), (-radius, 0)
            {
                X_draw = X + center.X;
                Y_draw = -Y + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

                X_draw = Y + center.X;
                Y_draw = X + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);

                X_draw = -Y + center.X;
                Y_draw = X + center.Y;
                gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
            }

            int P = (int)Math.Round(5.0 / 4 - radius);
            // Vẽ đường tròn bằng thuật toán Bresenham 
            while (X < Y)
            {
                X++;
                if (P < 0)
                {
                    P += 2 * X + 1;
                }
                else
                {
                    Y--;
                    P += 2 * X - 2 * Y + 1;
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
                // Điểm đối xứng với (X, Y) qua y = x + (center.X + center.Y);
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0) và đổi giá trị X, Y cho nhau
                    int tmp = _X;
                    _X = _Y;
                    _Y = tmp;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua y = - x + (center.X + center.Y);
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0), đổi giá trị X, Y cho nhau và đổi dấu cả 2
                    int tmp = _X;
                    _X = -_Y;
                    _Y = -tmp;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua y = x + (center.X + center.Y) và y = center.Y;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0), đổi giá trị X, Y cho nhau và đổi dấu giá trị Y
                    int tmp = _X;
                    _X = _Y;
                    _Y = -tmp;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }
                // Điểm đối xứng với (X, Y) qua y = - x + (center.X + center.Y) và x = center.X;
                {
                    int _X = X;
                    int _Y = Y;

                    // Đưa toạ độ tâm về (0,0), đổi giá trị X, Y cho nhau và đổi dấu giá trị X
                    int tmp = _X;
                    _X = -_Y;
                    _Y = tmp;

                    X_draw = _X + center.X;
                    Y_draw = _Y + center.Y;
                    gl.Vertex(X_draw, gl.RenderContextProvider.Height - Y_draw);
                }

            }

            gl.End();
        }
    }
}
