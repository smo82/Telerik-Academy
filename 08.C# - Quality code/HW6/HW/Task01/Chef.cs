//Task01
//Refactor the following class using best practices for organizing straight-line code:

using System;

public class Chef
{
    public void Cook()
    {
        Bowl bowl = GetBowl();

        Potato potato = GetPotato();
        ProcessVegetable(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        ProcessVegetable(carrot);
        bowl.Add(carrot);
    }

    private Bowl GetBowl()
    {
        return new Bowl(); 
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private void ProcessVegetable(Vegetable vegetable)
    {
        Peel(vegetable);
        Cut(vegetable);
    }

    private void Peel(Vegetable vegetable)
    {
        //...
    }

    private void Cut(Vegetable vegetable)
    {
        //...
    }
}