using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEditor
{
    public partial class ShapeEditorControl : UserControl
    {
        private List<Shape> _shapes = new List<Shape>();
        private EditorMode _mode;
        private int SelectionHandleToleranceInPizels = 8;
        private Point _mouseOrigin = Point.Empty;
        private Shape? _currentShape = null;
        private Point _currentShapeLocation = Point.Empty;
        private Size _currentShapeSize = Size.Empty;
        private SelectionHandle _currentSelectionHandle = SelectionHandle.None;
        private string _currentDocumentName = string.Empty;
        // Kasutame värelusvaba joonistamise jaoks tausalt olevat Bitmap-i
        Bitmap? _drawBuffer = null;

        public ShapeEditorControl()
        {
            // Need seadistused aitavad pisut, kui tegu on otsese joonistamisega,
            // aga nüüd, kus me kasutame omaenda taustal oleva pildi kaudu joonistamist,
            // ei mõjuta need enam suurt
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ////SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            ////SetStyle(ControlStyles.ResizeRedraw, true);
            //this.DoubleBuffered = true;

            InitializeComponent();

            _mode = EditorMode.Select;
        }

        private void RequestRedraw()
        {
            DrawShapes();
            //Invalidate();
        }

        private void ShapeEditorControl_MouseClick(object sender, MouseEventArgs e)
        {
            var mousePos = e.Location;

            if (Mode == EditorMode.Select && mousePos.IsWithinTolerance(_mouseOrigin, 4))
            {
                var shape = GetShapeAtPosition(mousePos);
                if (shape != null)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        shape.Selected = !shape.Selected;
                    }
                    else
                    {
                        shape.Selected = true;

                        SelectNone(excludeShape: shape);
                    }
                }
                else
                    SelectNone();

                RequestRedraw();
            }
        }

        private void ShapeEditorControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOrigin = e.Location;

            if (Mode == EditorMode.Select)
            {
                _currentShape = GetShapeAtPosition(_mouseOrigin);
                _currentShapeLocation = _currentShape?.Location ?? Point.Empty;
                _currentShapeSize = _currentShape?.Size ?? Size.Empty;
                _currentSelectionHandle = _currentShape?.GetSelectionHandle(_mouseOrigin,
                    SelectionHandleToleranceInPizels) ?? SelectionHandle.None;
            }
            else if (Mode == EditorMode.Rectangle)
            {
                _currentShape = new RectangleShape(_mouseOrigin);
                _shapes.Add(_currentShape);
            }
            else if (Mode == EditorMode.Ellipse)
            {
                _currentShape = new EllipseShape(_mouseOrigin);
                _shapes.Add(_currentShape);
            }
        }

        private void ShapeEditorControl_MouseMove(object sender, MouseEventArgs e)
        {
            var currentLocation = e.Location;

            MouseLocationChanged?.Invoke(this, currentLocation);

            // Esiteks on vaja aru saada, kas oleme mõne valitud kujundi kohal
            var shape = GetShapeAtPosition(currentLocation);

            SelectionHandle selectionHandle =
                shape?.GetSelectionHandle(currentLocation, SelectionHandleToleranceInPizels)
                ?? SelectionHandle.None;
            bool shapeIsInBounds = shape?.IsInBounds(currentLocation) ?? false;
            bool shapeIsSelected = shape?.Selected ?? false;

            UpdateCursor(selectionHandle, shapeIsInBounds, shapeIsSelected);

            if (e.Button == MouseButtons.None || _currentShape == null)
                return;

            if (Mode == EditorMode.Select)
            {
                // Kui nupp oli all ja meil on Select režiim, siis saame kujundit kas liigutada või 
                // suurust muuta
                if (!e.Button.HasFlag(MouseButtons.Left))
                    return; // Jäta aktiivse kujundi puudumisel ülejäänud kood vahele

                // Arvutame nihke hiire algpositsiooni ja praeguse koha vahel
                int dx = e.Location.X - _mouseOrigin.X;
                int dy = e.Location.Y - _mouseOrigin.Y;

                if (_currentSelectionHandle != SelectionHandle.None)
                {
                    switch (_currentSelectionHandle)
                    {
                        case SelectionHandle.None:
                            break;
                        case SelectionHandle.TopCenter:    // Muudame Y ja Height väärtust
                            _currentShape.Location = new Point(_currentShape.Location.X,
                                                               _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShape.Size.Width,
                                                          _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomCenter: // Muudame ainult Height väärtust
                            _currentShape.Size = new Size(_currentShape.Size.Width,
                                                          _currentShapeSize.Height + dy);
                            break;
                        case SelectionHandle.LeftCenter:   // Muudame X ja Width väärtust
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx,
                                                               _currentShape.Location.Y);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx,
                                                          _currentShape.Size.Height);
                            break;
                        case SelectionHandle.RightCenter:  // Muudame ainult Size.Width väärtust
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx,
                                                          _currentShape.Size.Height);
                            break;
                        case SelectionHandle.TopLeft:      // Muudame X, Y,  Width ja Height väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx,
                                                               _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx,
                                                          _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomRight:  // Muudame Width ja Height väärtusi
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx,
                                                          _currentShapeSize.Height + dy);
                            break;
                        case SelectionHandle.TopRight:     // Muudame kõiki väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X,
                                                               _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx,
                                                          _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomLeft:   // Muudame kõiki väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx,
                                                               _currentShape.Location.Y);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx,
                                                          _currentShapeSize.Height + dy);
                            break;
                        default:
                            break;
                    }
                }
                else if (shapeIsInBounds)
                {
                    // Arvutame kujundi uue algpositsiooni, milleks on tema salvestatud 
                    // algpositsioon + nihe
                    int newX = _currentShapeLocation.X + dx;
                    int newY = _currentShapeLocation.Y + dy;

                    _currentShape.Location = new Point(newX, newY);
                }
            }
            else // it is a shape drawing mode
            {
                if (_currentShape == null)
                    return;

                Point newLocation = _currentShape.Location;
                Size newSize = _currentShape.Size;

                if (currentLocation.X < _mouseOrigin.X)
                {
                    newLocation.X = currentLocation.X;
                    newSize.Width = _mouseOrigin.X - currentLocation.X;
                }
                else
                {
                    newLocation.X = _mouseOrigin.X;
                    newSize.Width = currentLocation.X - _mouseOrigin.X;
                }
                if (currentLocation.Y < _mouseOrigin.Y)
                {
                    newLocation.Y = currentLocation.Y;
                    newSize.Height = _mouseOrigin.Y - currentLocation.Y;
                }
                else
                {
                    newLocation.Y = _mouseOrigin.Y;
                    newSize.Height = currentLocation.Y - _mouseOrigin.Y;
                }

                _currentShape.Location = newLocation;
                _currentShape.Size = newSize;
            }

            RequestRedraw();
        }

        private void UpdateCursor(SelectionHandle selectionHandle, bool shapeIsInBounds, bool shapeIsSelected)
        {
            Cursor cursor = Cursors.Default; // Vaikimisi kursor, kui muud pole valitud

            // Kuna kursoreid on vaja kohandada sõltumata sellest, kas hiire nupp on alla vajutatud 
            // või mitte, siis kursori valik sõltub režiimist. Ehk neid on vaja kuvada vaid siis, 
            // kui Select on aktiivne
            if (Mode == EditorMode.Select)
            {
                // Kui oleme, tuleb aru saada, kus me selle kujundi juures oleme
                if (shapeIsSelected)
                {
                    switch (selectionHandle)
                    {
                        case SelectionHandle.None:
                            // Kui Handle point pole määratud ja hiir asub kujundi piirides, 
                            // siis saame liigutada
                            if (shapeIsInBounds)
                            {
                                if (shapeIsSelected)
                                    cursor = Cursors.SizeAll;
                                else
                                    cursor = Cursors.Hand;
                            }
                            break;
                        case SelectionHandle.TopCenter:
                            cursor = Cursors.SizeNS;
                            break;
                        case SelectionHandle.BottomCenter:
                            cursor = Cursors.SizeNS;
                            break;
                        case SelectionHandle.LeftCenter:
                            cursor = Cursors.SizeWE;
                            break;
                        case SelectionHandle.RightCenter:
                            cursor = Cursors.SizeWE;
                            break;
                        case SelectionHandle.TopLeft:
                            cursor = Cursors.SizeNWSE;
                            break;
                        case SelectionHandle.BottomRight:
                            cursor = Cursors.SizeNWSE;
                            break;
                        case SelectionHandle.TopRight:
                            cursor = Cursors.SizeNESW;
                            break;
                        case SelectionHandle.BottomLeft:
                            cursor = Cursors.SizeNESW;
                            break;
                        default:
                            break;
                    }
                }
                else if (shapeIsInBounds)
                {
                    cursor = Cursors.Hand;
                }
            }

            if (Cursor != cursor)
                Cursor = cursor;
        }

        private void ShapeEditorControl_MouseUp(object sender, MouseEventArgs e)
        {
            _currentShape = null;
            _currentShapeLocation = Point.Empty;
            _currentShapeSize = Size.Empty;
            _currentSelectionHandle = SelectionHandle.None;

            RequestRedraw();
        }

        private void ShapeEditorControl_Paint(object sender, PaintEventArgs e)
        {
            //DrawShapes();
        }

        private void ShapeEditorControl_Resize(object sender, EventArgs e)
        {
            RequestRedraw();

            // Kuna komponendi mõõtmed on muutunud, eemaldame praeguse bitmapi,
            // et see joonistamisel uute mõõtmetega uuesti luua
            _drawBuffer?.Dispose();
            _drawBuffer = null;
        }


        private void DrawShapes()
        {
            // Kui tausta-bitmap ei eksisteeri, siis loome selle
            if (_drawBuffer == null)
                _drawBuffer = new Bitmap(this.Width, this.Height);

            // Küsime pildi käest graafika konteksti, et me saaks selle peale joonistada
            using (Graphics g = Graphics.FromImage(_drawBuffer))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.Clear(BackColor);
                //g.FillRectangle(new SolidBrush(BackColor),
                //    new Rectangle(0, 0, Size.Width, Size.Height));

                Brush handleBrush = new SolidBrush(Color.Black);

                foreach (Shape shape in _shapes)
                {
                    shape.Draw(g);

                    if (shape.Selected)
                    {
                        shape.DrawSelection(g, handleBrush, 8);
                    }
                }
            }

            // Küsime redaktori komponendi graafika konteksti ja joonistame 
            // puhverdatud bitmapi sellele
            using (Graphics g = this.CreateGraphics())
            {
                g.DrawImageUnscaled(_drawBuffer, 0, 0);
            }
        }

        //private Shape? GetSelectedShape()
        //{
        //    foreach (var shape in _shapes)
        //    {
        //        if (shape.Selected)
        //            return shape;
        //    }

        //    return null;
        //}

        private Shape? GetShapeAtPosition(Point position)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsInBounds(position))
                    return shape;
            }

            return null;
        }

        private void ForEachShape(Action<Shape> shapeAction, Shape? excludeShape = null)
        {
            if (_shapes != null && _shapes.Count > 0)
            {
                _shapes.ForEach(shape =>
                {
                    if (shape != excludeShape)
                        shapeAction(shape);
                });
            }
        }

        public void SelectNone(Shape? excludeShape = null)
        {
            ForEachShape(shape => shape.Selected = false, excludeShape);
        }
        public void SelectAll(Shape? excludeShape = null)
        {
            ForEachShape(shape => shape.Selected = true, excludeShape);
        }

        public override void Refresh()
        {
            // Kui baas-refresh välja kutsuda, siis ta esmalt joonistab komponendi enda asjad
            // ja siis joonistame oma asjad selle peale. Antud juhul põhjustab see õrna vilkumist
            //base.Refresh();

            RequestRedraw();
        }

        public void DeleteSelectedShapes()
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];

                if (shape != null && shape.Selected)
                {
                    _shapes.RemoveAt(i);
                }
            }

            RequestRedraw();
        }

        public void ClearAllShapes()
        {
            _shapes.Clear();
            _currentDocumentName = string.Empty;
            RequestRedraw();
        }

        public void LoadShapesFromFile(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);

#pragma warning disable CS8601 // Possible null reference assignment.
                _shapes = JsonConvert.DeserializeObject<List<Shape>>(json,
                     new JsonSerializerSettings
                     {
                         TypeNameHandling = TypeNameHandling.All
                     });
#pragma warning restore CS8601 // Possible null reference assignment.

                RequestRedraw();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveShapesToFile(string fileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(_shapes,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModeChanged()
        {
            //UpdateCommands();
            EditorModeChanged?.Invoke(this, Mode);
        }


        public EditorMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                ModeChanged();
            }
        }

        public string CurrentDocumentName
        { 
            get { return _currentDocumentName; }
            set { _currentDocumentName = value; }
        }

        public event EventHandler<EditorMode>? EditorModeChanged;
        public event EventHandler<Point>? MouseLocationChanged;

    }
}
