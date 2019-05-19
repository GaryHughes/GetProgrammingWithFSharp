using System;

namespace CSharpProject
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void PrintName() => Console.WriteLine($"My name is {Name}");
    }
}
