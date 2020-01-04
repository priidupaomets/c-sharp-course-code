using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace WinFormsGraphics
{
    public partial class ShapeEditorControl : UserControl
    {
        private int SelectionHandleToleranceInPizels = 4;

        private List<Shape> _shapes;
        private EditorMode _mode;
        private Point _mouseOrigin;
        private Shape _currentShape = null;
        private Point _currentShapeLocation;
        private Size _currentShapeSize;
        private SelectionHandle _currentSelectionHandle = SelectionHandle.None;

        private string _currentDocumentFileName = string.Empty;

        public ShapeEditorControl()
        {
            InitializeComponent();

            _mode = EditorMode.Select;

            _shapes = new List<Shape>();
        }

        private Shape GetSelectedShape()
        {
            foreach (var shape in _shapes)
            {
                if (shape.Selected)
                {
                    return shape;
                }
            }

            return null;
        }

        private Shape GetShapeAtPosition(Point position)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsInBounds(position))
                {
                    return shape;
                }
            }

            return null;
        }

        private void panelDraw_MouseClick(object sender, MouseEventArgs e)
        {
            var mousePos = e.Location;

            if (_mode == EditorMode.Select && mousePos.IsWithinTolerance(_mouseOrigin, 4))
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

                RefreshGraphics();
            }
        }

        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOrigin = e.Location;

            if (_mode == EditorMode.Select)
            {
                _currentShape = GetShapeAtPosition(_mouseOrigin); // GetSelectedShape();
                _currentShapeLocation = _currentShape?.Location ?? Point.Empty;
                _currentShapeSize = _currentShape?.Size ?? Size.Empty;
                _currentSelectionHandle = _currentShape?.GetSelectionHandle(_mouseOrigin, SelectionHandleToleranceInPizels) ?? SelectionHandle.None;
            }
            else if (_mode == EditorMode.Rectangle)
            {
                _currentShape = new RectangleShape(_mouseOrigin);
                _shapes.Add(_currentShape);
            }
            else if (_mode == EditorMode.Ellipse)
            {
                _currentShape = new EllipseShape(_mouseOrigin);
                _shapes.Add(_currentShape);
            }
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            var currentLocation = e.Location;

            if (MouseLocationChanged != null)
            {
                MouseLocationChanged(this, currentLocation);
            }
            // toolStripStatusLabelPosition.Text = $"X: {currentLocation.X}, Y: {currentLocation.Y}";

            Cursor cursor = Cursors.Default; // Vaikimisi kursor, kui muud pole valitud

            // Esiteks on vaja aru saada, kas oleme mõne valitud kujundi kohal
            var shape = GetShapeAtPosition(currentLocation);

            SelectionHandle selectionHandle = shape?.GetSelectionHandle(currentLocation, SelectionHandleToleranceInPizels) ?? SelectionHandle.None;
            bool shapeIsInBounds = shape?.IsInBounds(currentLocation) ?? false;
            bool shapeIsSelected = shape?.Selected ?? false;

            // Kuna kursoreid on vaja kohandada sõltumata sellest, kas hiire nupp on alla vajutatud või mitte, 
            // siis kursori valik sõltub režiimist. Ehk neid on vaja kuvada vaid siis, kui Select on aktiivne
            if (Mode == EditorMode.Select)
            {
                // Kui oleme, tuleb aru saada, kus me selle kujundi juures oleme
                if (shapeIsSelected)
                {
                    switch (selectionHandle)
                    {
                        case SelectionHandle.None:
                            // Kui Handle point pole määratud ja hiir asub kujundi piirides, siis saame liigutada
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
            }

            if (panelDraw.Cursor != cursor)
                panelDraw.Cursor = cursor;

            // Kui hiire vasak nupp pole alla vajutatud või puudub aktiivne kujund, võime siit haldurist lahkuda
            if (e.Button == MouseButtons.None || _currentShape == null)
                return;

            if (Mode == EditorMode.Select)
            {
                // Kui nupp oli all ja meil on Select režiim, siis saame kujundit kas liigutada või suurust muuta
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
                        case SelectionHandle.TopCenter:    // Nihutame Location.Y positsiooni ja Size.Height väärtust
                            _currentShape.Location = new Point(_currentShape.Location.X, _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShape.Size.Width, _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomCenter: // Muudame ainult Size.Height väärtust
                            _currentShape.Size = new Size(_currentShape.Size.Width, _currentShapeSize.Height + dy);
                            break;
                        case SelectionHandle.LeftCenter:   // Nihutame Location.X positsiooni ja Size.Width väärtust
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShape.Location.Y);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShape.Size.Height);
                            break;
                        case SelectionHandle.RightCenter:  // Muudame ainult Size.Width väärtust
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShape.Size.Height);
                            break;
                        case SelectionHandle.TopLeft:      // Muudame nii Location X ja Y, kui ka Size Width ja Height väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomRight:  // Muudame Size Width ja Height väärtusi
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShapeSize.Height + dy);
                            break;
                        case SelectionHandle.TopRight:     // Muudame kõiki väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X, _currentShapeLocation.Y + dy);
                            _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShapeSize.Height - dy);
                            break;
                        case SelectionHandle.BottomLeft:   // Muudame kõiki väärtusi
                            _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShape.Location.Y);
                            _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShapeSize.Height + dy);
                            break;
                        default:
                            break;
                    }
                }
                else if (shapeIsInBounds)
                {
                    // Arvutame kujundi uue algpositsiooni, milleks on tema salvestatud algpositsioon + nihe
                    int newX = _currentShapeLocation.X + dx;
                    int newY = _currentShapeLocation.Y + dy;

                    _currentShape.Location = new Point(newX, newY);
                }
            }
            else
            //if (Mode != EditorMode.Select && Mode != EditorMode.Move /* && Mode != EditorMode.Delete */)
            {
                Point newLocation = _currentShape.Location;
                Size newSize = _currentShape.Size;

                if (currentLocation.X < _mouseOrigin.X)
                {
                    newLocation.X = currentLocation.X;
                    newSize.Width = _mouseOrigin.X - currentLocation.X;
                }
                else
                {
                    newLocation.X = _mouseOrigin.X; // Original mouse location
                    newSize.Width = currentLocation.X - _mouseOrigin.X;
                }
                if (currentLocation.Y < _mouseOrigin.Y)
                {
                    newLocation.Y = currentLocation.Y;
                    newSize.Height = _mouseOrigin.Y - currentLocation.Y;
                }
                else
                {
                    newLocation.Y = _mouseOrigin.Y; // Original mouse location
                    newSize.Height = currentLocation.Y - _mouseOrigin.Y;
                }
                _currentShape.Location = newLocation;
                _currentShape.Size = newSize;
            }

            RefreshGraphics();
        }

        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            var endLocation = e.Location;

            _currentShape = null;
            _currentShapeLocation = Point.Empty;
            _currentShapeSize = Size.Empty;
            _currentSelectionHandle = SelectionHandle.None;

            RefreshGraphics();
        }

        private void panelDraw_Resize(object sender, EventArgs e)
        {
            RefreshGraphics();
        }

        public void RefreshGraphics()
        {
            if (_shapes == null)
                return;

            using (Graphics g = panelDraw.CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(panelDraw.BackColor),
                    new Rectangle(0, 0, panelDraw.Size.Width, panelDraw.Size.Height));

                Brush handleBrush = new SolidBrush(Color.Black);

                foreach (var shape in _shapes)
                {
                    shape.Draw(g);

                    if (shape.Selected)
                        shape.DrawSelection(g, handleBrush, 4);
                }
            }
        }

        public void DeleteSelectedShapes()
        {
            // Liigume kujundite listist lõpust ettepoole ja eemaldame kõik valitud kujundid
            // Eest tahapoole liikudes läheks meil järjestus sassi ja foreach ei lubaks seda üldse
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];

                if (shape != null && shape.Selected)
                {
                    _shapes.RemoveAt(i);
                }
            }

            RefreshGraphics();
        }

        private void ForEachShape(Action<Shape> shapeAction, Shape excludeShape = null)
        {
            if (_shapes != null && _shapes.Count > 0)
            {
                _shapes.ForEach(shape =>
                {
                    if (shape != excludeShape)
                    {
                        shapeAction(shape);
                    }
                });

            }
        }

        public void SelectNone(Shape excludeShape = null)
        {
            ForEachShape(shape => shape.Selected = false, excludeShape);
        }

        public void SelectAll(Shape excludeShape = null)
        {
            ForEachShape(shape => shape.Selected = true, excludeShape);
        }

        public void ClearAllShapes()
        {
            _shapes.Clear();
            _currentDocumentFileName = string.Empty;
            RefreshGraphics();
        }

        public void LoadShapesFromFile(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);

                _shapes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                _currentDocumentFileName = fileName;

                RefreshGraphics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveShapesToFile(string fileName)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(_shapes, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                File.WriteAllText(fileName, json);

                _currentDocumentFileName = fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CurrentDocumentFileName
        {
            get { return _currentDocumentFileName; }
            set { _currentDocumentFileName = value; }
        }

        public EditorMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
            }
        }

        public event EventHandler<Point> MouseLocationChanged;

    }
}
