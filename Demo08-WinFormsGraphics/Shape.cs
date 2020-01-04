using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using WinFormsGraphics.Converters;

namespace WinFormsGraphics
{
    public abstract class Shape
    {
        public Point Location { get; set; }
        [JsonConverter(typeof(SizeJsonConverter))]
        public Size Size { get; set; }
        public bool Selected { get; set; }

        public abstract void Draw(Graphics g);
        //public abstract void DrawSelection(Graphics g);

        public virtual bool IsInBounds(Point value)
        {
            if (value.X >= Location.X &&
                value.X <= (Location.X + Size.Width) &&
                value.Y >= Location.Y &&
                value.Y <= (Location.Y + Size.Height))
            {
                return true;
            }

            return false;
        }
    }

    public class RectangleShape : Shape
    {
        public RectangleShape()
        {
            Pen = new Pen(Color.Black);
            Location = Point.Empty;
            Size = Size.Empty;
        }

        public RectangleShape(Point location) : this()
        {
            Location = location;
        }

        public RectangleShape(Point location, Size size) : this(location)
        {
            Size = size;
        }

        [JsonConverter(typeof(PenJsonConverter))]
        public Pen Pen { get; set; }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen,
                Location.X, Location.Y,
                Size.Width, Size.Height);

            //if (Selected)
            //    DrawSelection(g);
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Brush selectionBrush = new SolidBrush(Color.Black);

        //    g.FillRectangle(selectionBrush,
        //        Location.X - 2, Location.Y - 2,
        //        4, 4);

        //    g.FillRectangle(selectionBrush,
        //        Location.X + Size.Width - 2, Location.Y - 2,
        //        4, 4);

        //    g.FillRectangle(selectionBrush,
        //        Location.X - 2, Location.Y + Size.Height - 2,
        //        4, 4);

        //    g.FillRectangle(selectionBrush,
        //        Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //        4, 4);
        //}
    }

    public class EllipseShape : Shape
    {
        public EllipseShape()
        {
            Pen = new Pen(Color.Black);
            Location = Point.Empty;
            Size = Size.Empty;
        }

        public EllipseShape(Point location) : this()
        {
            Location = location;
        }

        public EllipseShape(Point location, Size size) : this(location)
        {
            Size = size;
        }


        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pen,
                Location.X, Location.Y,
                Size.Width, Size.Height);

            //if (Selected)
            //    DrawSelection(g);
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Orange);

        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y - 2,
        //        4, 4);


        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y + Size.Height - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //        4, 4);
        //}

        [JsonConverter(typeof(PenJsonConverter))]
        public Pen Pen { get; set; }
    }

    public class TextShape : Shape
    {
        public TextShape()
        {
            Brush = new SolidBrush(Color.YellowGreen);
            Font = new Font("Arial", 12, FontStyle.Regular);
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(Text, Font, Brush,
                new RectangleF(Location.X, Location.Y, Size.Width, Size.Height));

            //if (Selected)
            //    DrawSelection(g);
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Orange);

        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y - 2,
        //        4, 4);


        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y + Size.Height - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //        4, 4);
        //}

        public Brush Brush { get; set; }

        public Font Font { get; set; }
        public string Text { get; set; }
    }

    public class LinesShape : Shape
    {
        public LinesShape()
        {
            Pen = new Pen(Color.Black);
            Points = new List<Point>();
        }

        public override void Draw(Graphics g)
        {
            //g.DrawPath(Pen, new System.Drawing.Drawing2D.GraphicsPath());
            g.DrawLines(Pen, Points.ToArray());

            //if (Selected)
            //    DrawSelection(g);
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Orange);

        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y - 2,
        //        4, 4);


        //    g.DrawRectangle(selectionPen,
        //        Location.X - 2, Location.Y + Size.Height - 2,
        //        4, 4);

        //    g.DrawRectangle(selectionPen,
        //        Location.X + Size.Width - 2, Location.Y + Size.Height - 2,
        //        4, 4);
        //}

        [JsonConverter(typeof(PenJsonConverter))]
        public Pen Pen { get; set; }
        //public Brush Brush { get; set; }

        public List<Point> Points { get; set; }
    }


}