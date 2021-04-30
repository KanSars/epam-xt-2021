using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4._1
{
    static class Recoil
    {
        static Dictionary<int, string> dict;

        static string Repository;

        static string pathOfDict;

        static int maxKeyinDict;

        public static void RecoilIt(string WatchedDir)
        {
            pathOfDict = Path.GetDirectoryName(WatchedDir) + "\\Watcher\\dict.txt";

            try
            {
                if (!File.Exists(pathOfDict))
                {
                    throw new Exception();
                }
                else
                {
                    //--- считываем из блокнота данные в dict и выводим его
                    //--- предлагаем задать ключ и ждем ответа
                    //--- считываем ключ, проверив его наличие в dict, по ключу откатываемся из Repository

                    ReadDictFromTxt();

                    string s = Console.ReadLine();

                    maxKeyinDict = (dict.OrderByDescending(x => x.Key).FirstOrDefault().Key);

                    int key;

                    while (!int.TryParse(s, out key) || key < 1 || key > maxKeyinDict)
                    {
                        s = Console.ReadLine();
                    }

                    Repository = Path.GetDirectoryName(WatchedDir) + @"\Watcher\" + $"{key + " " + dict[key]}";

                    deleteFolder(WatchedDir);
                    CopyBack(Repository, WatchedDir);
                }
            }
            catch (Exception)
            {

            }
           
        }

        public static void ReadDictFromTxt()
        {
            dict = File.ReadLines(pathOfDict)
                   .Select(line => line.Split('\t'))
                   .Where(arr => arr.Length == 2)
                   .ToDictionary(arr => int.Parse(arr[0]), arr => arr[1]);
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
        }
        public static void deleteFolder(string WatchedDir)
        {
            try
            {
                //Класс DirectoryInfo позволяет работать с папками. Создаём объект этого
                //класса, в качестве параметра передав путь до папки.
                DirectoryInfo di = new DirectoryInfo(WatchedDir);
                //Создаём массив дочерних вложенных директорий директории di
                DirectoryInfo[] diA = di.GetDirectories();
                //Создаём массив дочерних файлов директории di
                FileInfo[] fi = di.GetFiles();
                //В цикле пробегаемся по всем файлам директории di и удаляем их
                foreach (FileInfo f in fi)
                {
                    f.Delete();
                }
                //В цикле пробегаемся по всем вложенным директориям директории di 
                foreach (DirectoryInfo df in diA)
                {
                    //рекурсия
                    deleteFolder(df.FullName);
                    //Если в папке нет больше вложенных папок и файлов - удаляем её
                    if (df.GetDirectories().Length == 0 && df.GetFiles().Length == 0) df.Delete();
                }
            }
            //Начинаем перехватывать ошибки
            //DirectoryNotFoundException - директория не найдена
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
            }
            //UnauthorizedAccessException - отсутствует доступ к файлу или папке
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
            }
            //Во всех остальных случаях
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка. Обратитесь к администратору. Ошибка: " + ex.Message);
            }
        }

        public static void CopyBack(string Repository, string WatchedDir)
        {
            if (!Directory.Exists(WatchedDir))
            {
                DirectoryInfo directory = Directory.CreateDirectory(WatchedDir);
                directory.Attributes = FileAttributes.Hidden;
            }
            foreach (string s1 in Directory.GetFiles(Repository))
            {
                string s2 = WatchedDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(Repository))
            {
                CopyBack(s, WatchedDir + "\\" + Path.GetFileName(s));
            }
        }
    }
}
