using ExtendedDictionary;

namespace Project;

    public static class Project
    {
        public static void Main()
        {
            String[] A = { "Falluot 3", "Daxter 2", "System Shok 2", "Morrowind", "Pes 2013" }; 
            int[] B = { 2, -7, -10, 6, 7, 9, 3 }; 
            String[] C = { "Light Green", "Red", "Green", "Yellow", "Purple", 
                "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow" };
            
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" }; 
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            //1
            var task1 = A.Where(i => i.Contains(' '));
            foreach (var a in task1)
                Console.Write($"{a}, ");
            Console.WriteLine();
            
            //2
            var task2 = B.Where(i => i > 0);
            foreach (var b in task2)
                Console.Write($"{b}, ");
            Console.WriteLine();
            
            //3
            var task3 = C.Where(i => i.Contains("Red"));
            foreach (var c in task3)
                Console.Write($"{c}, ");
            Console.WriteLine();
            
            
            
            //6
            var task6 = myCars.Concat(yourCars).ToList();
            foreach (var c in task6)
                Console.Write($"{c}, ");
            Console.WriteLine();
        }

      
    }

 
