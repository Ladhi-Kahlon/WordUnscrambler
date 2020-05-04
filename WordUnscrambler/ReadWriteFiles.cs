using System;

namespace WordUnscrambler
{
    class ReadWriteFiles
    {
        public void WriteFileUseCase()
        {
            string[] writeLines = {"First Line", "Second Line", "3rd Line", "4th Line"};

            System.IO.File.WriteAllLinesAsync("TextFile.txt",writeLines);
        }

        public void ReadFileUseCase()
        {
            var readFile = System.IO.File.ReadAllLines("TextFile.txt");

            foreach (var line in readFile)
            {
                Console.WriteLine(line);
            }
        }
    }
}