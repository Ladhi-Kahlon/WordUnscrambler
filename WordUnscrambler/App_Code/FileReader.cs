using System;
using System.IO;

// ReSharper disable once CheckNamespace
namespace WordUnscrambler.App_Code
{
    internal class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContents = null;
            try
            {
                // Read file contents for given file name.
                fileContents = File.ReadAllLines(fileName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return fileContents;
        }
    }
}
