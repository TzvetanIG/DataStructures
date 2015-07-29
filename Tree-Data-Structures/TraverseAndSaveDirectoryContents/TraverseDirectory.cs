namespace TraverseAndSaveDirectoryContents
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class TraverseDirectory
    {
        static void Main()
        {
            var startDirectory = @"C:\WINDOWS";

            var queue = new Queue<Folder>();
            
            var directoryInfo = new DirectoryInfo(startDirectory);
             var files = directoryInfo.GetFiles()
                 .Select(f => new File {Name = f.Name, Size = f.Length})
                 .ToArray();

             var childFolders = directoryInfo.GetDirectories()
                 .Select(f => new Folder {Name = f.Name})
                 .ToArray();

            var folder = new Folder()
            {
                Name = startDirectory,
                Files = files,
                ChildFolders = childFolders
            };
        }

        // public static Folder create
    }
}
