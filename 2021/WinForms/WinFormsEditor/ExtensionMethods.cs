﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsEditor
{
    public static class ExtensionMethods
    {
        public static bool IsWithinTolerance(this Point value, Point reference, int tolerance = 0)
        {
            return IsWithinTolerance(value.X, value.Y, reference.X, reference.Y, tolerance);
        }

        public static bool IsWithinTolerance(this Point value, int referenceX, int referenceY,
          int tolerance = 0)
        {
            return IsWithinTolerance(value.X, value.Y, referenceX, referenceY, tolerance);
        }

        private static bool IsWithinTolerance(int x, int y, int referenceX, int referenceY,
          int tolerance = 0)
        {
            return x >= referenceX - tolerance && x <= referenceX + tolerance &&
                   y >= referenceY - tolerance && y <= referenceY + tolerance;
        }

        public static bool IsWithinBounds(this Point value, Point reference, Size size, int tolerance = 0)
        {
            return IsWithinBounds(value.X, value.Y, reference.X, reference.Y, 
                size.Width, size.Height, tolerance);
        }

        public static bool IsWithinBounds(this Point value, int referenceX, int referenceY,
          int referenceWidth, int referenceHeight, int tolerance = 0)
        {
            return IsWithinBounds(value.X, value.Y, referenceX, referenceY, 
                referenceWidth, referenceHeight, tolerance);
        }

        private static bool IsWithinBounds(int x, int y, int referenceX, int referenceY,
            int referenceWidth, int referenceHeight, int tolerance = 0)
        {
            return x >= referenceX - tolerance && x <= referenceX + referenceWidth + tolerance &&
                   y >= referenceY - tolerance && y <= referenceY + referenceHeight + tolerance;
        }

        public static SelectionHandle GetSelectionHandle(this Shape shape, Point value,
          int toleranceInPixels = 2)
        {
            SelectionHandle handlePoint = SelectionHandle.None;

            // Nurgad
            if (value.IsWithinTolerance(shape.Location, toleranceInPixels))
                handlePoint = SelectionHandle.TopLeft;
            else if (value.IsWithinTolerance(shape.Location.X + shape.Size.Width,
                                             shape.Location.Y + shape.Size.Height,
                                             toleranceInPixels))
                handlePoint = SelectionHandle.BottomRight;
            else if (value.IsWithinTolerance(shape.Location.X + shape.Size.Width,
                                             shape.Location.Y, toleranceInPixels))
                handlePoint = SelectionHandle.TopRight;
            else if (value.IsWithinTolerance(shape.Location.X,
                                             shape.Location.Y + shape.Size.Height,
                                             toleranceInPixels))
                handlePoint = SelectionHandle.BottomLeft;

            // Ülemine ja alumine keskkoht
            else if (value.IsWithinTolerance(shape.Location.X + (shape.Size.Width / 2),
                                             shape.Location.Y, toleranceInPixels))
                handlePoint = SelectionHandle.TopCenter;
            else if (value.IsWithinTolerance(shape.Location.X + (shape.Size.Width / 2),
                                             shape.Location.Y + shape.Size.Height,
                                             toleranceInPixels))
                handlePoint = SelectionHandle.BottomCenter;

            // Külgmised keskkohad
            else if (value.IsWithinTolerance(shape.Location.X,
                                             shape.Location.Y + (shape.Size.Height / 2),
                                             toleranceInPixels))
                handlePoint = SelectionHandle.LeftCenter;
            else if (value.IsWithinTolerance(shape.Location.X + shape.Size.Width,
                                             shape.Location.Y + (shape.Size.Height / 2),
                                             toleranceInPixels))
                handlePoint = SelectionHandle.RightCenter;

            return handlePoint;
        }


        public static void DrawSelection(this Shape shape, Graphics g, Brush brush,
           int pointSize = 4)
        {
            Brush selectionBrush = new SolidBrush(Color.Black);

            int halfPointSize = pointSize / 2;

            // Nurgad
            g.FillRectangle(selectionBrush,
                shape.Location.X - halfPointSize, shape.Location.Y - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + shape.Size.Width - halfPointSize,
                shape.Location.Y - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X - halfPointSize,
                shape.Location.Y + shape.Size.Height - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + shape.Size.Width - halfPointSize,
                shape.Location.Y + shape.Size.Height - halfPointSize,
                pointSize, pointSize);

            // Ülemine ja alumine keskkoht
            g.FillRectangle(selectionBrush,
                shape.Location.X + (shape.Size.Width / 2) - halfPointSize, 
                shape.Location.Y - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + (shape.Size.Width / 2) - halfPointSize,
                shape.Location.Y + shape.Size.Height - halfPointSize,
                pointSize, pointSize);

            // Külgmised keskkohad
            g.FillRectangle(selectionBrush,
                shape.Location.X - halfPointSize,
                shape.Location.Y + (shape.Size.Height / 2) - halfPointSize,
                pointSize, pointSize);

            g.FillRectangle(selectionBrush,
                shape.Location.X + shape.Size.Width - halfPointSize,
                shape.Location.Y + (shape.Size.Height / 2) - halfPointSize,
                pointSize, pointSize);
        }

    }
}
