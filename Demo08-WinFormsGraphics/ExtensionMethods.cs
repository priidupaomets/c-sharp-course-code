﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGraphics
{
    public static class ExtensionMethods
    {
        public static bool IsWithinTolerance(this Point value, Point reference, int tolerance = 0)
        {
            return IsWithinTolerance(value.X, value.Y, reference.X, reference.Y, tolerance);
        }

        public static bool IsWithinTolerance(this Point value, int referenceX, int referenceY, int tolerance = 0)
        {
            return IsWithinTolerance(value.X, value.Y, referenceX, referenceY, tolerance);
        }

        private static bool IsWithinTolerance(int x, int y, int referenceX, int referenceY, int tolerance = 0)
        {
            return x >= referenceX - tolerance && x <= referenceX + tolerance &&
                   y >= referenceY - tolerance && y <= referenceY + tolerance;
        }


        public static SelectionHandle GetSelectionHandle(this Shape shape, Point value, int toleranceInPixels = 2)
        {
            SelectionHandle handlePoint = SelectionHandle.None;

            if (value.IsWithinTolerance(shape.Location, toleranceInPixels)) // Top left corner
                handlePoint = SelectionHandle.TopLeft;
            else if (value.IsWithinTolerance(shape.Location + shape.Size, toleranceInPixels)) // Bottom right corner
                handlePoint = SelectionHandle.BottomRight;
            else if (value.IsWithinTolerance(shape.Location.X + shape.Size.Width, shape.Location.Y, toleranceInPixels)) // Top right corner
                handlePoint = SelectionHandle.TopRight;
            else if (value.IsWithinTolerance(shape.Location.X, shape.Location.Y + shape.Size.Height, toleranceInPixels)) // Bottom left corner
                handlePoint = SelectionHandle.BottomLeft;

            else if (value.IsWithinTolerance(shape.Location.X + (shape.Size.Width / 2), shape.Location.Y, toleranceInPixels)) // Top center
                handlePoint = SelectionHandle.TopCenter;
            else if (value.IsWithinTolerance(shape.Location.X + (shape.Size.Width / 2), shape.Location.Y + shape.Size.Height, toleranceInPixels)) // Bottom center
                handlePoint = SelectionHandle.BottomCenter;

            else if (value.IsWithinTolerance(shape.Location.X, shape.Location.Y + (shape.Size.Height / 2), toleranceInPixels)) // Left center
                handlePoint = SelectionHandle.LeftCenter;
            else if (value.IsWithinTolerance(shape.Location.X + shape.Size.Width, shape.Location.Y + (shape.Size.Height / 2), toleranceInPixels)) // Right center
                handlePoint = SelectionHandle.RightCenter;

            return handlePoint;
        }

        public static void DrawSelection(this Shape shape, Graphics g, Brush brush, int pointSize = 4)
        {
            Brush selectionBrush = new SolidBrush(Color.Black);

            int halfPointSize = pointSize / 2;

            g.FillRectangle(selectionBrush,
                shape.Location.X - halfPointSize, shape.Location.Y - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + shape.Size.Width - halfPointSize, shape.Location.Y - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X - halfPointSize, shape.Location.Y + shape.Size.Height - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + shape.Size.Width - halfPointSize, shape.Location.Y + shape.Size.Height - halfPointSize,
                pointSize, pointSize);
        }

    }
}
