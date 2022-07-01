using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120285_BT3
{
    internal class Shape
    {
        protected Point pStart;
        protected Point pEnd;
        protected Color borderColor = Color.Black;
        protected Color fillingColor = Color.White;
        protected int lineWidth = 1;
        protected List<Point> controlPoints = new();

        // Đặt điểm đầu và điểm cuối của hình
        public void SetPoint(Point x, Point y)
        {
            if (x.X < y.X)
            {
                pStart = x;
                pEnd = y;
            }
            else
            {
                pStart = y;
                pEnd = x;
            }
        }

        // Đặt điểm điều khiển (tuỳ vào hình mà có điểm điều khiển bao sát xung quanh)
        /* 
        Thứ tự các điểm điều khiển của một hình
                0 
        6       7       8

        4     Shape(9)  5

        1       2       3
         */
        public virtual void SetControlPoint()
        { }

        // Đặt màu viền
        public void SetBorderColor(Color color)
        {
            borderColor = color;
        }

        // Lấy màu viền
        public Color GetBorderColor()
        { return borderColor; }

        // Đặt màu tô
        public void SetFillingColor(Color color)
        {
            fillingColor = color;
        }

        // Lấy màu tô
        public Color GetFillColor()
        { return fillingColor; }

        // Đặt độ dày nét vẽ
        public void SetLineWidth(int width)
        {
            lineWidth = width;
        }

        // Lấy độ dày nét vẽ
        public int GetLineWidth()
        { return lineWidth; }

        // Hàm vẽ hình
        public virtual void DrawShape(OpenGL gl)
        { }

        // Hàm vẽ điểm điều khiển
        public void DrawControlPoint(OpenGL gl)
        {
            // Màu mặc định của điểm điều khiển là đen
            gl.Color(0.0f, 0.0f, 0.0f);
            // Kích thước mặc định của điểm điều khiển là 5
            gl.PointSize(5);
            // Làm mịn pixel để vẽ tròn hơn
            gl.Enable(OpenGL.GL_POINT_SMOOTH);
            // Bắt đầu vẽ
            gl.Begin(OpenGL.GL_POINTS);

            for (int i = 0; i < controlPoints.Count; i++)
            {
                gl.Vertex(controlPoints[i].X, gl.RenderContextProvider.Height - controlPoints[i].Y);
            }    

            gl.End();
        }

        // Kiểm tra điểm đang chọn có thuộc control point nào của hình không
        // Trả về vị trí control được chọn, nếu không thuộc control point thì trả về -1
        public int CheckControlPoint(Point point)
        {
            for (int i = 0;i < controlPoints.Count;i++)
            {
                if (Math.Abs(point.X - controlPoints[i].X) <= 5 && Math.Abs(point.Y - controlPoints[i].Y) <= 5)
                {
                    return i;
                }
            }
            return -1;
        }

        // Lấy điểm đầu
        public Point GetPStart()
        {
            return pStart;
        }

        // Lấy điểm cuối
        public Point GetPEnd()
        {
            return pEnd;
        }

        // Lấy danh sách điểm (dành riêng cho polygon)
        public virtual List<Point> GetListPoint()
        {
            return null;
        }

        // Kiểm tra điểm có thuộc hình hay không
        public bool CheckInsideShape(Point point)
        {
            if (controlPoints.Count == 0)
                return false;

            if (point.X < controlPoints[1].X + 10 && point.X > controlPoints[1].X - 10)
                return false;
            if (point.Y > controlPoints[2].Y - 10 && point.Y < controlPoints[7].Y + 10)
                return false;
            return true;
        }
    }
}
