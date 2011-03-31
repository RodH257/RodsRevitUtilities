using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;

namespace RodsUtilities.Comparers
{
    /// <summary>
    /// Comparer for Views by View Name
    /// </summary>
    public class ViewNameComparer: IComparer<View>
    {
        public int Compare(View x, View y)
        {
            return x.ViewName.CompareTo(y.ViewName);
        }
    }
}
