using System;
using System.Drawing;

namespace Demo07_WinForms
{
    public abstract class GraphicsPrimitive
    {
        public abstract void Draw(Graphics g);

        protected abstract Rectangle GetBoundingBox();

        protected virtual void DrawSelectionBox(Graphics g)
        {
            if (Selected)
            {
                Brush brush = new SolidBrush(Color.Black);

                // Draw 8 squares
                Rectangle boundingBox = GetBoundingBox();

                g.FillRectangle(brush, boundingBox.X, boundingBox.Y, 4, 4);
                g.FillRectangle(brush, (int)Math.Round(((boundingBox.X + boundingBox.Width) / 2m)), boundingBox.Y + boundingBox.Height, 4, 4);
                g.FillRectangle(brush, boundingBox.X, boundingBox.Y, 4, 4);

                g.FillRectangle(brush, boundingBox.X, boundingBox.Y, 4, 4);
                g.FillRectangle(brush, boundingBox.X + boundingBox.Width, (int)Math.Floor((boundingBox.Y + boundingBox.Height) / 2m), 4, 4);

                g.FillRectangle(brush, boundingBox.X, boundingBox.Y + boundingBox.Height, 4, 4);
                g.FillRectangle(brush, (int)Math.Round(((boundingBox.X + boundingBox.Width) / 2m)), boundingBox.Y + boundingBox.Height, 4, 4);
                g.FillRectangle(brush, boundingBox.X + boundingBox.Width, boundingBox.Y + boundingBox.Height, 4, 4);

            }
        }

        public Point Location { get; set; }

        public bool Selected { get; set; }
    }

    public abstract class BoundedGraphicsPrimitive : GraphicsPrimitive
    {
        protected override Rectangle GetBoundingBox()
        {
            return new Rectangle(Location, Size);
        }

        public Size Size { get; set; }
    }

    public class RectanglePrimitive: BoundedGraphicsPrimitive
    {
        public RectanglePrimitive()
        {
            Pen = new Pen(Color.Black); // Default pen is of black color
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen, new System.Drawing.Rectangle(Location, Size));

            if (Selected)
                DrawSelectionBox(g);
        }

        public Pen Pen { get; set; }
    }

    public class EllipsePrimitive : BoundedGraphicsPrimitive
    {
        public EllipsePrimitive()
        {
            Pen = new Pen(Color.Black); // Default pen is of black color
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, new System.Drawing.Rectangle(Location, Size));
        }

        public Pen Pen { get; set; }
    }

    public class TextPrimitive : BoundedGraphicsPrimitive
    {
        public TextPrimitive()
        {
            Brush = new SolidBrush(Color.Black); // Default pen is of black color
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(Text, Font, Brush, Location);
        }

        public Brush Brush { get; set; }

        public Font Font { get; set; }
        public string Text { get; set; }
    }

    //public class PolygonPrimitive : GraphicsPrimitive
    //{
    //    public PolygonPrimitive()
    //    {
    //        Pen = new Pen(Color.Black); // Default pen is of black color
    //    }

    //    public override void Draw(Graphics g)
    //    {
    //        g.DrawEllipse(Pen, new System.Drawing.Rectangle(Location, Size));
    //    }

    //    public Size Size { get; set; }

    //    public Brush Brush { get; set; }
    //    public Pen Pen { get; set; }
    //}



        //public abstract class Shape
        //{
        //    public abstract void Draw(Graphics g);
        //}

        //public class RectangleShape : Shape
        //{
        //    public RectangleShape()
        //    {
        //        Pen = new Pen(Color.Black);
        //    }

        //    public Pen Pen { get; set; }
        //    public Point Location { get; set; }
        //    public Size Size { get; set; }

        //    public override void Draw(Graphics g)
        //    {
        //        // g.FillRectangle()

        //        g.DrawRectangle(Pen,
        //            Location.X, Location.Y,
        //            Size.Width, Size.Height);
        //    }
        //}

        //public class EllipseShape : Shape
        //{
        //    public EllipseShape()
        //    {
        //        Pen = new Pen(Color.Black);
        //    }

        //    public override void Draw(Graphics g)
        //    {
        //        g.DrawEllipse(Pen,
        //            Location.X, Location.Y,
        //            Size.Width, Size.Height);

        //        if (Selected)
        //            DrawSelection(g);
        //    }

        //    public override void DrawSelection(Graphics g)
        //    {
        //        Pen selectionPen = new Pen(Color.Orange);

        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y - 2,
        //            4, 4);


        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y + Size.Height - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //            4, 4);
        //    }

        //    public Pen Pen { get; set; }
        //}

        //public class TextShape : Shape
        //{
        //    public TextShape()
        //    {
        //        Brush = new SolidBrush(Color.YellowGreen);
        //        Font = new Font("Arial", 12, FontStyle.Regular);
        //    }

        //    public override void Draw(Graphics g)
        //    {
        //        g.DrawString(Text, Font, Brush,
        //            new RectangleF(Location.X, Location.Y, Size.Width, Size.Height));

        //        if (Selected)
        //            DrawSelection(g);
        //    }

        //    public override void DrawSelection(Graphics g)
        //    {
        //        Pen selectionPen = new Pen(Color.Orange);

        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y - 2,
        //            4, 4);


        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y + Size.Height - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //            4, 4);
        //    }

        //    public Brush Brush { get; set; }

        //    public Font Font { get; set; }
        //    public string Text { get; set; }
        //}

        //public class LinesShape : Shape
        //{
        //    public LinesShape()
        //    {
        //        Pen = new Pen(Color.Black);
        //        Points = new List<Point>();
        //    }

        //    public override void Draw(Graphics g)
        //    {
        //        //g.DrawPath(Pen, new System.Drawing.Drawing2D.GraphicsPath());
        //        g.DrawLines(Pen, Points.ToArray());

        //        if (Selected)
        //            DrawSelection(g);
        //    }

        //    public override void DrawSelection(Graphics g)
        //    {
        //        Pen selectionPen = new Pen(Color.Orange);

        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y - 2,
        //            4, 4);


        //        g.DrawRectangle(selectionPen,
        //            Location.X - 2, Location.Y + Size.Height - 2,
        //            4, 4);

        //        g.DrawRectangle(selectionPen,
        //            Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //            4, 4);
        //    }

        //    public Pen Pen { get; set; }
        //    //public Brush Brush { get; set; }

        //    public List<Point> Points { get; set; }
        //}


    //}

}