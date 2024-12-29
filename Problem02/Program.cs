using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return this.Name == other.Name &&
               this.Engine == other.Engine &&
               this.MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Car otherCar)
            return Equals(otherCar);
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }
}

public class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                throw new IndexOutOfRangeException("Index is out of range.");

            var car = cars[index];
            return $"{car.Name} ({car.Engine})";
        }
    }

    public int Count => cars.Count;
}

class Program
{
    public static void Main(string[] args)
    {
        var catalog = new CarsCatalog();
        catalog.AddCar(new Car("Tesla Model S", "Electric", 250));
        catalog.AddCar(new Car("Ferrari 488", "Gasoline", 340));

        for (int i = 0; i < catalog.Count; i++)
        {
            Console.WriteLine(catalog[i]);
        }

        var car1 = new Car("Tesla Model S", "Electric", 250);
        var car2 = new Car("Tesla Model S", "Electric", 250);
        Console.WriteLine(car1.Equals(car2));  // True
    }
}
