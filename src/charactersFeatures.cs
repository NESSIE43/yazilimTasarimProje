using System;

public interface ICharacter
{
  void Attack();
}

public class Dusman : ICharacter
{
    public string target;
    public int damage;
    public int health;
    public int armor;
    public Dusman (string target, int damage,int health,int armor)
    {
        this.target = target;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
    }

    public void Attack()
    {
        Console.WriteLine("Dusman, " + target + " hedefine " + damage + " hasar verdi.");
    }

    public void TakeDamage(int damage)
    {
        int incomingDamage = damage - armor;
        if (incomingDamage < 0)
        {
            incomingDamage = 0;
        }
        health -= incomingDamage;
        Console.WriteLine("Dusman, " + incomingDamage + " hasar aldý. Kalan saðlýk: " + health);
    }
}

public class Dost : ICharacter
{
    public string target;
    public int damage;
    public int health;
    public bool specialAbilityExist;

    public Dost(string target, int damage, int health, bool specialAbilityExist)
    {
        this.target = target;
        this.damage = damage;
        this.health = health;
        this.specialAbilityExist = specialAbilityExist;
    }

    public void Attack()
    {
        if (specialAbilityExist)
        {
            Console.WriteLine("Dost, " + target + " hedefine " + damage * 2 + " hasar verdi. Özel yeteneði kullandý ve *2 hasar verdi");
        }
        else
        {
            Console.WriteLine("Dost, " + target + " hedefine " + damage + " hasar verdi.");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (specialAbilityExist)
        {
            Console.WriteLine("Dost, " + damage + " hasar aldý. Kalan saðlýk: " + health / 2 + ". Özel yeteneði kullandý ve /2 hasar aldi");
        }
        else
        {
            Console.WriteLine("Dost, " + damage + " hasar aldý. Kalan saðlýk: " + health);
        }

    }
}

public class Object : ICharacter
{
    public string name;
    public float range;

    public Object(string name, float range)
        {
            this.name = name;
            this.range = range;
    }


    public void Attack()
    {
        Console.WriteLine("Nesne saldiramaz");
    }

}

public class CharacterCreation
{ 

public ICharacter CreateDost(string target, int damage, int health, bool specialAbilityExist)
{
  return new Dost(target, damage, health, specialAbilityExist);

}
public ICharacter CreateDusman(string target, int damage, int health, int armor)
{
  return new Dusman(target, damage, health, armor);
}

public ICharacter CreateObject(string name, float range)
{
  return new Object(name, range);
}
}


public class EskiSistemUzayli
{
    public string isim;

    public EskiSistemUzayli(string isim)
    {
        this.isim = isim;
    }

    public void atesEt()
    {
        Console.WriteLine(isim + " ateþ ediyor!");
    }
}

public class UzayliAdapter : ICharacter
{
    private EskiSistemUzayli eskiSistemUzayli;
    public UzayliAdapter(EskiSistemUzayli eskiUzayli)
    {
        this.eskiSistemUzayli = eskiUzayli;
    }

    public void Attack()
    {
        eskiSistemUzayli.atesEt();
    }
}


public class CharacterDecorator : ICharacter
{
    protected ICharacter character;
    public CharacterDecorator(ICharacter character)
    {
        this.character = character;
    }
    public virtual void Attack()
    {
        character.Attack();
    }
}

public class ZehirliSaldiriDecorator : CharacterDecorator
{
    public ZehirliSaldiriDecorator(ICharacter character) : base(character)
    {
    }
    public override void Attack()
    {
        base.Attack();
        Console.WriteLine("Bu saldýrý zehir etkisi de içeriyor!");
    }
}



