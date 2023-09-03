using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisAbstrFabric
{
    public partial class Form1 : Form
    {
        public int verticalCell, horizontalCell, size = 25;
        public static Brush shapeCol;
        public Form1()
        {
            InitializeComponent();          
                     
        }

        public void Init()
        {
            InitMap();
            
            curShape = new TetrShape(3, 0);
            DrawShape();
            this.KeyUp += new KeyEventHandler(keyFunc);
            timer1.Start();
        }
        public void StartGame()
        {
            Init();

        }
        class TetrShape
        {
            public int[,] matrix = new int[3,3];
            Shape shape = new Shape(new ConcreteShape());
            public int x;
            public int y;
            public TetrShape(int _x, int _y)
            {
                matrix = shape.ShForm();
                shapeCol = shape.ShColor();
                x = _x;
                y = _y;
            }
            public void MoveDown()
            {
                y++;
            }
            public void MoveRight()
            {
                x++;
            }
            public void MoveLeft()
            {
                x--;
            }
            public void CreateNewShape(int _x, int _y)
            {
                x = _x;
                y = _y;
                Shape shape = new Shape(new ConcreteShape());
                matrix = shape.ShForm();
                shapeCol = shape.ShColor();
            }
        }

        
        public int[,] map;
        TetrShape curShape;

        private void timer1_Tick(object sender, EventArgs e)
        {
            ResetArea();

            if (!Collide())
            {
                curShape.MoveDown();
                
            }
            else
            {
                DrawShape();
                SliceMap();
                curShape.CreateNewShape(3, 0);
            }
            DrawShape();
            Invalidate();
          
        }


        public void DrawMap(Graphics g)
        {
            for(int i=0; i<= verticalCell; i++)
            {
                g.DrawLine(Pens.Black, new Point(50, 100 + i * size), new Point(50 + horizontalCell * size, 100 + i * size));
            }
            for (int i = 0; i <= horizontalCell; i++)
            {
                g.DrawLine(Pens.Black, new Point(50 + i * size, 100), new Point(50 + i * size, 100 + verticalCell * size));
            }
        }
        public void DrawShape(Graphics e)
        {

            for (int i = 0; i < verticalCell; i++)
            {
                for (int j = 0; j < horizontalCell; j++)
                {
                    if (map[i, j] == 1) 
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + j * (size) + 1, 100 + i * (size) + 1, size - 1, size - 1));
                       
                    }
                    if (map[i, j] == 2)
                    {
                        e.FillRectangle(Brushes.Green, new Rectangle(50 + j * (size) + 1, 100 + i * (size) + 1, size - 1, size - 1));

                    }
                    if (map[i, j] == 3)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(50 + j * (size) + 1, 100 + i * (size) + 1, size - 1, size - 1));

                    }
                }
            }
        }
        public void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawShape(e.Graphics);
        }

        public void InitMap()
        {
            map = new int[verticalCell, horizontalCell];
            for (int i = 0; i < verticalCell; i++)
            {
                for (int j = 0; j < horizontalCell; j++)
                {
                    map[i, j] = 0;
                }
            }

        }
        public void DrawShape()
        {
            for (int i = curShape.y; i < curShape.y + 3; i++)
            {
                for (int j = curShape.x; j < curShape.x + 3; j++)
                {
                    if (curShape.matrix[i - curShape.y, j - curShape.x] != 0 && i < 20)
                    {
                        if (shapeCol == Brushes.Red)
                            map[i, j] = curShape.matrix[i - curShape.y, j - curShape.x];
                        if (shapeCol == Brushes.Green)
                            map[i, j] = curShape.matrix[i - curShape.y, j - curShape.x]+1;
                        if (shapeCol == Brushes.Blue)
                            map[i, j] = curShape.matrix[i - curShape.y, j - curShape.x]+2;
                    }
                }
            }
        }


        public void ResetArea()
        {
            for (int i = curShape.y; i < curShape.y + 3; i++)
            {
                for (int j = curShape.x; j < curShape.x + 3; j++)
                {
                    if (i >= 0 && j >= 0 && i < verticalCell && j < horizontalCell)
                    {
                        if (curShape.matrix[i - curShape.y, j - curShape.x] != 0)
                        {
                            map[i, j] = 0;
                        }
                    }
                }
            }
        }
        public bool Collide()
        {
            for (int i = curShape.y + 2; i >= curShape.y; i--)
            {
                for (int j = curShape.x; j < curShape.x + 3; j++)
                {
                    if (curShape.matrix[i - curShape.y, j - curShape.x] != 0)
                    {
                        if (i + 1 == verticalCell)
                            return true;
                        if (map[i + 1, j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                

                case Keys.Right:
                    if (!CollideHor(1))
                    {
                        ResetArea();
                        curShape.MoveRight();
                        DrawShape();
                        Invalidate();
                    }
                    break;
                case Keys.Left:
                    if (!CollideHor(-1))
                    {
                        ResetArea();
                        curShape.MoveLeft();
                        DrawShape();
                        Invalidate();
                    }
                    break;
            }
        }
        public bool CollideHor(int dir)
        {
            for (int i = curShape.y; i < curShape.y + 3; i++)
            {
                for (int j = curShape.x; j < curShape.x + 3; j++)
                {
                    if (curShape.matrix[i - curShape.y, j - curShape.x] != 0)
                    {
                        if (j + 1 * dir > horizontalCell-1 || j + 1 * dir < 0)
                            return true;

                        if (map[i, j + 1 * dir] != 0)
                        {
                            if (j - curShape.x + 1 * dir >= 3 || j - curShape.x + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (curShape.matrix[i - curShape.y, j - curShape.x + 1 * dir] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }



        public int linesRemoved = 0;
        public void SliceMap()
        {
            int count = 0;
            int curRemovedLines = 0;
            for (int i = 0; i < verticalCell; i++)
            {
                count = 0;
                for (int j = 0; j < horizontalCell; j++)
                {
                    if (map[i, j] != 0)
                        count++;
                }
                if (count == horizontalCell)
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < horizontalCell; o++)
                        {
                            map[k, o] = map[k - 1, o];
                        }
                    }
                }
            }           
            linesRemoved += curRemovedLines;
            LabelVirus.Text = Convert.ToString(linesRemoved);
        }
    }
}
