namespace WinFormsEditor;

public partial class MainForm : Form
{
    //private List<Shape> _shapes = new List<Shape>();
    //private EditorMode _mode;

    public MainForm()
    {
        //SetStyle(ControlStyles.UserPaint, true);
        ////SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        ////SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        ////SetStyle(ControlStyles.ResizeRedraw, true);

        InitializeComponent();

        //_mode = EditorMode.Select;

        //CreateShapes();

        UpdateCommands();
    }

    private void UpdateCommands()
    {
        toolStripButtonSelect.Checked = Mode == EditorMode.Select;
        toolStripButtonMove.Checked = Mode == EditorMode.Move;
        //toolStripButtonDelete.Checked = _mode == EditorMode.Delete;

        toolStripButtonRectangle.Checked = Mode == EditorMode.Rectangle;
        toolStripButtonEllipse.Checked = Mode == EditorMode.Ellipse;
        toolStripButtonText.Checked = Mode == EditorMode.Text;

        toolStripStatusLabelStatus.Text = Mode.ToString();
    }

    //private void CreateShapes()
    //{
    //    //_shapes.Add(new RectangleShape()
    //    //{
    //    //    Location = new Point(10, 10),
    //    //    Size = new Size(60, 40)
    //    //});
    //    //_shapes.Add(new RectangleShape()
    //    //{
    //    //    Pen = new Pen(Color.Blue, 4),
    //    //    Location = new Point(70, 50),
    //    //    Size = new Size(60, 40)
    //    //});

    //    //_shapes.Add(new EllipseShape()
    //    //{
    //    //    Pen = new Pen(Color.Green, 2),
    //    //    Location = new Point(70, 50),
    //    //    Size = new Size(60, 40)
    //    //});

    //    //_shapes.Add(new TextShape()
    //    //{
    //    //    Location = new Point(100, 100),
    //    //    Text = "Mingi tekst"
    //    //});

    //    //_shapes.Add(new LinesShape()
    //    //{
    //    //    Pen = new Pen(Color.Orange),
    //    //    Points = { 
    //    //        new Point(30, 30),
    //    //        new Point(60, 50),
    //    //        new Point(80, 20)
    //    //    }
    //    //});
    //}

    private void Form1_Load(object sender, EventArgs e)
    {
        // Siia vıib kirjutada koodi, mis k‰ivitub, kui aken on loodud
        // ja initsialiseeritud - ehk on turvaline kasutada kıiki objekte,
        // mis akna sisse kuuluvad
    }

    //private void RefreshGraphics()
    //{
    //    this.DoubleBuffered = true;

    //    //var bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

    //    using (Graphics g = pictureBox.CreateGraphics())
    //    {
    //        //g.DrawImage(bmp, 0, 0);

    //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    //        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

    //        //Pen pen = new Pen(Color.OrangeRed, 3);
    //        //g.DrawRectangle(pen, 10, 10, 50, 40);

    //        //g.Clear(pictureBox.BackColor);
    //        g.FillRectangle(new SolidBrush(pictureBox.BackColor),
    //            new Rectangle(0, 0, pictureBox.Size.Width, pictureBox.Size.Height));

    //        Brush handleBrush = new SolidBrush(Color.Black);

    //        foreach (Shape shape in _shapes)
    //        {
    //            shape.Draw(g);

    //            if (shape.Selected)
    //            {
    //                shape.DrawSelection(g, handleBrush, 8);
    //                //ExtensionMethods.DrawSelection(shape, g, handleBrush, 8);
    //            }

    //            //if (shape is RectangleShape)
    //            //{
    //            //    RectangleShape? rect = shape as RectangleShape;

    //            //    if (rect != null)
    //            //    {
    //            //        g.DrawRectangle(rect.Pen,
    //            //            rect.Location.X, rect.Location.Y,
    //            //            rect.Size.Width, rect.Size.Height);
    //            //    }
    //            //}
    //            //else if (shape is EllipseShape)
    //            //{
    //            //    EllipseShape? ellipse = shape as EllipseShape;

