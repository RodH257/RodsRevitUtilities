using System;
using System.Reflection;
using Autodesk.Revit.DB;

namespace RodsUtilities
{
    /// <summary>
    /// Extension methods for the Revit API 
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Gets the name of the FailureDefinitionId as defined in the BuiltInFailures namespace
        /// </summary>
        /// <param name="failureDefinitionId">the failure definition.</param>
        /// <returns>name of builtinfailures</returns>
        public static string GetFailureName(this FailureDefinitionId failureDefinitionId)
        {
            //get the base type
            Type failuresType = typeof(BuiltInFailures);

            //get all of the nested types. The BuiltInFailures.WallFailures etc are nested classes.
            foreach (Type nestedType in failuresType.GetNestedTypes())
            {
                //in each of these classes, go through their properties, which are the FailureID's 
                foreach (PropertyInfo failureIdProperty in nestedType.GetProperties())
                {
                    //now we are onto BUiltInFailures.xxxx.ActualProperty
                    //get the value
                    object actualProperty = failureIdProperty.GetValue(null, null);
                    if (actualProperty is FailureDefinitionId)
                    {
                        //convert it to FailureDefinitionId
                        FailureDefinitionId propertyId = actualProperty as FailureDefinitionId;
                        //check if it matches the one we are after
                        if (propertyId.Guid.Equals(failureDefinitionId.Guid))
                        {
                            //match! Spit out the name
                            string name = nestedType.Name + "." + failureIdProperty.Name;
                            return name;
                        }
                    }
                }
            }
            return null;
        }
    }
}
