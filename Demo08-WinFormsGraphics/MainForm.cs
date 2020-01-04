using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGraphics
{
    public partial class MainForm : Form
    {
        //private int HandlePointToleranceInPizels = 4;

        //private List<Shape> _shapes;
        //private EditorMode _mode;
        //private Point _mouseOrigin;
        //private Shape _currentShape = null;
        //private Point _currentShapeLocation;
        //private Size _currentShapeSize;
        //private ShapeHandlePoint _currentShapeHandlePoint = ShapeHandlePoint.None;

        //private string _currentDocumentFileName = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            //_mode = EditorMode.Select;

            //_shapes = new List<Shape>();
            //_shapes.Add(new RectangleShape()
            //{
            //    Location = new Point(10, 10),
            //    Size = new Size(60, 40)
            //});
            //_shapes.Add(new RectangleShape()
            //{
            //    Pen = new Pen(Color.Blue, 4),
            //    Location = new Point(70, 50),
            //    Size = new Size(60, 40)
            //});

            //_shapes.Add(new EllipseShape()
            //{
            //    Pen = new Pen(Color.Green, 2),
            //    Location = new Point(70, 50),
            //    Size = new Size(60, 40)
            //});

            //_shapes.Add(new TextShape()
            //{
            //    Brush = new SolidBrush(Color.Violet),
            //    Font = new Font("verdana", 16),
            //    Location = new Point(70, 150),
            //    Size = new Size(160, 40),
            //    Text = "Tere tulemast"
            //});

            //_shapes.Add(new LinesShape()
            //{
            //    Pen = new Pen(Color.Orange),
            //    Points = new List<Point>()
            //    {
            //        new Point(100, 100),
            //        new Point(150, 100),
            //        new Point(150, 200)
            //    }
            //});

            UpdateCommands();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            shapeEditor.RefreshGraphics();
        }

        //private void RefreshGraphics()
        //{
        //    using (Graphics g = panelDraw.CreateGraphics())
        //    {
        //        g.FillRectangle(new SolidBrush(panelDraw.BackColor),
        //            new Rectangle(0, 0, panelDraw.Size.Width, panelDraw.Size.Height));

        //        Brush handleBrush = new SolidBrush(Color.Black);

        //        foreach (var shape in _shapes)
        //        {
        //            shape.Draw(g);

        //            if (shape.Selected)
        //                shape.DrawSelection(g, handleBrush, 4);

        //            //if (shape is RectangleShape)
        //            //{
        //            //    var rect = shape as RectangleShape;

        //            //    g.DrawRectangle(rect.Pen,
        //            //        rect.Location.X, rect.Location.Y,
        //            //        rect.Size.Width, rect.Size.Height);
        //            //}
        //            //else if (shape is EllipseShape)
        //            //{
        //            //    var rect = shape as EllipseShape;

        //            //    g.DrawEllipse(rect.Pen,
        //            //        rect.Location.X, rect.Location.Y,
        //            //        rect.Size.Width, rect.Size.Height);
        //            //}
        //        }
        //        //Pen pen = new Pen(Color.OrangeRed, 3);
        //        //g.DrawRectangle(pen, 10, 10, 50, 40);
        //    }
        //}

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeEditor.RefreshGraphics();
        }

        public EditorMode Mode
        {
            get { return shapeEditor.Mode; }
            set
            {
                shapeEditor.Mode = value;
                UpdateCommands();
            }
        }

        private void UpdateCommands()
        {
            toolStripButtonSelect.Checked = Mode == EditorMode.Select;
            //toolStripButtonMove.Checked = Mode == EditorMode.Move;
            //toolStripButtonDelete.Checked = Mode == EditorMode.Delete;

            toolStripButtonRectangle.Checked = Mode == EditorMode.Rectangle;
            toolStripButtonEllipse.Checked = Mode == EditorMode.Ellipse;
            toolStripButtonText.Checked = Mode == EditorMode.Text;

            toolStripStatusLabelStatus.Text = Mode.ToString();
        }

        private void ToolStripButtonSelect_Click(object sender, EventArgs e)
        {
            Mode = EditorMode.Select;
        }

        //private void ToolStripButtonMove_Click(object sender, EventArgs e)
        //{
        //    Mode = EditorMode.Move;
        //}

        //private void ToolStripButtonDelete_Click(object sender, EventArgs e)
        //{
        //    Mode = EditorMode.Delete;
        //}

        private void ToolStripButtonRectangle_Click(object sender, EventArgs e)
        {
            Mode = EditorMode.Rectangle;
        }

        private void ToolStripButtonEllipse_Click(object sender, EventArgs e)
        {
            Mode = EditorMode.Ellipse;
        }

        private void toolStripButtonText_Click(object sender, EventArgs e)
        {
            Mode = EditorMode.Text;
        }

        //private Shape GetSelectedShape()
        //{
        //    foreach (var shape in _shapes)
        //    {
        //        if (shape.Selected)
        //        {
        //            return shape;
        //        }
        //    }

        //    return null;
        //}

        //private Shape GetShapeAtPosition(Point position)
        //{
        //    foreach (var shape in _shapes)
        //    {
        //        if (shape.IsInBounds(position))
        //        {
        //            return shape;
        //        }
        //    }

        //    return null;
        //}

        //private void PanelDraw_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //_mouseOrigin = e.Location;

        //    //if (_mode == EditorMode.Select)
        //    //{
        //    //    _currentShape = GetShapeAtPosition(_mouseOrigin); // GetSelectedShape();
        //    //    _currentShapeLocation = _currentShape?.Location ?? Point.Empty;
        //    //    _currentShapeSize = _currentShape?.Size ?? Size.Empty;
        //    //    _currentShapeHandlePoint = _currentShape?.GetHandlePoint(_mouseOrigin, HandlePointToleranceInPizels) ?? ShapeHandlePoint.None;
        //    //}
        //    //else if (_mode == EditorMode.Rectangle)
        //    //{
        //    //    _currentShape = new RectangleShape(_mouseOrigin);
        //    //    _shapes.Add(_currentShape);
        //    //}
        //    //else if (_mode == EditorMode.Ellipse)
        //    //{
        //    //    _currentShape = new EllipseShape(_mouseOrigin);
        //    //    _shapes.Add(_currentShape);
        //    //}
        //}

        //private void PanelDraw_MouseMove(object sender, MouseEventArgs e)
        //{
        //    //var currentLocation = e.Location;

        //    //toolStripStatusLabelPosition.Text = $"X: {currentLocation.X}, Y: {currentLocation.Y}";

        //    //Cursor cursor = Cursors.Default; // Vaikimisi kursor, kui muud pole valitud

        //    //// Esiteks on vaja aru saada, kas oleme mõne valitud kujundi kohal
        //    //var shape = GetShapeAtPosition(currentLocation);

        //    //ShapeHandlePoint handlePoint = shape?.GetHandlePoint(currentLocation, HandlePointToleranceInPizels) ?? ShapeHandlePoint.None;
        //    //bool shapeIsInBounds = shape?.IsInBounds(currentLocation) ?? false;
        //    //bool shapeIsSelected = shape?.Selected ?? false;

        //    //// Kuna kursoreid on vaja kohandada sõltumata sellest, kas hiire nupp on alla vajutatud või mitte, 
        //    //// siis kursori valik sõltub režiimist. Ehk neid on vaja kuvada vaid siis, kui Select on aktiivne
        //    //if (Mode == EditorMode.Select)
        //    //{
        //    //    // Kui oleme, tuleb aru saada, kus me selle kujundi juures oleme
        //    //    if (shapeIsSelected)
        //    //    {
        //    //        switch (handlePoint)
        //    //        {
        //    //            case ShapeHandlePoint.None:
        //    //                // Kui Handle point pole määratud ja hiir asub kujundi piirides, siis saame liigutada
        //    //                if (shapeIsInBounds)
        //    //                {
        //    //                    if (shapeIsSelected)
        //    //                        cursor = Cursors.SizeAll;
        //    //                    else
        //    //                        cursor = Cursors.Hand;
        //    //                }
        //    //                break;
        //    //            case ShapeHandlePoint.TopCenter:
        //    //                cursor = Cursors.SizeNS;
        //    //                break;
        //    //            case ShapeHandlePoint.BottomCenter:
        //    //                cursor = Cursors.SizeNS;
        //    //                break;
        //    //            case ShapeHandlePoint.LeftCenter:
        //    //                cursor = Cursors.SizeWE;
        //    //                break;
        //    //            case ShapeHandlePoint.RightCenter:
        //    //                cursor = Cursors.SizeWE;
        //    //                break;
        //    //            case ShapeHandlePoint.TopLeft:
        //    //                cursor = Cursors.SizeNWSE;
        //    //                break;
        //    //            case ShapeHandlePoint.BottomRight:
        //    //                cursor = Cursors.SizeNWSE;
        //    //                break;
        //    //            case ShapeHandlePoint.TopRight:
        //    //                cursor = Cursors.SizeNESW;
        //    //                break;
        //    //            case ShapeHandlePoint.BottomLeft:
        //    //                cursor = Cursors.SizeNESW;
        //    //                break;
        //    //            default:
        //    //                break;
        //    //        }
        //    //    }
        //    //}

        //    //if (panelDraw.Cursor != cursor)
        //    //    panelDraw.Cursor = cursor;

        //    //// Kui hiire vasak nupp pole alla vajutatud või puudub aktiivne kujund, võime siit haldurist lahkuda
        //    //if (e.Button == MouseButtons.None || _currentShape == null)
        //    //    return;

        //    //if (Mode == EditorMode.Select)
        //    //{
        //    //    // Kui nupp oli all ja meil on Select režiim, siis saame kujundit kas liigutada või suurust muuta
        //    //    if (!e.Button.HasFlag(MouseButtons.Left))
        //    //        return; // Jäta aktiivse kujundi puudumisel ülejäänud kood vahele

        //    //    // Arvutame nihke hiire algpositsiooni ja praeguse koha vahel
        //    //    int dx = e.Location.X - _mouseOrigin.X;
        //    //    int dy = e.Location.Y - _mouseOrigin.Y;

        //    //    if (_currentShapeHandlePoint != ShapeHandlePoint.None)
        //    //    {
        //    //        switch (_currentShapeHandlePoint)
        //    //        {
        //    //            case ShapeHandlePoint.None:
        //    //                break;
        //    //            case ShapeHandlePoint.TopCenter:    // Nihutame Location.Y positsiooni ja Size.Height väärtust
        //    //                _currentShape.Location = new Point(_currentShape.Location.X, _currentShapeLocation.Y + dy);
        //    //                _currentShape.Size = new Size(_currentShape.Size.Width, _currentShapeSize.Height - dy);
        //    //                break;
        //    //            case ShapeHandlePoint.BottomCenter: // Muudame ainult Size.Height väärtust
        //    //                _currentShape.Size = new Size(_currentShape.Size.Width, _currentShapeSize.Height + dy);                            
        //    //                break;
        //    //            case ShapeHandlePoint.LeftCenter:   // Nihutame Location.X positsiooni ja Size.Width väärtust
        //    //                _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShape.Location.Y);
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShape.Size.Height);
        //    //                break;
        //    //            case ShapeHandlePoint.RightCenter:  // Muudame ainult Size.Width väärtust
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShape.Size.Height);
        //    //                break;
        //    //            case ShapeHandlePoint.TopLeft:      // Muudame nii Location X ja Y, kui ka Size Width ja Height väärtusi
        //    //                _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShapeLocation.Y + dy);
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShapeSize.Height - dy);
        //    //                break;
        //    //            case ShapeHandlePoint.BottomRight:  // Muudame Size Width ja Height väärtusi
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShapeSize.Height + dy);
        //    //                break;
        //    //            case ShapeHandlePoint.TopRight:     // Muudame kõiki väärtusi
        //    //                _currentShape.Location = new Point(_currentShapeLocation.X, _currentShapeLocation.Y + dy);
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width + dx, _currentShapeSize.Height - dy);
        //    //                break;
        //    //            case ShapeHandlePoint.BottomLeft:   // Muudame kõiki väärtusi
        //    //                _currentShape.Location = new Point(_currentShapeLocation.X + dx, _currentShape.Location.Y);
        //    //                _currentShape.Size = new Size(_currentShapeSize.Width - dx, _currentShapeSize.Height + dy);
        //    //                break;
        //    //            default:
        //    //                break;
        //    //        }
        //    //    }
        //    //    else if (shapeIsInBounds)
        //    //    {
        //    //        // Arvutame kujundi uue algpositsiooni, milleks on tema salvestatud algpositsioon + nihe
        //    //        int newX = _currentShapeLocation.X + dx;
        //    //        int newY = _currentShapeLocation.Y + dy;

        //    //        _currentShape.Location = new Point(newX, newY);
        //    //    }
        //    //}
        //    //else
        //    ////if (Mode != EditorMode.Select && Mode != EditorMode.Move /* && Mode != EditorMode.Delete */)
        //    //{
        //    //    Point newLocation = _currentShape.Location;
        //    //    Size newSize = _currentShape.Size;

        //    //    if (currentLocation.X < _mouseOrigin.X)
        //    //    {
        //    //        newLocation.X = currentLocation.X;
        //    //        newSize.Width = _mouseOrigin.X - currentLocation.X;
        //    //    }
        //    //    else
        //    //    {
        //    //        newLocation.X = _mouseOrigin.X; // Original mouse location
        //    //        newSize.Width = currentLocation.X - _mouseOrigin.X;
        //    //    }
        //    //    if (currentLocation.Y < _mouseOrigin.Y)
        //    //    {
        //    //        newLocation.Y = currentLocation.Y;
        //    //        newSize.Height = _mouseOrigin.Y - currentLocation.Y;
        //    //    }
        //    //    else
        //    //    {
        //    //        newLocation.Y = _mouseOrigin.Y; // Original mouse location
        //    //        newSize.Height = currentLocation.Y - _mouseOrigin.Y;
        //    //    }
        //    //    _currentShape.Location = newLocation;
        //    //    _currentShape.Size = newSize; 
        //    //}

        //    //RefreshGraphics();
        //}

        //private void PanelDraw_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //var endLocation = e.Location;

        //    //_currentShape = null;
        //    //_currentShapeLocation = Point.Empty;
        //    //_currentShapeSize = Size.Empty;
        //    //_currentShapeHandlePoint = ShapeHandlePoint.None;

        //    //RefreshGraphics();
        //}

        //private void panelDraw_MouseClick(object sender, MouseEventArgs e)
        //{
        //    //var mousePos = e.Location;

        //    //if (_mode == EditorMode.Select && mousePos.IsWithinTolerance(_mouseOrigin, 4))
        //    //{
        //    //    var shape = GetShapeAtPosition(mousePos);

        //    //    if (shape != null)
        //    //    {
        //    //        if (Control.ModifierKeys == Keys.Shift)
        //    //        {
        //    //            shape.Selected = !shape.Selected;
        //    //        }
        //    //        else
        //    //        {
        //    //            shape.Selected = true;

        //    //            SelectNone(excludeShape: shape);
        //    //        }
        //    //    }
        //    //    else
        //    //        SelectNone();

        //    //    RefreshGraphics();

        //    //    //foreach (var shape in _shapes)
        //    //    //{
        //    //    //    if (shape.IsInBounds(mousePos))
        //    //    //    {
        //    //    //        shape.Selected = !shape.Selected;

        //    //    //        RefreshGraphics();
        //    //    //        return;
        //    //    //    }
        //    //    //}
        //    //}
        //}

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeEditor.DeleteSelectedShapes();
        }

        //private void DeleteSelectedShapes()
        //{
        //    // Liigume kujundite listist lõpust ettepoole ja eemaldame kõik valitud kujundid
        //    // Eest tahapoole liikudes läheks meil järjestus sassi ja foreach ei lubaks seda üldse
        //    for (int i = _shapes.Count - 1; i >= 0; i--)
        //    {
        //        var shape = _shapes[i];

        //        if (shape != null && shape.Selected)
        //        {
        //            _shapes.RemoveAt(i);
        //        }
        //    }

        //    RefreshGraphics();
        //}

        //private void ForEachShape(Action<Shape> shapeAction, Shape excludeShape = null)
        //{
        //    if (_shapes != null && _shapes.Count > 0)
        //    {
        //        foreach (var shape in _shapes)
        //        {
        //            if (shape != excludeShape)
        //            {
        //                shapeAction(shape);
        //            }
        //        }
        //    }
        //}

        //private void SelectNone(Shape excludeShape = null)
        //{
        //    ForEachShape(shape => shape.Selected = false, excludeShape);
        //}

        //private void SelectAll(Shape excludeShape = null)
        //{
        //    ForEachShape(shape => shape.Selected = true, excludeShape);
        //}

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeEditor.SelectNone();
            shapeEditor.RefreshGraphics();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeEditor.SelectAll();
            shapeEditor.RefreshGraphics();
        }

        private void ClearAllShapes()
        {
            shapeEditor.ClearAllShapes();
            //_shapes.Clear();
            //_currentDocumentFileName = string.Empty;
            //RefreshGraphics();
        }

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                //_currentDocumentFileName = fileName;

                shapeEditor.LoadShapesFromFile(fileName);
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(shapeEditor.CurrentDocumentFileName))
            {
                SaveFileAs();
            }
            else
            {
                shapeEditor.SaveShapesToFile(shapeEditor.CurrentDocumentFileName);
            }
        }

        private void SaveFileAs()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                //_currentDocumentFileName = fileName;

                shapeEditor.SaveShapesToFile(fileName);
            }
        }

        //private void LoadShapesFromFile(string fileName)
        //{
        //    try
        //    {
        //        string json = File.ReadAllText(fileName);

        //        _shapes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings
        //        {
        //            TypeNameHandling = TypeNameHandling.All
        //        });

        //        RefreshGraphics();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void SaveShapesToFile(string fileName)
        //{
        //    try
        //    {
        //        string json = Newtonsoft.Json.JsonConvert.SerializeObject(_shapes, new JsonSerializerSettings
        //        {
        //            TypeNameHandling = TypeNameHandling.All
        //        });

        //        File.WriteAllText(fileName, json);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAllShapes();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void shapeEditor_MouseLocationChanged(object sender, Point e)
        {
            toolStripStatusLabelPosition.Text = $"X: {e.X}, Y: {e.Y}";
        }
    }
}
