AI'a sorduğum soru:
Karakterlere yeni özellikler eklemek istiyorum bunun için Decorator pattern mi daha uygun olur yoksa Strategy pattern mi?
2. olarak da farklı yazılmış bir hazır karakteri şimdiki sisteme Adapter pattern ile mi uyarlamalıyız yoksa Facade pattern ile mi?

AI yanıtı:
1. -> Decorator pattern daha iyi olur. Strategy pattern saldırı algoritmalarını tamamen değiştirmek için kullanılır. Ancak Decorator kullanman için ICharacter arayüzünü de değiştirmelisin.
2. -> Adapter pattern daha iyi olur. Facade pattern, uyumsuz bir sınıfı dönüştürmek için değil çok karmaşık bir alt sistemi tek bir basit arayüze indirgemek için kullanılır.

AI'ın eksik veya yanlış önerdiği kısım:

AI bana Decorator pattern önerdiğinde ayrıca arayüzü de değiştirmemi söyledi ancak Decorator pattern'inin asıl amacı arayüzü değiştirmeden yeni nesneler oluşturmak. 
Bu yüzden bu patterni kullanırken arayüzü sabit tuttum.
