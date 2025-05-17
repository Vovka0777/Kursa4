using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppКУРСОВАЯ
{
    class Animal
    {
        public int IdAnimal { get; }
        public string Name { get; }
        public string Species { get; }
        public string Breed { get; }
        public int Age { get; }
        public Owner Owner { get; }

        public Animal(int idAnimal, string name, string species, string breed, int age, Owner owner)
        {
            IdAnimal = idAnimal;
            Name = name;
            Species = species;
            Breed = breed;
            Age = age;
            Owner = owner;
        }
    }
}
