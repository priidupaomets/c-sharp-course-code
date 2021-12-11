using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsEditor.Converters;

namespace WinFormsEditor
{
    public abstract class Shape
    {
        public Shape()
        {
            Pen = new Pen(Color.Black);
            Location = Point.Empty;
            Size = Size.Empty;
        }

        public Shape(Point location) : this()
        {
            Location = location;
        }

        public Shape(Point location, Size size): this(location)
        {
            Size = size;
        }

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

        [JsonConverter(typeof(PenJsonConverter))]
        public Pen Pen { get; set; }
        public Point Location { get; set; }

        [JsonConverter(typeof(SizeJsonConverter))]
        public Size Size { get; set; }

        public bool Selected { get; set; }
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


        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen,
                Location.X, Location.Y,
                Size.Width, Size.Height);
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Black);
        //    Brush selectionBrush = new SolidBrush(Color.Black);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y + Size.Height - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2, 
        //                                    Location.Y + Size.Height - 2, 4, 4);
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
        }
        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Black);
        //    Brush selectionBrush = new SolidBrush(Color.Black);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y + Size.Height - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2,
        //                                    Location.Y + Size.Height - 2, 4, 4);
        //}
    }

    public class TextShape : Shape
    {
        public TextShape()
        {
            Brush = new SolidBrush(Color.YellowGreen);
            Font = new Font("Arial", 12, FontStyle.Regular);
            Text = string.Empty;
        }

        public override void Draw(Graphics g)
        {
            //g.DrawString(Text, Font, Brush, Location.X, Location.Y);

            g.DrawString(Text, Font, Brush, 
                new RectangleF(Location.X, Location.Y, Size.Width, Size.Height));
        }
        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Black);
        //    Brush selectionBrush = new SolidBrush(Color.Black);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y + Size.Height - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2,
        //                                    Location.Y + Size.Height - 2, 4, 4);
        //}

        public Brush Brush { get; set; }
        public Font Font { get; set; }
        public string Text { get; set; }
    }

    public class LinesShape : Shape
    {
        public LinesShape()
        {
            Points = new List<Point>();
        }

        public override void Draw(Graphics g)
        {
            g.DrawLines(Pen, Points.ToArray());
        }

        //public override void DrawSelection(Graphics g)
        //{
        //    Pen selectionPen = new Pen(Color.Black);
        //    Brush selectionBrush = new SolidBrush(Color.Black);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2, Location.Y - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X - 2, Location.Y + Size.Height - 2, 4, 4);

        //    g.FillRectangle(selectionBrush, Location.X + Size.Width - 2,
        //                                    Location.Y + Size.Height - 2, 4, 4);
        //}
        public List<Point> Points { get; set; }
    }
}
