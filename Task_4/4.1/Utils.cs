using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4._1
{
    static class Utils
    {

        static string ToDir;

        public static Dictionary<int, string> dict;

        public static int newKey;

        static KeyValuePair<int, string> max;

        static string pathOfDict = $@"D:\epam-xt-2021\Task_4\dict.txt";

        static string pathOfDir;

        public static void CopyDirToNew(string WatchedDir)
        {
            pathOfDir = Path.GetDirectoryName(WatchedDir) + "\\Watcher\\";

            pathOfDict = Path.GetDirectoryName(WatchedDir) + "\\Watcher\\dict.txt";

            dict = new Dictionary<int, string>();

            if (!Directory.Exists(pathOfDir))
            {
                DirectoryInfo directory = Directory.CreateDirectory(pathOfDir);
                directory.Attributes = FileAttributes.Hidden;
            }
            //------ Работаем с диктионари---------
            //--- перед работой с файлом - проверяем его наличие по требуемому адресу, иначе создаем новый и добавляем в него новое значение диктионари
            //--- достаем из файла все значения диктионари, для работы с ним: создание нового ключа++, присвоение ему новой даты
            //--- далее работаем с максимальным (последним) ключем и датой для создания новой папки

            // проверка/создание
            if (!File.Exists(pathOfDict))
            {
                dict.Add(1, DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss"));
                // Запись
                using (var writer = new StreamWriter(pathOfDict))
                {
                    foreach (var kvp in dict)
                    {
                        writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
                    }
                }
            }

            else
            {
                // Чтение
                dict = File.ReadLines(pathOfDict)
                    .Select(line => line.Split('\t'))
                    .Where(arr => arr.Length == 2)
                    .ToDictionary(arr => int.Parse(arr[0]), arr => arr[1]);

                //--- добавляем новую директорию (строку) в загруженную(актуаьную) диктонари
                newKey = (dict.OrderByDescending(x => x.Key).FirstOrDefault().Key + 1); // находим максимальный ключ, увеличиваем его на 1
                dict.Add(newKey, DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss"));
            }

            // используем максимальную (последнюю добавленную строку) в CopyDir
            max = dict.OrderByDescending(x => x.Key).FirstOrDefault();

            ToDir = Path.GetDirectoryName(WatchedDir) + @"\Watcher\" + $"{max.Key + " " + max.Value}";

            CopyDir(WatchedDir, ToDir);

            // переписываем файл с диктионари
            using (var writer = new StreamWriter(pathOfDict))
            {
                foreach (var kvp in dict)
                {
                    writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
                }
            }
        }

        public static void CopyDir(string WatchedDir, string ToDir)
        {
            if (!Directory.Exists(ToDir))
            {
                DirectoryInfo directory = Directory.CreateDirectory(ToDir);
                directory.Attributes = FileAttributes.Hidden;
            }
            foreach (string s1 in Directory.GetFiles(WatchedDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(WatchedDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        
    }
}
