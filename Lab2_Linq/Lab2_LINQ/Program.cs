using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_Linq
{
    internal class Program
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
            Console.WriteLine("\ntask1");
            var task1 = A.Where(i => i.Contains(' '));
            foreach (var a in task1) 
                Console.Write($"{a}, ");
            Console.WriteLine();
            Console.WriteLine();
            
            //2
            Console.WriteLine("\ntask2");
            var task2 = B.Where(i => i > 0);
            foreach (var b in task2)
                Console.Write($"{b}, ");
            Console.WriteLine();
            Console.WriteLine();
            
            //3
            Console.WriteLine("\ntask3");
            var task3 = C.Where(i => i.Contains("Red"));
            foreach (var c in task3)
                Console.Write($"{c}, ");
            Console.WriteLine();
            Console.WriteLine();
            
            //4
            Console.WriteLine("\ntask4");
            var rand = new Random();
            var cars = new List<Car>();
            var names = myCars.Concat(yourCars).ToList();
            for (int i = 0; i < 6; i++)
            {
                cars.Add(new Car
                {
                    MaxSpeed = rand.Next(150, 301),
                    Color = "black",
                    Name = names[i],
                    NumberOfPlaces = 5
                });
            }

            var CarDpeenOver200 = cars.Where(i => i.MaxSpeed > 200);
            foreach (var car in CarDpeenOver200)
            {
                Console.WriteLine($"{car.Name}, {car.MaxSpeed}, {car.Color}, {car.NumberOfPlaces}");
            }
            Console.WriteLine();
            
            //5
            Console.WriteLine("\ntask5");
            var products = new List<Product>();
            for (int i = 0; i < 6; i++)
            {
                var name = rand.Next(100, 1000);
                var amount = rand.Next(1, 10);
                products.Add(new Product
                {
                    Name = name.ToString(),
                    Amount = amount,
                    Description = $"{name} in amount of {amount}"
                });
            }

            var productsLINQ = products.Where(i => i.Amount < 5);
            foreach (var prod in productsLINQ)
            {
                Console.WriteLine($"{prod.Description}");
            }
            Console.WriteLine();

            //6
            Console.WriteLine("\ntask6");
            var task6 = myCars.Concat(yourCars).ToList();
            foreach (var c in task6)
                Console.Write($"{c}, ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    class Car
    {
        public int MaxSpeed { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public int NumberOfPlaces { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
