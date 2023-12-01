using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.WinForms;

namespace Lab7_OpenTk
{
    public partial class Form1 : Form
    {

        private Random random = new Random();
        private float[] data;

        public Form1()
        {
            InitializeComponent();
            InitializeOpenGL();
            data = GenerateRandomData();
            timer1.Interval = 1000;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data = GenerateRandomData();
            glControl.Invalidate();
        }

        private float[] GenerateRandomData()
        {
            float[] newData = new float[10];
            for (int i = 0; i < newData.Length; i++)
            {
                newData[i] = random.Next(1, 100);
            }
            return newData;
        }

        private void InitializeOpenGL()
        {
            glControl.Paint += GlControl_Paint;
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            DrawBarChart();
            glControl.SwapBuffers();
        }

        private void DrawBarChart()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, 10, 0, 100, -1, 1);

            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < data.Length; i++)
            {
                GL.Color3(Color.FromArgb(0, 255, 0));
                GL.Vertex2(i, 0);
                GL.Vertex2(i + 0.8, 0);
                GL.Vertex2(i + 0.8, data[i]);
                GL.Vertex2(i, data[i]);
            }
            GL.End();
        }
    }
}