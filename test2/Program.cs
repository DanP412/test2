using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IAnimal animal = new Dog();
            animal.LimbCount = 4;

            Animal ani1 = new Dog();
            Animal ani2 = new Duck();

            Dog burek = new Dog();

            PerformSoundOnAnimal(animal);
            PerformSoundOnAnimal(burek);

            animal.MakeSound();
            Console.WriteLine("Mam tyle kończyn: " + animal.LimbCount);

            //Duck donald = new Duck();
            //donald.Quack();
            //Console.WriteLine("Mam tyle nóg: " + burek.LegCount);

        }

        static void PerformSoundOnAnimal(IAnimal animal)
        {
            animal.MakeSound();
        }
    }

    // Polimorfizm
    // Hermetyzacja - ukrywanie wszelkich danych, które nie są potrzebne na zewnątrz
    // Dziedziczenie
    // Dompozycja
    class Dog : Animal, IAnimal
    {
        // Zmienna
        public int _age = 10;
        
        // Właściwość
        public int LimbCount { get; set; }

        public void MakeSound()
        {
            Console.WriteLine("Szczek");
            Console.WriteLine($"Btw, mam {_age} lat");
        }
    }

    class Duck : Animal, IAnimal
    {
        public int LimbCount { get; set; }

        public void MakeSound()
        {
            Console.WriteLine("Kwak");
        }
    }

    class Animal
    {

    }

    interface IAnimal
    {
        int LimbCount { get; set; }

        void MakeSound();
    }
}