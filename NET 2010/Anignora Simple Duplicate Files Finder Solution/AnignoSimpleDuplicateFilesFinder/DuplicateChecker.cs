using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoSimpleDuplicateFilesFinder
{
    public class DuplicateChecker
    {
        public delegate void DuplicateFileFoundDelegate(string key,FileInfo fileInfo,List<FileInfo> duplicatesList);
        public event DuplicateFileFoundDelegate OnDuplicateFileFound;
        public Dictionary<string, List<FileInfo>> AllFilesDictionary = new Dictionary<string, List<FileInfo>>();

        public void CheckAndAddFile(FileInfo fileInfo,bool isCheckSize,bool isCheckName)
        {
            string fileName=Path.GetFileName(fileInfo.FullName);
            string fileSize = fileInfo.Length.ToString();
            string key = "";
            //string fullKeyName = "";
            //fullKeyName = fileName + " Size=" + fileSize;
            if (isCheckName) key += fileName;
            if (isCheckSize) key += " Size="+fileSize;
            if (AllFilesDictionary.ContainsKey(key))
            {
                AllFilesDictionary[key].Add(fileInfo);
                if (OnDuplicateFileFound != null) OnDuplicateFileFound(key,fileInfo, AllFilesDictionary[key]);
            }
            else
            {
                List<FileInfo> instances = new List<FileInfo>();
                AllFilesDictionary.Add(key, instances);
                instances.Add(fileInfo);
            }
        }

        public void Clear()
        {
            AllFilesDictionary.Clear();
        }
    }
}
