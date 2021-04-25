using System;
using System.IO;

namespace _4._1
{
    class Watcher
    {
        public void WatchChanges(string watchedDir)
        {
            Console.WriteLine($"Отслеживается: {watchedDir}");
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

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();


            void OnChanged(object sender, FileSystemEventArgs e)
            {
                //приостанавливаем watcher
                watcher.EnableRaisingEvents = false;

                if (e.ChangeType != WatcherChangeTypes.Changed)
                {
                    return;
                }

                Console.WriteLine($"Changed: {e.FullPath}");

                Utils.CopyDirToNew(WatchedDir);

                // продолжаем работу watcher
                watcher.EnableRaisingEvents = true;
            }

            void OnCreated(object sender, FileSystemEventArgs e)
            {

                Console.WriteLine($"Created: {e.FullPath}");
                Utils.CopyDirToNew(WatchedDir);
            }

            void OnDeleted(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine($"Deleted: {e.FullPath}");
                Utils.CopyDirToNew(WatchedDir);
            }
        }
    }
}
