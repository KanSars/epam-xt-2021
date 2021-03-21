using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Player!");

            Panda pandaPo = new Panda();
            Lung Lung = new Lung();

            Location location = new Location(5, 6);
            Dumpling dumpling_1 = new Dumpling(location);

            List<GameObject> gameObjects = new List<GameObject>();

            do
            {
                Console.ReadKey();
                //движение Панды
                //взаимодействие с объектами
                foreach (GameObject item in gameObjects)
                    Console.WriteLine($"{item}");

            } while (pandaPo.Hp > 0);
        }
    }
}
