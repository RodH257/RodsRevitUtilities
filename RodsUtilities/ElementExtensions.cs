using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RodsUtilities
{
    public static class ElementExtensions
    {
        /// <summary>
        /// Gets the parameter with a certain name
        /// </summary>
        public static Parameter GetParameterWithName(this Element element, string parameterName)
        {
            foreach (Parameter parameter in element.Parameters)
            {
                if (parameter.Definition.Name.ToLower().Equals(parameterName.ToLower()))
                {
                    return parameter;
                }
            }
            return null;
        }

        /// <summary>
        /// Highlights the certain element in the UI.
        /// </summary>
        public static void HighlightInUi(this Element element, UIDocument uiDoc)
        {
            uiDoc.Selection.Elements.Clear();
            uiDoc.Selection.Elements.Add(element);
            uiDoc.ShowElements(element);
        }
    }
}
