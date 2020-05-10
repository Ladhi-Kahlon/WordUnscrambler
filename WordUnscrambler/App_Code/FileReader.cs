using System;
using System.IO;

// ReSharper disable once CheckNamespace
namespace WordUnscrambler.App_Code
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContents;
            try
            {
                if (File.Exists(fileName))
                {
                    fileContents = File.ReadAllLines(fileName);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return fileContents;
        }
    }
}
