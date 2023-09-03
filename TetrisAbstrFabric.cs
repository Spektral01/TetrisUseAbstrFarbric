using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisAbstrFabric
{
    abstract class ShapeFactory //
    {
        public abstract ShapeForm CreateForm();
        public abstract ShapeColor CreateColor();
    }

    abstract class ShapeForm //
    {
        public abstract int[,] SetForm();
    }
    abstract class ShapeColor //
    {
        public abstract Brush SetColor();
    }

    class ConcreteShape:ShapeFactory //
    {
        public override ShapeForm CreateForm()
        {
            Random rnd = new Random();
            int shapeValue = rnd.Next(0, 5);
            switch (shapeValue)
            {
                case 0:
                    return new StickShapeForm();
                case 1:
                    return new SquareShapeForm();
                case 2:
                    return new TShapeForm();
                case 3:
                    return new ZShapeForm();
                case 4:
                    return new LShapeForm();
                default:
                    return new SquareShapeForm();
            }
            
        }
        public override ShapeColor CreateColor()
        {
            Random rnd = new Random();
            int colorValue = rnd.Next(0, 5);
            switch (colorValue)
            {
                case 0:
                    return new RedShapeColor();
                case 1:
                    return new BlueShapeColor();
                case 2:
                    return new GreenShapeColor();
                default:
                    return new RedShapeColor();
            }
        }
    }

    class Shape //
    {
        private ShapeColor shColor;
        private ShapeForm shForm;
        
        public Shape(ShapeFactory factory)
        {
            shColor = factory.CreateColor();
            shForm = factory.CreateForm();
        }
        public int[,] ShForm()
        {
            return shForm.SetForm();
        }
        public Brush ShColor()
        {
            return shColor.SetColor();
        }

    }

    class StickShapeForm : ShapeForm
    {
        public override int[,] SetForm()
        {
            int [,] matrix =
                { {0,1,0},
                {0,1,0},
                {0,1,0} };
            return matrix;
        }
    }

    class SquareShapeForm : ShapeForm
    {
        public override int[,] SetForm()
        {
            int[,] matrix =
                 { {0,0,0},
                {0,1,1},
                {0,1,1} };
            return matrix;
        }
    }
    class TShapeForm : ShapeForm
    {
        public override int[,] SetForm()
        {
            int[,] matrix =
                { {1,1,1},
                {0,1,0},
                {0,1,0} };
            return matrix;
        }
    }

    class ZShapeForm : ShapeForm
    {
        public override int[,] SetForm()
        {
            int[,] matrix =
                { {1,1,0},
                {0,1,1},
                {0,0,0} };
            return matrix;
        }
    }
    class LShapeForm : ShapeForm
    {
        public override int[,] SetForm()
        {
            int[,] matrix =
                { {0,1,0},
                {0,1,0},
                {0,1,1} };
            return matrix;
        }
    }
    class RedShapeColor : ShapeColor
    {
        public override Brush SetColor()
        {

            return Brushes.Red;
        }
    }
    class BlueShapeColor : ShapeColor
    {
        public override Brush SetColor()
        {
           return Brushes.Blue;
        }
    }
    class GreenShapeColor : ShapeColor
    {
        public override Brush SetColor()
        {
            return Brushes.Green;
        }
    }

}
