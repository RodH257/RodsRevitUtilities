using System;
using System.Configuration;

namespace RodsUtilities
{
    /// <summary>
    /// Utility class to get around the problem of app.config files not working correctly when a dll is hosted in Revit.
    /// </summary>
    public static class HostedConfiguration
    {
        /// <summary>
        /// Gets a specific config property
        /// </summary>
        /// <param name="key">the property to get</param>
        /// <param name="type">type of class asking - to get right assembly</param>
        /// <returns>value</returns>
        public static string GetConfigProperty(string key, Type type)
        {
            Configuration config = GetConfig(type);
            return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// Get the configuration for the supplied type
        /// </summary>
        /// <param name="type">type of class</param>
        /// <returns>a configuration</returns>
        public static Configuration GetConfig(Type type)
        {
            //workout app.config lokcation
            string dllLocation = type.Assembly.Location + ".config";

            if (dllLocation == null)
                throw new System.IO.FileNotFoundException("Could not find config file, add .config in DLL location");


            //create config
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {ExeConfigFilename = dllLocation};
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            return config;
        }
    }
}