    //            //    if (ellipse != null)
    //            //    {
    //            //        g.DrawEllipse(ellipse.Pen,
    //            //            ellipse.Location.X, ellipse.Location.Y,
    //            //            ellipse.Size.Width, ellipse.Size.Height);
    //            //    }
    //            //}
    //        }
    //    }
    //}

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void toolStripButtonSelect_Click(object sender, EventArgs e)
    {
        Mode = EditorMode.Select;
    }

    private void toolStripButtonMove_Click(object sender, EventArgs e)
    {
        Mode = EditorMode.Move;
    }

    //private void toolStripButtonDelete_Click(object sender, EventArgs e)
    //{
    //    Mode = EditorMode.Delete;
    //}

    private void toolStripButtonRectangle_Click(object sender, EventArgs e)
    {
        Mode = EditorMode.Rectangle;
    }

    private void toolStripButtonEllipse_Click(object sender, EventArgs e)
    {
        Mode = EditorMode.Ellipse;
    }

    private void toolStripButtonText_Click(object sender, EventArgs e)
    {
        Mode = EditorMode.Text;
    }

    public EditorMode Mode
    {
        get { return shapeEditor.Mode; }
        set
        {
            shapeEditor.Mode = value;
            //UpdateCommands();
        }
    }

    //private Shape GetSelectedShape()
    //{
    //    foreach (var shape in _shapes)
    //    {
    //        if (shape.Selected)
    //            return shape;
    //    }

    //    return null;
    //}

    //private Shape GetShapeAtPosition(Point position)
    //{
    //    foreach (var shape in _shapes)
    //    {
    //        if (shape.IsInBounds(position))
    //            return shape;
    //    }

    //    return null;
    //}

    //private void ForEachShape(Action<Shape> shapeAction, Shape excludeShape = null)
    //{
    //    if (_shapes != null && _shapes.Count > 0)
    //    {
    //        _shapes.ForEach(shape =>
    //        {
    //            if (shape != excludeShape)
    //                shapeAction(shape);
    //        });
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


    //private void pictureBox_MouseClick(object sender, MouseEventArgs e)
    //{
    //    var mousePos = e.Location;

    //    if (Mode == EditorMode.Select && mousePos.IsWithinTolerance(_mouseOrigin, 4))
    //    {
    //        var shape = GetShapeAtPosition(mousePos);
    //        if (shape != null)
    //        {
    //            if (Control.ModifierKeys == Keys.Shift)
    //            {
    //                shape.Selected = !shape.Selected;
    //            }
    //            else
    //            {
    //                shape.Selected = true;

    //                SelectNone(excludeShape: shape);
    //            }
    //        }
    //        else
    //            SelectNone();

    //        RefreshGraphics();

    //        //foreach (var shape in _shapes)
    //        //{
    //        //    if (shape.IsInBounds(mousPos))
    //        //    {
    //        //        shape.Selected = !shape.Selected;

    //        //        RefreshGraphics();
    //        //        return;
    //        //    }
    //        //}
    //    }
    //}

    //private int SelectionHandleToleranceInPizels = 8;
    //private Point _mouseOrigin = Point.Empty;
    //private Shape _currentShape = null;
    //private Point _currentShapeLocation = Point.Empty;
    //private Size _currentShapeSize = Size.Empty;
    //private SelectionHandle _currentSelectionHandle = SelectionHandle.None;
    //private string _currentDocumentName = string.Empty;

    //private void pictureBox_MouseDown(object sender, MouseEventArgs e)
    //{
    //    _mouseOrigin = e.Location;

