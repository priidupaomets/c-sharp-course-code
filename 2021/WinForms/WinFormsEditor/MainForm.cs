namespace WinFormsEditor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

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

    private void Form1_Load(object sender, EventArgs e)
    {
        // Siia võib kirjutada koodi, mis käivitub, kui aken on loodud
        // ja initsialiseeritud - ehk on turvaline kasutada kõiki objekte,
        // mis akna sisse kuuluvad
    }

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

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        shapeEditor.DeleteSelectedShapes();
    }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
    {
        shapeEditor.Refresh();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
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

    private void ShapeEditorControl_EditorModeChanged(object sender, EditorMode mode)
    {
        UpdateCommands();
    }
    private void ShapeEditorControl_MouseLocationChanged(object sender, Point location)
    {
        toolStripStatusLabelPosition.Text = $"X: {location.X}, Y: {location.Y}";
    }

    public EditorMode Mode
    {
        get { return shapeEditor.Mode; }
        set
        {
            shapeEditor.Mode = value;
        }
    }

}
