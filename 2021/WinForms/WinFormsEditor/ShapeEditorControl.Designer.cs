namespace WinFormsEditor
{
    partial class ShapeEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShapeEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ShapeEditorControl";
            this.Size = new System.Drawing.Size(571, 345);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShapeEditorControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShapeEditorControl_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeEditorControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShapeEditorControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShapeEditorControl_MouseUp);
            this.Resize += new System.EventHandler(this.ShapeEditorControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