    //    if (Mode == EditorMode.Select)
    //    {
    //        _currentShape = GetShapeAtPosition(_mouseOrigin);
    //        _currentShapeLocation = _currentShape?.Location ?? Point.Empty;
    //        _currentShapeSize = _currentShape?.Size ?? Size.Empty;
    //        _currentSelectionHandle = _currentShape?.GetSelectionHandle(_mouseOrigin,
    //            SelectionHandleToleranceInPizels) ?? SelectionHandle.None;
    //    }
    //    //else if (Mode == EditorMode.Move)
    //    //{
    //    //    _currentShape = GetSelectedShape();
    //    //    _currentShapeLocation = _currentShape?.Location ?? Point.Empty;
    //    //}
    //    else if (Mode == EditorMode.Rectangle)
    //    {
    //        _currentShape = new RectangleShape(_mouseOrigin);
    //        _shapes.Add(_currentShape);
    //    }
    //    else if (Mode == EditorMode.Ellipse)
    //    {
    //        _currentShape = new EllipseShape(_mouseOrigin);
    //        _shapes.Add(_currentShape);
    //    }
    //}

    //private void pictureBox_MouseMove(object sender, MouseEventArgs e)
    //{
    //    var currentLocation = e.Location;

    //    toolStripStatusLabelPosition.Text = $"X: {currentLocation.X}, Y: {currentLocation.Y}";

    //    Cursor cursor = Cursors.Default; // Vaikimisi kursor, kui muud pole valitud

    //    // Esiteks on vaja aru saada, kas oleme mıne valitud kujundi kohal
    //    var shape = GetShapeAtPosition(currentLocation);

    //    SelectionHandle selectionHandle = 
    //        shape?.GetSelectionHandle(currentLocation, SelectionHandleToleranceInPizels) 
    //        ?? SelectionHandle.None;
    //    bool shapeIsInBounds = shape?.IsInBounds(currentLocation) ?? false;
    //    bool shapeIsSelected = shape?.Selected ?? false;

    //    // Kuna kursoreid on vaja kohandada sıltumata sellest, kas hiire nupp on alla vajutatud 
    //    // vıi mitte, siis kursori valik sıltub reûiimist. Ehk neid on vaja kuvada vaid siis, 
    //    // kui Select on aktiivne
    //    if (Mode == EditorMode.Select)
    //    {
    //        // Kui oleme, tuleb aru saada, kus me selle kujundi juures oleme
    //        if (shapeIsSelected)
    //        {
    //            switch (selectionHandle)
    //            {
    //                case SelectionHandle.None:
    //                    // Kui Handle point pole m‰‰ratud ja hiir asub kujundi piirides, 
    //                    // siis saame liigutada
    //                    if (shapeIsInBounds)
    //                    {
    //                        if (shapeIsSelected)
    //                            cursor = Cursors.SizeAll;
    //                        else
    //                            cursor = Cursors.Hand;
    //                    }
    //                    break;
    //                case SelectionHandle.TopCenter:
    //                    cursor = Cursors.SizeNS;
    //                    break;
    //                case SelectionHandle.BottomCenter:
    //                    cursor = Cursors.SizeNS;
    //                    break;
    //                case SelectionHandle.LeftCenter:
    //                    cursor = Cursors.SizeWE;
    //                    break;
    //                case SelectionHandle.RightCenter:
    //                    cursor = Cursors.SizeWE;
    //                    break;
    //                case SelectionHandle.TopLeft:
    //                    cursor = Cursors.SizeNWSE;
    //                    break;
    //                case SelectionHandle.BottomRight:
    //                    cursor = Cursors.SizeNWSE;
    //                    break;
    //                case SelectionHandle.TopRight:
    //                    cursor = Cursors.SizeNESW;
    //                    break;
    //                case SelectionHandle.BottomLeft:
    //                    cursor = Cursors.SizeNESW;
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            if (shapeIsInBounds)
    //            {
    //                cursor = Cursors.Hand;
    //            }
    //        }
    //    }

    //    if (pictureBox.Cursor != cursor)
    //        pictureBox.Cursor = cursor;

    //    if (e.Button == MouseButtons.None || _currentShape == null)
    //        return;

    //    if (Mode == EditorMode.Select)
    //    {
    //        // Kui nupp oli all ja meil on Select reûiim, siis saame kujundit kas liigutada vıi 
    //        // suurust muuta
    //        if (!e.Button.HasFlag(MouseButtons.Left))
    //            return; // J‰ta aktiivse kujundi puudumisel ¸lej‰‰nud kood vahele

