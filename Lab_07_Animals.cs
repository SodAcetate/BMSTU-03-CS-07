namespace library;

public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

public enum eFavouriteFood
{
    Meat,
    Plants,
    Everything
}

[MyAttribute("♪ Baby I'm preying on you tonight ♪")]
public class Animal
{
    public string Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string Name { get; set; }
    public string WhatAnimal { get; set; }

    public Animal(string country,  bool hideFromOtherAnimals, string name, string whatAnimal)
    {
        Country = country;
        HideFromOtherAnimals = hideFromOtherAnimals;
        Name = name;
        WhatAnimal = whatAnimal;
    }
  
    public void Deconstruct()
    {
        
    }
    public eClassificationAnimal GetClassificationAnimal()
    {
        return eClassificationAnimal.Omnivores;
    }
    public virtual eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Everything;
    }
    public virtual string SayHello()
    {
        return " ";
    }
}

[MyAttribute("♪ Hunt you down, eat you alive ♪")]
public class Cow : Animal
{
    public Cow(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Cow") { }
    
    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Plants;
    }
    
    public override string SayHello()
    {
        return "Moo (Hoi mate)";
    }
}

[MyAttribute("♪ Just like animals, animals ♪")]
public class Lion : Animal
{
    public Lion(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Lion") { }
    
    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Meat;
    }
    
    public override string SayHello()
    {
        return "Growl (Heya fella)";
    }
}

[MyAttribute("♪ Like animals-mals ♪")]
public class Pig : Animal
{
    public Pig(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Pig") { }

    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Plants;
    }

    public override string SayHello()
    {
        return "Oink (Wazzup bro)";
    }
}