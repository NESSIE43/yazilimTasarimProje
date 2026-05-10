# Mini Oyun Motoru - Tasarım Örnekleri

Bu proje, bir oyun motorundaki karakter ve saldırı sistemlerinin tasarım örüntüleri kullanılarak nasıl daha esnek ve geliştirilebilir hale getirildiğini göstermektedir.

## 🚀 Proje Hakkında
Bu çalışma kapsamında, başlangıçta spagetti kod olan bir yapı; Creational, Structural ve Behavioral örüntüler uygulanarak SOLID prensiplerine uygun hale getirilmiştir.

## 🛠 Kullanılan Tasarım Örüntüleri

### Faz 1: Creational (Nesne Yaratma)
- **Factory Method:** Karakter nesnelerinin (Dost, Dusman, Obje) yaratım süreçlerini merkezi bir sınıfa topladık.

### Faz 2: Structural (Yapısal)
- **Decorator:** Karakterlere çalışma zamanında arayüzü bozmadan yeni özellikler (Zehirli saldırı vb.) ekledik.
- **Adapter:** Sisteme uyumsuz olan eski sınıf yapılarını mevcut arayüzümüze entegre ettik.

### Faz 3: Behavioral (Davranışsal)
- **Strategy:** Karakterlerin saldırı türlerini (Kılıç, Ok vb.) dinamik olarak değiştirilebilir hale getirdik.
- **Observer:** Karakter hasar aldığında UI ve Ses sistemlerinin otomatik olarak haberdar olmasını sağladık.

## 💻 Nasıl Çalıştırılır?
1. Projeyi bilgisayarınıza indirin.
2. .NET SDK'nın yüklü olduğundan emin olun.
3. "dotnet build" komutu ile derleyin.

## 📊 Mimari Diyagram

```mermaid
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
