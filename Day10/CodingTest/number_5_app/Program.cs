using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 문제 5
namespace number_5_app
{
    interface IAnimal
    {
        void Eat();
        void Sleep();
        void Sound();
    }

    class Animal
    {
        private int age;
        private string name;
        public int Age
        {
            get => age; set => age = value;
        }
        public string Name
        {
            get => name; set => name = value;
        }
    }

    class Dog : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("{0}가 먹습니다.", Name);
        }
        public void Sleep() 
        {
            Console.WriteLine("{0}가 잠듭니다.", Name);
        }
        public void Sound() 
        {
            Console.WriteLine("멍멍");
        }
    }

    class Cat : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("{0}가 먹습니다.", Name);
        }
        public void Sleep()
        {
            Console.WriteLine("{0}가 잠듭니다.", Name);
        }
        public void Sound()
        {
            Console.WriteLine("야옹");
        }
    }

    class Hores : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("{0}(이)가 먹습니다.", Name);
        }
        public void Sleep()
        {
            Console.WriteLine("{0}(이)가 잠듭니다.", Name);
        }
        public void Sound()
        {
            Console.WriteLine("이히힝");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Dog dog = new Dog { Name = "강아지", Age = 5 };
            dog.Eat();
            Cat cat = new Cat { Name = "고양이", Age = 2 };
            cat.Sleep();
            Hores horse = new Hores { Name = "말", Age = 10 };
            horse.Sound();

            dog.Sound();
            cat.Sound();
        }
    }
}
