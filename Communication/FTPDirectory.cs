// -----------------------------------------------------------------------
// <copyright file="FTPDirectory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>

    [Serializable]
    public class FTPDirectory
    {
        //This class is used for showing directory info in the FTP screen for both server and client(s), 
        //such as title, size, date. This class can be dragged from one control to another, and the folder/file
        //in question will be sent over.

        public string Name;
        public string Path;
        public int Size = 0;
        public int kbSize = 0; //size in kb
        public List<FTPDirectory> Children; // if none, then it must be a file. Else, it's a folder.
        public FTPDirectory Parent = null;
        public bool IsFile; //If true, then its a file, else, then its a directory
        public string Date = "";
        private string id;

        public FTPDirectory(string path, bool IsFile, FTPDirectory parent = null)
        {
            id = Guid.NewGuid().ToString();
            if (path.Split('\\').Length == 0) { this.Name = path; }
            else
            {
                this.Name = path.Split('\\')[path.Split('\\').Length - 1];
            }
            this.IsFile = IsFile;
            this.Path = path;
            if (parent != null)
            {
                Parent = parent;
            }

            //sort out the directories.
            if (IsFile)
            {
                FileInfo i = new FileInfo(path);
                this.Size = (int) (i.Length / 1024); //get mb
                this.kbSize =(int) i.Length;
            }
        }
        public void GetDirs()
        {
            if (!IsFile)
            {
                Children = new List<FTPDirectory>();
                try
                {
                    foreach (string d in Directory.GetDirectories(Path))
                    {
                        try
                        {
                            FTPDirectory temp = new FTPDirectory(d, false, this);

                            Children.Add(temp);
                        }
                        catch (IOException e) { Console.WriteLine(d); }
                    }

                    foreach (string d in Directory.GetFiles(Path))
                    {
                        try
                        {
                            FTPDirectory temp = new FTPDirectory(d, true, this);

                            Children.Add(temp);
                        }
                        catch (Exception e) { Console.WriteLine(d); }
                    }
                }
                catch (System.Exception excpt)
                {
                }
            }
        }

        public List<FTPDirectory> GetChildren()
        {
            GetDirs();
            GetChildrenDirs();

            return this.Children;
        }
        public void GetChildrenDirs()
        {
            foreach (FTPDirectory c in Children)
            {
                c.GetDirs();
            }
        }

        public string GetID()
        {
            return this.id;
        }

        public FTPDirectory FindDirectory(string nodeID)
        {
            if (Children == null) { return null; }
            foreach (FTPDirectory ftp in Children)
            {
                if (ftp.GetID().Equals(nodeID))
                {
                    return ftp;
                }
            }

            FTPDirectory dir = null;

            foreach (FTPDirectory ftp in Children)
            {
                dir = ftp.FindDirectory(nodeID);
                if (dir != null)
                {
                    return dir;
                }
            }
            return dir;
        }
    }
}
