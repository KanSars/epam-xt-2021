using System;
using System.IO;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string WatchedDir = $@"D:\epam-xt-2021\Task_4\1";

            string[] names = WatchedDir.Split('\\');

            string PathFolderWatchedDir = Path.GetDirectoryName(WatchedDir) + "\\Watcher";

            Watcher watcher = new Watcher();

            Menu();

            int mode = ReadNeededMode();

            switch (mode)
            {
                case 1:
                    watcher.WatchChanges(WatchedDir);
                    break;
                case 2:
                    Recoil.RecoilIt(WatchedDir);
                    break;
                default:
                    break;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Выберете режим:");
            Console.WriteLine("Режима наблюдения: 1");
            Console.WriteLine("Режима отката: 2");

        }
        static int ReadNeededMode()
        {
            string s = Console.ReadLine();

            while (!int.TryParse(s, out int i) || int.Parse(s) < 1 || int.Parse(s) > 2) // || -важно, чтобы int.Parse(s) не сработал if!true
            {
                s = Console.ReadLine();
            }
            return int.Parse(s);
        }
    }
}
