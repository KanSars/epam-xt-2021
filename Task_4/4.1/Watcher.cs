using System;
using System.IO;

namespace _4._1
{
    class Watcher
    {
        public void WatchChanges(string watchedDir)
        {
            string WatchedDir = watchedDir;

            using var watcher = new FileSystemWatcher(WatchedDir);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;

            watcher.Filter = "*.txt";

            watcher.EnableRaisingEvents = true;

            Console.ReadLine();


            void OnChanged(object sender, FileSystemEventArgs e)
            {
                watcher.EnableRaisingEvents = false;

                if (e.ChangeType != WatcherChangeTypes.Changed)
                {
                    return;
                }

                Utils.CopyDirToNew(WatchedDir);

                watcher.EnableRaisingEvents = true;
            }

            void OnCreated(object sender, FileSystemEventArgs e) => Utils.CopyDirToNew(WatchedDir);

            void OnDeleted(object sender, FileSystemEventArgs e) => Utils.CopyDirToNew(WatchedDir);
        }
    }
}
