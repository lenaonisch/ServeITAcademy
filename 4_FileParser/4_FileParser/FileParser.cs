using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_FileParser
{
    class FileParser
    {
        const string FILE_NOT_FOUND = "File not found";

        public string filePath { get; set; }

        public FileParser(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.filePath = filePath;
            }
            else
            {
                throw new FileNotFoundException(FILE_NOT_FOUND, filePath);
            }
        }

        private string CreateTmpFile()
        {
            string tmpFileName = string.Empty;

            try
            {
                // Get the full name of the newly created Temporary file. 
                // Note that the GetTempFileName() method actually creates
                // a 0-byte file and returns the name of the created file.
                tmpFileName = Path.GetTempFileName();

                // Craete a FileInfo object to set the file's attributes
                FileInfo fileInfo = new FileInfo(tmpFileName);

                // Set the Attribute property of this file to Temporary. 
                // Although this is not completely necessary, the .NET Framework is able 
                // to optimize the use of Temporary files by keeping them cached in memory.
                fileInfo.Attributes = FileAttributes.Temporary;

                Console.WriteLine("TEMP file created at: " + tmpFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create TEMP file or set its attributes: " + ex.Message);
            }

            return tmpFileName;
        }

        public void ReplacePattern(string pattern, string replacement)
        {
            string tmpFileName = CreateTmpFile();
            
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(tmpFileName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string currentLine = streamReader.ReadLine();
                        string str = ReplaceLine(currentLine, pattern, replacement);
                        streamWriter.WriteLine(str);
                    }
                }
            }
            File.Copy(tmpFileName, filePath, true);
            File.Delete(tmpFileName);
        }

        protected string ReplaceLine(string input, string pattern, string replacement)
        {
            string newLine = input.Replace(pattern, replacement);
            return newLine;
        }

        public int CountPattern(string pattern)
        {
            int result = 0;
            using (StreamReader streamReader = new StreamReader(filePath))
            { 
                while (!streamReader.EndOfStream)
                {
                    string currentLine = streamReader.ReadLine();
                    result += Regex.Matches(currentLine, pattern).Count;
                }
            }

            return result;
        }
    }
}
