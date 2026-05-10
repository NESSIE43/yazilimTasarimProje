Ben: Faz 3 için Strategy ve Observer patternlerini eklemek istiyorum.
Karakterlerin saldırı türünü değiştirmek için Strategy Patterni, Karakterler hasar aldığında veya öldüğünde sisteme haber vermek için de Observer Patterni kullanabilir miyiz?
Bu mimari Açık/Kapalı Prensibine (OCP)'ye uygun olur mu? Bunun için review yazar mısın?


AI yanıtı: Evet 2 örüntü de uygundur.
Strategy için: IAttackStrategy adında bir arayüz aç ve yeni saldirilar ekle. Bu OCP'ye uygundur çünkü yeni silah eklerken eski kodu değiştirmezsin.
Observer için: Karakterin hasar aldığını UI veya ses sistemine bildirmek için, Dost ve Dusman class'larının içine doğrudan UIManager ui = new UIManager ve SoundManager sound = new SoundManager() yazabilirsin.
TakeDamage metodu çalıştığında ui.UpdateHealth() çağırarak sisteme haber verebilirsin.

AI beni nerede yanılttı, nerede hata yaptı?
Strategy için gayet düzgün bir şekilde açıkladı ve OCP'den kopmadı ancak aynı şeyi Observer için söyleyemeyiz.
Observer örüntüsünü açıklarken bana class'ların içinde UIManager nesnesini new ile yaratmamı söyledi. Ancak ben bunu yaparsam Observer'ın asıl amacı olan OCP'yi ihlal etmiş olurum. 
Her yeni bir sistem eklendiğinde class'lar içindeki kodu değiştirmem gerekirdi.

Ben bunun yerine IObserver adında yeni bir arayüz açtım ve karakterlerin içine List<IObserver> listesi koydum.
Bu sayede artık classlar sadece Notify() metodunu tetiklereyek ekstra uğraş olmadan haber gönderebilecek.

AI Olmadan Bu Faz Ne Kadar Sürerdi?
Açıkçası AI olmadan bu pattern'leri tam nasıl kullanacağımı bilmediğim için vaktimi fazlasıyla alırdı(Gerçi AI'da hata yapıp uğraştırabiliyor Örnek az önce yanlış söylediği new mantığı). Tahmini bir 3-4 saatimi alırdı AI olmadan yapmaya çalışsam. 