using System;
using System.IO;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string WatchedDir = $@"D:\epam-xt-2021\Task_4\1";

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
            string menu = "Выберете режим: \n" +
                          "Режима наблюдения: 1 \n" +
                          "Режима отката: 2";
            Console.WriteLine(menu);
        }
        static int ReadNeededMode()
        {
            string s = Console.ReadLine();

            int mode;

            while (!int.TryParse(s, out mode) || mode < 1 || mode > 2)
            {
                s = Console.ReadLine();
            }
            return mode;
        }
    }
}
