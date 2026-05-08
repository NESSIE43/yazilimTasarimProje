Faz 1 : Creational Örüntüler

Uygulanan Örüntü : Factory Method
Nerede Uygulandı : "Character Creation" class'ında ve "ICharacter" arayüzü ve bu arayüzün alt sınıflarında
Neden Uygulandı : Tüm karakterler aynı sınıftan türetiliyordu ve bu yeni bir özellik eklemek istediğimizde işimizi çok zora sokuyordu. Ayrıca aynı fonksiyon içinde ayrım yapıyorduk ve bu da çökme riski taşıyordu.
Bu örüntü ne kazandırdı:
- Artık yeni bir özellik eklemek için sadece o sınıfta değişiklik yapıyoruz.
- Gereksiz özellikler diğer sınıflara aktarılmıyor (Örnek: Zırh özelliği obje sınıfında olmuyor)
- Nesne yaratmak için CharacterCreation sınıfı var ve içinde karakter oluşturma için her sınıf için ayrı ayrı metotlar var.