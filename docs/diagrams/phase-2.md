classDiagram
    class ICharacter {
        <<interface>>
        +Attack()
    }

    class Dusman {
        +string target
        +int damage
        +int health
        +int armor
        +Dusman(target, damage, health, armor)
        +Attack()
        +TakeDamage(damage)
    }

    class Dost {
        +string target
        +int damage
        +int health
        +bool specialAbilityExist
        +Dost(target, damage, health, specialAbilityExist)
        +Attack()
        +TakeDamage(damage)
    }

    class Object {
        +string name
        +float range
        +Object(name, range)
        +Attack()
    }

    class EskiSistemUzayli {
        +string isim
        +EskiSistemUzayli(isim)
        +atesEt()
    }

    class UzayliAdapter {
        -EskiSistemUzayli eskiSistemUzayli
        +UzayliAdapter(eskiUzayli)
        +Attack()
    }

    class CharacterDecorator {
        #ICharacter character
        +CharacterDecorator(character)
        +Attack()
    }

    class ZehirliSaldiriDecorator {
        +ZehirliSaldiriDecorator(character)
        +Attack()
    }

    class CharacterCreation {
        +CreateDost(target, damage, health, specialAbilityExist) ICharacter
        +CreateDusman(target, damage, health, armor) ICharacter
        +CreateObject(name, range) ICharacter
    }

    ICharacter <|.. Dusman : Implements
    ICharacter <|.. Dost : Implements
    ICharacter <|.. Object : Implements
    
    ICharacter <|.. UzayliAdapter : Implements
    UzayliAdapter --> EskiSistemUzayli : Adapts

    ICharacter <|.. CharacterDecorator : Implements
    CharacterDecorator --> ICharacter : Wraps
    CharacterDecorator <|-- ZehirliSaldiriDecorator : Extends
    
    CharacterCreation ..> ICharacter : Createss