    //        // Arvutame nihke hiire algpositsiooni ja praeguse koha vahel
    //        int dx = e.Location.X - _mouseOrigin.X;
    //        int dy = e.Location.Y - _mouseOrigin.Y;

    //        if (_currentSelectionHandle != SelectionHandle.None)
    //        {
    //            switch (_currentSelectionHandle)
    //            {
    //                case SelectionHandle.None:
    //                    break;
    //                case SelectionHandle.TopCenter:    // Muudame Y ja Height v‰‰rtust
    //                    _currentShape.Location = new Point(_currentShape.Location.X,
    //                                                       _currentShapeLocation.Y + dy);
    //                    _currentShape.Size = new Size(_currentShape.Size.Width,
    //                                                  _currentShapeSize.Height - dy);
    //                    break;
    //                case SelectionHandle.BottomCenter: // Muudame ainult Height v‰‰rtust
    //                    _currentShape.Size = new Size(_currentShape.Size.Width,
    //                                                  _currentShapeSize.Height + dy);
    //                    break;
    //                case SelectionHandle.LeftCenter:   // Muudame X ja Width v‰‰rtust
    //                    _currentShape.Location = new Point(_currentShapeLocation.X + dx,
    //                                                       _currentShape.Location.Y);
    //                    _currentShape.Size = new Size(_currentShapeSize.Width - dx,
    //                                                  _currentShape.Size.Height);
    //                    break;
    //                case SelectionHandle.RightCenter:  // Muudame ainult Size.Width v‰‰rtust
    //                    _currentShape.Size = new Size(_currentShapeSize.Width + dx,
    //                                                  _currentShape.Size.Height);
    //                    break;
    //                case SelectionHandle.TopLeft:      // Muudame X, Y,  Width ja Height v‰‰rtusi
    //                    _currentShape.Location = new Point(_currentShapeLocation.X + dx,
    //                                                       _currentShapeLocation.Y + dy);
    //                    _currentShape.Size = new Size(_currentShapeSize.Width - dx,
    //                                                  _currentShapeSize.Height - dy);
    //                    break;
    //                case SelectionHandle.BottomRight:  // Muudame Width ja Height v‰‰rtusi
    //                    _currentShape.Size = new Size(_currentShapeSize.Width + dx,
    //                                                  _currentShapeSize.Height + dy);
    //                    break;
    //                case SelectionHandle.TopRight:     // Muudame kıiki v‰‰rtusi
    //                    _currentShape.Location = new Point(_currentShapeLocation.X,
    //                                                       _currentShapeLocation.Y + dy);
    //                    _currentShape.Size = new Size(_currentShapeSize.Width + dx,
    //                                                  _currentShapeSize.Height - dy);
    //                    break;
    //                case SelectionHandle.BottomLeft:   // Muudame kıiki v‰‰rtusi
    //                    _currentShape.Location = new Point(_currentShapeLocation.X + dx,
    //                                                       _currentShape.Location.Y);
    //                    _currentShape.Size = new Size(_currentShapeSize.Width - dx,
    //                                                  _currentShapeSize.Height + dy);
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        else if (shapeIsInBounds)
    //        {
    //            // Arvutame kujundi uue algpositsiooni, milleks on tema salvestatud 
    //            // algpositsioon + nihe
    //            int newX = _currentShapeLocation.X + dx;
    //            int newY = _currentShapeLocation.Y + dy;

    //            _currentShape.Location = new Point(newX, newY);
    //        }
    //    }
    //    else

    //    //else if (Mode == EditorMode.Move)
    //    //{
    //    //    if (_currentShape == null || !e.Button.HasFlag(MouseButtons.Left))
    //    //        return;

    //    //    int dx = e.Location.X - _mouseOrigin.X;
    //    //    int dy = e.Location.Y - _mouseOrigin.Y;

    //    //    int newX = _currentShapeLocation.X + dx;
    //    //    int newY = _currentShapeLocation.Y + dy;

    //    //    _currentShape.Location = new Point(newX, newY);
    //    //    RefreshGraphics();
    //    //}

