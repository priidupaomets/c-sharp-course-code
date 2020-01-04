using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGraphics
{
    public enum EditorMode
    {
        Select, // Numeratsioon algab 0-st
        Move,
        //Delete,

        // Jätame ruumi muudele võimalikele käskudele

        Rectangle = 10,
        Ellipse = 11,
        Text = 12,
        Lines = 13
    };

    public enum SelectionHandle
    {
        None,
        TopCenter,
        BottomCenter,
        LeftCenter,
        RightCenter,
        TopLeft,
        BottomRight,
        TopRight,
        BottomLeft
    }


}
