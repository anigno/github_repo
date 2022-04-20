using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;

namespace AnignoLibrary.Helpers
{
    [TestFixture]
    public class FilesAndFoldersHelper
    {
		#region (------------------  Static Methods  ------------------)
        public static string[][] ReadCsvFile(string filename)
        {
            string[] splitArray={","};
            List<string[]> lRet = new List<string[]>();
            TextReader tr = new StreamReader(filename);
            string s;
            do
            {
                s = tr.ReadLine();
                if (s != null)
                {
                    string[] parts=s.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);
                    lRet.Add(parts);
                }
            } while (s != null);
            return lRet.ToArray();
        }
		#endregion (------------------  Static Methods  ------------------)


		#region (------  Const Fields  ------)

        public const string DIRECTORY_SEPERATOR = @"\";
        public const string EXTENSION_SEPERATOR = @".";

		#endregion (------  Const Fields  ------)


		#region (------  Tests  ------)

        [Test]
        public void Test_GetDirectoryNameEx()
        {
            Dictionary<string,string> tests=new Dictionary<string, string>();
            tests.Add(@"c:\aaa\bbb\ccc\file.ext",@"c:\aaa\bbb\ccc");
            tests.Add(@"c:\file.ext",@"c:");
            tests.Add(@"file.ext", @"");
            tests.Add(@"c", @"");
            tests.Add(@"c:\d\e\f\", @"c:\d\e\f");
            tests.Add(@"c:\d\e\f", @"c:\d\e");

            foreach (KeyValuePair<string, string> test in tests)
            {
                Debug.WriteLine(test.Key);
                string directoryName = GetDirectoryNameEx(test.Key);
                Assert.AreEqual(test.Value, directoryName);
            }
        }

        [Test]
        public void Test_GetExtensionNameEx()
        {
            Dictionary<string, string> tests = new Dictionary<string, string>();
            tests.Add(@"c:\aaa\bbb\ccc\file.ext", @"ext");
            tests.Add(@"c:\file.ext", @"ext");
            tests.Add(@"file.ext", @"ext");
            tests.Add(@"c", @"");
            tests.Add(@"c:\d\e\f\", @"");
            tests.Add(@"c:\d\e\f\a.b.c.d.e.ext", @"ext");
            foreach (KeyValuePair<string, string> test in tests)
            {
                Debug.WriteLine(test.Key);
                string fileName = GetExtensionNameEx(test.Key);
                Assert.AreEqual(test.Value, fileName);
            }
        }

        [Test]
        public void Test_GetFileNameEx()
        {
            Dictionary<string, string> tests = new Dictionary<string, string>();
            tests.Add(@"c:\aaa\bbb\ccc\file.ext", @"file.ext");
            tests.Add(@"c:\file.ext", @"file.ext");
            tests.Add(@"file.ext", @"file.ext");
            tests.Add(@"c", @"c");
            tests.Add(@"c:\d\e\f\", @"");
            foreach (KeyValuePair<string, string> test in tests)
            {
                Debug.WriteLine(test.Key);
                string fileName = GetFileNameEx(test.Key);
                Assert.AreEqual(test.Value, fileName);
            }
        }

       [Test]
        public void Test_GetFileNameWithoutExtensionEx()
        {
            Dictionary<string, string> tests = new Dictionary<string, string>();
            tests.Add(@"c:\aaa\bbb\ccc\file.ext", @"file");
            tests.Add(@"c:\file.ext", @"file");
            tests.Add(@"file.ext", @"file");
            tests.Add(@"c", @"c");
            tests.Add(@"c:\d\e\f\", @"");
            foreach (KeyValuePair<string, string> test in tests)
            {
                Debug.WriteLine(test.Key);
                string fileName = GetFileNameWithoutExtensionEx(test.Key);
                Assert.AreEqual(test.Value, fileName);
            }
        }

		#endregion (------  Tests  ------)


		#region (------  Static Methods  ------)

        /// <summary>
        /// Replaces the Directory.GetFiles(path,pattern), allow multiple patterns for given directory (No recursive run)
        /// </summary>
        public static string[] DirectoryGetFiles(string path, params string[] patterns)
        {
            List<string> FilesReturn = new List<string>();
            try
            {
                foreach (string pattern in patterns)
                {
                    string[] files = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                    FilesReturn.AddRange(files);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //System folders exception, Do nothing
            }
            return FilesReturn.ToArray();
        }

        /// <summary>
        /// Replace the Path.GetDirectoryName(), can get value of longer then 255 chars path
        /// </summary>
        public static string GetDirectoryNameEx(string filePath)
        {
            int lastDirIndex = filePath.LastIndexOf(DIRECTORY_SEPERATOR);
            //If path contains no directory seperator, return empty string
            if (lastDirIndex < 0) return "";
            return filePath.Substring(0, lastDirIndex);
        }

        /// <summary>
        /// Replace the Path.GetExtension(), can get value of longer then 255 chars path
        /// </summary>
        public static string GetExtensionNameEx(string filePath)
        {
            filePath = GetFileNameEx(filePath);
            int lastSeperatorIndex = filePath.LastIndexOf(EXTENSION_SEPERATOR);
            //If path contains no extension seperator, return filePath
            if (lastSeperatorIndex < 0) return "";
            return filePath.Substring(lastSeperatorIndex + 1);
        }

        /// <summary>
        /// Replace the Path.GetFileName(), can get value of longer then 255 chars path
        /// </summary>
        public static string GetFileNameEx(string filePath)
        {
            int lastDirIndex = filePath.LastIndexOf(DIRECTORY_SEPERATOR);
            //If path contains no directory seperator, return filePath
            if (lastDirIndex < 0) return filePath;
            return filePath.Substring(lastDirIndex + 1);
        }

        /// <summary>
        /// Replace the Path.GetFileNameWithoutExtension(), can get value of longer then 255 chars path
        /// </summary>
        public static string GetFileNameWithoutExtensionEx(string filePath)
        {
            filePath = GetFileNameEx(filePath);
            int lastSeperatorIndex = filePath.LastIndexOf(EXTENSION_SEPERATOR);
            //If no extention return filePath
            if (lastSeperatorIndex < 0) return filePath;
            return filePath.Substring(0, lastSeperatorIndex);
        }

        /// <summary>
        /// Rar a directory, Recurse subdirectories, with password
        /// </summary>
        /// <param name="winRarPath">Path to WinRar.exe file</param>
        /// <param name="destFile">Destination path and file name without .RAR extension</param>
        /// <param name="sourceDir">Source directory to archive</param>
        /// <param name="password">Password to protect the archive, if left empty no password protection is added</param>
        /// <returns>true if archiving succedded, else return false</returns>
        public static bool RarDirectory(string winRarPath, string destFile, string sourceDir, string password)
        {
            //Usage: RarDirectory(@"C:\Program Files\WinRAR\winrar.exe", @"c:\test", @"e:\_temp\2", "1234");
            string tempFilename = DateTime.Now.Ticks.ToString();
            string tempDestFilePath = Path.GetDirectoryName(destFile) + "\\" + tempFilename;
            //a -p1234 -r c:\test e:\_temp\2
            string passwordString = "-p" + password;
            if (password == "") passwordString = "";
            string commandline = " a " + passwordString + " -r " + tempDestFilePath + " " + sourceDir;
            Process p = new Process();
            p.StartInfo.FileName = winRarPath;
            p.StartInfo.Arguments = commandline;
            p.Start();
            p.WaitForExit();
            if (File.Exists(tempDestFilePath + ".rar"))
            {
                File.Delete(destFile + ".rar");
                File.Move(tempDestFilePath + ".rar", destFile + ".rar");
                return true;
            }
            return false;
        }

		#endregion (------  Static Methods  ------)
    }
}
    