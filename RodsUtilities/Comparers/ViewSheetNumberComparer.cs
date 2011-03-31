using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;

namespace RodsUtilities.Comparers
{
    /// <summary>
    /// Compares view sheets by sheet number
    /// </summary>
    public class ViewSheetNumberComparer: IComparer<ViewSheet>
    {
        public int Compare(ViewSheet x, ViewSheet y)
        {
            return x.SheetNumber.CompareTo(y.SheetNumber);
        }
    }
}
