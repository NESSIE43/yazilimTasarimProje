classDiagram
    class ICharacter {
        <<interface>>
        +Attack()
    }

    class Dusman {
        -List~IObserver~ observers
        -IAttackStrategy attackStrategy
        +Attack()
        +TakeDamage(int damage)
        +AddObserver(IObserver observer)
        +SetAttackStrategy(IAttackStrategy newStrategy)
    }

    class Dost {
        -List~IObserver~ observers
        -IAttackStrategy attackStrategy
        +Attack()
        +TakeDamage(int damage)
        +AddObserver(IObserver observer)
        +SetAttackStrategy(IAttackStrategy newStrategy)
    }

    class Object {
        +string name
        +float range
        +Attack()
    }

    class IAttackStrategy {
        <<interface>>
        +ExecuteAttack(string attacker, string target, int damage)
    }

    class KilicSaldirisi {
        +ExecuteAttack()
    }

    class YaySaldirisi {
        +ExecuteAttack()
    }

    class IObserver {
        <<interface>>
        +OnNotify(string message)
    }

    class UIManager {
        +OnNotify()
    }

    class SoundManager {
        +OnNotify()
    }

    class EskiSistemUzayli {
        +atesEt()
    }

    class UzayliAdapter {
        +Attack()
    }

    class CharacterDecorator {
        +Attack()
    }

    class ZehirliSaldiriDecorator {
        +Attack()
    }

    class CharacterCreation {
        +CreateDost() ICharacter
        +CreateDusman() ICharacter
    }

    ICharacter <|.. Dusman
    ICharacter <|.. Dost
    ICharacter <|.. Object
    ICharacter <|.. UzayliAdapter
    ICharacter <|.. CharacterDecorator
    CharacterDecorator <|-- ZehirliSaldiriDecorator
    UzayliAdapter --> EskiSistemUzayli
    CharacterCreation ..> ICharacter
    
    IAttackStrategy <|.. KilicSaldirisi
    IAttackStrategy <|.. YaySaldirisi
    Dusman --> IAttackStrategy
    Dost --> IAttackStrategy

    IObserver <|.. UIManager
    IObserver <|.. SoundManager
    Dusman --> IObserver
    Dost --> IObserver