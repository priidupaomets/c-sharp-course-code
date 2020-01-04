using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo07_WinForms
{
    public partial class MainForm : Form
    {
        private List<GraphicsPrimitive> _objects;

        public MainForm()
        {
            InitializeComponent();
            _objects = new List<GraphicsPrimitive>();
            _objects.Add(new RectanglePrimitive() { Location = new Point(10, 10), Size = new Size(22, 46), Selected = true });
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGraphics();
        }

        private void RefreshGraphics()
        {
            using (var g = pictureBox.CreateGraphics())
            {
                foreach (var item in _objects)
                {
                    item.Draw(g);
                }
                //Pen pen = new Pen(Color.Red);
                //g.DrawEllipse(pen, new System.Drawing.Rectangle(10, 10, 20, 30));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private GraphicsPrimitive GetGraphicsPrimitiveUnderCursor(Point mouseLocation)
        {
            if (_objects != null && _objects.Count > 0)
            {
                foreach (var item in _objects)
                {
                    //if (item.IsPointInBounds(mouseLocation))
                    //    return item;

                    ////if (mouseLocation.X > item.Location.X)
                }
            }

            return null;
        }

        private List<GraphicsPrimitive> GetGraphicsPrimitivesUnderCursor(Point mouseLocation)
        {


            return null;
        }
    }
}
