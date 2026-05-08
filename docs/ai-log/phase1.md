 AI'a ne sordum?

-Sana verdiğim kodu nasıl Factory Method ile düzenleyip nesne yaratma sorununu çözebilirim? Bana bunun için bir kod review ver.

AI yanıtı(Özet):

-Kodda her şey kurucu metot içinde ve yeni bir özellik ekleyince sıkıntı çıkartıyor.
-Gereksiz bellek kullanımı
-İstemci bağımlılığı: Her şey if-else ile bağlı

Çözüm: Factory Method

Ardından AI bana bu sorunu çözmek için öncelikle tüm karakterlerin ortak dili olması gerektiğini söyledi ve 1 tane ICharacter interface'i açtı
Sonrasında bunun içinde sadece void attack() fonksiyonu yazıp başka bir şey eklemedi.

Devamında verdiği kodlarda her bir karakter sınıfı için yeni bir class açtı ve geri kalan özellikleri onun içine yazdı.
Son olarak da son bir CharacterFactory class'ı açarak onun içine yeni bir karakter kodu yazdı.

AI ne gördü, ben ne yaptım:

AI yeni açılan sınıflara yeni bir özellik eklememişti, sadece target ve damage eklemişti. Ben onun yerine düşman'a zırh, dost'a da özelGüçVarmı ekledim.
AI sadece saldırmak için olan arayüzdeki fonksiyonu kullanmıştı, ben onun aksine dost ve düşman sınıfına hasar alma fonksiyonu da ekledim.
AI'ın bana verdiği CharacterFactory class'ının kodunda AI type'a göre if-else yaparak yeni bir karakter oluşturuyordu, ben onu her bir sınıf için yeni bir metod yazarak yaptım.

AI'da ben de ICharacter arayüzü kullandık ve onun içine sadece void Attack() yazdık.
AI'da ben de temelde aynı yapıyı kullandık. Yeni sınıf aç, içine özellikleri yaz ve ardından void Attack fonksiyonunu yaz.
