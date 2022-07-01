using SharpGL;
using System.Diagnostics;

namespace _19120285_BT3
{
    public partial class Form1 : Form
    {
        List<Shape> listShapes; // Danh sách hình cần vẽ
        List<Point> listPoints; // Danh sách đỉnh của đa giác hiện tại.
        Shape _currentShape;    // Hình đang vẽ hiện tại
        Color _borderColor; // Màu cạnh
        Color _fillingColor; // Màu tô
        int _lineWidth;  // Kích thước nét vẽ
        bool isDrawing;     // Kiểm tra người dùng có đang vẽ hình không
        bool newShape;  // Kiểm tra người dùng có vẽ hình mới chưa
        bool checkDrawed;   // Kiểm tra người dùng đã vẽ hình nào chưa
        bool checkPolygon;  // Kiểm tra có đang vẽ polygon không
        bool checkSeclected;    // Kiểm tra có hình nào đang được chọn không
        int _currenControlPoint;    // Điểm điều khiển đang chọn
        int mode;
        /*
            Chế độ đang chọn:
            0 - Chọn hình
            1 - đoạn thẳng
            2 - hình chữ nhật
            3 - hình vuông
            4 - hình ellipse
            5 - hình tròn
            6 - hình tam giác đều
            7 - Hình ngũ giác đều
            8 - Hình lục giác đều
            9 - Hình đa giác
        */

        Point pStart;
        Point pEnd;
        OpenGL gl;
        Affine transform;
        Stopwatch borderTime;   // Đo thời gian vẽ cạnh
        bool checkBorderTime; // Kiểm tra hình đã vẽ xong chưa để dừng việc đo

        public Form1()
        {
            InitializeComponent();

            listShapes = new List<Shape>();
            listPoints = new List<Point>();
            _currentShape = new Shape();
            _borderColor = Color.Black;
            _fillingColor = Color.White;
            _lineWidth = 1;
            isDrawing = false;
            newShape = false;
            checkPolygon = false;
            checkPolygon = false;
            checkSeclected = false;
            _currenControlPoint = -1;
            mode = 0;
            transform = new Affine();
            borderTime = new Stopwatch();
            checkBorderTime = false;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(1, 1, 1, 0);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //// Get the OpenGL object.
            //OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            numericUpDown_LineWidth.Value = _lineWidth;

            if (newShape)
            {
                // Clear the color and depth buffer.
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                // Vẽ hình có trong danh sách
                for (int i = 0; i < listShapes.Count; i++)
                {
                    listShapes[i].DrawShape(gl);
                }

                // Vẽ hình đang xét
                if (mode != 0)
                {
                    switch (mode)
                    {
                        case 1:
                            {
                                _currentShape = new Line(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 2:
                            {
                                _currentShape = new Rectangle(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 3:
                            {
                                _currentShape = new Square(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 4:
                            {
                                _currentShape = new Ellipse(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 5:
                            {
                                _currentShape = new Circle(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 6:
                            {
                                _currentShape = new EquilateralTriangle(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 7:
                            {
                                _currentShape = new EquilateralPentagon(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 8:
                            {
                                _currentShape = new EquilateralHexagon(pStart, pEnd);
                                _currentShape.SetControlPoint();
                                break;
                            }
                        case 9:
                            {
                                _currentShape = new Polygon(listPoints);
                                _currentShape.SetControlPoint();
                                break;
                            }
                    }
                }
                else
                {
                    if (_currenControlPoint != -1 && checkSeclected)
                    {
                        transform.TransformShape(ref _currentShape, pStart, pEnd, _currenControlPoint);
                    }
                    
                    


                    // Đưa các thông số cho hình
                    _currentShape.SetLineWidth(_lineWidth);
                    _currentShape.SetBorderColor(_borderColor);
                    _currentShape.SetFillingColor(_fillingColor);

                    _currentShape.DrawControlPoint(gl);
                }

                // Tính thời gian vẽ và bắt đầu vẽ
                if (checkBorderTime) { borderTime.Start(); }
                _currentShape.DrawShape(gl);
                if (checkBorderTime)
                {
                    tb_BorderTime.Text = borderTime.Elapsed.ToString();
                    borderTime.Reset();
                    checkBorderTime = false;
                }

                gl.Flush();// Thực hiện lệnh vẽ ngay lập tức thay vì đợi sau 1 khoảng thời gian
            }

            // Nếu không còn vẽ polygon thì xoá list point của polygon để tránh bị cộng dồn với lần vẽ sau
            if (!checkPolygon)
            {
                listPoints.Clear();
            }
        }

        // Xác định người dùng vẽ hình mới và đưa hình hiện tại vào list
        private void drawNewShape()
        {
            if (checkDrawed)
            {
                if (newShape)
                {
                    listShapes.Add(_currentShape);
                    _currentShape = new Shape();
                }
                newShape = false;
            }
        }

        private void button_BorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialogBorder.ShowDialog() == DialogResult.OK)
            {
                _borderColor = colorDialogBorder.Color;
            }
        }

        private void button_FillColor_Click(object sender, EventArgs e)
        {
            if (colorDialogFill.ShowDialog() == DialogResult.OK)
            {
                _borderColor = colorDialogFill.Color;
            }
        }

        private void numericUpDown_LineWidth_ValueChanged(object sender, EventArgs e)
        {
            _lineWidth = (int)numericUpDown_LineWidth.Value;
        }

        private void button_Line_Click(object sender, EventArgs e)
        {
            mode = 1;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            mode = 2;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Square_Click(object sender, EventArgs e)
        {
            mode = 3;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            mode = 4;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            mode = 5;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            mode = 6;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Pentagon_Click(object sender, EventArgs e)
        {
            mode = 7;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Hexagon_Click(object sender, EventArgs e)
        {
            mode = 8;
            checkPolygon = false;
            drawNewShape();
        }

        private void button_Polygon_Click(object sender, EventArgs e)
        {
            mode = 9;
            checkPolygon = true;
            drawNewShape();
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkPolygon)
            {
                drawNewShape();
            }

            pStart = e.Location;
            pEnd = pStart;
            isDrawing = true;
            newShape = true;
            if (mode != 0)
            {
                checkDrawed = true;
            }
            else
            {
                for (int i = 0; i < listShapes.Count; i++)
                {
                    _currenControlPoint = listShapes[i].CheckControlPoint(pStart);
                    if (_currenControlPoint != -1)
                    {
                        checkSeclected = true;
                        _currentShape = listShapes[i];
                        _borderColor = _currentShape.GetBorderColor();
                        _fillingColor = _currentShape.GetFillColor();
                        _lineWidth = _currentShape.GetLineWidth();
                        listShapes.RemoveAt(i);
                        break;
                    }
                }
            }

            if (checkPolygon)
            {
                if (e.Button == MouseButtons.Right)
                {
                    drawNewShape();
                    listPoints.Clear();
                }
                else
                {
                    listPoints.Add(pStart);
                }
            }
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                pEnd = e.Location;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
            isDrawing = false;
            checkSeclected = false;
            checkBorderTime = true;
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            mode = 0;
            checkPolygon = false;
            drawNewShape();
        }

    }
}