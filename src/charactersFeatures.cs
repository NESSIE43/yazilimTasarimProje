using System;
using System.Collections.Generic;


public interface IObserver
{
    void OnNotify(string message);
}

public class UIManager : IObserver
{
    public void OnNotify(string message)
    {
        Console.WriteLine("[UI EKRANI GÜNCELLENDÝ] -> " + message);
    }
}

public class SoundManager : IObserver
{
    public void OnNotify(string message)
    {
        Console.WriteLine("[SES EFEKTÝ ÇALINDI] -> " + message);
    }
}


public interface IAttackStrategy
{
    void ExecuteAttack(string attackerName, string target, int damage);
}

public class KilicSaldirisi : IAttackStrategy
{
    public void ExecuteAttack(string attackerName, string target, int damage)
    {
        Console.WriteLine(attackerName + ", " + target + " hedefine KILIÇ ile savurarak " + damage + " hasar verdi!");
    }
}

public class YaySaldirisi : IAttackStrategy
{
    public void ExecuteAttack(string attackerName, string target, int damage)
    {
        Console.WriteLine(attackerName + ", " + target + " hedefine OK fýrlatarak " + damage + " hasar verdi!");
    }
}


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

    private List<IObserver> observers = new List<IObserver>();
  
    private IAttackStrategy attackStrategy;

    public Dusman(string target, int damage, int health, int armor)
    {
        this.target = target;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
       
        this.attackStrategy = new KilicSaldirisi();
    }

   
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

 
    private void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(message);
        }
    }

   
    public void SetAttackStrategy(IAttackStrategy newStrategy)
    {
        this.attackStrategy = newStrategy;
        Console.WriteLine("Dusman silah deðiþtirdi!");
    }

    public void Attack()
    {
       
        attackStrategy.ExecuteAttack("Dusman", target, damage);
    }

    public void TakeDamage(int damage)
    {
        int incomingDamage = damage - armor;
        if (incomingDamage < 0)
        {
            incomingDamage = 0;
        }

        health -= incomingDamage;

     
        NotifyObservers("Dusman " + incomingDamage + " hasar aldý! Kalan Saðlýk: " + health);
    }
}

public class Dost : ICharacter
{
    public string target;
    public int damage;
    public int health;
    public bool specialAbilityExist;

    private List<IObserver> observers = new List<IObserver>();
    private IAttackStrategy attackStrategy;

    public Dost(string target, int damage, int health, bool specialAbilityExist)
    {
        this.target = target;
        this.damage = damage;
        this.health = health;
        this.specialAbilityExist = specialAbilityExist;
        this.attackStrategy = new YaySaldirisi();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    private void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(message);
        }
    }

    public void SetAttackStrategy(IAttackStrategy newStrategy)
    {
        this.attackStrategy = newStrategy;
        Console.WriteLine("Dost silah deðiþtirdi!");
    }

    public void Attack()
    {
        int finalDamage;

        if (specialAbilityExist)
        {
            finalDamage = damage * 2;
        }
        else
        {
            finalDamage = damage;
        }

        attackStrategy.ExecuteAttack("Dost", target, finalDamage);

        if (specialAbilityExist)
        {
            Console.WriteLine("(Özel yetenek kullanýldý!)");
        }
    }

    public void TakeDamage(int damage)
    {
        int finalDamage;

        if (specialAbilityExist)
        {
            finalDamage = damage / 2;
        }
        else
        {
            finalDamage = damage;
        }

        health -= finalDamage;
        NotifyObservers("Dost " + finalDamage + " hasar aldý! Kalan Saðlýk: " + health);
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
    public EskiSistemUzayli(string isim) { this.isim = isim; }
    public void atesEt() { Console.WriteLine(isim + " ateþ ediyor!"); }
}

public class UzayliAdapter : ICharacter
{
    private EskiSistemUzayli eskiSistemUzayli;
    public UzayliAdapter(EskiSistemUzayli eskiUzayli) { this.eskiSistemUzayli = eskiUzayli; }
    public void Attack() { eskiSistemUzayli.atesEt(); }
}

public class CharacterDecorator : ICharacter
{
    protected ICharacter character;
    public CharacterDecorator(ICharacter character) { this.character = character; }
    public virtual void Attack() { character.Attack(); }
}

public class ZehirliSaldiriDecorator : CharacterDecorator
{
    public ZehirliSaldiriDecorator(ICharacter character) : base(character) { }
    public override void Attack()
    {
        base.Attack();
        Console.WriteLine("Bu saldýrý zehir etkisi de içeriyor!");
    }
}