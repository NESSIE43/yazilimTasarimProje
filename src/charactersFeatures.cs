using System;

public class charactersFeatures
{
    public string name;
    public string target;
    public int health;
    public int damage;

    public charactersFeatures(string name, string target, int health, int damage)
    {
        this.name = name;
        this.target = target;
        this.health = health;
        this.damage = damage;
    }

    public void attack()
    {
        if(this.name == "Dusman")
        {
            if(this.target == "Dost")
            {
                Console.WriteLine("Dusman Dost'a saldiriyor ve "+ this.damage +" hasar verdi.");
            }
        }
        else if (this.name == "Dost")
        {
            if(this.target == "Dusman")
            {
                Console.WriteLine("Dost Dusman'a saldiriyor ve "+ this.damage +" hasar verdi.");
            }
        }
        else if (this.name == "Obje")
        {
            Console.WriteLine("Obje saldiramaz.");
        }
    }
}