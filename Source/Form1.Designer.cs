namespace _19120285_BT3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.colorDialogBorder = new System.Windows.Forms.ColorDialog();
            this.colorDialogFill = new System.Windows.Forms.ColorDialog();
            this.button_BorderColor = new System.Windows.Forms.Button();
            this.numericUpDown_LineWidth = new System.Windows.Forms.NumericUpDown();
            this.button_Line = new System.Windows.Forms.Button();
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.button_Square = new System.Windows.Forms.Button();
            this.button_Ellipse = new System.Windows.Forms.Button();
            this.button_Circle = new System.Windows.Forms.Button();
            this.button_Triangle = new System.Windows.Forms.Button();
            this.button_Pentagon = new System.Windows.Forms.Button();
            this.button_Hexagon = new System.Windows.Forms.Button();
            this.button_Polygon = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_BorderTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.BackColor = System.Drawing.SystemColors.Control;
            this.openGLControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.Control;
            this.openGLControl.Location = new System.Drawing.Point(13, 84);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(856, 555);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // colorDialogFill
            // 
            this.colorDialogFill.Color = System.Drawing.Color.White;
            // 
            // button_BorderColor
            // 
            this.button_BorderColor.Location = new System.Drawing.Point(741, 12);
            this.button_BorderColor.Name = "button_BorderColor";
            this.button_BorderColor.Size = new System.Drawing.Size(128, 29);
            this.button_BorderColor.TabIndex = 1;
            this.button_BorderColor.Text = "Border Color";
            this.button_BorderColor.UseVisualStyleBackColor = true;
            this.button_BorderColor.Click += new System.EventHandler(this.button_BorderColor_Click);
            // 
            // numericUpDown_LineWidth
            // 
            this.numericUpDown_LineWidth.Location = new System.Drawing.Point(786, 49);
            this.numericUpDown_LineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_LineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_LineWidth.Name = "numericUpDown_LineWidth";
            this.numericUpDown_LineWidth.Size = new System.Drawing.Size(84, 27);
            this.numericUpDown_LineWidth.TabIndex = 3;
            this.numericUpDown_LineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_LineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_LineWidth.ValueChanged += new System.EventHandler(this.numericUpDown_LineWidth_ValueChanged);
            // 
            // button_Line
            // 
            this.button_Line.Location = new System.Drawing.Point(13, 12);
            this.button_Line.Name = "button_Line";
            this.button_Line.Size = new System.Drawing.Size(94, 29);
            this.button_Line.TabIndex = 4;
            this.button_Line.Text = "Line";
            this.button_Line.UseVisualStyleBackColor = true;
            this.button_Line.Click += new System.EventHandler(this.button_Line_Click);
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.Location = new System.Drawing.Point(113, 12);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(94, 29);
            this.button_Rectangle.TabIndex = 5;
            this.button_Rectangle.Text = "Rectangle";
            this.button_Rectangle.UseVisualStyleBackColor = true;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // button_Square
            // 
            this.button_Square.Location = new System.Drawing.Point(213, 12);
            this.button_Square.Name = "button_Square";
            this.button_Square.Size = new System.Drawing.Size(94, 29);
            this.button_Square.TabIndex = 6;
            this.button_Square.Text = "Square";
            this.button_Square.UseVisualStyleBackColor = true;
            this.button_Square.Click += new System.EventHandler(this.button_Square_Click);
            // 
            // button_Ellipse
            // 
            this.button_Ellipse.Location = new System.Drawing.Point(313, 12);
            this.button_Ellipse.Name = "button_Ellipse";
            this.button_Ellipse.Size = new System.Drawing.Size(94, 29);
            this.button_Ellipse.TabIndex = 7;
            this.button_Ellipse.Text = "Ellipse";
            this.button_Ellipse.UseVisualStyleBackColor = true;
            this.button_Ellipse.Click += new System.EventHandler(this.button_Ellipse_Click);
            // 
            // button_Circle
            // 
            this.button_Circle.Location = new System.Drawing.Point(413, 12);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(94, 29);
            this.button_Circle.TabIndex = 8;
            this.button_Circle.Text = "Circle";
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // button_Triangle
            // 
            this.button_Triangle.Location = new System.Drawing.Point(13, 47);
            this.button_Triangle.Name = "button_Triangle";
            this.button_Triangle.Size = new System.Drawing.Size(120, 29);
            this.button_Triangle.TabIndex = 9;
            this.button_Triangle.Text = "Triangle";
            this.button_Triangle.UseVisualStyleBackColor = true;
            this.button_Triangle.Click += new System.EventHandler(this.button_Triangle_Click);
            // 
            // button_Pentagon
            // 
            this.button_Pentagon.Location = new System.Drawing.Point(139, 47);
            this.button_Pentagon.Name = "button_Pentagon";
            this.button_Pentagon.Size = new System.Drawing.Size(117, 29);
            this.button_Pentagon.TabIndex = 10;
            this.button_Pentagon.Text = "Pentagon";
            this.button_Pentagon.UseVisualStyleBackColor = true;
            this.button_Pentagon.Click += new System.EventHandler(this.button_Pentagon_Click);
            // 
            // button_Hexagon
            // 
            this.button_Hexagon.Location = new System.Drawing.Point(262, 47);
            this.button_Hexagon.Name = "button_Hexagon";
            this.button_Hexagon.Size = new System.Drawing.Size(117, 29);
            this.button_Hexagon.TabIndex = 11;
            this.button_Hexagon.Text = "Hexagon";
            this.button_Hexagon.UseVisualStyleBackColor = true;
            this.button_Hexagon.Click += new System.EventHandler(this.button_Hexagon_Click);
            // 
            // button_Polygon
            // 
            this.button_Polygon.Location = new System.Drawing.Point(385, 47);
            this.button_Polygon.Name = "button_Polygon";
            this.button_Polygon.Size = new System.Drawing.Size(122, 29);
            this.button_Polygon.TabIndex = 12;
            this.button_Polygon.Text = "Polygon";
            this.button_Polygon.UseVisualStyleBackColor = true;
            this.button_Polygon.Click += new System.EventHandler(this.button_Polygon_Click);
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(578, 12);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(94, 29);
            this.button_Select.TabIndex = 13;
            this.button_Select.Text = "Select";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Size:";
            // 
            // tb_BorderTime
            // 
            this.tb_BorderTime.Location = new System.Drawing.Point(605, 49);
            this.tb_BorderTime.Name = "tb_BorderTime";
            this.tb_BorderTime.ReadOnly = true;
            this.tb_BorderTime.Size = new System.Drawing.Size(130, 27);
            this.tb_BorderTime.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Draw Time:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_BorderTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.button_Polygon);
            this.Controls.Add(this.button_Hexagon);
            this.Controls.Add(this.button_Pentagon);
            this.Controls.Add(this.button_Triangle);
            this.Controls.Add(this.button_Circle);
            this.Controls.Add(this.button_Ellipse);
            this.Controls.Add(this.button_Square);
            this.Controls.Add(this.button_Rectangle);
            this.Controls.Add(this.button_Line);
            this.Controls.Add(this.numericUpDown_LineWidth);
            this.Controls.Add(this.button_BorderColor);
            this.Controls.Add(this.openGLControl);
            this.Name = "Form1";
            this.Text = "19120285";
            this.Click += new System.EventHandler(this.button_Pentagon_Click);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private ColorDialog colorDialogBorder;
        private ColorDialog colorDialogFill;
        private Button button_BorderColor;
        private NumericUpDown numericUpDown_LineWidth;
        private Button button_Line;
        private Button button_Rectangle;
        private Button button_Square;
        private Button button_Ellipse;
        private Button button_Circle;
        private Button button_Triangle;
        private Button button_Pentagon;
        private Button button_Hexagon;
        private Button button_Polygon;
        private Button button_Select;
        private Label label1;
        private TextBox tb_BorderTime;
        private Label label2;
    }
}