    //    //if (Mode != EditorMode.Select && Mode != EditorMode.Move /*&& Mode != EditorMode.Delete*/)
    //    {
    //        if (_currentShape == null)
    //            return;

    //        Point newLocation = _currentShape.Location;
    //        Size newSize = _currentShape.Size;

    //        if (currentLocation.X < _mouseOrigin.X)
    //        {
    //            newLocation.X = currentLocation.X;
    //            newSize.Width = _mouseOrigin.X - currentLocation.X;
    //        }
    //        else
    //        {
    //            newLocation.X = _mouseOrigin.X;
    //            newSize.Width = currentLocation.X - _mouseOrigin.X;
    //        }
    //        if (currentLocation.Y < _mouseOrigin.Y)
    //        {
    //            newLocation.Y = currentLocation.Y;
    //            newSize.Height = _mouseOrigin.Y - currentLocation.Y;
    //        }
    //        else
    //        {
    //            newLocation.Y = _mouseOrigin.Y;
    //            newSize.Height = currentLocation.Y - _mouseOrigin.Y;
    //        }

    //        _currentShape.Location = newLocation;
    //        _currentShape.Size = newSize;
    //    }

    //    RefreshGraphics();
    //}

    //private void pictureBox_MouseUp(object sender, MouseEventArgs e)
    //{
    //    _currentShape = null;
    //    _currentShapeLocation = Point.Empty;
    //    _currentShapeSize = Size.Empty;
    //    _currentSelectionHandle = SelectionHandle.None;

    //    RefreshGraphics();
    //}

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        shapeEditor.DeleteSelectedShapes();
    }

    //private void DeleteSelectedShapes()
    //{
    //    for (int i = _shapes.Count - 1; i >= 0 ; i--)
    //    {
    //        var shape = _shapes[i];

    //        if (shape != null && shape.Selected)
    //        {
    //            _shapes.RemoveAt(i);
    //        }
    //    }

    //    RefreshGraphics();
    //}

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
    {
        shapeEditor.Refresh();
        //RefreshGraphics();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        //RefreshGraphics();
    }

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

    private void ClearAllShapes()
    {
        shapeEditor.ClearAllShapes();
        //_shapes.Clear();
        //_currentDocumentName = string.Empty;
        //RefreshGraphics();
    }

    private void OpenFile()
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string fileName = openFileDialog.FileName;
            shapeEditor.CurrentDocumentName = fileName;

            shapeEditor.LoadShapesFromFile(fileName);
        }
    }

    private void SaveFile()
    {
        if (string.IsNullOrWhiteSpace(shapeEditor.CurrentDocumentName))
            SaveFileAs();
        else
            shapeEditor.SaveShapesToFile(shapeEditor.CurrentDocumentName);
    }

    private void SaveFileAs()
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string fileName = saveFileDialog.FileName;
            shapeEditor.CurrentDocumentName = fileName;

            shapeEditor.SaveShapesToFile(fileName);
        }
    }

    //private void LoadShapesFromFile(string fileName)
    //{
    //    try
    //    {
    //        string json = File.ReadAllText(fileName);

    //        _shapes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Shape>>(json,
    //             new JsonSerializerSettings
    //             {
    //                 TypeNameHandling = TypeNameHandling.All
    //             });

    //        RefreshGraphics();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Error loading file: {ex.Message}", "Error",
    //           MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    //private void SaveShapesToFile(string fileName)
    //{
    //    try
    //    {
    //        string json = Newtonsoft.Json.JsonConvert.SerializeObject(_shapes,
    //            new JsonSerializerSettings
    //            {
    //                TypeNameHandling = TypeNameHandling.All
    //            });

    //        File.WriteAllText(fileName, json);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Error saving file: {ex.Message}", "Error",
    //            MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    private void ShapeEditorControl_EditorModeChanged(object sender, EditorMode mode)
    {
        UpdateCommands();
    }
    private void ShapeEditorControl_MouseLocationChanged(object sender, Point location)
    {
        toolStripStatusLabelPosition.Text = $"X: {location.X}, Y: {location.Y}";
    }
}
